namespace DotNetWebProject.Models;

public class ParsedLLMResponse
{
    public ParsedLLMResponse(string OperationType){
        this.OperationType = OperationType;
    }

    public string OperationType { get; set; } // 操作类型（Invoice Status Enquiry, New Invoice Submission, Client Information Enquiry）
    public string? InvoiceID { get; set; }
    public string? ClientID { get; set; }
    public string? ClientName { get; set; }
    public string? ClientEmail { get; set; }
    public string? Status { get; set; }
}