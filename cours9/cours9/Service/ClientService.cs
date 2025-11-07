using cours9.Donnees;
using cours9.Entity;

namespace cours9.Service
{
    public class ClientService
    {
        private ClientRepository _clientRepository;

        public ClientService()
        {
            _clientRepository = new ClientRepository();
        }

        public string GetClientInfo(Client client)
        {
            return $"Nom : {client.Nom}, Email : {client.Email}";
        }

        public IEnumerable<Client> ListClients()
        {
            return _clientRepository.GetAllClients();
        }
    }
}
