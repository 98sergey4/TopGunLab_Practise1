using Box.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box.MyCollections
{
    public class FighterCollection<T>: IEnumerable<T>
    {
        private const int defaultCapacity = 4;
        private T[] items;
        private int size;
        static readonly T[] emptyArray = new T[0];

        public FighterCollection()
        {
            items = emptyArray;
        }

        public FighterCollection(int capacity)
        {
            if (capacity == 0)
                items = emptyArray;
            else
                items = new T[capacity];
        }
        
        public int Capacity 
        {
            get
            {
                return items.Length;
            }
            set
            {
                if (value < size)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (value != items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (size > 0)
                        {
                            Array.Copy(items, 0, newItems, 0, size);
                        }
                        items = newItems;
                    }
                    else
                    {
                        items = emptyArray;
                    }
                }
            }
        }
        public int Count { get { return size; }  }

        public void Add(T item)
        {
            if (size == items.Length) EnsureCapacity(size + 1);
            items[size++] = item;
        }
        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)size)
            {
                throw new ArgumentOutOfRangeException();
            }
            size--;
            if (index < size)
            {
                Array.Copy(items, index + 1,items, index, size - index);
            }
            items[size] = default(T);
        }
        public int IndexOf(T item)
        {
            return Array.IndexOf(items, item, 0, size);
        }
        public T Choose(int index)
        {
            return items[index];
        }
        public void Clear()
        {
            if (size > 0)
            {
                Array.Clear(items, 0, size);
                size = 0;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(items);
        }

        private void EnsureCapacity(int min)
        {
            if (items.Length < min)
            {
                int newCapacity = items.Length == 0 ? defaultCapacity : items.Length * 2;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
        }
    }
    
}
