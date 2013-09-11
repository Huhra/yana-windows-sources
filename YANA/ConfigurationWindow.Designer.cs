namespace YANA
{
    partial class ConfigurationWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.textAPI_URL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkLAUNCH_AT_STARTUP = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textTOKEN = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboSELECTED_VOICE = new System.Windows.Forms.ComboBox();
            this.comboCHECK_INTERVAL = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textAPI_URL
            // 
            this.textAPI_URL.Location = new System.Drawing.Point(13, 46);
            this.textAPI_URL.Name = "textAPI_URL";
            this.textAPI_URL.Size = new System.Drawing.Size(375, 22);
            this.textAPI_URL.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adresse du serveur Y.A.N.A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Voix windows utilisée";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Interval entre chaques vérification d\'évènements";
            // 
            // checkLAUNCH_AT_STARTUP
            // 
            this.checkLAUNCH_AT_STARTUP.AutoSize = true;
            this.checkLAUNCH_AT_STARTUP.Location = new System.Drawing.Point(13, 158);
            this.checkLAUNCH_AT_STARTUP.Name = "checkLAUNCH_AT_STARTUP";
            this.checkLAUNCH_AT_STARTUP.Size = new System.Drawing.Size(180, 21);
            this.checkLAUNCH_AT_STARTUP.TabIndex = 6;
            this.checkLAUNCH_AT_STARTUP.Text = "Démarrer avec windows";
            this.checkLAUNCH_AT_STARTUP.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Token d\'identification";
            // 
            // textTOKEN
            // 
            this.textTOKEN.Location = new System.Drawing.Point(13, 110);
            this.textTOKEN.Name = "textTOKEN";
            this.textTOKEN.Size = new System.Drawing.Size(375, 22);
            this.textTOKEN.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 432);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 35);
            this.button1.TabIndex = 9;
            this.button1.Text = "Enregistrer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textAPI_URL);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textTOKEN);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 154);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection et authentification";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboSELECTED_VOICE);
            this.groupBox2.Controls.Add(this.comboCHECK_INTERVAL);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.checkLAUNCH_AT_STARTUP);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 226);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Avancé";
            // 
            // comboSELECTED_VOICE
            // 
            this.comboSELECTED_VOICE.FormattingEnabled = true;
            this.comboSELECTED_VOICE.Location = new System.Drawing.Point(16, 58);
            this.comboSELECTED_VOICE.Name = "comboSELECTED_VOICE";
            this.comboSELECTED_VOICE.Size = new System.Drawing.Size(379, 24);
            this.comboSELECTED_VOICE.TabIndex = 9;
            // 
            // comboCHECK_INTERVAL
            // 
            this.comboCHECK_INTERVAL.FormattingEnabled = true;
            this.comboCHECK_INTERVAL.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22"});
            this.comboCHECK_INTERVAL.Location = new System.Drawing.Point(13, 116);
            this.comboCHECK_INTERVAL.Name = "comboCHECK_INTERVAL";
            this.comboCHECK_INTERVAL.Size = new System.Drawing.Size(53, 24);
            this.comboCHECK_INTERVAL.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "secondes entre chaques requetes";
            // 
            // ConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 479);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "ConfigurationWindow";
            this.Text = "ConfigurationWindow";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textAPI_URL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkLAUNCH_AT_STARTUP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textTOKEN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboCHECK_INTERVAL;
        private System.Windows.Forms.ComboBox comboSELECTED_VOICE;
    }
}