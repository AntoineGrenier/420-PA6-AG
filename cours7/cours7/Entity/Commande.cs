using System.Reflection.Metadata;

namespace cours7.Entity
{
    /// <summary>
    /// Représente une commande avec un identifiant et une description.
    /// </summary>
    public class Commande : IEntity
    {
        /// <summary>
        /// Identifiant unique de la commande.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Description de la commande.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Montant total de la commande.
        /// </summary>
        public decimal Montant { get; set; }
        /// <summary>
        /// Retourne une représentation textuelle de la commande.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Commande {Id}: {Description}, Montant: {Montant}";
    }

    /// <summary>
    /// Comparateur pour trier les commandes par montant.
    /// </summary>
    public class CommandeParMontant : IComparer<Commande>
    {
        public int Compare(Commande? x, Commande? y)
        {
            if (x == null || y == null) return 0;
            return x.Montant.CompareTo(y.Montant);
        }
    }
}
