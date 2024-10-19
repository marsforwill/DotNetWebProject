using DotNetWebProject.Models;
using Newtonsoft.Json;

namespace DotNetWebProject.Services
{
    public class ClientService
    {
        private readonly List<Client> _clients;

        public ClientService()
        {
            // Seed data can be loaded from JSON files here
            _clients = LoadClientsFromJson();
        }

        public Client? GetClientByID(string? clientId, string? clientName, string? clientEmail)
        {
            var client = _clients.FirstOrDefault(
                cli => (string.IsNullOrEmpty(clientId) || cli.ClientId == clientId) &&
                        (string.IsNullOrEmpty(clientName) || cli.Name == clientName) &&
                        (string.IsNullOrEmpty(clientEmail) || cli.Email == clientEmail));
            return client;
        }

        public List<Client> LoadClientsFromJson()
        {
            var jsonData = File.ReadAllText("Data/clients-attelas.json");
            return JsonConvert.DeserializeObject<List<Client>>(jsonData);
        }
    }
}
