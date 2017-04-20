using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doublelinkedlist
{
    class CircularDoubleLinkedList<T> where T : class
    {
        class Header<T> where T : class
        {
            public Header<T> Next = null;
            public Header<T> Prev = null;
            public T Data = null;
        }

        Header<T> Head = null;

        public void Add(T Item)
        {
            if (Head == null)
            {
                Head = new Header<T>()
                {
                    Data = Item
                };

                Head.Next = Head;
                Head.Prev = Head;
            }
            else
            {
                Header<T> hdr = new Header<T>
                {
                    Data = Item
                };

                hdr.Prev = Head.Prev;
                //hdr.Next = Head;
                hdr.Next = hdr.Prev.Next;
                hdr.Prev.Next = hdr;
                hdr.Next.Prev = hdr;
            }
        }

        public void Insert(int Index, T Item)
        {
            if (Head == null)
            {
                Add(Item);
                return;
            }

            Header<T> Act = Head;
            int idx = 0;

            while (idx < Index)
            {
                Act = Act.Next;
                idx++;

                if (Act == Head)
                {
                    throw new OverflowException();
                }
            }

            Header<T> hdr = new Header<T>
            {
                Data = Item
            };

            hdr.Next = Act;
            hdr.Prev = Act.Prev;

            // előző álltása
            //Act.Prev.Next = hdr;
            hdr.Prev.Next = hdr;

            //Act.Prev = hdr;
            hdr.Next.Prev = hdr;

            if (Index == 0)
                Head = hdr;
        }

        public void Delete(int Index)
        {
            if (Head == null)
            {
                throw new OverflowException();
            }

            Header<T> Act = Head;
            int idx = 0;

            while (idx < Index)
            {
                Act = Act.Next;
                idx++;

                if (Act == Head)
                {
                    throw new OverflowException("Te barom, túlindexeltél");
                }
            }

            if (Index == 0)
            {
                if (Head.Next == Head) // 1 elemű lista
                {
                    Head = null;
                    return;
                }
                else
                    Head = Head.Next;
            }

            Act.Prev.Next = Act.Next;
            Act.Next.Prev = Act.Prev;
        }

        public T Get(int Index)
        {
            if (Head == null)
            {
                throw new OverflowException("Túlindexeltél!");
            }

            Header<T> Act = Head;
            int idx = 0;

            while (idx < Index)
            {
                Act = Act.Next;
                idx++;

                if (Act == Head)
                {
                    throw new OverflowException("Te barom, túlindexeltél");
                }
            }

            return Act.Data;
        }

        public T this[int Index]
        {
            get
            {
                return Get(Index);
            }
        }

        public int Count
        {
            get {
                if (Head == null)
                    return 0;

                Header<T> Act = Head;
                int cnt = 0;

                while(true)
                {
                    Act = Act.Next;
                    cnt++;

                    if (Act == Head)
                        return cnt;
                }
            }
        }
    }
}
