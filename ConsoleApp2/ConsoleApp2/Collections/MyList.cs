using System.Collections;

namespace CustomList.Collections
{
    public class MyList<T>:IEnumerable<T>
    {
        public int Count { get; private set; }
        private int _capacity;
        private T[] array;
        public int Capacity
        {
            get
            {
                return _capacity;
            }
            set 
            {
                _capacity = value; 
            }  
        }
        public MyList()
        {
            Count = 0;
            _capacity = 0;
            array = new T[Capacity];

        }

        public T this[int index]
        {
            get
            {
                if (index > Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return array[index];
            }
            set
            {
                if(index < Count)
                {
                    throw new IndexOutOfRangeException();
                }
                

            }
        }
        public void Add(T obj) 
        {
            if(_capacity == 0)
            {
                _capacity = 4;
                Array.Resize(ref array, _capacity);
            }
            if(_capacity==Count)
            {
                _capacity *= 2;
                Array.Resize(ref array, _capacity);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new ();
        }
        public bool Contains(T obj)
        {
            for (int i = 0; i < Count; i++)
            {
                if (obj.Equals(Count))
                {
                    return true;
                }

            }
            return false;
        }

        public T? Find(Predicate<T> predicate)
        {
            for (int i = 0; i < Count; i++)
            {
                if (predicate.Equals(Count))
                {
                    return array[i];
                }

            }
            
        }

    }
}
