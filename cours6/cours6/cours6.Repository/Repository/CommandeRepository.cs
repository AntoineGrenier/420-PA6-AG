using cours6.Repository.Modele;
using Microsoft.Data.SqlClient;
using System.Data;

namespace cours6.Repository.Repository
{
    /// <summary>
    /// Repository pour gérer les opérations CRUD sur les commandes.
    /// </summary>
    public class CommandeRepository : BaseRepository<Commande>
    {
        public CommandeRepository(string connectionString) : base(connectionString) { }

        /// <inheritdoc/>
        public override DataTable ObtenirTout()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var adapter = new SqlDataAdapter("SELECT * FROM Commandes", connection);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        /// <inheritdoc/>
        public override bool Inserer(Commande entity)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand("INSERT INTO Commandes (ClientId, Montant, DateCommande) VALUES (@ClientId, @Montant, @DateCommande)", connection);
            cmd.Parameters.AddWithValue("@ClientId", entity.ClientId);
            cmd.Parameters.AddWithValue("@Montant", entity.Montant);
            cmd.Parameters.AddWithValue("@DateCommande", entity.DateCommande);
            return cmd.ExecuteNonQuery() > 0;
        }

        /// <inheritdoc/>
        public override bool MaJ(Commande entity)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand("UPDATE Commandes SET ClientId = @ClientId, Montant = @Montant, DateCommande = @DateCommande WHERE Id = @Id", connection);
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@ClientId", entity.ClientId);
            cmd.Parameters.AddWithValue("@Montant", entity.Montant);
            cmd.Parameters.AddWithValue("@DateCommande", entity.DateCommande);
            return cmd.ExecuteNonQuery() > 0;
        }

        /// <inheritdoc/>
        public override bool Supprimer(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand("DELETE FROM Commandes WHERE Id = @Id", connection);
            cmd.Parameters.AddWithValue("@Id", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        /// <summary>
        /// Obtenir les commandes par ID client.
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public virtual DataTable GetCommandesByClient(int clientId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand("SELECT * FROM Commandes WHERE ClientId = @ClientId", connection);
            cmd.Parameters.AddWithValue("@ClientId", clientId);
            var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
