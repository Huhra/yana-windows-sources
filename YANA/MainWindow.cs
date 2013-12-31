/**
 * Yana for Windows par Valentin CARRUESCO aka idleman <idleman@idleman.fr> 
 * Licence Creative Commons -by -sa -nc
 * Classe de gestion de la fenetre principale
**/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace YANA
{
    public partial class MainWindow : Form
    {
        private static MainWindow instance;

        private MainWindow()
        {
            InitializeComponent();

            this.Text = Program.PROGRAM_NAME + " V" + Program.PROGRAM_VERSION;
            webBrowserContent.Navigate("about:blank");
            String img = Function.getProjectPath() + "\\img";

            String html = @"<html><head><style>" + YANA.Properties.Resources.style + @"</style></head>
                <body>
                    <div class='header'>
                        <div class='logo'><img  src='" + img + @"\YANA.png'></div><h1 style='margin:10px 0 0 10px;'>Yana</h1><a href='http://blog.idleman.fr' target='_blank' id='configButton' class='configButton'><img border='0' title='A propos' style='margin:20px' src='" + img + @"\config.png'></a>
                    </div>
                    <div id='content' class='content'>
                        <img style='float:left;margin:30px 10px 0 10px;'  src='" + img + @"\ip_adress.png'>
                        <h1 style='float:left;margin-top:25px;'>" + Regex.Replace(Program.API_URL, "http://", "") + @"</h1>
                        <div style='clear:both;'></div>
                        <div id='messages'></div>
                    </div>
                     <div class='footer'>
                       <p>" + Program.PROGRAM_NAME + " V" + Program.PROGRAM_VERSION + @" By Idleman - CC by nc sa</p>
                    </div>
                </body>
            </html>";
            webBrowserContent.Document.Write(html);
        }



        public static MainWindow getInstance()
        {
            if (instance == null)
            {
                instance = new MainWindow();
            }
            return instance;
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            if (null!=TrayIcon.timer) TrayIcon.timer.Stop();
            Application.ExitThread();
            Application.Exit();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x112 && m.WParam.ToInt32() == 0xf020)
            {
                this.Hide();
                return;
            }
            base.WndProc(ref m);
        }

        public void addMessage(String message, bool send)
        {
            String img = Function.getProjectPath() + "\\img";
            try
            {
                if (send)
                {
                    webBrowserContent.Document.GetElementById("messages").InnerHtml += "<div class='messageContainer'><img class='messageResponse' src='" + img + "\\reponse.png'/>";
                    webBrowserContent.Document.GetElementById("messages").InnerHtml += "<div class='message'>" + message + "</div>";
                    webBrowserContent.Document.GetElementById("messages").InnerHtml += "<div style='clear:both;'></div></div>";
                }
                else
                {
                    webBrowserContent.Document.GetElementById("messages").InnerHtml += "<div class='messageContainer'>";
                    webBrowserContent.Document.GetElementById("messages").InnerHtml += "<img class='messageQuestion' style='float:right;margin:3px 0 0 0;' src='" + img + "\\envoi.png'/>";
                    webBrowserContent.Document.GetElementById("messages").InnerHtml += "<div class='message' style='background-color:#DEF1FA;margin:0px;float:right;'>" + message + "</div>";
                    webBrowserContent.Document.GetElementById("messages").InnerHtml += "<div style='clear:both;'></div></div>";
                }
                webBrowserContent.Document.GetElementById("messages").ScrollTop += webBrowserContent.Document.GetElementById("messages").ScrollRectangle.Height;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
