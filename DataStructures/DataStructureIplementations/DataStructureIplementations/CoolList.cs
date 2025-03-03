using System.Collections;

public class CoolList<T> : IEnumerable<T>
{
    private const int InitialCapacity = 8;
    private T[] array;
    private int count;

    public CoolList()
    {
        this.array = new T[InitialCapacity];
        count = 0;
    }

    public int Count => this.count;

    public T this[int index]
    {
        get 
        {
            if (index<0 || index > count)
            {
                throw new IndexOutOfRangeException();
            }

            return array[index]; 
        }
        set
        {
            if (index < 0 || index >= this.count) 
            {
                throw new IndexOutOfRangeException();
            }
            array[index] = value;
        }
    }
    public void Add(T item)
    {
        if (count == array.Length)
        {
            Resize();
        }
        array[count] = item;
        count++;
    }

    public void Remove(T item)
    {
        if(count==0)
        {
            throw new InvalidOperationException();
        }
        array[count-1] = default;
        count--;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = index; i < count; i++)
        {
            array[i] = array[i + 1];
        }
        array[count - 1] = default;
        count--;
    }

    private void Resize()
    {
        T[] newArray = new T[array.Length*2];
        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }
        array = newArray;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return array[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}