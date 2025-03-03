
namespace MyDictionary
{
    public class MyDictionary<T1, T2>
    {
        private const int InitialCapacity = 16;
        private List<KeyValue<T1, T2>>[] buckets;
        private HashSet<T1> keys;

        public MyDictionary(int capacity = InitialCapacity)
        {

            buckets = new List<KeyValue<T1, T2>>[capacity];
            keys = new HashSet<T1>();
        }

        public int Count { get; private set; }
        public T2 this[T1 key]
        {
            get
            {
                if (!keys.Contains(key))
                {
                    throw new KeyNotFoundException("No such key exists!");
                }
                int index = GetBucketIndex(key, buckets.Length);
                return buckets[index].First(x => x.Key!.Equals(key)).Value;

            }
            set
            {
                int index = GetBucketIndex(key, buckets.Length);

                if (!keys.Contains(key))
                {
                    Add(key, value);
                    return;
                }

                var list = buckets[index];
                var existingItem = list!.FirstOrDefault(x => x.Key!.Equals(key));

                if (existingItem != null)
                {
                    existingItem.Value = value;
                }
            }
        }
        public void Add(T1 key, T2 value)
        {
            if (key == null || value == null)
            {
                throw new ArgumentNullException("Key and value should be positive value");
            }

            if (keys.Contains(key))
            {
                throw new IndexOutOfRangeException("Already existing key");
            }

            int index = GetBucketIndex(key, buckets.Length);
            if (buckets[index] == null)
            {
                buckets[index] = new List<KeyValue<T1, T2>>();
            }
            var pair = new KeyValue<T1, T2>(key, value);
            buckets[index].Add(pair);
            keys.Add(key);
            Count++;

            if (Count / buckets.Length * 100 > 60)
            {
                Resize();
            }
        }

        public void Remove(T1 key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key should not be null");
            }
            int index = GetBucketIndex(key, buckets.Length);
            var list = buckets[index];

            var itemToRemove = list!.FirstOrDefault(x => x.Key!.Equals(key));
            if (itemToRemove != null)
            {
                list.Remove(itemToRemove);
                keys.Remove(key);
                Count--;
            }
        }

        public bool Contains(T1 key) => keys.Contains(key);

        private int GetBucketIndex(T1 key, int size)
        {
            return Math.Abs(key!.GetHashCode() % size);
        }

        private void Resize()
        {
            var newArray = new List<KeyValue<T1, T2>>[buckets.Length * 2];
            foreach (var list in buckets)
            {
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        int index = GetBucketIndex(item.Key, newArray.Length);
                        if (newArray[index] == null)
                        {
                            newArray[index] = new List<KeyValue<T1, T2>>();
                        }
                        newArray[index].Add(item);
                    }
                }
            }
            buckets = newArray;
        }
    }
}
