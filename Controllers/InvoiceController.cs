using DotNetWebProject.Models;
using DotNetWebProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebProject.Controllers
{
    [Route("api/invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;

        private readonly AzureOpenAIService _azureOpenAIService;

        public InvoiceController(InvoiceService invoiceService, AzureOpenAIService azureOpenAIService)
        {
            _invoiceService = invoiceService;
            _azureOpenAIService = azureOpenAIService;
        }

        [HttpGet("query")]
        public ActionResult<List<Invoice>> GetInvoiceStatus(string? invoiceID, string? clientID, string? status)
        {
            var invoices = _invoiceService.GetInvoices(invoiceID, clientID, status);
            if (invoices == null)
            {
                return NotFound("Invoice not found.");
            }
            return Ok(invoices);
        }

        [HttpGet("text")]
        public async Task<ActionResult<string>> queryText(string text)
        {
            var response = await _azureOpenAIService.GetLLMResponseAsync(text);
            if (response == null)
            {
                return NotFound("queryText error");
            }
            return Ok(response);
        }
    }
}
