namespace cours7.Entity
{
    /// <summary>
    /// Classe représentant un client.
    /// </summary>
    public class Client : IEntity, IComparable<Client>
    {
        /// <summary>
        /// Identifiant unique du client.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nom du client.
        /// </summary>
        public required string Nom { get; set; }
        /// <summary>
        /// Adresse email du client.
        /// </summary>
        public required string Email { get; set; }
        /// <summary>
        /// Date d'inscription du client.
        /// </summary>
        public DateTime DateInscription { get; set; }

        /// <summary>
        /// Tri naturel par Nom (ordre alphabétique)
        /// </summary>
        /// <param name="autre"></param>
        /// <returns></returns>
        public int CompareTo(Client? autre)
        {
            return string.Compare(this.Nom, autre?.Nom, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Retourne une représentation textuelle du client.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {Id}, Nom: {Nom}, Email: {Email}, DateInscription: {DateInscription:yyyy-MM-dd}";
        }
    }

    /// <summary>
    /// Classe pour comparer des clients par date d'inscription.
    /// </summary>
    public class ClientParDate : IComparer<Client>
    {
        /// <summary>
        /// Compare deux clients par leur date d'inscription.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(Client? x, Client? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return DateTime.Compare(x.DateInscription, y.DateInscription);
        }
    }
}
