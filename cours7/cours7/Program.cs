static class Program
{
    static void Main(string[] args)
    {
        var strConnectionString = "Server = {VOTRE_SERVEUR};Database = {VOTRE_BASE}; Trusted_Connection = True; TrustServerCertificate = true; ";

        //Exercice 1 – Interface de base pour entité
        //Objectif: Définir une interface simple pour représenter une entité avec un identifiant.
        //Énoncé :
        //Créer une interface IEntity avec une propriété int Id;
        //Implémenter cette interface dans une classe Client contenant les propriétés Id, Nom, Email;
        //Instancier quelques objets Client et afficher leurs informations dans la console;
        //Bonne pratique : utiliser une interface pour uniformiser l’accès aux identifiants dans les entités.
        Console.WriteLine("|*************************Exercice #1*************************|");

        //Exercice 2 – Repository générique en mémoire
        //Objectif : Implémenter une interface générique pour gérer des entités en mémoire.
        //Énoncé :
        //Définir une interface IRepository<T> avec les méthodes Add(T), Remove(int id), GetAll();
        //Implémenter une classe Repository<T> utilisant une List<T> pour stocker les éléments;
        //Créer une instance Repository<Client> et tester l’ajout, la suppression et l’affichage des clients.
        //Bonne pratique : séparer la logique métier de la gestion des données avec des interfaces génériques.
        Console.WriteLine("|*************************Exercice 2*************************|");

        //Exercice 3 – Tri avec IComparable et IComparer
        //Objectif : Implémenter des interfaces de comparaison pour trier des entités.
        //Énoncé :
        //Ajouter à la classe Client l’interface IComparable<Client> pour trier par Nom;
        //Créer une classe ClientParDate qui implémente IComparer<Client> pour trier par DateInscription;
        //Créer une liste de clients et la trier selon les deux critères.
        //Bonne pratique : utiliser IComparable pour l’ordre naturel et IComparer pour les tris personnalisés.
        Console.WriteLine("|*************************Exercice #3*************************|");

        //Exercice 4 – Classe générique avec itérateurs
        //Objectif: Implémenter une structure de données personnalisée avec itération.
        //Énoncé:
        //Créer une classe générique Chaine<T> représentant une liste chaînée;
        //Ajouter une méthode Ajouter(T valeur) pour insérer un élément à la fin;
        //Implémenter IEnumerable<T> pour permettre l’utilisation de foreach.
        //Tester la classe avec des objets Commande.
        //Bonne pratique : utiliser yield return pour simplifier l’implémentation des itérateurs.
        Console.WriteLine("|*************************Exercice #4*************************|");

        //Exercice 5 – Repository DB +structure de données
        //Objectif: Combiner accès DB, structure de données et tri personnalisé.
        //Énoncé:
        //Créer une classe CommandeRepository qui lit les commandes depuis une base SQL avec ADO.NET;
        //Stocker les commandes dans une Queue<Commande> pour simuler une file d’attente;
        //Créer une Stack<string> pour enregistrer les requêtes SQL exécutées;
        //Implémenter un comparateur CommandeParMontant pour trier les commandes par montant;
        //Afficher un rapport des commandes triées.
        //Bonne pratique : utiliser SqlParameter pour sécuriser les requêtes et structurer les données selon leur usage métier.
        Console.WriteLine("|*************************Exercice #5*************************|");
    }
}