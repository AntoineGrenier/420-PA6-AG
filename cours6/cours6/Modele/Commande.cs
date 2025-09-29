namespace cours6.Modele
{
    /// <summary>
    /// Modèle représentant une commande.
    /// </summary>
    public class Commande
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public decimal Montant { get; set; }
        public DateTime DateCommande { get; set; }
    }
}
