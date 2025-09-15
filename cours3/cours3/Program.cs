using System;

/// <summary>
/// Programme principal qui permet à l'utilisateur de choisir un animal
/// et d'afficher ses comportements grâce au polymorphisme.
/// </summary>
class Program
{
    static void Main()
    {
        Console.WriteLine("|*************************Exercice héritage*************************|");
        // Affiche les options d'animaux disponibles
        Console.WriteLine("1. Chien");
        Console.WriteLine("2. Chat");
        Console.WriteLine("3. Truite");

        // Invite l'utilisateur à faire un choix
        Console.Write("Choisissez un animal (1-3): ");
        var iChoix = 0;

        // Boucle de validation du choix utilisateur
        while (iChoix < 1 || iChoix > 3)
        {
            // Vérifie que l'entrée est un entier entre 1 et 3
            if (!int.TryParse(Console.ReadLine(), out iChoix) || iChoix < 1 || iChoix > 3)
            {
                Console.Write("Choix invalide. Veuillez choisir un animal (1-3): ");
            }
        }

        // Utilisation du polymorphisme : on déclare une variable de type interface
        IAnimal animal = null;

        // Sélection de l'animal selon le choix de l'utilisateur
        switch (iChoix)
        {
            case 1:
                animal = new Chien();
                break;
            case 2:
                animal = new Chat();
                break;
            case 3:
                animal = new Truite();
                break;
            default:
                animal = new Chien();
                break;
        }

        // Affiche le type et les comportements de l'animal choisi
        Console.WriteLine($"Vous avez choisi: {animal.GetType().Name}");
        Console.WriteLine(animal.Manger());
        Console.WriteLine(animal.Deplacer());
        Console.WriteLine(animal.FaireBruit());

        Console.WriteLine("|*************************Exercice #1*************************|");
        int[] tab = [1, 2, 3, 4, 5];
        Console.WriteLine($"Somme : {tab.Sum()}");
        Console.WriteLine($"Len : {tab.Length}");

        Console.WriteLine("|*************************Exercice #2*************************|");
        var listePrenoms = new List<string>() { "Jean", "Pierre", "Jacques" };
        listePrenoms.Add("Michel");
        listePrenoms.Remove("Jacques");
        Console.WriteLine($"Count : {listePrenoms.Count}");

        Console.WriteLine("|*************************Exercice #3*************************|");
        var str = "Nous sommes dans un cours de C# et de bd!";
        var strUpper = str.ToUpper();
        Console.WriteLine(strUpper);
        var strReplace = str.Replace("cours", "formation");
        Console.WriteLine($"Len : {strReplace.Length}");

        Console.WriteLine("|*************************Exercice #4*************************|");
        var produit = new Produit();
        Console.WriteLine(produit.Afficher());

        Console.WriteLine("|*************************Exercice #5*************************|");
        var compteBanquaire = new CompteBanquaire();
        compteBanquaire.Deposer(50.0m);
        Console.WriteLine(compteBanquaire.AfficherSolde());
    }
}

/// <summary>
/// Classe représentant un produit avec un nom et un prix.
/// </summary>
public class Produit
{
    /// <summary>
    /// Nom du produit.
    /// </summary>
    public string Nom { get; set; }

    /// <summary>
    /// Prix du produit.
    /// </summary>
    public decimal Prix { get; set; }

    /// <summary>
    /// Constructeur par défaut.
    /// </summary>
    public Produit()
    {
        Nom = "Produit générique";
        Prix = 100.0m;
    }
    /// <summary>
    /// Constructeur de base pour initialiser les propriétés du produit.
    /// </summary>
    /// <param name="nom"></param>
    /// <param name="prix"></param>
    public Produit(string nom, decimal prix)
    {
        Nom = nom;
        Prix = prix;
    }

    /// <summary>
    /// Méthode pour afficher les détails du produit.
    /// </summary>
    /// <returns></returns>
    public string Afficher()
    {
        return $"Nom: {Nom}, Prix: {Prix}$";
    }
}

/// <summary>
/// Classe représentant un compte bancaire.
/// </summary>
public class CompteBanquaire
{
    /// <summary>
    /// Solde du compte bancaire.
    /// </summary>
    public decimal Solde { get; private set; }

    /// <summary>
    /// Constructeur par défaut.
    /// </summary>
    public CompteBanquaire()
    {
        Solde = 100.0m;
    }

    /// <summary>
    /// Constructeur de base pour initialiser les propriétés du compte bancaire.
    /// </summary>
    /// <param name="soldeInitial"></param>
    public CompteBanquaire(decimal soldeInitial)
    {
        Solde = soldeInitial;
    }

    /// <summary>
    /// Méthode pour déposer un montant sur le compte bancaire.
    /// </summary>
    /// <param name="montant"></param>
    public void Deposer(decimal montant)
    {
        if (montant > 0)
        {
            Solde += montant;
        }
    }

    /// <summary>
    /// Méthode pour retirer un montant du compte bancaire.
    /// </summary>
    /// <returns></returns>
    public string AfficherSolde()
    {
        return $"Solde: {Solde}$";
    }
}

/// <summary>
/// Interface définissant les comportements communs à tous les animaux.
/// </summary>
public interface IAnimal
{
    /// <summary>
    /// Décrit la façon dont l'animal mange.
    /// </summary>
    string Manger();

    /// <summary>
    /// Décrit la façon dont l'animal se déplace.
    /// </summary>
    string Deplacer();

