using System;
using System.Collections.Generic;

namespace DictionaryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> sehirler = new Dictionary<string, string>();
            sehirler.Add("54","sakarya");

            MyDictionary<string, string> sehirler2 = new MyDictionary<string, string>();
            sehirler2.Add("54","sakarya");
            sehirler2.Add("","trabzon");
            sehirler2.Add("34","istanbul");

           

        }
    }
}
