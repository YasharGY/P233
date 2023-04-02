using System.Collections;

namespace CustomList.Collections;

public class MyList<T>:IEnumerable<T>
{
    public int Count { get; private set; }
    private int _capacity;
    public int Capacity 
    {
        get => _capacity;
        set
        {
            if (value < Count)
            {
                throw new ArgumentOutOfRangeException("capacity was less than the current size.");
            }
            _capacity = value;
            Array.Resize(ref array, _capacity);
        }
    }
    private T[] array;
    public MyList()
    {
        Count = 0;
        _capacity = 0;
        array = new T[_capacity];
    }
    public T this[int index] { 
        get
        {
            if (index >= Count) 
            { 
                throw new ArgumentOutOfRangeException(); 
            }
            return array[index];
        } 
        set
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            array[index] = value;
        } 
    }

    public void Add(T obj)
    {
        if (_capacity == 0)
        {
            _capacity = 4;
            Array.Resize(ref array, _capacity);
        }
        if (_capacity == Count)
        {
            _capacity *= 2;
            Array.Resize(ref array, _capacity);
        }
        array[Count]=obj;
        Count++;
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
        return GetEnumerator();
    }

    public bool Contains(T obj)
    {
        for (int i = 0; i < Count; i++)
        {
            if (obj.Equals(array[i]))
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
            if (predicate(array[i]))
            {
                return array[i];
            }
        }
        return default;
    }


    public void Clear()
    {
        _capacity= 0;
        Count= 0;
        array = default;
    }

    public void AddRange(IEnumerable<T> values)
    {
        foreach (T item in values)
        {
            Add(item);
        }
    }

    public void Reverse()
    {
        if (Count == 0)
        {
            throw new Exception();
        }
        Array.Reverse(array, 0, Count);
    }


    public bool Exists(Predicate<T> predicate)
    {

        foreach (var item in array)
        {
            if (predicate(item))
            {
                return true;
            }
        }
        return false;
    }
    public bool Remove(T obj)
    {
         for (int i = 0; i < Count; i++)
         {
                if (obj.Equals(array[i]))
                {
                    array[i] = default;
                    break;
                }

         }
             return false;
    }

}




