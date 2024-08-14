using AutoMapper;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            var mapper = new Mapper (new MapperConfiguration(x=>x.AddProfile<TravelAgencyProfile>()));
            StringBuilder sb = new StringBuilder();
            var xml = new XmlSerializer(typeof(CustomerImportDto[]), new XmlRootAttribute("Customers"));
            var reader = new StringReader(xmlString);
            var customers = (CustomerImportDto[])xml.Deserialize(reader);
           
            foreach (var customer in customers)
            {
                if (!IsValid(customer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (context.Customers.Any(x=>x.FullName==customer.FullName)
                    || context.Customers.Any(x => x.Email == customer.Email)
                    || context.Customers.Any(x => x.PhoneNumber == customer.phoneNumber))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                var validCustomer = mapper.Map<Customer>(customer); 
                context.Customers.Add(validCustomer);
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, validCustomer.FullName));
                context.SaveChanges();
            }

            return sb.ToString().Trim();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var bookings = JsonConvert.DeserializeObject<BookingImportDto[]>(jsonString);
            foreach (var booking in bookings)
            {
                if (!IsValid(booking))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDateValid = DateTime.TryParse(booking.BookingDate,CultureInfo.InvariantCulture,DateTimeStyles.None,out var date);
                if(!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var validBooking = new Booking()
                {
                    BookingDate = date,
                    CustomerId = context.Customers.FirstOrDefault(x => x.FullName == booking.CustomerName).Id,
                    TourPackageId = context.TourPackages.FirstOrDefault(x => x.PackageName == booking.TourPackageName).Id
                };
                context.Bookings.Add(validBooking);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfullyImportedBooking, booking.TourPackageName, booking.BookingDate));
            }

            return sb.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
