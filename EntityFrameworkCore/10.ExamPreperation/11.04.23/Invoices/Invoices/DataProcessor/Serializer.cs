namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ExportDto;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var clients = context.Clients.ToArray()
                .Where(x=>x.Invoices.Any(x=>x.IssueDate>date))
                .Select(x=> new Client1()
                {
                    ClientName = x.Name,
                    VatNumber = x.NumberVat,
                    Invoices = x.Invoices.
                }


            return null;


        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            var products = context.Products.ToList()
                .Where(x => x.ProductsClients.Any(x => x.Client.Name.Length >= nameLength))
                .Select(x => new
                {
                    Name = x.Name,
                    Price = x.Price,
                    Category = x.CategoryType.ToString(),
                    Clients = x.ProductsClients.Where(x => x.Client.Name.Length >= nameLength).Select(x => new
                    {
                        Name = x.Client.Name,
                        NumberVat = x.Client.NumberVat,
                    }).ToArray().OrderBy(x => x.Name)
                }).OrderByDescending(x => x.Clients.Count()).ThenBy(x => x.Name).Take(5).ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
    }
}