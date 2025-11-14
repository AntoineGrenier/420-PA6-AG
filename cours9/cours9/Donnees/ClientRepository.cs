using cours9.Modele.Entity;

namespace cours9.Presentation.Donnees
{
    public class ClientRepository
    {
        private IList<Client> _clients;

        public ClientRepository() 
        {
            _clients = new List<Client>
            {
                new Client { Id = 1, Email = "email1@email.com", Nom = "Nom1" },
                new Client { Id = 2, Email = "email2@email.com", Nom = "Nom2" },
                new Client { Id = 3, Email = "email3@email.com", Nom = "Nom3" }
            };
        }

        public IList<Client> GetAllClients()
        {
            return _clients;
        }

        public void AddClient(Client client)
        {
            _clients.Add(client);
        }

        public Client GetClientById(int id)
        {
            return _clients.FirstOrDefault(c => c.Id == id);
        }
    }
}
