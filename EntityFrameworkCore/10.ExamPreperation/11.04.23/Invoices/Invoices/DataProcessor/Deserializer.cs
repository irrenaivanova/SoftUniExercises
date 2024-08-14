namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            var mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<InvoicesProfile>()));
            StringBuilder sb = new StringBuilder();
            var xml = new XmlSerializer(typeof(ClientImportDto[]), new XmlRootAttribute("Clients"));
            var reader = new StringReader(xmlString);
            var clients = (ClientImportDto[])xml.Deserialize(reader);
            
            foreach (var client in clients)
            {
                if(!IsValid(client))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var validAddresses = new List<Address>();
                
                foreach (var address in client.Addresses)
                {
                    if (!IsValid(address))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var validAddress = mapper.Map<Address>(address);
                    validAddresses.Add(validAddress);
                }

                var validClient = new Client()
                {
                    Name = client.Name,
                    NumberVat = client.NumberVat,
                    Addresses = validAddresses,
                };
               
                context.Clients.Add(validClient);
                sb.AppendLine(string.Format(SuccessfullyImportedClients, client.Name));
            }
            context.SaveChanges();

            return sb.ToString().TrimEnd();
            
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            var mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<InvoicesProfile>()));
            StringBuilder sb = new StringBuilder();
            var invoices = JsonConvert.DeserializeObject<InvoiceImportDto[]>(jsonString);
            
            foreach (var invoice in invoices)
            {
                if (!IsValid(invoice))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (invoice.DueDate<invoice.IssueDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<int> clientIds = context.Clients.Select(x => x.Id).ToList();

                if (!clientIds.Contains(invoice.ClientId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validInvoice = mapper.Map<Invoice>(invoice);
                context.Invoices.Add(validInvoice);
                sb.AppendLine(string.Format(SuccessfullyImportedInvoices, validInvoice.Number));
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ICollection<Product> productsToImport = new List<Product>();

            var products = JsonConvert.DeserializeObject<ProductImportDto[]>(jsonString);
            foreach (var product in products)
            {
                if (!IsValid(product))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                //List<int> clientsIds = context.Clients.Select(x => x.Id).ToList();
                var productClients = new List<ProductClient>();

                var validProduct = new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    CategoryType = (CategoryType)product.CategoryType,

                };

                foreach (var client in product.Clients.Distinct())
                {
                    if (!context.Clients.Any(cl => cl.Id == client))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    productClients.Add(new ProductClient() { ClientId = client, Product = validProduct });
                }

                validProduct.ProductsClients = productClients;

                context.Products.Add(validProduct);
                sb.AppendLine(string.Format(SuccessfullyImportedProducts, validProduct.Name, validProduct.ProductsClients.Count()));
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
