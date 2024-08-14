using Newtonsoft.Json;
using TravelAgency.Data;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            throw new NotImplementedException();
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var custumers = context.Customers.ToArray()
            .Where(x => x.Bookings.Any(x => x.TourPackage.PackageName == "Horse Riding Tour"))
            .Select(x => new
            {
                FullName = x.FullName,
                PhoneNumber = x.PhoneNumber,
                Bookings = x.Bookings.Where(x => x.TourPackage.PackageName == "Horse Riding Tour").Select(x => new
                {
                    TourPackageName = x.TourPackage.PackageName,
                    Date = x.BookingDate.ToString("yyyy-MM-dd")
                }).ToArray().OrderBy(x => x.Date)
            }).OrderByDescending(x => x.Bookings.Count()).ThenBy(x => x.FullName).ToArray();

            return JsonConvert.SerializeObject(custumers, Formatting.Indented).ToString();
        }
    }
}
