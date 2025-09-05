public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("|*************************Exercice #1*************************|");
        Console.WriteLine("Quel est votre nom?");
        var strNom = Console.ReadLine();
        Console.WriteLine("Quel est votre âge?");
        var iAge = 0;
        while (!int.TryParse(Console.ReadLine(), out iAge))
        {
            Console.WriteLine("Veuillez entrer un âge valide.");
        }
        Console.WriteLine($"Bonjour {strNom}, vous avez {iAge} ans.");

        Console.WriteLine("|*************************Exercice #2*************************|");
        //Déclaration de la variable gauche
        var iNombreGauche = 0;
        //Déclaration de la variable droite
        var iNombreDroite = 0;
        Console.WriteLine("Entrez un nombre entier:");
        var strErreur = "Veuillez entrer une valeurs entière valide.";
        while (!int.TryParse(Console.ReadLine(), out iNombreGauche))
        {
            Console.WriteLine(strErreur);
        }
        Console.WriteLine("Entrez un deuxième nombre entier:");
        while (!int.TryParse(Console.ReadLine(), out iNombreDroite))
        {
            Console.WriteLine(strErreur);
        }
        //Appel de la fonction Somme
        var iNombreSomme = Calcul.Somme(iNombreGauche, iNombreDroite);
        Console.WriteLine($"La somme de {iNombreGauche} et {iNombreDroite} est égale à {iNombreSomme}.");
    }

    /// <summary>
    /// Classe de calcul
    /// </summary>
    public static class Calcul
    {
        /// <summary>
        /// Additionne deux nombres et retourne le résultat
        /// </summary>
        /// <param name="a">nombre de gauche</param>
        /// <param name="b">nom de droite</param>
        /// <returns>Somme entière</returns>
        public static int Somme(int a, int b)
        {
            //Additionne deux nombres et retourne le résultat
            return a + b;
        }
    }
}