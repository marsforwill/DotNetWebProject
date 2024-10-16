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

        public string GetInvoiceStatus(string invoiceNumber)
        {
            var invoice = _invoices.FirstOrDefault(inv => inv.InvoiceNumber == invoiceNumber);
            return invoice?.Status;
        }

        public List<Invoice> LoadInvoicesFromJson()
        {
            var jsonData = File.ReadAllText("Data/invoices-attelas.json");
            return JsonConvert.DeserializeObject<List<Invoice>>(jsonData);
        }
    }
}
