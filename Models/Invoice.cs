namespace DotNetWebProject.Models
{
    public class Invoice
    {
        public Invoice(string invoiceNumber, string clientId, DateTime? dueDate, string status, List<LineItem>? lineItems)
        {
            InvoiceNumber = invoiceNumber;
            ClientId = clientId;
            DueDate = dueDate;
            Status = status;
            LineItems = lineItems;
        }

        public string InvoiceNumber { get; set; }
        public string ClientId { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; } // Paid, Pending, Overdue
        public List<LineItem>? LineItems { get; set; }

    }
}
