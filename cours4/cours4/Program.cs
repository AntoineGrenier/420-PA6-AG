static class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("|*************************Exercice threads*************************|");

        //Exercice 1 – Propriétés automatiques
        //Objectif : Créer une classe simple avec des propriétés automatiques.
        //Énoncé :
        //Créer une classe Livre avec les propriétés suivantes :
        //Titre(string);
        //Auteur(string);
        //Pages(int).
        //Dans Main, créer un objet Livre, initialise ses propriétés, puis afficher les informations du livre.
        Console.WriteLine("|*************************Exercice #1*************************|");

        //Exercice 2 – Propriétés avec validation
        //Objectif : Ajouter de la logique dans les accesseurs.
        //Énoncé :
        //Créer une classe CompteBancaire avec une propriété Solde(decimal);
        //Le set doit refuser les valeurs négatives et lever une exception.
        //Dans Main, créer un compte et tenter d’assigner un solde négatif pour tester la validation.
        Console.WriteLine("|*************************Exercice #2*************************|");

        //Exercice 3 – Exceptions personnalisées
        //Objectif: Créer et utiliser une exception personnalisée.
        //Énoncé:
        //Créer une exception SoldeInsuffisantException qui hérite d’Exception;
        //Créer une méthode Retirer(decimal montant) dans CompteBancaire qui lève cette exception si le solde est insuffisant.
        //Dans Main, tester le retrait avec un montant supérieur au solde.
        Console.WriteLine("|*************************Exercice #3*************************|");

        //Exercice 4 – Thread simple
        //Objectif: Créer et exécuter un thread.
        //Énoncé :
        //Créer une méthode AfficherMessage() qui affiche "Bonjour du thread" toutes les 2 secondes;
        //Lancer cette méthode dans un thread.
        //Pendant ce temps, le thread principal affiche "Main continue..." toutes les secondes, pendant 5 secondes.
        Console.WriteLine("|*************************Exercice #4*************************|");

        //Exercice 5 – Synchronisation avec lock
        //Objectif : Protéger une ressource partagée entre threads.
        //Énoncé:
        //Créer une variable compteur partagée;
        //Lancer 3 threads qui incrémentent cette variable 1000 fois chacun;
        //Utiliser lock pour éviter les conflits.
        //Afficher le résultat final dans Main.
        Console.WriteLine("|*************************Exercice #5*************************|");
    }
}
