# Backend Engineer Coding Challenge - README

## Project Overview:

This project implements a set of **RESTful web APIs** that process text inputs and trigger predefined workflows, simulating basic interactions in an accounting and finance environment. The project demonstrates the ability to manage **invoice status enquiries**, **new invoice submissions**, and **client information retrieval** using clean, well-structured C# code base on Dotnet8.0.

### Key Workflows:
flow entry in [TextController](https://github.com/marsforwill/DotNetWebProject/blob/master/Controllers/TextController.cs) : /api/text/query
and you can use other InvoiceController/ClientController test basic function as well.

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

- **Controllers**: Handle incoming HTTP requests, process the input, and return appropriate responses.  
  Example: `InvoiceController.cs` for handling invoice-related requests.
  
- **Services**: Business logic resides here. For example, `InvoiceService.cs` is responsible for managing the invoices and performing operations like status retrieval and submission.

- **Models**: Represent the data structures used in the system, such as `Invoice.cs` and `Client.cs`.

This structure ensures a clean separation of concerns, making the project easy to maintain and extend in the future. The implementation focuses on simplicity and minimalism due to time constraints.

## LLM Integration

The project integrates **Azure OpenAI Services** to process natural language queries related to invoices and clients. The Large Language Model (LLM) assists in extracting key information from text inputs, mapping them to predefined workflows (Invoice Status Enquiry, New Invoice Submission, Client Information Enquiry).
resource config in [appsetting file](https://github.com/marsforwill/DotNetWebProject/blob/master/appsettings.json), (will remove or update soon for sercurity reason) :


## How to Run the Project

1. **Clone the Repository running locally**:
   pull the code from the reop to your local environment and running locally as a common Dotnet web project.
2. **using github corresponding [codeSpaces](https://docs.github.com/en/codespaces/overview)**:
   start/enter the corresponding codeSpaces, no need to set up any dependency, and it will maintain a container env for dev/test/running
   <img width="752" alt="image" src="https://github.com/user-attachments/assets/0843405f-79bc-489e-aa95-7be55c6abb75">
   
## Testing

Several basic cases were tested in limited time：

Invoice Status Enquiry
![image](https://github.com/user-attachments/assets/bfcb9f82-bb63-468c-b0a8-0db648d0e96a)
New Invoice Submission
![image](https://github.com/user-attachments/assets/ce26697b-1292-4429-b630-c19256361815)
Client Information Enquiry
![image](https://github.com/user-attachments/assets/7dab7f89-0a5e-4aab-9dd1-195125aae249)
