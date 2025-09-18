static class Program
{
    static AutoResetEvent autoEvent = new AutoResetEvent(false);
    static ManualResetEvent manualEvent = new ManualResetEvent(false);
    static Mutex mutex = new Mutex();
    static Semaphore semaphore = new Semaphore(2, 2); // max 2 threads à la fois

    static void Main(string[] args)
    {
        Console.WriteLine("|*************************Exercice threads*************************|");
        Console.WriteLine("=== Démonstration AutoResetEvent ===");
        Thread t1 = new Thread(ThreadAutoReset);
        t1.Start();
        Thread.Sleep(1000);
        Console.WriteLine("Main : signal AutoResetEvent");
        autoEvent.Set(); // Libère un seul thread

        t1.Join();

        Console.WriteLine("\n=== Démonstration ManualResetEvent ===");
        Thread t2 = new Thread(ThreadManualReset);
        Thread t3 = new Thread(ThreadManualReset);
        t2.Start();
        t3.Start();
        Thread.Sleep(1000);
        Console.WriteLine("Main : signal ManualResetEvent");
        manualEvent.Set(); // Libère tous les threads en attente
        Thread.Sleep(1000);
        manualEvent.Reset(); // Rebloque

        t2.Join();
        t3.Join();

        Console.WriteLine("\n=== Démonstration Mutex ===");
        for (int i = 0; i < 3; i++)
        {
            new Thread(ThreadMutex).Start(i);
        }
        Thread.Sleep(3000);

        Console.WriteLine("\n=== Démonstration Semaphore ===");
        for (int i = 0; i < 5; i++)
        {
            new Thread(ThreadSemaphore).Start(i);
        }
        Thread.Sleep(4000);

        Console.WriteLine("\n=== Démonstration WaitAny / WaitAll ===");

        // ManualResetEvent : reste signalé jusqu'à Reset()
        ManualResetEvent e1 = new ManualResetEvent(false);
        ManualResetEvent e2 = new ManualResetEvent(false);

        new Thread(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("Thread 1 prêt");
            e1.Set(); // Signal persistant
        }).Start();

        new Thread(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("Thread 2 prêt");
            e2.Set(); // Signal persistant
        }).Start();

        Console.WriteLine("Main : attend qu'un des deux soit prêt (WaitAny)");
        int index = WaitHandle.WaitAny(new WaitHandle[] { e1, e2 });
        Console.WriteLine($"Main : événement {index + 1} déclenché");

        Console.WriteLine("Main : attend que les deux soient prêts (WaitAll)");
        WaitHandle.WaitAll(new WaitHandle[] { e1, e2 });
        Console.WriteLine("Main : les deux événements sont déclenchés");

        Console.WriteLine("\nFin de la démonstration.");


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

    /// <summary>
    /// Thread utilisant AutoResetEvent
    /// </summary>
    static void ThreadAutoReset()
    {
        Console.WriteLine("ThreadAutoReset : en attente du signal...");
        autoEvent.WaitOne();
        Console.WriteLine("ThreadAutoReset : signal reçu !");
    }

    /// <summary>
    /// Thread utilisant ManualResetEvent
    /// </summary>
    static void ThreadManualReset()
    {
        Console.WriteLine($"ThreadManualReset {Thread.CurrentThread.ManagedThreadId} : en attente...");
        manualEvent.WaitOne();
        Console.WriteLine($"ThreadManualReset {Thread.CurrentThread.ManagedThreadId} : signal reçu !");
    }

    /// <summary>
    /// Thread utilisant Mutex
    /// </summary>
    /// <param name="id"></param>
    static void ThreadMutex(object id)
    {
        Console.WriteLine($"Thread {id} : en attente du mutex...");
        mutex.WaitOne();
        Console.WriteLine($"Thread {id} : a le mutex");
        Thread.Sleep(1000);
        Console.WriteLine($"Thread {id} : libère le mutex");
        mutex.ReleaseMutex();
    }

    /// <summary>
    /// Thread utilisant Semaphore
    /// </summary>
    /// <param name="id"></param>
    static void ThreadSemaphore(object id)
    {
        Console.WriteLine($"Thread {id} : en attente du sémaphore...");
        semaphore.WaitOne();
        Console.WriteLine($"Thread {id} : dans la section critique");
        Thread.Sleep(1500);
        Console.WriteLine($"Thread {id} : libère le sémaphore");
        semaphore.Release();
    }

}
