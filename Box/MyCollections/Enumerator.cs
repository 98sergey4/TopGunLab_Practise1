using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box.MyCollections
{
    public struct Enumerator<T> : IEnumerator<T>, System.Collections.IEnumerator
    {
        private T[] list;
        private int index;
        private T current;

        public Enumerator(T[] list)
        {
            this.list = list;
            index = -1;
            current = default(T);
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (++index >= list.Length)
            {
                return false;
            }
            else
            {
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
            index = -1;
            current = default(T);
        }

    }
}
