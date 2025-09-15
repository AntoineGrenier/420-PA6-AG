using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Net;
using System.Security.Policy;
using System.Threading.Channels;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    public static void Main(string[] args)
    {
        //Exercice 1
        //Déclarer une variable int nommée nombre et lui donner la valeur 42;
        //Tester si nombre est supérieur à 10 et afficher un message adapté.
        Console.WriteLine("|*************************Exercice #1*************************|");
        int nombre = 42;
        if (nombre > 10)
        {
            Console.WriteLine("Le nombre est supérieur à 10.");
        }
        else
        {
            Console.WriteLine("Le nombre est inférieur ou égal à 10.");
        }

        //Exercice 2
        //Écrire une boucle for qui affiche tous les entiers pairs de 0 à 20.
        Console.WriteLine("|*************************Exercice #2*************************|");
        for (int i = 0; i <= 20; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }

        //Exercice 3
        //Objectif: combiner for, conditions et opérations arithmétiques.
        //Énoncé :
        //Écrire un programme qui calcule et affiche la somme de tous les nombres pairs entre 1 et 100 inclus;
        //Bonus : afficher aussi combien de nombres ont été additionnés.
        Console.WriteLine("|*************************Exercice #3*************************|");
        var iNombre = 0;
        var iResultat = 0;
        for (int i = 1; i <= 100; i++)
        {
            if (i % 2 == 0)
            {
                iResultat = iResultat + i;
                iNombre++;
            }
        }
        Console.WriteLine("La somme des nombres pairs entre 1 et 100 est : " + iResultat);
        Console.WriteLine("Le nombre de nombres pairs entre 1 et 100 est : " + iNombre);


        //Exercice 4
        //Objectif: exploiter while et conditions sur chaînes.
        //Énoncé :
        //Demander à l’utilisateur d’entrer du texte à répétition;
        //Tant qu’il ne tape pas STOP(majuscules), continuer à afficher la longueur de chaque phrase saisie;
        //Astuce: utiliser Console.ReadLine() et string.Length.
        Console.WriteLine("|*************************Exercice #4*************************|");
        var strValeur = "";
        do
        {
            Console.WriteLine("Compter le nombre de caractère entrée ou écrire STOP pour arrêter.");
            strValeur = Console.ReadLine();
            Console.WriteLine("Le nombre de caractère entrée est : " + strValeur?.Length);

        } while (strValeur?.Trim().ToUpper() != "STOP");


        //Exercice 5
        //Objectif: double boucle imbriquée(for dans for).
        //Énoncé :
        //Afficher la table de multiplication de 1 à 10 sous forme de tableau aligné;
        //Bonus: mettre en évidence les carrés parfaits(1, 4, 9, 16…).
        Console.WriteLine("|*************************Exercice #5*************************|");
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                if (i == j)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine($"{i} X {j} = {i * j}");
            }
        }
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}