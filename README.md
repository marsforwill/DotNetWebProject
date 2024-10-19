# Backend Engineer Coding Challenge - README

## Project Overview:

This project implements a set of **RESTful web APIs** that process text inputs and trigger predefined workflows, simulating basic interactions in an accounting and finance environment. The project demonstrates the ability to manage **invoice status enquiries**, **new invoice submissions**, and **client information retrieval** using clean, well-structured C# code base on Dotnet8.0.

### Key Workflows:
flow entry, test entry
1. **Invoice Status Enquiry**: Retrieves the status of a specified invoice (Paid, Pending, Overdue).
2. **New Invoice Submission**: Adds a new invoice to storage with optional line items and due date.
3. **Client Information Enquiry**: Fetches company information for a specific client.

## Data Sources

The data for invoices and clients is loaded into memory from two JSON files to keep the implementation simple and efficient:

- **Invoices Data**: `invoices-attelas.json`
- **Clients Data**: `clients-attelas.json`

These JSON files simulate the backend data for invoices and client details, allowing quick testing and development.

## Project Structure

The project follows the **MVC (Model-View-Controller)** architecture pattern. Here's a quick breakdown of the directory structure:

### Explanation of Layers:

- **Controllers**: Handle incoming HTTP requests, process the input, and return appropriate responses.  
  Example: `InvoiceController.cs` for handling invoice-related requests.
  
- **Services**: Business logic resides here. For example, `InvoiceService.cs` is responsible for managing the invoices and performing operations like status retrieval and submission.

- **Models**: Represent the data structures used in the system, such as `Invoice.cs` and `Client.cs`.

This structure ensures a clean separation of concerns, making the project easy to maintain and extend in the future. The implementation focuses on simplicity and minimalism due to time constraints.

## LLM Integration

The project integrates **Azure OpenAI Services** to process natural language queries related to invoices and clients. The Large Language Model (LLM) assists in extracting key information from text inputs, mapping them to predefined workflows (Invoice Status Enquiry, New Invoice Submission, Client Information Enquiry).

### Configuration:

Azure OpenAI Services is set up and configured through the following environment settings:
- **Model Name**: You can configure your preferred model in `appsettings.json`.
- **Deployment**: Connects to the Azure OpenAI resource to handle text inputs and extract relevant data.

To use your own Azure OpenAI Service, replace the relevant configuration values in `appsettings.json` with your own Azure credentials.

## How to Run the Project

1. **Clone the Repository**:
   Download the code from the [GitHub repository](<link-to-your-repository>) to your local environment.
   
## Testing
