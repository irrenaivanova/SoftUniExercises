using System.Text;

namespace EstateAgency
{
    public class EstateAgency
    {

        public EstateAgency(int capacity)
        {
            Capacity = capacity;
            RealEstates = new List<RealEstate>();
        }

        public int Capacity { get; private set; }
        public List<RealEstate> RealEstates { get; set; }
        public int Count => RealEstates.Count;
        //public void AddRealEstate(RealEstate realEstate)
        //{
        //       if (Capacity > Count && !RealEstates.Any(x => x.Address == realEstate.Address))
        //    {
        //        RealEstates.Add(realEstate);
        //    }

        //}

        public bool AddRealEstate(RealEstate realEstate)
        {
            if (this.RealEstates.Any(r => r.Address == realEstate.Address))
            {
                return false;
            }
            if (Count < Capacity)
            {
                RealEstates.Add(realEstate);
                return true;
            }
            return false;
        }

        public bool RemoveRealEstate(string address)
        {
            RealEstate current = RealEstates.FirstOrDefault(x => x.Address == address);
            if (current == null)
            {
                return false;
            }

            RealEstates.Remove(current);
            return true;
        }

        public List<RealEstate> GetRealEstates(string postalCode)
        {
            return RealEstates.Where(x => x.PostalCode == postalCode).ToList();
        }

        public RealEstate GetRealEstate(string address)
        {
            return RealEstates.FirstOrDefault(r => r.Address == address);
        }
        public RealEstate GetCheapest()
        {
            return RealEstates.OrderBy(x => x.Price).FirstOrDefault();
        }



        public double GetLargest()
        {
            return RealEstates.OrderByDescending(x => x.Size).FirstOrDefault().Size;
        }

        public string EstateReport()
        {
            StringBuilder sb = new();
            sb.AppendLine("Real estates available:");
            foreach (var item in RealEstates)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}
