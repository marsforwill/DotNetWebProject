using DotNetWebProject.Models;
using Newtonsoft.Json;

namespace DotNetWebProject.Services
{
    public class InvoiceService
    {
        private readonly List<Invoice> _invoices;

        public InvoiceService()
        {
            // Seed data can be loaded from JSON files here
            _invoices = LoadInvoicesFromJson();
        }

        public List<Invoice> GetInvoices(string? invoiceID, string? clientID, string? status)
        {
            var invoices = _invoices.FindAll(
                inv =>  (string.IsNullOrEmpty(invoiceID) || inv.InvoiceNumber == invoiceID) &&
                        (string.IsNullOrEmpty(clientID) || inv.ClientId == clientID) &&
                        (string.IsNullOrEmpty(status) || inv.Status == status));
            return invoices;
        }

        public Invoice AddNewInvoice(string invoiceID, string clientID, string status){
            var invoice = new Invoice(invoiceID, clientID, null, status, null);
            _invoices.Add(invoice);
            return invoice;
        }

        public List<Invoice> LoadInvoicesFromJson()
        {
            var jsonData = File.ReadAllText("Data/invoices-attelas.json");
            return JsonConvert.DeserializeObject<List<Invoice>>(jsonData);
        }
    }
}
