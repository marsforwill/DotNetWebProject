using System.Text.Json.Serialization;

namespace DotNetWebProject.Models
{
    [JsonSerializable(typeof(Client))]
    public class Client
    {
        public Client(string clientId, string name, string email, string address)
        {
            ClientId = clientId;
            Name = name;
            Email = email;
            Address = address;
        }

        public string ClientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
