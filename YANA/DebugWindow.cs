/**
 * Yana for Windows par Valentin CARRUESCO aka idleman <idleman@idleman.fr> 
 * Licence Creative Commons -by -sa -nc
 * Classe de gestion de la fenetre de debug
**/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YANA
{
    public partial class DebugWindow : Form
    {
        private static DebugWindow instance;


        private DebugWindow()
        {
            InitializeComponent();
            this.webBrowserDebug.ScrollBarsEnabled = false;
            this.Text = Program.PROGRAM_NAME + " V" + Program.PROGRAM_VERSION + " : Historique";
            Size = new Size(580, 350);

            string head = @"<html style='height:100%;'>
                                <head>
                                    <style>" + YANA.Properties.Resources.style + @"</style>
                                </head>
                                <body  style='height:100%;'>
                                    <div id='logBox'>
                                        <ul id='logList'></ul>
                                    </div>
                                </body>
                            </html>";

            webBrowserDebug.Navigate("about:blank");
            webBrowserDebug.Document.Write(head);

        }

        public static void message(string message)
        {

            DebugWindow debug = DebugWindow.getInstance();
            try
            {
                debug.Invoke((MethodInvoker)delegate
                {
                    message = "<li>" + message + "<div class='clear'></div></li>";
                    debug.webBrowserDebug.Document.GetElementById("logList").InnerHtml += message;
                    debug.webBrowserDebug.Document.GetElementById("logBox").ScrollTop += debug.webBrowserDebug.Document.GetElementById("logBox").ScrollRectangle.Height;
                });
            }
            catch (Exception e)
            {
                Function.error(e);
            }

        }
        public static DebugWindow getInstance()
        {
            if (instance == null)
            {
                instance = new DebugWindow();
            }
            return instance;
        }

        private void DebugWindow_Load(object sender, EventArgs e)
        {

        }




    }
}
