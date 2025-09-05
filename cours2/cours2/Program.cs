public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("|*************************Exercice #1*************************|");
        int nombre = 42;
        if(nombre > 10)
        {
            Console.WriteLine("Le nombre est supérieur à 10.");
        }
        else
        {
            Console.WriteLine("Le nombre est inférieur ou égal à 10.");
        }

        Console.WriteLine("|*************************Exercice #2*************************|");
        for(int i = 0; i <= 20; i++)
        {
            if(i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }

        Console.WriteLine("|*************************Exercice #3*************************|");
        var iNombre = 0;
        var iResultat = 0;
        for(int i = 1; i <= 100; i++)
        {
            if(i % 2 == 0)
            {
                iResultat = iResultat + i;
                iNombre++;
            }
        }
        Console.WriteLine("La somme des nombres pairs entre 1 et 100 est : " + iResultat);
        Console.WriteLine("Le nombre de nombres pairs entre 1 et 100 est : " + iNombre);

        Console.WriteLine("|*************************Exercice #4*************************|");
        var strValeur = "";
        do
        {
            Console.WriteLine("Compter le nombre de caractère entrée ou écrire STOP pour arrêter.");
            strValeur = Console.ReadLine();
            Console.WriteLine("Le nombre de caractère entrée est : " + strValeur?.Length);

        } while (strValeur?.Trim().ToUpper() != "STOP");

        Console.WriteLine("|*************************Exercice #5*************************|");
        for(int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                if(i == j)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine($"{i} X {j} = {i * j}");
            }
        }
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}