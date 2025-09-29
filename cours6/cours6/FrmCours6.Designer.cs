namespace cours6
{
    partial class frmCours6
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnExercice1 = new Button();
            txtNom = new TextBox();
            lbNom = new Label();
            lbEmail = new Label();
            txtEmail = new TextBox();
            btnInserer = new Button();
            dgvClients = new DataGridView();
            lbId = new Label();
            txtId = new TextBox();
            btnSupprimer = new Button();
            btnMaj = new Button();
            btnRefraichir = new Button();
            lbDomaine = new Label();
            txtDomaine = new TextBox();
            btnExercice2 = new Button();
            lbMontantCommande = new Label();
            txtMontantCommande = new TextBox();
            btnExercice3 = new Button();
            btnExercice4 = new Button();
            dgvCommandes = new DataGridView();
            gbClient = new GroupBox();
            gbCommande = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCommandes).BeginInit();
            gbClient.SuspendLayout();
            gbCommande.SuspendLayout();
            SuspendLayout();
            // 
            // btnExercice1
            // 
            btnExercice1.Location = new Point(200, 297);
            btnExercice1.Name = "btnExercice1";
            btnExercice1.Size = new Size(100, 23);
            btnExercice1.TabIndex = 0;
            btnExercice1.Text = "Exercice #1";
            btnExercice1.UseVisualStyleBackColor = true;
            btnExercice1.Click += btnExercice1_Click;
            // 
            // txtNom
            // 
            txtNom.Location = new Point(58, 22);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(100, 23);
            txtNom.TabIndex = 1;
            // 
            // lbNom
            // 
            lbNom.AutoSize = true;
            lbNom.Location = new Point(12, 25);
            lbNom.Name = "lbNom";
            lbNom.Size = new Size(40, 15);
            lbNom.TabIndex = 2;
            lbNom.Text = "Nom :";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(10, 54);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(42, 15);
            lbEmail.TabIndex = 3;
            lbEmail.Text = "Email :";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(58, 51);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 4;
            // 
            // btnInserer
            // 
            btnInserer.Location = new Point(270, 22);
            btnInserer.Name = "btnInserer";
            btnInserer.Size = new Size(75, 23);
            btnInserer.TabIndex = 5;
            btnInserer.Text = "Insérer";
            btnInserer.UseVisualStyleBackColor = true;
            btnInserer.Click += btnInserer_Click;
            // 
            // dgvClients
            // 
            dgvClients.BackgroundColor = Color.White;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Font = new Font("Segoe UI", 9F);
            dgvClients.Location = new Point(10, 130);
            dgvClients.Name = "dgvClients";
            dgvClients.Size = new Size(449, 150);
            dgvClients.TabIndex = 6;
            dgvClients.SelectionChanged += dgvClients_SelectionChanged;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Location = new Point(170, 25);
            lbId.Name = "lbId";
            lbId.Size = new Size(23, 15);
            lbId.TabIndex = 8;
            lbId.Text = "Id :";
            // 
            // txtId
            // 
            txtId.Location = new Point(199, 22);
            txtId.Name = "txtId";
            txtId.Size = new Size(60, 23);
            txtId.TabIndex = 7;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Location = new Point(199, 51);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(65, 23);
            btnSupprimer.TabIndex = 9;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // btnMaj
            // 
            btnMaj.Location = new Point(270, 51);
            btnMaj.Name = "btnMaj";
            btnMaj.Size = new Size(75, 23);
            btnMaj.TabIndex = 10;
            btnMaj.Text = "MaJ";
            btnMaj.UseVisualStyleBackColor = true;
            btnMaj.Click += btnMaj_Click;
            // 
            // btnRefraichir
            // 
            btnRefraichir.Location = new Point(270, 80);
            btnRefraichir.Name = "btnRefraichir";
            btnRefraichir.Size = new Size(75, 23);
            btnRefraichir.TabIndex = 11;
            btnRefraichir.Text = "Rafraîchir";
            btnRefraichir.UseVisualStyleBackColor = true;
            btnRefraichir.Click += btnRefraichir_Click;
            // 
            // lbDomaine
            // 
            lbDomaine.AutoSize = true;
            lbDomaine.Location = new Point(10, 300);
            lbDomaine.Name = "lbDomaine";
            lbDomaine.Size = new Size(61, 15);
            lbDomaine.TabIndex = 13;
            lbDomaine.Text = "Domaine :";
            // 
            // txtDomaine
            // 
            txtDomaine.Location = new Point(79, 297);
            txtDomaine.Name = "txtDomaine";
            txtDomaine.Size = new Size(100, 23);
            txtDomaine.TabIndex = 12;
            // 
            // btnExercice2
            // 
            btnExercice2.Location = new Point(250, 21);
            btnExercice2.Name = "btnExercice2";
            btnExercice2.Size = new Size(134, 48);
            btnExercice2.TabIndex = 14;
            btnExercice2.Text = "Ajouter commande (Exercice #2)";
            btnExercice2.UseVisualStyleBackColor = true;
            btnExercice2.Click += btnExercice2_Click;
            // 
            // lbMontantCommande
            // 
            lbMontantCommande.AutoSize = true;
            lbMontantCommande.Location = new Point(12, 25);
            lbMontantCommande.Name = "lbMontantCommande";
            lbMontantCommande.Size = new Size(126, 15);
            lbMontantCommande.TabIndex = 16;
            lbMontantCommande.Text = "Montant commande : ";
            // 
            // txtMontantCommande
            // 
            txtMontantCommande.Location = new Point(144, 22);
            txtMontantCommande.Name = "txtMontantCommande";
            txtMontantCommande.Size = new Size(100, 23);
            txtMontantCommande.TabIndex = 15;
            // 
            // btnExercice3
            // 
            btnExercice3.Location = new Point(310, 297);
            btnExercice3.Name = "btnExercice3";
            btnExercice3.Size = new Size(100, 23);
            btnExercice3.TabIndex = 17;
            btnExercice3.Text = "Exercice #3";
            btnExercice3.UseVisualStyleBackColor = true;
            btnExercice3.Click += btnExercice3_Click;
            // 
            // btnExercice4
            // 
            btnExercice4.Location = new Point(420, 297);
            btnExercice4.Name = "btnExercice4";
            btnExercice4.Size = new Size(100, 23);
            btnExercice4.TabIndex = 18;
            btnExercice4.Text = "Exercice #4";
            btnExercice4.UseVisualStyleBackColor = true;
            btnExercice4.Click += btnExercice4_Click;
            // 
            // dgvCommandes
            // 
            dgvCommandes.BackgroundColor = Color.White;
            dgvCommandes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCommandes.Font = new Font("Segoe UI", 9F);
            dgvCommandes.Location = new Point(465, 130);
            dgvCommandes.Name = "dgvCommandes";
            dgvCommandes.Size = new Size(390, 150);
            dgvCommandes.TabIndex = 19;
            // 
            // gbClient
            // 
            gbClient.BackColor = Color.WhiteSmoke;
            gbClient.Controls.Add(lbNom);
            gbClient.Controls.Add(txtNom);
            gbClient.Controls.Add(lbEmail);
            gbClient.Controls.Add(txtEmail);
            gbClient.Controls.Add(lbId);
            gbClient.Controls.Add(txtId);
            gbClient.Controls.Add(btnInserer);
            gbClient.Controls.Add(btnMaj);
            gbClient.Controls.Add(btnSupprimer);
            gbClient.Controls.Add(btnRefraichir);
            gbClient.Location = new Point(10, 10);
            gbClient.Name = "gbClient";
            gbClient.Size = new Size(449, 110);
            gbClient.TabIndex = 0;
            gbClient.TabStop = false;
            gbClient.Text = "Gestion des Clients";
            // 
            // gbCommande
            // 
            gbCommande.BackColor = Color.WhiteSmoke;
            gbCommande.Controls.Add(lbMontantCommande);
            gbCommande.Controls.Add(txtMontantCommande);
            gbCommande.Controls.Add(btnExercice2);
            gbCommande.Location = new Point(465, 10);
            gbCommande.Name = "gbCommande";
            gbCommande.Size = new Size(390, 110);
            gbCommande.TabIndex = 7;
            gbCommande.TabStop = false;
            gbCommande.Text = "Commandes du Client sélectionné";
            // 
            // frmCours6
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(868, 350);
            Controls.Add(gbClient);
            Controls.Add(dgvClients);
            Controls.Add(gbCommande);
            Controls.Add(dgvCommandes);
            Controls.Add(lbDomaine);
            Controls.Add(txtDomaine);
            Controls.Add(btnExercice1);
            Controls.Add(btnExercice3);
            Controls.Add(btnExercice4);
            Name = "frmCours6";
            Text = "Cours #6 - Gestion Clients & Commandes";
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCommandes).EndInit();
            gbClient.ResumeLayout(false);
            gbClient.PerformLayout();
            gbCommande.ResumeLayout(false);
            gbCommande.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExercice1;
        private TextBox txtNom;
        private Label lbNom;
        private Label lbEmail;
        private TextBox txtEmail;
        private Button btnInserer;
        private DataGridView dgvClients;
        private Label lbId;
        private TextBox txtId;
        private Button btnSupprimer;
        private Button btnMaj;
        private Button btnRefraichir;
        private Label lbDomaine;
        private TextBox txtDomaine;
        private Button btnExercice2;
        private Label lbMontantCommande;
        private TextBox txtMontantCommande;
        private Button btnExercice3;
        private Button btnExercice4;
        private DataGridView dgvCommandes;
        private GroupBox gbClient;
        private GroupBox gbCommande;
    }
}
