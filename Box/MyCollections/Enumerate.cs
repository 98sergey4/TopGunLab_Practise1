using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box.MyCollections
{

    public class Enumerator<T> : IEnumerator<T>, System.Collections.IEnumerator
    {
        private FighterCollection<T> list;
        private int index;
        private T current;

        internal Enumerator(FighterCollection<T> list)
        {
            this.list = list;
            index = 0;
            current = default(T);
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {

            FighterCollection<T> localList = list;

            //if (version == localList._version && ((uint)index < (uint)localList._size))
            //{
            //    current = localList._items[index];
            //    index++;
            //    return true;
            //}
            //return MoveNextRare();
            if (++index >= list.Count)
            {
                return false;
            }
            else
            {
                // Set current box to next item in collection.
                current = list[index];
            }
            return true;
        }

        
        public T Current
        {
            get
            {
                return current;
            }
        }

        Object System.Collections.IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        void System.Collections.IEnumerator.Reset()
        {
            index = 0;
            current = default(T);
        }

    }
}

