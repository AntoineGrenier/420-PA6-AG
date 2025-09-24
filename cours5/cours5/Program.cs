using Microsoft.Data.SqlClient;

static class Program
{
    static void Main(string[] args)
    {
        string connStr = "Server=TOUR-ANTOINE;Database=MaBase;Trusted_Connection=True;TrustServerCertificate=true;";
        using (SqlConnection con = new SqlConnection(connStr))
        {
            con.Open();
            Console.WriteLine("Connexion réussie");
            var strQuery = "SELECT * FROM Clients";
            SqlCommand cmd = new SqlCommand(strQuery, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["Id"]}, Nom: {reader["Nom"]}, Email: {reader["Email"]}");
            }
        }

        //Exercice 1 – Connexion à la base
        //Objectif: Vérifier la connexion à SQL Server depuis C#.
        //Énoncé:
        //Créer une base MaBase dans SSMS;
        //Écrire un programme C# qui ouvrir une connexion et afficher "Connexion réussie" si tout fonctionne.
        Console.WriteLine("|*************************Exercice #1*************************|");
        var strConnectionString = "Server = {VOTRE_SERVEUR};Database = {VOTRE_BASE}; Trusted_Connection = True; TrustServerCertificate = true; ";
        using (SqlConnection connection = new SqlConnection(strConnectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connexion réussie");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur de connexion: {ex.Message}");
            }
        }

        //Exercice 2 – Lecture des données
        //Objectif : Lire et afficher des données avec SqlDataReader.
        //Énoncé :
        //Dans SSMS, créer une table Clients avec Id, Nom, Email et insérer quelques lignes;
        //Écrire un programme C# qui lit et afficher tous les clients.
        Console.WriteLine("|*************************Exercice #2*************************|");
        var strQuery2 = "SELECT * FROM Clients";
        using (SqlConnection connection = new SqlConnection(strConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(strQuery2, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["Id"]}, Nom: {reader["Nom"]}, Email: {reader["Email"]}");
            }
        }

        //Exercice 3 – Insertion de données
        //Objectif : Ajouter un enregistrement depuis C#.
        //Énoncé :
        //Demander à l’utilisateur un nom et un email;
        //Insérer ces données dans la table Clients avec SqlCommand et paramètres.
        Console.WriteLine("|*************************Exercice #3*************************|");

        //Exercice 4 – Mise à jour de données
        //Objectif : Modifier un enregistrement existant.
        //Énoncé:
        //Demander à l’utilisateur l’ID d’un client et un nouvel email;
        //Mettre à jour l’email dans la base;
        //Afficher un message confirmant la modification.
        Console.WriteLine("|*************************Exercice #4*************************|");

        //Exercice 5 – Suppression de données
        //Objectif : Supprimer un enregistrement.
        //Énoncé :
        //Demander à l’utilisateur l’ID d’un client à supprimer;
        //Le supprimer de la table Clients;
        //Afficher "Client supprimé" si la suppression est réussie.
        Console.WriteLine("|*************************Exercice #5*************************|");
    }
}
