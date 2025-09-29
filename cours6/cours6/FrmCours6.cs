using cours6.Modele;
using cours6.Repository;
using Microsoft.Data.SqlClient;
using System.Data;

namespace cours6
{
    public partial class frmCours6 : Form
    {
        private ClientRepository _clientRepo;
        private CommandeRepository _commandeRepo;
        private string _strConnectionString = "Server = {VOTRE_SERVEUR};Database = {VOTRE_BASE}; Trusted_Connection = True; TrustServerCertificate = true; ";

        /// <summary>
        /// Constructeur du formulaire
        /// </summary>
        public frmCours6()
        {
            InitializeComponent();
            _clientRepo = new ClientRepository(_strConnectionString);
            _commandeRepo = new CommandeRepository(_strConnectionString);
            CreerTablesSiNonExistantes();
            RechargerDataGridClient();
        }

        /// <summary>
        /// Gestion de la fermeture du formulaire
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            SupprimerTables();
        }

        /// <summary>
        /// Insérer un client dans la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInserer_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = txtNom.Text;
                string email = txtEmail.Text;
                var client = new Client { Nom = nom, Email = email };

                if (_clientRepo.Inserer(client))
                {
                    var strMessage = "Client ajouté avec succès";
                    Console.WriteLine(strMessage);
                    MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RechargerDataGridClient();
                }
                else
                {
                    var strMessage = "Erreur lors de l'ajout du client";
                    Console.WriteLine(strMessage);
                    MessageBox.Show(strMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                var strMessage = $"Erreur : {ex.Message}";
                Console.WriteLine(strMessage);
                MessageBox.Show(strMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Supprimer un client de la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtId.Text, out int id))
                {
                    var strMessage = "L'ID doit être un nombre entier.";
                    Console.WriteLine(strMessage);
                    MessageBox.Show(strMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_clientRepo.Supprimer(id))
                {
                    var strMessage = "Client supprimé avec succès";
                    Console.WriteLine(strMessage);
                    MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RechargerDataGridClient();
                }
                else
                {
                    var strMessage = "Aucun client trouvé avec cet ID";
                    Console.WriteLine(strMessage);
                    MessageBox.Show(strMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                var strMessage = $"Erreur : {ex.Message}";
                Console.WriteLine(strMessage);
                MessageBox.Show(strMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mettre à jour un client dans la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtId.Text, out int id))
                {
                    var strMessage = "L'ID doit être un nombre entier.";
                    Console.WriteLine(strMessage);
                    MessageBox.Show(strMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string nom = txtNom.Text;
                string email = txtEmail.Text;
                var client = new Client { Id = id, Nom = nom, Email = email };

                if (_clientRepo.MaJ(client))
                {
                    var strMessage = "Client mis à jour avec succès";
                    Console.WriteLine(strMessage);
                    MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RechargerDataGridClient();
                }
                else
                {
                    var strMessage = "Aucun client trouvé avec cet ID";
                    Console.WriteLine(strMessage);
                    MessageBox.Show(strMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                var strMessage = $"Erreur : {ex.Message}";
                Console.WriteLine(strMessage);
                MessageBox.Show(strMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Recharger le DataGridView avec les données de la base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefraichir_Click(object sender, EventArgs e)
        {
            RechargerDataGridClient();
        }

        /// <summary>
        /// Recharger le DataGridView avec les données de la base
        /// </summary>
        private void RechargerDataGridClient()
        {
            try
            {
                dgvClients.DataSource = null;
                dgvClients.DataSource = _clientRepo.ObtenirTout();
            }
            catch (Exception ex)
            {
                var strMessage = $"Erreur lors du rechargement du DataGridView : {ex.Message}";
                Console.WriteLine(strMessage);
                MessageBox.Show(strMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Afficher les commandes du client sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null) return;
            if (dgvClients.CurrentRow.DataBoundItem is DataRowView clientView)
            {
                object idValue = clientView["Id"];
                if (idValue == DBNull.Value)
                    return;
                int clientId = Convert.ToInt32(idValue);
                dgvCommandes.DataSource = _commandeRepo.GetCommandesByClient(clientId);
            }
        }

        /// <summary>
        /// Créer les tables Clients et Commandes si elles n'existent pas
        /// </summary>
        private void CreerTablesSiNonExistantes()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_strConnectionString))
                {
                    connection.Open();

                    // Créer la table Clients si elle n'existe pas
                    string createClientsTable = @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Clients')
                BEGIN
                    CREATE TABLE Clients (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        Nom NVARCHAR(100) NOT NULL,
                        Email NVARCHAR(100) NOT NULL,
                        Solde DECIMAL(18,2) NOT NULL DEFAULT(0)
                    )
                END";
                    using (SqlCommand cmdClients = new SqlCommand(createClientsTable, connection))
                    {
                        cmdClients.ExecuteNonQuery();
                    }

                    // Créer la table Commandes si elle n'existe pas
                    string createCommandesTable = @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Commandes')
                BEGIN
                    CREATE TABLE Commandes (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        ClientId INT NOT NULL,
                        Montant DECIMAL(18,2) NOT NULL,
                        DateCommande DATETIME NOT NULL,
                        CONSTRAINT FK_Commandes_Clients FOREIGN KEY (ClientId)
                            REFERENCES Clients(Id) ON DELETE CASCADE
                    )
                END";
                    using (SqlCommand cmdCommandes = new SqlCommand(createCommandesTable, connection))
                    {
                        cmdCommandes.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                var strMessage = $"Erreur lors de la création des tables : {ex.Message}";
                Console.WriteLine(strMessage);
                MessageBox.Show(strMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Supprimer les tables Clients et Commandes
        /// </summary>
        private void SupprimerTables()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_strConnectionString))
                {
                    connection.Open();

                    // Supprimer la table Commandes si elle existe
                    string dropCommandesTable = @"
                IF OBJECT_ID('Commandes', 'U') IS NOT NULL
                BEGIN
                    DROP TABLE Commandes
                END";
                    using (SqlCommand cmdDropCommandes = new SqlCommand(dropCommandesTable, connection))
                    {
                        cmdDropCommandes.ExecuteNonQuery();
                    }

                    // Supprimer la table Clients si elle existe
                    string dropClientsTable = @"
                IF OBJECT_ID('Clients', 'U') IS NOT NULL
                BEGIN
                    DROP TABLE Clients
                END";
                    using (SqlCommand cmdDropClients = new SqlCommand(dropClientsTable, connection))
                    {
                        cmdDropClients.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                var strMessage = $"Erreur lors de la suppression des tables : {ex.Message}";
                Console.WriteLine(strMessage);
                MessageBox.Show(strMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Exercice 1 – Lecture filtrée avec paramètres(mode connecté)
        //• Objectif : Lire des données avec SqlDataReader en utilisant des paramètres sécurisés.
        //• Énoncé :
        //• Dans la table Clients, insérer plusieurs enregistrements avec différents courriels;
        //• Écrire un programme C# qui demande à l’utilisateur un domaine de courriel (ex. @gmail.com);
        //• Utiliser SqlCommand avec un paramètre pour sélectionner uniquement les clients correspondants;
        //• Afficher les résultats avec SqlDataReader.
        //• Bonne pratique : toujours utiliser SqlParameter pour éviter l’injection SQL.
        private void btnExercice1_Click(object sender, EventArgs e)
        {
            try
            {
                string domaine = txtDomaine.Text;

                if (string.IsNullOrWhiteSpace(domaine))
                {
                    var strMessage = "Le domaine de courriel ne peut pas être vide.";
                    Console.WriteLine(strMessage);
                    MessageBox.Show(strMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dt = _clientRepo.GetClientsByEmailDomain(domaine);

                if (dt.Rows.Count == 0)
                {
                    var strMessage = "Aucun client trouvé pour ce domaine.";
                    Console.WriteLine(strMessage);
                    MessageBox.Show(strMessage, "Résultat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvClients.DataSource = null;
                }
                else
                {
                    var strMessage = $"Clients filtrés trouvés: {dt.Rows.Count}";
                    Console.WriteLine(strMessage);
                    dgvClients.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                var strMessage = $"Erreur : {ex.Message}";
                Console.WriteLine(strMessage);
                MessageBox.Show(strMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Exercice 2 – Transaction(mode connecté)
        //• Objectif : Utiliser une transaction pour garantir la cohérence des données.
        //• Énoncé :
        //• Créer une table Commandes liée à Clients(clé étrangère);
        //• Écrire un programme C# qui :
        //• Ajouter une nouvelle commande pour un client donné;
        //• Mettre à jour le solde du client(champ à ajouter dans la table Clients);
        //• Utiliser une transaction pour que les deux opérations soient validées ensemble;
        //• Si une erreur survient, annuler les deux opérations;
        //• Bonne pratique : toujours encapsuler les opérations critiques dans une transaction.
        private void btnExercice2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voir l'exercice 2 dans le code source.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Exercice 3 – DataSet et DataAdapter(mode déconnecté)
        //• Objectif : Charger et manipuler des données en mémoire.
        //• Énoncé :
        //• Utiliser SqlDataAdapter pour remplir un DataSet avec la table Clients;
        //• Modifier en mémoire le nom d’un client;
        //• Ajouter un nouveau client dans le DataSet;
        //• Synchroniser les modifications avec la base (adapter.Update);
        //• Afficher la liste des clients après mise à jour.
        //• Bonne pratique : valider les données en mémoire avant de les synchroniser.
        private void btnExercice3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voir l'exercice 3 dans le code source.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Exercice 4 – Jointure et affichage(mode déconnecté)
        //• Objectif : Manipuler plusieurs tables dans un DataSet.
        //• Énoncé :
        //• Remplir un DataSet avec les tables Clients et Commandes;
        //• Créer une relation(DataRelation) entre les deux tables;
        //• Afficher pour chaque client la liste de ses commandes.
        //• Bonne pratique : utiliser les relations dans le DataSet pour éviter de refaire des requêtes multiples.
        private void btnExercice4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voir l'exercice 4 dans le code source.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
