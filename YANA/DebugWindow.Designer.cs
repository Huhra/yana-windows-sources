namespace YANA
{
    partial class DebugWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugWindow));
            this.webBrowserDebug = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserDebug
            // 
            this.webBrowserDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserDebug.Location = new System.Drawing.Point(0, 0);
            this.webBrowserDebug.Margin = new System.Windows.Forms.Padding(0);
            this.webBrowserDebug.MaximumSize = new System.Drawing.Size(520, 400);
            this.webBrowserDebug.Name = "webBrowserDebug";
            this.webBrowserDebug.Size = new System.Drawing.Size(504, 362);
            this.webBrowserDebug.TabIndex = 0;
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 362);
            this.Controls.Add(this.webBrowserDebug);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(520, 400);
            this.MinimumSize = new System.Drawing.Size(520, 400);
            this.Name = "DebugWindow";
            this.Text = "Yana : historique";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserDebug;
    }
}