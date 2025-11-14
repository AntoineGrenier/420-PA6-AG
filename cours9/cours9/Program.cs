using cours9.Modele.Entity;
using cours9.Presentation.Service;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //Exercice 1 – Interface de base pour entité
        //Objectif: Définir une interface simple pour représenter une entité avec un identifiant.
        //Énoncé :
        //Créer une interface IEntity avec une propriété int Id;
        //Implémenter cette interface dans une classe Client contenant les propriétés Id, Nom, Email;
        //Instancier quelques objets Client et afficher leurs informations dans la console;
        //Bonne pratique : utiliser une interface pour uniformiser l’accès aux identifiants dans les entités.
        Console.WriteLine("|*************************Exercice #1*************************|");
        var listeClients = new List<Client>
        {
            new Client { Id = 1, Email = "email1@email.com", Nom = "Nom1" },
            new Client { Id = 2, Email = "email2@email.com", Nom = "Nom2" },
            new Client { Id = 3, Email = "email3@email.com", Nom = "Nom3" }
        };

        foreach (var clientObj in listeClients)
        {
            Console.WriteLine($"Id = {clientObj.Id}, Nom = {clientObj.Nom}, Email = {clientObj.Email}");
        }

        //Exercice 2 – Séparation Présentation / Logique
        //Objectif : Introduire la séparation entre la couche présentation et la logique métier.
        //Énoncé :
        //Créer une classe ClientService avec une méthode GetClientInfo(Client c) qui retourne une chaîne formatée "Nom : X, Email : Y ";
        //Dans la méthode Main, instancier un Client, appeler ClientService.GetClientInfo et afficher le résultat;
        //Bonne pratique : la logique de formatage et de validation doit être centralisée dans la couche métier, pas dans l’UI.
        Console.WriteLine("|*************************Exercice #2*************************|");
        var clientService = new ClientService();
        foreach (var clientObj in listeClients)
        {
            Console.WriteLine(clientService.GetClientInfo(clientObj));
        }

        //Exercice 3 – Couche Données avec Repository
        //Objectif : Introduire la couche d’accès aux données.
        //Énoncé :
        //Créer une classe ClientRepository avec une méthode GetAllClients() qui retourne une liste de Client;
        //Simuler une base de données avec une liste en mémoire;
        //Dans ClientService, ajouter une méthode ListClients() qui appelle le repository;
        //Afficher la liste des clients dans la console.
        //Bonne pratique : utiliser le pattern Repository pour isoler l’accès aux données.
        Console.WriteLine("|*************************Exercice #3*************************|");
        var clients = clientService.ListClients();
        foreach (var clientObj in clients)
        {
            Console.WriteLine(clientService.GetClientInfo(clientObj));
        }

        //Exercice 4 – Architecture 3 couches complète
        //Objectif: Mettre en place les 3 couches(Présentation, Logique, Données).
        //Énoncé :
        //Couche Données : ClientRepository avec méthodes AddClient, GetClientById.
        //Couche Logique : ClientService avec règles métiers(ex.refuser un client sans email).
        //Couche Présentation : programme console qui demande à l’utilisateur de saisir un client, puis l’ajoute via ClientService.
        //Bonne pratique : chaque couche doit avoir une responsabilité unique et ne pas dépendre directement des autres.
        Console.WriteLine("|*************************Exercice #4*************************|");
        Console.WriteLine("Nom client");
        var strNom = Console.ReadLine();
        Console.WriteLine("Email client");
        var strEmail = Console.ReadLine();
        var client = new Client { Email = strEmail, Nom = strNom };
        try
        {
            clientService.AddClient(client);
            clients = clientService.ListClients();
            foreach (var clientObj in clients)
            {
                Console.WriteLine(clientService.GetClientInfo(clientObj));
            }

            var clientById = clientService.GetClientById(3);
            Console.WriteLine(clientService.GetClientInfo(clientById));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }


        //Exercice 5 – Passage au multicouches(simulation distribuée)
        //Objectif: Simuler une architecture multicouches avec appels séparés.
        //Énoncé :
        //Créer une API REST(par ex. en ASP.NET Core) exposant les opérations GET / clients et POST / clients;
        //La couche Présentation = client console qui appelle l’API via HttpClient;
        //La couche Logique = contrôleur + service qui valide les règles métiers;
        //La couche Données = repository connecté à une base SQLite ou en mémoire.
        //Bonne pratique : séparer physiquement les couches(client ↔ API ↔ DB) pour illustrer la scalabilité et la sécurité.
        Console.WriteLine("|*************************Exercice #5*************************|");
        //À faire
    }
}