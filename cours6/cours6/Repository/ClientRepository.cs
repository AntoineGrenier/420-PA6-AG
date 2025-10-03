using cours6.Modele;
using Microsoft.Data.SqlClient;
using System.Data;

namespace cours6.Repository
{
    /// <summary>
    /// Repository pour gérer les opérations CRUD sur les clients.
    /// </summary>
    public class ClientRepository : BaseRepository<Client>
    {
        public ClientRepository(string connectionString) : base(connectionString) { }

        /// <inheritdoc/>
        public override DataTable ObtenirTout()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var adapter = new SqlDataAdapter("SELECT * FROM Clients", connection);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        /// <inheritdoc/>
        public override bool Inserer(Client entity)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand("INSERT INTO Clients (Nom, Email) VALUES (@Nom, @Email)", connection);
            cmd.Parameters.AddWithValue("@Nom", entity.Nom);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            return cmd.ExecuteNonQuery() > 0;
        }

        /// <inheritdoc/>
        public override bool MaJ(Client entity)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand("UPDATE Clients SET Nom = @Nom, Email = @Email WHERE Id = @Id", connection);
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@Nom", entity.Nom);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            return cmd.ExecuteNonQuery() > 0;
        }

        /// <inheritdoc/>
        public override bool Supprimer(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand("DELETE FROM Clients WHERE Id = @Id", connection);
            cmd.Parameters.AddWithValue("@Id", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        /// <summary>
        /// Obtenir les clients par domaine email.
        /// </summary>
        /// <param name="domaine"></param>
        /// <returns></returns>
        public DataTable ObtenirClientsParDomaine(string domaine)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand("SELECT Id, Nom, Email FROM Clients WHERE Email LIKE @Domaine", connection);
            cmd.Parameters.AddWithValue("@Domaine", "%" + domaine);
            var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Ajouter une commande et mettre à jour le solde du client dans une transaction.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="montant"></param>
        /// <param name="dateCommande"></param>
        /// <returns></returns>
        public bool AjouterCommandeEtMettreAJourSolde(int clientId, decimal montant, DateTime dateCommande)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                // Insert commande
                var cmdCommande = new SqlCommand(
                    "INSERT INTO Commandes (ClientId, Montant, DateCommande) VALUES (@ClientId, @Montant, @DateCommande)",
                    connection, transaction);
                cmdCommande.Parameters.AddWithValue("@ClientId", clientId);
                cmdCommande.Parameters.AddWithValue("@Montant", montant);
                cmdCommande.Parameters.AddWithValue("@DateCommande", dateCommande);
                cmdCommande.ExecuteNonQuery();

                // Update solde
                var cmdSolde = new SqlCommand(
                    "UPDATE Clients SET Solde = Solde + @Montant WHERE Id = @ClientId",
                    connection, transaction);
                cmdSolde.Parameters.AddWithValue("@Montant", montant);
                cmdSolde.Parameters.AddWithValue("@ClientId", clientId);
                cmdSolde.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Synchroniser un DataSet avec la table Clients.
        /// </summary>
        /// <param name="ds"></param>
        public void SynchroniserDataSet(DataSet ds)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var adapter = new SqlDataAdapter("SELECT * FROM Clients", connection);
            var builder = new SqlCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
        }
    }
}
