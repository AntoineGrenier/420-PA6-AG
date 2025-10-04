using System.Data;

namespace cours6.Repository.Repository
{
    /// <summary>
    /// Interface générique pour les opérations CRUD
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Obtenir tous les enregistrements
        /// </summary>
        /// <returns></returns>
        DataTable ObtenirTout();
        /// <summary>
        /// Insérer un enregistrement
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Inserer(T entity);
        /// <summary>
        /// Mettre à jour un enregistrement
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool MaJ(T entity);
        /// <summary>
        /// Supprimer un enregistrement par son ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Supprimer(int id);
    }
}
