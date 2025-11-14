using System.Collections;

namespace cours7.Liste
{
    /// <summary>
    /// Implémentation d'une liste chaînée générique.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Chaine<T> : IEnumerable<T>
    {
        /// <summary>
        /// Noeud interne représentant un élément de la liste chaînée.
        /// </summary>
        private class Noeud
        {
            /// <summary>
            /// Valeur stockée dans le noeud.
            /// </summary>
            public T Valeur { get; set; }
            /// <summary>
            /// Référence vers le noeud suivant dans la liste chaînée.
            /// </summary>
            public Noeud? Suivant { get; set; }
            /// <summary>
            /// Constructeur du noeud.
            /// </summary>
            /// <param name="valeur"></param>
            public Noeud(T valeur) => Valeur = valeur;
        }

        /// <summary>
        /// Référence vers le premier noeud de la liste chaînée.
        /// </summary>
        private Noeud? _tete = null;
        /// <summary>
        /// Référence vers le dernier noeud de la liste chaînée.
        /// </summary>
        private Noeud? _fin = null;

        /// <summary>
        /// Ajoute une valeur à la fin de la liste chaînée.
        /// </summary>
        /// <param name="valeur"></param>
        public void Ajouter(T valeur)
        {
            var nouveau = new Noeud(valeur);
            if (_tete == null)
            {
                _tete = nouveau;
                _fin = nouveau;
            }
            else
            {
                _fin!.Suivant = nouveau;
                _fin = nouveau;
            }
        }

        /// <summary>
        /// Implémentation générique de GetEnumerator pour IEnumerable<T>.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            var courant = _tete;
            while (courant != null)
            {
                yield return courant.Valeur;
                courant = courant.Suivant;
            }
        }

        /// <summary>
        /// Implémentation non générique de GetEnumerator pour IEnumerable.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
