using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherAPI.LFUCache
{
    public class LFU
    {
        private int _size;
        private int _capacity;
        private Dictionary<string, Node> _node;
        private Dictionary<int, DLinkedList> _freq;
        private int _minfreq;
        private static readonly ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();



        public LFU(int capacity)
        {
            _size = 0;
            _capacity = capacity;
            _node = new Dictionary<string, Node>();
            _freq = new Dictionary<int, DLinkedList>();
            _minfreq = 0;
        }


        //update ne sme imati ulaz u writeLock jer dolazi do deadlock-a
        private void Update(Node node)
        {
            
            try
            {
                int freq = node.Freq;

                _freq[freq].Pop(node);
                if (_minfreq == freq && _freq[freq].Count == 0)
                    _minfreq++;

                node.Freq++;
                freq = node.Freq;
                if (!_freq.ContainsKey(freq))
                    _freq[freq] = new DLinkedList();
                _freq[freq].Append(node);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            
        }

        public string Get(string key)
        {
            cacheLock.EnterWriteLock();
            try
            {
                if (!_node.ContainsKey(key))
                    return null;

                Node node = _node[key];
                Update(node);
                return node.Val;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        public void Put(string key, string value)
        {
            cacheLock.EnterWriteLock();
            try
            {
                Node node;

                if (_node.ContainsKey(key))
                {
                    node = _node[key];
                    Update(node);
                    node.Val = value;
                } // Ako grad vec postoji, posecujemo ga i updatujemo
                else // ako ne postoji
                {
                    if (_size == _capacity)
                    {
                        node = _freq[_minfreq].Pop();
                        _node.Remove(node.Key);
                        _size--;
                    } // ukoliko nam je cache vec pun potrebno je obrisati lfu cvor 

                    node = new Node(key, value);
                    _node[key] = node;
                    if (!_freq.ContainsKey(1)) // ovo se obavlja samo za prvi cvor
                        _freq[1] = new DLinkedList();
                    _freq[1].Append(node);
                    _minfreq = 1;
                    _size++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

    }
}
