using cours7.Entity;
using Microsoft.Data.SqlClient;
using System.Text;

namespace cours7.Repository
{
    /// <summary>
    /// Repository spécialisé pour la gestion des commandes, avec accès base SQL et structure de file.
    /// </summary>
    public class CommandeRepository : Repository<Commande>
    {
        /// <summary>
        /// Chaîne de connexion à la base de données SQL.
        /// </summary>
        private readonly string _connectionString;
        /// <summary>
        /// File FIFO pour gérer les commandes dans l'ordre d'arrivée.
        /// </summary>
        public Queue<Commande> FileCommandes { get; } = new();
        /// <summary>
        /// Pile pour stocker l'historique des requêtes SQL exécutées.
        /// </summary>
        public Stack<string> HistoriqueRequetes { get; } = new();
        /// <summary>
        /// Constructeur qui initialise le repository avec la chaîne de connexion.
        /// </summary>
        /// <param name="connectionString"></param>
        public CommandeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Charge les commandes depuis la base SQL et les ajoute à la file.
        /// </summary>
        public void ChargerCommandes()
        {
            var requete = "SELECT Id, Description, Montant FROM Commandes";
            HistoriqueRequetes.Push(requete);

            using var connexion = new SqlConnection(_connectionString);
            using var commande = new SqlCommand(requete, connexion);
            connexion.Open();
            using var reader = commande.ExecuteReader();
            while (reader.Read())
            {
                var cmd = new Commande
                {
                    Id = reader.GetInt32(0),
                    Description = reader.GetString(1),
                    Montant = reader.GetDecimal(2)
                };
                FileCommandes.Enqueue(cmd);
                Ajouter(cmd); // Ajoute aussi dans le repository générique
            }
        }

        /// <summary>
        /// Retourne la liste triée des commandes par montant.
        /// </summary>
        public List<Commande> ObtenirCommandesTrieesParMontant()
        {
            var liste = new List<Commande>(FileCommandes);
            liste.Sort(new CommandeParMontant());
            return liste;
        }
    }
}
