using Newtonsoft.Json;
using System.Runtime.Intrinsics.X86;
using System.Xml.Serialization;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            var guides = context.Guides
                .Where(x => x.Language == Language.Spanish)
                .Select(x => new Guide1()
                {
                    FullName = x.FullName,
                    TourPackages = x.TourPackagesGuides.Select(x => x.TourPackage).Select(x => new TourPackage1()
                    {
                        Name = x.PackageName,
                        Description = x.Description,
                        Price = x.Price
                    }).ToArray().OrderByDescending(x => x.Price).ThenBy(x => x.Name).ToArray()
                }).OrderByDescending(x => x.TourPackages.Count()).ThenBy(x => x.FullName).ToArray();

            var xml = new XmlSerializer(typeof(Guide1[]), new XmlRootAttribute("Guides"));
            StringWriter writer = new StringWriter();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            xml.Serialize(writer, guides, ns);
            return writer.ToString();

        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var custumers = context.Customers
            .Where(x => x.Bookings.Any(x => x.TourPackage.PackageName == "Horse Riding Tour"))
            .ToArray()
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

            return JsonConvert.SerializeObject(custumers, Formatting.Indented);
        }
    }
}
