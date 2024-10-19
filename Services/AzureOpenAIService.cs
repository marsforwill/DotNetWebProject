using Azure;
using Azure.AI.OpenAI;

public class AzureOpenAIService
{
    private readonly OpenAIClient _client;

    private readonly string modelName;

    public AzureOpenAIService(IConfiguration configuration)
    {
        string? endpoint = configuration["AzureOpenAI:Endpoint"];
        string? apiKey = configuration["AzureOpenAI:Key"];
        modelName = configuration["AzureOpenAI:DeployModel"] ?? "gpt-4o";
        if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(apiKey))
        {
            throw new ArgumentException("AzureOpenAI:Endpoint and AzureOpenAI:Key must be set in the configuration");
        }

        _client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
    }

    public async Task<string> GetLLMResponseAsync(string userInput)
    {
        string prompt = @"You are a helpful assistant that processes accounting-related tasks. Your goal is to extract relevant information from the following user input to trigger one of the predefined workflows:
1. **Invoice Status Enquiry**: If the user asks about the status of an invoice, extract the invoice number and return the correct status (Paid, Pending, Overdue).
2. **New Invoice Submission**: If the user requests to submit a new invoice, return ""New Invoice Submission"" and any client information they may have provided.
3. **Client Information Enquiry**: If the user asks for client details, extract the client ID, name, or email and return the correct company information.
Here is an example of user input:
""{Can you provide the status of invoice INV-1020?}""
Based on the user's input, extract the relevant information (e.g., invoice number, client ID, status) and return the type of operation (one of: Invoice Status Enquiry, New Invoice Submission, Client Information Enquiry), as well as any IDs, client names, or emails mentioned.
And you must response in these json format with relevet information
{
    'OperationType': 'Invoice Status Enquiry',
    'InvoiceID': 'INV-1020',
    'ClientID': null,
    'ClientName': null,
    'ClientEmail': null,
    'Status': null
}
";
        var chatCompletionsOptions = new ChatCompletionsOptions()
        {
            DeploymentName = modelName,
            ResponseFormat = ChatCompletionsResponseFormat.JsonObject,
            Messages =
            {
                // The system message represents instructions or other guidance about how the assistant should behave
                new ChatRequestSystemMessage(prompt),
                // User messages represent current or historical input from the end user
                new ChatRequestUserMessage(userInput),
            }
        };

        Response<ChatCompletions> response = await _client.GetChatCompletionsAsync(chatCompletionsOptions);
        ChatResponseMessage responseMessage = response.Value.Choices[0].Message;    

        return responseMessage.Content;
    }
}