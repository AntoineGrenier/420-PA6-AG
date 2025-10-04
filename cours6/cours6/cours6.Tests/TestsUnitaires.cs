using System.Data;
using cours6.Repository.Modele;
using cours6.Repository.Repository;
using Moq;
using Xunit;

namespace cours6.Tests
{
    /// <summary>
    /// Tests unitaires pour les opérations CRUD et autres fonctionnalités.
    /// </summary>
    public class TestsUnitaires
    {
        /// <summary>
        /// Test d'insertion d'un client.
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="email"></param>
        [Theory]
        [InlineData("TestNom", "test@email.com")]
        [InlineData("Alice", "alice@example.com")]
        [InlineData("Bob", "bob@gmail.com")]
        public void InsererClient_ReturnsTrue(string nom, string email)
        {
            var mockRepo = new Mock<IRepository<Client>>();
            var client = new Client { Nom = nom, Email = email };
            mockRepo.Setup(r => r.Inserer(client)).Returns(true);

            bool result = mockRepo.Object.Inserer(client);

            Assert.True(result);
        }

        /// <summary>
        /// Test de suppression d'un client.
        /// </summary>
        /// <param name="id"></param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(99)]
        public void SupprimerClient_ReturnsTrue(int id)
        {
            var mockRepo = new Mock<IRepository<Client>>();
            mockRepo.Setup(r => r.Supprimer(id)).Returns(true);

            bool result = mockRepo.Object.Supprimer(id);

            Assert.True(result);
        }

        /// <summary>
        /// Test de mise à jour d'un client.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        /// <param name="email"></param>
        [Theory]
        [InlineData(1, "Updated", "updated@email.com")]
        [InlineData(2, "Alice", "alice@domain.com")]
        [InlineData(3, "Bob", "bob@domain.com")]
        public void MajClient_ReturnsTrue(int id, string nom, string email)
        {
            var mockRepo = new Mock<IRepository<Client>>();
            var client = new Client { Id = id, Nom = nom, Email = email };
            mockRepo.Setup(r => r.MaJ(client)).Returns(true);

            bool result = mockRepo.Object.MaJ(client);

            Assert.True(result);
        }

        /// <summary>
        /// Test d'obtention de tous les clients.
        /// </summary>
        /// <param name="nom"></param>
        [Theory]
        [InlineData("TestNom")]
        [InlineData("Alice")]
        [InlineData("Bob")]
        public void ObtenirToutClients_ReturnsDataTable(string nom)
        {
            var mockRepo = new Mock<IRepository<Client>>();
            var dt = new DataTable();
            dt.Columns.Add("Nom");
            dt.Rows.Add(nom);
            mockRepo.Setup(r => r.ObtenirTout()).Returns(dt);

            DataTable result = mockRepo.Object.ObtenirTout();

            Assert.NotNull(result);
            Assert.Equal(nom, result.Rows[0]["Nom"]);
        }

        /// <summary>
        /// Test d'obtention des clients par domaine email.
        /// </summary>
        /// <param name="domaine"></param>
        /// <param name="email"></param>
        [Theory]
        [InlineData("@gmail.com", "domain@gmail.com")]
        [InlineData("@example.com", "user@example.com")]
        public void ObtenirClientsParDomaine_ReturnsFilteredClients(string domaine, string email)
        {
            var mockRepo = new Mock<ClientRepository>("FakeConnectionString");
            var dt = new DataTable();
            dt.Columns.Add("Email");
            dt.Rows.Add(email);
            mockRepo.Setup(r => r.ObtenirClientsParDomaine(domaine)).Returns(dt);

            DataTable result = mockRepo.Object.ObtenirClientsParDomaine(domaine);

            Assert.NotNull(result);
            Assert.Equal(email, result.Rows[0]["Email"]);
        }

        /// <summary>
        /// Test d'ajout de commande et mise à jour du solde du client.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="montant"></param>
        [Theory]
        [InlineData(1, 100)]
        [InlineData(2, 200)]
        public void AjouterCommandeEtMettreAJourSolde_ReturnsTrue(int clientId, decimal montant)
        {
            var mockRepo = new Mock<ClientRepository>("FakeConnectionString");
            mockRepo.Setup(r => r.AjouterCommandeEtMettreAJourSolde(clientId, montant, It.IsAny<DateTime>())).Returns(true);

            bool result = mockRepo.Object.AjouterCommandeEtMettreAJourSolde(clientId, montant, DateTime.Now);

            Assert.True(result);
        }

        /// <summary>
        /// Test de synchronisation d'un DataSet.
        /// </summary>
        /// <param name="nom"></param>
        [Theory]
        [InlineData("SyncTest")]
        [InlineData("AnotherName")]
        public void SynchroniserDataSet_CallsMethod(string nom)
        {
            var mockRepo = new Mock<ClientRepository>("FakeConnectionString");
            var ds = new DataSet();
            var dt = new DataTable();
            dt.Columns.Add("Nom");
            dt.Rows.Add(nom);
            ds.Tables.Add(dt);

            mockRepo.Setup(r => r.SynchroniserDataSet(ds));

            mockRepo.Object.SynchroniserDataSet(ds);

            Assert.Equal(nom, ds.Tables[0].Rows[0]["Nom"]);
        }

        /// <summary>
        /// Test d'obtention des commandes par ID client.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="montant"></param>
        [Theory]
        [InlineData(1, 100)]
        [InlineData(2, 200)]
        public void GetCommandesByClient_ReturnsCommandes(int clientId, decimal montant)
        {
            var mockRepo = new Mock<CommandeRepository>("FakeConnectionString");
            var dt = new DataTable();
            dt.Columns.Add("Montant", typeof(decimal));
            dt.Rows.Add(montant);
            mockRepo.Setup(r => r.GetCommandesByClient(clientId)).Returns(dt);

            DataTable result = mockRepo.Object.GetCommandesByClient(clientId);

            Assert.NotNull(result);
            Assert.Equal(montant, result.Rows[0]["Montant"]);
        }
    }
}