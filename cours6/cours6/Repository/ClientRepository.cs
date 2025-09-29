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
        /// <param name="domain"></param>
        /// <returns></returns>
        public DataTable GetClientsByEmailDomain(string domain)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand("SELECT Id, Nom, Email FROM Clients WHERE Email LIKE @Domaine", connection);
            cmd.Parameters.AddWithValue("@Domaine", "%" + domain);
            var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
