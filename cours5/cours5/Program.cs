using Microsoft.Data.SqlClient;

static class Program
{
    static void Main(string[] args)
    {
        var strConnectionString = "Server = {VOTRE_SERVEUR};Database = {VOTRE_BASE}; Trusted_Connection = True; TrustServerCertificate = true; ";
        using (SqlConnection con = new SqlConnection(strConnectionString))
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
        Console.Write("Entrez le nom du client: ");
        string nom = Console.ReadLine();
        Console.Write("Entrez l'email du client: ");
        string email = Console.ReadLine();
        var strInsert = "INSERT INTO Clients (Nom, Email) VALUES (@Nom, @Email)";
        using (SqlConnection connection = new SqlConnection(strConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(strInsert, connection);
            command.Parameters.AddWithValue("@Nom", nom);
            command.Parameters.AddWithValue("@Email", email);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Client ajouté avec succès");
            }
            else
            {
                Console.WriteLine("Erreur lors de l'ajout du client");
            }
        }

        //Exercice 4 – Mise à jour de données
        //Objectif : Modifier un enregistrement existant.
        //Énoncé:
        //Demander à l’utilisateur l’ID d’un client et un nouvel email;
        //Mettre à jour l’email dans la base;
        //Afficher un message confirmant la modification.
        Console.WriteLine("|*************************Exercice #4*************************|");
        Console.Write("Entrez l'ID du client à mettre à jour: ");
        int idToUpdate = int.Parse(Console.ReadLine());
        Console.Write("Entrez le nouvel email du client: ");
        string newEmail = Console.ReadLine();
        var strUpdate = "UPDATE Clients SET Email = @Email WHERE Id = @Id";
        using (SqlConnection connection = new SqlConnection(strConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(strUpdate, connection);
            command.Parameters.AddWithValue("@Email", newEmail);
            command.Parameters.AddWithValue("@Id", idToUpdate);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Client mis à jour avec succès");
            }
            else
            {
                Console.WriteLine("Erreur lors de la mise à jour du client");
            }
        }

        //Exercice 5 – Suppression de données
        //Objectif : Supprimer un enregistrement.
        //Énoncé :
        //Demander à l’utilisateur l’ID d’un client à supprimer;
        //Le supprimer de la table Clients;
        //Afficher "Client supprimé" si la suppression est réussie.
        Console.WriteLine("|*************************Exercice #5*************************|");
        Console.Write("Entrez l'ID du client à supprimer: ");
        int idToDelete = int.Parse(Console.ReadLine());
        var strDelete = "DELETE FROM Clients WHERE Id = @Id";
        using (SqlConnection connection = new SqlConnection(strConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(strDelete, connection);
            command.Parameters.AddWithValue("@Id", idToDelete);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Client supprimé avec succès");
            }
            else
            {
                Console.WriteLine("Erreur lors de la suppression du client");
            }
        }
    }
}
