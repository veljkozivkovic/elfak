using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.LFUCache
{
    public class DLinkedList
    {

        private Node _head;
        private int _size;

        public DLinkedList()
        {
            _head = new Node("", ""); // dummy node
            _head.Next = _head.Prev = _head;
            _size = 0;
        }

        public int Count => _size; // kao readonly property ne mozes da ga menjas samo citas

        public void Append(Node node)
        {
            node.Next = _head.Next;
            node.Prev = _head;
            node.Next.Prev = node;
            _head.Next = node;
            _size++;
        }

        public Node Pop(Node node = null)
        {
            if (_size == 0)
                return null;

            if (node == null)
                node = _head.Prev;

            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            _size--;

            return node;
        }

    }
}
