namespace cours7.Entity
{
    /// <summary>
    /// Classe représentant un client.
    /// </summary>
    public class Client : IEntity
    {
        /// <summary>
        /// Identifiant unique du client.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nom du client.
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Adresse email du client.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Retourne une représentation textuelle du client.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {Id}, Nom: {Nom}, Email: {Email}";
        }
    }
}
