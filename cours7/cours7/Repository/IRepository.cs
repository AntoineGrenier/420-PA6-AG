using cours7.Entity;

namespace cours7.Repository
{
    /// <summary>
    /// Interface générique pour gérer des entités en mémoire.
    /// </summary>
    public interface IRepository<T> where T : IEntity
    {
        /// <summary>
        /// Ajoute une entité au dépôt.
        /// </summary>
        /// <param name="entite">L'entité à ajouter.</param>
        void Ajouter(T entite);

        /// <summary>
        /// Supprime une entité selon son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'entité à supprimer.</param>
        /// <returns>True si l'entité a été supprimée, sinon False.</returns>
        bool Supprimer(int id);

        /// <summary>
        /// Retourne toutes les entités du dépôt.
        /// </summary>
        /// <returns>Collection des entités.</returns>
        IEnumerable<T> ObtenirTout();
    }
}
