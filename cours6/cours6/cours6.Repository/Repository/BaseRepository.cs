using System.Data;

namespace cours6.Repository.Repository
{
    /// <summary>
    /// Classe de base pour les dépôts
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRepository<T> : IRepository<T>
    {
        protected readonly string _connectionString;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="connectionString"></param>
        protected BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <inheritdoc/>
        public abstract DataTable ObtenirTout();
        /// <inheritdoc/>
        public abstract bool Inserer(T entity);
        /// <inheritdoc/>
        public abstract bool MaJ(T entity);
        /// <inheritdoc/>
        public abstract bool Supprimer(int id);
    }
}
