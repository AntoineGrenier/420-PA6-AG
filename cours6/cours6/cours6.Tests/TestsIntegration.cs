using System.Data;
using Microsoft.Data.SqlClient;
using cours6.Repository.Modele;
using cours6.Repository.Repository;
using Xunit;

namespace cours6.Tests
{
    /// <summary>
    /// Tests d'intégration pour les opérations CRUD sur les clients et commandes.
    /// </summary>
    public class TestsIntegration : IDisposable
    {
        private const string ConnStr = "Server={VOTRE_SERVEUR};Database={VOTRE_BASE};Trusted_Connection=True;TrustServerCertificate=true;";
        private readonly ClientRepository _clientRepo;
        private readonly CommandeRepository _commandeRepo;

        /// <summary>
        /// Initialise les repositories et prépare la base de données pour les tests.
        /// </summary>
        public TestsIntegration()
        {
            using var connection = new SqlConnection(ConnStr);
            connection.Open();

            // Rename real tables if they exist
            new SqlCommand(@"
                IF OBJECT_ID('Clients', 'U') IS NOT NULL
                    EXEC sp_rename 'Clients', 'ClientsReal';
                IF OBJECT_ID('Commandes', 'U') IS NOT NULL
                    EXEC sp_rename 'Commandes', 'CommandesReal';", connection).ExecuteNonQuery();

            // Create temp tables with same schema
            new SqlCommand(@"
                CREATE TABLE Clients (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Nom NVARCHAR(100) NOT NULL,
                    Email NVARCHAR(100) NOT NULL,
                    Solde DECIMAL(18,2) NOT NULL DEFAULT(0)
                );
                CREATE TABLE Commandes (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    ClientId INT NOT NULL,
                    Montant DECIMAL(18,2) NOT NULL,
                    DateCommande DATETIME NOT NULL
                );", connection).ExecuteNonQuery();

            _clientRepo = new ClientRepository(ConnStr);
            _commandeRepo = new CommandeRepository(ConnStr);
        }

        /// <summary>
        /// Test d'intégration pour l'insertion, la mise à jour et la suppression d'un client.
        /// </summary>
        [Fact]
        public void UpdateEtDeleteClient_Integration()
        {
            var client = new Client { Nom = "UpdateTest", Email = "update@test.com" };
            Assert.True(_clientRepo.Inserer(client));
            var clients = _clientRepo.ObtenirTout();
            var row = clients.Rows.Cast<DataRow>().FirstOrDefault(r => r["Email"].ToString() == "update@test.com");
            Assert.NotNull(row);
            int id = (int)row["Id"];

            client.Id = id;
            client.Nom = "UpdatedName";
            Assert.True(_clientRepo.MaJ(client));

            var updatedClients = _clientRepo.ObtenirTout();
            Assert.Contains(updatedClients.Rows.Cast<DataRow>(), r => r["Nom"].ToString() == "UpdatedName");

            Assert.True(_clientRepo.Supprimer(id));
            var afterDelete = _clientRepo.ObtenirTout();
            Assert.DoesNotContain(afterDelete.Rows.Cast<DataRow>(), r => (int)r["Id"] == id);
        }

        /// <summary>
        /// Test d'intégration pour l'insertion, la mise à jour et la suppression d'une commande.
        /// </summary>
        [Fact]
        public void UpdateEtDeleteCommande_Integration()
        {
            var client = new Client { Nom = "CmdUpdate", Email = "cmdupdate@test.com" };
            Assert.True(_clientRepo.Inserer(client));
            var clients = _clientRepo.ObtenirTout();
            var clientId = (int)clients.Rows[clients.Rows.Count - 1]["Id"];

            var commande = new Commande
            {
                ClientId = clientId,
                Montant = 50.00m,
                DateCommande = DateTime.Now
            };
            Assert.True(_commandeRepo.Inserer(commande));

            var commandes = _commandeRepo.ObtenirTout();
            var row = commandes.Rows.Cast<DataRow>().FirstOrDefault(r => (int)r["ClientId"] == clientId);
            Assert.NotNull(row);
            int id = (int)row["Id"];

            commande.Id = id;
            commande.Montant = 75.00m;
            Assert.True(_commandeRepo.MaJ(commande));

            var updatedCommandes = _commandeRepo.ObtenirTout();
            var updatedRow = updatedCommandes.Rows.Cast<DataRow>().FirstOrDefault(r => (int)r["Id"] == id);
            Assert.NotNull(updatedRow);
            Assert.Equal(75.00m, (decimal)updatedRow["Montant"]);

            Assert.True(_commandeRepo.Supprimer(id));
            var afterDelete = _commandeRepo.ObtenirTout();
            Assert.DoesNotContain(afterDelete.Rows.Cast<DataRow>(), r => (int)r["Id"] == id);
        }

        /// <summary>
        /// Test d'intégration pour une requête de jointure entre clients et commandes.
        /// </summary>
        [Fact]
        public void JoinClientsAndCommandes_Integration()
        {
            // Insert client
            var client = new Client { Nom = "JoinTest", Email = "jointest@test.com" };
            Assert.True(_clientRepo.Inserer(client));
            var clients = _clientRepo.ObtenirTout();
            var clientId = (int)clients.Rows[clients.Rows.Count - 1]["Id"];

            // Insert commandes
            var commande1 = new Commande { ClientId = clientId, Montant = 10, DateCommande = DateTime.Now };
            var commande2 = new Commande { ClientId = clientId, Montant = 20, DateCommande = DateTime.Now };
            Assert.True(_commandeRepo.Inserer(commande1));
            Assert.True(_commandeRepo.Inserer(commande2));

            // Join query
            using var connection = new SqlConnection(ConnStr);
            connection.Open();
            var joinCmd = new SqlCommand(@"
                SELECT c.Nom, c.Email, cmd.Montant, cmd.DateCommande
                FROM Clients c
                INNER JOIN Commandes cmd ON c.Id = cmd.ClientId
                WHERE c.Id = @ClientId", connection);
            joinCmd.Parameters.AddWithValue("@ClientId", clientId);
            using var reader = joinCmd.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                Assert.Equal("JoinTest", reader["Nom"].ToString());
                Assert.Equal("jointest@test.com", reader["Email"].ToString());
                Assert.True((decimal)reader["Montant"] == 10 || (decimal)reader["Montant"] == 20);
                count++;
            }
            Assert.Equal(2, count);
        }

        /// <summary>
        /// Nettoie la base de données en supprimant les tables temporaires et en restaurant les tables réelles.
        /// </summary>
        public void Dispose()
        {
            using var connection = new SqlConnection(ConnStr);
            connection.Open();

            // Drop temp tables
            new SqlCommand(@"
                IF OBJECT_ID('Commandes', 'U') IS NOT NULL
                    DROP TABLE Commandes;
                IF OBJECT_ID('Clients', 'U') IS NOT NULL
                    DROP TABLE Clients;", connection).ExecuteNonQuery();

            // Restore real tables if they were renamed
            new SqlCommand(@"
                IF OBJECT_ID('ClientsReal', 'U') IS NOT NULL
                    EXEC sp_rename 'ClientsReal', 'Clients';
                IF OBJECT_ID('CommandesReal', 'U') IS NOT NULL
                    EXEC sp_rename 'CommandesReal', 'Commandes';", connection).ExecuteNonQuery();
        }
    }
}