    /// <summary>
    /// Décrit le bruit que fait l'animal.
    /// </summary>
    string FaireBruit();
}

/// <summary>
/// Classe abstraite représentant un animal terrestre.
/// Implémente partiellement l'interface IAnimal.
/// </summary>
public abstract class AnimalTerrestre : IAnimal
{
    /// <summary>
    /// Longueur du poil de l'animal (ex. : court, long).
    /// </summary>
    public string LongueurPoil { get; }

    /// <summary>
    /// Nombre de pattes que possède l'animal.
    /// </summary>
    public int NombreDePatte { get; }

    /// <summary>
    /// Constructeur de base pour initialiser les propriétés communes aux animaux terrestres.
    /// </summary>
    /// <param name="longueurPoil">Longueur du poil.</param>
    /// <param name="nombreDePatte">Nombre de pattes.</param>
    public AnimalTerrestre(string longueurPoil, int nombreDePatte)
    {
        LongueurPoil = longueurPoil;
        NombreDePatte = nombreDePatte;
    }

    /// <inheritdoc/>
    public abstract string Manger();

    /// <inheritdoc/>
    public abstract string FaireBruit();

    /// <inheritdoc/>
    public string Deplacer()
    {
        return $"Je marche avec mon poil {LongueurPoil} sur la terre avec {NombreDePatte} pattes";
    }
}

/// <summary>
/// Classe abstraite représentant un animal aquatique.
/// Implémente partiellement l'interface IAnimal.
/// </summary>
public abstract class AnimalAquatique : IAnimal
{
    /// <summary>
    /// Type d'eau dans lequel vit l'animal (ex. : douce, salée).
    /// </summary>
    public string TypeEau { get; }

    /// <summary>
    /// Nombre de nageoires que possède l'animal.
    /// </summary>
    public int NombreDeNageoire { get; }

    /// <summary>
    /// Constructeur de base pour initialiser les propriétés communes aux animaux aquatiques.
    /// </summary>
    /// <param name="typeEau">Type d'eau.</param>
    /// <param name="nombreDeNageoire">Nombre de nageoires.</param>
    public AnimalAquatique(string typeEau, int nombreDeNageoire)
    {
        TypeEau = typeEau;
        NombreDeNageoire = nombreDeNageoire;
    }

    /// <inheritdoc/>
    public abstract string Manger();

    /// <inheritdoc/>
    public abstract string FaireBruit();

    /// <inheritdoc/>
    public string Deplacer()
    {
        return $"Je nage dans l'eau {TypeEau} avec {NombreDeNageoire} nageoires";
    }
}

/// <summary>
/// Classe représentant un chien.
/// Hérite de AnimalTerrestre et implémente ses méthodes abstraites.
/// </summary>
public class Chien : AnimalTerrestre
{
    /// <summary>
    /// Indique si le chien est dressé.
    /// </summary>
    public bool EstDressé { get; set; }

    /// <summary>
    /// Constructeur par défaut avec valeurs prédéfinies.
    /// </summary>
    public Chien() : base("long", 4) { }

    /// <summary>
    /// Constructeur personnalisé.
    /// </summary>
    /// <param name="longueurPoil">Longueur du poil.</param>
    /// <param name="nombreDePatte">Nombre de pattes.</param>
    public Chien(string longueurPoil, int nombreDePatte) : base(longueurPoil, nombreDePatte) { }

    /// <inheritdoc/>
    public override string Manger()
    {
        return "Je mange des croquettes.";
    }

    /// <inheritdoc/>
    public override string FaireBruit()
    {
        return "Woof Woof!";
    }
}

/// <summary>
/// Classe représentant un chat.
/// Hérite de AnimalTerrestre et implémente ses méthodes abstraites.
/// </summary>
public class Chat : AnimalTerrestre
{
    /// <summary>
    /// Indique si le chat est chasseur.
    /// </summary>
    public bool EstChasseur { get; set; }

    /// <summary>
    /// Constructeur par défaut avec valeurs prédéfinies.
    /// </summary>
    public Chat() : base("court", 4) { }

    /// <summary>
    /// Constructeur personnalisé.
    /// </summary>
    /// <param name="longueurPoil">Longueur du poil.</param>
    /// <param name="nombreDePatte">Nombre de pattes.</param>
    public Chat(string longueurPoil, int nombreDePatte) : base(longueurPoil, nombreDePatte) { }

    /// <inheritdoc/>
    public override string Manger()
    {
        return "Je mange des souris.";
    }

    /// <inheritdoc/>
    public override string FaireBruit()
    {
        return "Miaou Miaou!";
    }
}

/// <summary>
/// Classe représentant une truite.
/// Hérite de AnimalAquatique et implémente ses méthodes abstraites.
/// </summary>
public class Truite : AnimalAquatique
{
    /// <summary>
    /// Constructeur par défaut avec valeurs prédéfinies.
    /// </summary>
    public Truite() : base("douce", 2) { }

    /// <summary>
    /// Constructeur personnalisé.
    /// </summary>
    /// <param name="typeEau">Type d'eau.</param>
    /// <param name="nombreDeNageoire">Nombre de nageoires.</param>
    public Truite(string typeEau, int nombreDeNageoire) : base(typeEau, nombreDeNageoire) { }

    /// <inheritdoc/>
    public override string Manger()
    {
        return "Je mange du plancton.";
    }

    /// <inheritdoc/>
    public override string FaireBruit()
    {
        return "Blub Blub!";
    }
}
