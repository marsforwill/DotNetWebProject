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

        public InvoiceController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("status/{invoiceNumber}")]
        public ActionResult<string> GetInvoiceStatus(string invoiceNumber)
        {
            var status = _invoiceService.GetInvoiceStatus(invoiceNumber);
            if (status == null)
            {
                return NotFound("Invoice not found.");
            }
            return Ok(status);
        }
    }
}
