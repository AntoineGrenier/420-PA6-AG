Console.WriteLine("1. Chien");
Console.WriteLine("2. Chat");
Console.WriteLine("3. Truite");
Console.Write("Choisissez un animal (1-3): ");
var iChoix = 0;
while (iChoix < 1 || iChoix > 3)
{
    if (!int.TryParse(Console.ReadLine(), out iChoix) || iChoix < 1 || iChoix > 3)
    {
        Console.Write("Choix invalide. Veuillez choisir un animal (1-3): ");
    }
}

//Par polymorphisme, on peut utiliser une interface ou une classe abstraite
IAnimal animal = null;
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
    //Chien par défaut
    default:
        animal = new Chien();
        break;
}

Console.WriteLine($"Vous avez choisi: {animal.GetType().Name}");
Console.WriteLine(animal.Manger());
Console.WriteLine(animal.Deplacer());
Console.WriteLine(animal.FaireBruit());

public interface IAnimal
{
    public string Manger();
    public string Deplacer();
    public string FaireBruit();
}

public abstract class AnimalTerrestre : IAnimal
{
    public string LongueurPoil { get; }
    public int NombreDePatte { get; }

    public AnimalTerrestre(string longueurPoil, int nombreDePatte)
    {
        LongueurPoil = longueurPoil;
        NombreDePatte = nombreDePatte;
    }

    public abstract string Manger();
    public abstract string FaireBruit();

    public string Deplacer()
    {
        return $"Je marche avec mon poil {LongueurPoil} sur la terre avec {NombreDePatte} pattes";
    }
}

public abstract class AnimalAquatique : IAnimal
{
    public string TypeEau { get; }
    public int NombreDeNageoire { get; }

    public AnimalAquatique(string typeEau, int nombreDeNageoire)
    {
        TypeEau = typeEau;
        NombreDeNageoire = nombreDeNageoire;
    }

    public abstract string Manger();
    public abstract string FaireBruit();

    public string Deplacer()
    {
        return $"Je nage dans l'eau {TypeEau} avec {NombreDeNageoire} nageoires";
    }
}

public class Chien : AnimalTerrestre
{
    //Propriété spécifique au chien
    public bool EstDressé { get; set; }

    public Chien() : base("long", 4) { }
    public Chien(string longueurPoil, int nombreDePatte) : base(longueurPoil, nombreDePatte) { }

    public override string Manger()
    {
        return "Je mange des croquettes.";
    }
    public override string FaireBruit()
    {
        return "Woof Woof!";
    }
}

public class Chat : AnimalTerrestre
{
    //Propriété spécifique au chat
    public bool EstChasseur { get; set; }

    public Chat() : base("court", 6) { }
    public Chat(string longueurPoil, int nombreDePatte) : base(longueurPoil, nombreDePatte) { }

    public override string Manger()
    {
        return "Je mange des souris.";
    }
    public override string FaireBruit()
    {
        return "Miaou Miaou!";
    }
}

public class Truite : AnimalAquatique
{
    public Truite() : base("douce", 2) { }
    public Truite(string typeEau, int nombreDeNageoire) : base(typeEau, nombreDeNageoire) { }

    public override string Manger()
    {
        return "Je mange du plancton.";
    }
    public override string FaireBruit()
    {
        return "Blub Blub!";
    }
}