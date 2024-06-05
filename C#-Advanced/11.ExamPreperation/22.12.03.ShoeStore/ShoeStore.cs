using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        private List<Shoe> shoes;
        public ShoeStore(string name, int storageCapacity)
        {
            StorageCapacity = storageCapacity;
            Name = name;
            shoes = new List<Shoe>();
        }

        public int StorageCapacity { get; set; }

        public string Name { get; private set; }

        public IReadOnlyCollection<Shoe> Shoes => shoes;

        public int Count => shoes.Count;
        public string AddShoe(Shoe shoe) 
        {
            string textWrite = string.Empty;
            if (Shoes.Count==StorageCapacity)
            {
                textWrite = "No more space in the storage room.";
            }
        else
            {
                shoes.Add(shoe);
                textWrite = $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
            return textWrite;
        }
        public int RemoveShoes(string material)
        {
            return shoes.RemoveAll(s => s.Material == material);
        }

        public List<Shoe> GetShoesByType(string type)
             => shoes.FindAll(s => s.Type.ToLower() == type.ToLower());
        public Shoe GetShoeBySize(double size)
        {
            return shoes.FirstOrDefault(x => x.Size == size);
        }
        public string StockList(double size, string type) 
        {
            StringBuilder sb = new StringBuilder();
            List<Shoe> newList = shoes.Where(x=>x.Size==size && x.Type == type).ToList();
            if (newList.Count==0)
            {
                return "No matches found!";
            }
            else
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (var item in newList)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}

