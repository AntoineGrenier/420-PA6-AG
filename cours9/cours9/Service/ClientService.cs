using cours9.Modele.Entity;
using cours9.Presentation.Donnees;

namespace cours9.Presentation.Service
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

        public IList<Client> ListClients()
        {
            return _clientRepository.GetAllClients();
        }

        public void AddClient(Client client)
        {
            if (client != null)
            {
                if (!string.IsNullOrEmpty(client.Email))
                {
                    var count = _clientRepository.GetAllClients().Count;
                    client.Id = count + 2;
                    _clientRepository.AddClient(client);
                } 
                else
                {
                    throw new Exception("Pas de courriel pour le client");
                }
            }
        }

        public Client GetClientById(int id)
        {
            return _clientRepository.GetClientById(id);
        }
    }
}
