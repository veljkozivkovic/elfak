using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.LFUCache
{
    public class Node
    {
        public string Key { get; set; }
        public string Val { get; set; }
        public int Freq { get; set; }
        public Node Prev { get; set; }
        public Node Next { get; set; } 

        public Node(string key, string val)
        {
            Key = key;
            Val = val;
            Freq = 1;
            Prev = Next = null;
        }

    }
}
