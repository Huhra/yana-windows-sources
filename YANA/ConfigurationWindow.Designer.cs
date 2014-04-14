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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationWindow));
            this.textAPI_URL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkLAUNCH_AT_STARTUP = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textTOKEN = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textREQUEST_TIMEOUT = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboCHECK_INTERVAL = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.comboSELECTED_VOICE = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboVOICE_EMPHASIS = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboVOICE_VOLUME = new System.Windows.Forms.ComboBox();
            this.comboVOICE_SPEED = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textAPI_URL
            // 
            this.textAPI_URL.Location = new System.Drawing.Point(13, 46);
            this.textAPI_URL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Interval entre chaques vérification d\'évènements";
            // 
            // checkLAUNCH_AT_STARTUP
            // 
            this.checkLAUNCH_AT_STARTUP.AutoSize = true;
            this.checkLAUNCH_AT_STARTUP.Location = new System.Drawing.Point(12, 140);
            this.checkLAUNCH_AT_STARTUP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkLAUNCH_AT_STARTUP.Name = "checkLAUNCH_AT_STARTUP";
            this.checkLAUNCH_AT_STARTUP.Size = new System.Drawing.Size(180, 21);
            this.checkLAUNCH_AT_STARTUP.TabIndex = 6;
            this.checkLAUNCH_AT_STARTUP.Text = "Démarrer avec windows";
            this.checkLAUNCH_AT_STARTUP.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Token d\'identification";
            // 
            // textTOKEN
            // 
            this.textTOKEN.Location = new System.Drawing.Point(12, 136);
            this.textTOKEN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textTOKEN.Name = "textTOKEN";
            this.textTOKEN.Size = new System.Drawing.Size(375, 22);
            this.textTOKEN.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 432);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 34);
            this.button1.TabIndex = 9;
            this.button1.Text = "Enregistrer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textAPI_URL);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textTOKEN);
            this.groupBox1.Location = new System.Drawing.Point(11, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(401, 192);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection et authentification";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(13, 167);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(372, 26);
            this.label11.TabIndex = 10;
            this.label11.Text = "Numéro fournis sur la page d\'accueil de votre yana server";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(13, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(372, 41);
            this.label10.TabIndex = 9;
            this.label10.Text = "Adresse entiere (avec http://) suivis de action.php, exemple : http://127.0.0.1/y" +
                "ana-server/action.php";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.textREQUEST_TIMEOUT);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.comboCHECK_INTERVAL);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.checkLAUNCH_AT_STARTUP);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(11, 202);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(401, 186);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Avancé";
            // 
            // textREQUEST_TIMEOUT
            // 
            this.textREQUEST_TIMEOUT.Location = new System.Drawing.Point(12, 101);
            this.textREQUEST_TIMEOUT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textREQUEST_TIMEOUT.Name = "textREQUEST_TIMEOUT";
            this.textREQUEST_TIMEOUT.Size = new System.Drawing.Size(56, 22);
            this.textREQUEST_TIMEOUT.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(73, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 17);
            this.label12.TabIndex = 9;
            this.label12.Text = "milli secondes";
            this.label12.Click += new System.EventHandler(this.label12_Click);
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
            this.comboCHECK_INTERVAL.Location = new System.Drawing.Point(15, 44);
            this.comboCHECK_INTERVAL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboCHECK_INTERVAL.Name = "comboCHECK_INTERVAL";
            this.comboCHECK_INTERVAL.Size = new System.Drawing.Size(53, 24);
            this.comboCHECK_INTERVAL.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "secondes entre chaques requetes";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(432, 426);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(424, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Général";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.comboSELECTED_VOICE);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(424, 397);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Voix";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(11, 331);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(399, 52);
            this.label9.TabIndex = 14;
            this.label9.Text = "Nb: les réglages des plugins YANA son prioritaires sur les réglages ci dessus. Ce" +
                "ux ci ne sont pris en compte que lorsque le plugin ne spécifie pas de valeur pré" +
                "cise.";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // comboSELECTED_VOICE
            // 
            this.comboSELECTED_VOICE.FormattingEnabled = true;
            this.comboSELECTED_VOICE.Location = new System.Drawing.Point(27, 46);
            this.comboSELECTED_VOICE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboSELECTED_VOICE.Name = "comboSELECTED_VOICE";
            this.comboSELECTED_VOICE.Size = new System.Drawing.Size(379, 24);
            this.comboSELECTED_VOICE.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Voix windows utilisée";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboVOICE_EMPHASIS);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.comboVOICE_VOLUME);
            this.groupBox3.Controls.Add(this.comboVOICE_SPEED);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(9, 89);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(401, 236);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Réglage Voix";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // comboVOICE_EMPHASIS
            // 
            this.comboVOICE_EMPHASIS.FormattingEnabled = true;
            this.comboVOICE_EMPHASIS.Location = new System.Drawing.Point(16, 188);
            this.comboVOICE_EMPHASIS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboVOICE_EMPHASIS.Name = "comboVOICE_EMPHASIS";
            this.comboVOICE_EMPHASIS.Size = new System.Drawing.Size(364, 24);
            this.comboVOICE_EMPHASIS.TabIndex = 13;
            this.comboVOICE_EMPHASIS.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Emphase";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // comboVOICE_VOLUME
            // 
            this.comboVOICE_VOLUME.FormattingEnabled = true;
            this.comboVOICE_VOLUME.Location = new System.Drawing.Point(16, 117);
            this.comboVOICE_VOLUME.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboVOICE_VOLUME.Name = "comboVOICE_VOLUME";
            this.comboVOICE_VOLUME.Size = new System.Drawing.Size(364, 24);
            this.comboVOICE_VOLUME.TabIndex = 11;
            // 
            // comboVOICE_SPEED
            // 
            this.comboVOICE_SPEED.FormattingEnabled = true;
            this.comboVOICE_SPEED.Location = new System.Drawing.Point(16, 49);
            this.comboVOICE_SPEED.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboVOICE_SPEED.Name = "comboVOICE_SPEED";
            this.comboVOICE_SPEED.Size = new System.Drawing.Size(364, 24);
            this.comboVOICE_SPEED.TabIndex = 10;
            this.comboVOICE_SPEED.SelectedIndexChanged += new System.EventHandler(this.comboVOICE_SPEED_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Rapidité";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Volume";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(302, 17);
            this.label13.TabIndex = 11;
            this.label13.Text = "Délais d\'attente avant le timeout d\'une requete";
            // 
            // ConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 479);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ConfigurationWindow";
            this.Text = "ConfigurationWindow";
            this.Load += new System.EventHandler(this.ConfigurationWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textAPI_URL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkLAUNCH_AT_STARTUP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textTOKEN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboCHECK_INTERVAL;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboVOICE_VOLUME;
        private System.Windows.Forms.ComboBox comboVOICE_SPEED;
        private System.Windows.Forms.ComboBox comboVOICE_EMPHASIS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboSELECTED_VOICE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textREQUEST_TIMEOUT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}