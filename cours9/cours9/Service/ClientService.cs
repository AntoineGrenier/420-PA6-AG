using cours9.Entity;

namespace cours9.Service
{
    public class ClientService
    {
        public string GetClientInfo(Client client)
        {
            return $"Nom : {client.Nom}, Email : {client.Email}";
        }
    }
}
