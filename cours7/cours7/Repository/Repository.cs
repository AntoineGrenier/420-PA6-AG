using cours7.Entity;

namespace cours7.Repository
{
    /// <summary>
    /// Classe générique pour gérer des entités en mémoire.
    /// </summary>
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly List<T> _elements = new();

        /// <inheritdoc />
        public void Ajouter(T entite)
        {
            _elements.Add(entite);
        }

        /// <inheritdoc />
        public bool Supprimer(int id)
        {
            var element = _elements.FirstOrDefault(e => e.Id == id);
            if (element != null)
            {
                _elements.Remove(element);
                return true;
            }
            return false;
        }

        /// <inheritdoc />
        public IEnumerable<T> ObtenirTout()
        {
            return _elements;
        }
    }
}
