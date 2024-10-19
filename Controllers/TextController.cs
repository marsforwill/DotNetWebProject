using DotNetWebProject.Models;
using DotNetWebProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNetWebProject.Controllers
{
    [Route("api/text")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;

        private readonly ClientService _clientService;

        private readonly AzureOpenAIService _azureOpenAIService;

        public TextController(InvoiceService invoiceService, AzureOpenAIService azureOpenAIService, ClientService clientService)
        {
            _invoiceService = invoiceService;
            _clientService = clientService;
            _azureOpenAIService = azureOpenAIService;
        }

        [HttpGet("query")]
        public async Task<ActionResult> GetInvoiceStatus(string text)
        {
            var response = await _azureOpenAIService.GetLLMResponseAsync(text);
            ParsedLLMResponse llmResponse = JsonConvert.DeserializeObject<ParsedLLMResponse>(response);
            switch (llmResponse?.OperationType)
            {
                case "Invoice Status Enquiry":
                    // 调用发票状态查询服务
                    var invoices = _invoiceService.GetInvoices(llmResponse.InvoiceID, llmResponse.ClientID, llmResponse.Status);
                    return new OkObjectResult(invoices);

                case "New Invoice Submission":
                    // 新建发票，假设我们有个AddNewInvoice方法
                    var newInvoice = _invoiceService.AddNewInvoice(llmResponse.InvoiceID??"testInvoiceID", llmResponse.ClientID??"testClientID", llmResponse.Status??"Pending");
                    return new OkObjectResult(newInvoice);

                case "Client Information Enquiry":
                    // 查询客户信息
                    var client = _clientService.GetClientByID(llmResponse.ClientID, llmResponse.ClientName, llmResponse.ClientEmail);
                    return client != null ? new OkObjectResult(client) : new NotFoundResult();

                default:
                    return new BadRequestObjectResult("Unknown operation");
            }
        }
    }
}
