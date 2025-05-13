using System;
using System.Collections.Generic;

namespace HashSozlukGUI_Fix
{
    public record CellInfo(string DisplayText, string Status);

    public class HashEntry
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public HashEntry(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    public class HashTable
    {
        private HashEntry[] table;
        private int size;
        private int count;

        public HashTable(int initialSize = 8)
        {
            size = initialSize;
            table = new HashEntry[size];
            count = 0;
        }

        public void Add(string key, string value)
        {
            int index = HashFunction(key);
            int originalIndex = index;
            int i = 1;

            while (table[index] != null && table[index].Key != "__DELETED__")
            {
                index = (originalIndex + i) % size;
                i++;
            }

            table[index] = new HashEntry(key, value);
            count++;

            if ((float)count / size > 0.75f)
                Rehash();
        }

        public string? Search(string key)
        {
            int index = HashFunction(key);
            int originalIndex = index;
            int i = 1;

            while (table[index] != null)
            {
                if (table[index].Key == key)
                    return table[index].Value;

                index = (originalIndex + i) % size;
                i++;
            }

            return null;
        }

        public void Delete(string key)
        {
            int index = HashFunction(key);
            int originalIndex = index;
            int i = 1;

            while (table[index] != null)
            {
                if (table[index].Key == key)
                {
                    table[index] = new HashEntry("__DELETED__", "__DELETED__");
                    return;
                }

                index = (originalIndex + i) % size;
                i++;
            }
        }

        private int HashFunction(string key)
        {
            int hash = 0;
            foreach (char c in key)
                hash += c;
            return hash % size;
        }

        private void Rehash()
        {
            var oldTable = table;
            size *= 2;
            table = new HashEntry[size];
            count = 0;

            foreach (var entry in oldTable)
            {
                if (entry != null && entry.Key != "__DELETED__")
                    Add(entry.Key, entry.Value);
            }
        }

        public List<CellInfo> DumpDetailed()
        {
            var list = new List<CellInfo>();

            for (int i = 0; i < size; i++)
            {
                if (table[i] == null)
                {
                    list.Add(new CellInfo($"[{i}] → boş", "boş"));
                }
                else if (table[i].Key == "__DELETED__")
                {
                    list.Add(new CellInfo($"[{i}] → ❌ silinmiş", "silinmiş"));
                }
                else
                {
                    list.Add(new CellInfo($"[{i}] → ({table[i].Key}, {table[i].Value})", "dolu"));
                }
            }

            return list;
        }
    }
}
