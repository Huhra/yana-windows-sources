/**
 * Yana for Windows par Valentin CARRUESCO aka idleman <idleman@idleman.fr> 
 * Licence Creative Commons -by -sa -nc
 * Classe de coeur du programe, gère l'icone de la barre de tâche, lance les timers, initialise les fenetres
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Net;

namespace YANA
{
    class TrayIcon
    {
        private static TrayIcon instance;
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        public static Timer timer;
        private TrayIcon()
        {
            Configuration config = Configuration.getInstance();
            try
            {
                Function.log("Chargement des configurations...");

                //Récuperation des valeurs de configuration et stockage dans les variables globales de configuration
                Program.CHECK_INTERVAL = int.Parse(config.get("CHECK_INTERVAL"));
                Program.API_URL = config.get("API_URL");
                Program.SELECTED_VOICE = config.get("SELECTED_VOICE");
                Program.VOICE_EMPHASIS = int.Parse(config.get("VOICE_EMPHASIS"));
                Program.VOICE_SPEED = int.Parse(config.get("VOICE_SPEED"));
                Program.REQUEST_TIMEOUT = int.Parse(config.get("REQUEST_TIMEOUT"));
                Program.VOICE_VOLUME = int.Parse(config.get("VOICE_VOLUME"));
                Program.EVENT_ACTION = config.get("EVENT_ACTION");
                Program.COMMAND_ACTION = config.get("COMMAND_ACTION");
                Program.TOKEN = config.get("TOKEN");
                Program.LAUNCH_AT_STARTUP = (config.get("LAUNCH_AT_STARTUP") == "1" ? true : false);
            }
            catch (Exception e)
            {
                Function.error(e);
            }




            //Instanciation du tray icon et de son menu
            trayMenu = new ContextMenu();
            trayIcon = new NotifyIcon();
            //Ajout d'une image personnalisée sur le tray icon
            trayIcon.Icon = new Icon(Function.getProjectPath() + "YANA.ico", 256, 256);
            //Définition du titre au survol du tray icon
            trayIcon.Text = Program.PROGRAM_NAME;
            //Ajout d'un evenement au clic simple du tray icon
            trayIcon.Click += new EventHandler(onTrayClick);
            //Ajout de sitems au menu
            trayMenu.MenuItems.Add("Configuration", this.onConfig);
            trayMenu.MenuItems.Add("Historique", this.onHistory);
            trayMenu.MenuItems.Add("Quitter", this.onExit);
            //Liaison tray icon/menu
            trayIcon.ContextMenu = trayMenu;


            DebugWindow debug = DebugWindow.getInstance();
            MainWindow mainWindow = MainWindow.getInstance();
            mainWindow.Show();
            /**/
            try
            {
                mainWindow.addMessage("Salut!! :)", true);

                //Récuperation des valeurs de configuration et stockage dans les variables globales de configuration
                Program.CHECK_INTERVAL = int.Parse(config.get("CHECK_INTERVAL"));
                Program.API_URL = config.get("API_URL");
                Program.SELECTED_VOICE = config.get("SELECTED_VOICE");
                Program.VOICE_EMPHASIS = int.Parse(config.get("VOICE_EMPHASIS"));
                Program.VOICE_SPEED = int.Parse(config.get("VOICE_SPEED"));
                Program.VOICE_VOLUME = int.Parse(config.get("VOICE_VOLUME"));
                Program.EVENT_ACTION = config.get("EVENT_ACTION");
                Program.COMMAND_ACTION = config.get("COMMAND_ACTION");
                Program.LAUNCH_AT_STARTUP = (config.get("LAUNCH_AT_STARTUP") == "1" ? true : false);
                Program.REQUEST_TIMEOUT = int.Parse(config.get("REQUEST_TIMEOUT"));

                //Lancement au démarrage si la configuration LAUNCH_AT_STARTUP est à "1"
                try
                {
                    Function.launchAtStartup(Program.LAUNCH_AT_STARTUP);
                }
                catch (Exception e1)
                {
                    Function.error(e1);
                    Function.error("Le programme ne se lancera pas au démarrage");
                }

                //Récapitulatif des informations au lancement
                Function.log("Url API : " + Program.API_URL);
                Function.log("Interval de vérification : " + Program.CHECK_INTERVAL + " secondes");
                Function.log("Dossier son : " + Program.SOUND_DIR);
                Function.log("Lancement au démarrage : " + Program.LAUNCH_AT_STARTUP);
                Function.log("Fichier d'erreur : " + Program.ERROR_FILE);
                Function.log("Voix utilisée : " + Program.SELECTED_VOICE);
                Function.log("Voix - emphase : " + Program.VOICE_EMPHASIS);
                Function.log("Voix - volume : " + Program.VOICE_VOLUME);
                Function.log("Voix - vitesse : " + Program.VOICE_SPEED);
                Function.log("Requete - timeout : " + Program.REQUEST_TIMEOUT+" ms");



                //Récuperation des commandes vocales à reconnaitre sur le serveur distant
                try
                {
                    Function.log("Récuperation des configurations distantes..." + Program.API_URL + Program.COMMAND_ACTION);
                    //Envois de la requete sur l'url serveur avec l'action de récuperation des commandes
                    Http.get(Program.API_URL + Program.COMMAND_ACTION + "&token=" + Program.TOKEN, new AsyncCallback(receive));
                }
                catch (Exception e2)
                {
                    Function.error(e2);
                    Function.error("La reconnaissance vocale ne fonctionnera pas");
                    mainWindow.addMessage(Program.MSG_NO_SERVER_CONNEXION, true);
                }

                //Lancement d'une requete d'écoute des nouveau evenements toutes les x secondes (parametre CHECK_INTERVAL)
                //Et synthése vocale OU execution commande OU lancement d'un bruitage en fonction de la réponse
                try
                {
                    Function.log("Initialisation du timer");

                    timer = new Timer();
                    timer.Tick += new EventHandler(timing);
                    timer.Interval = (1000) * Program.CHECK_INTERVAL;
                    timer.Start();
                    Function.log("Lancement du timer dans " + Program.CHECK_INTERVAL + " secondes");
                    //GC.KeepAlive(timer);
                    mainWindow.addMessage("Je peux maintenant parler :)", true);
                }
                catch (Exception e3)
                {
                    Function.error(e3);
                    Function.error("L'écoute d'évenements n'aura pas lieu");
                    mainWindow.addMessage("L'écoute d'évenements n'aura pas lieu... :(, cause :" + e3.Message, true);
                }
            }
            catch (Exception e)
            {
                Function.error(e);
            }
            /**/

        }

        public static void receive(IAsyncResult result)
        {
            MainWindow mainWindow = MainWindow.getInstance();
            try
            {
                HttpWebResponse response = (result.AsyncState as HttpWebRequest).EndGetResponse(result) as HttpWebResponse;
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader sr = new StreamReader(responseStream))
                {
                    String responseText = sr.ReadToEnd();
                    Function.log("Reponse :" + responseText);

                    try
                    {

                        //Parsing de la réponse JSON du serveur contenant les commandes
                        Json jsonResponse = new Json(responseText);
                        List<Json> commands = jsonResponse.fGetList("commands");
                        Function.log("Lancement de la reconnaissance...");
                        //Lancement de la reconnaissance vocale avec les commandes possible comme parametre
                        Recognition reco = new Recognition(commands);

                        mainWindow.Invoke((MethodInvoker)delegate
                        {
                            String commandList = "<li>YANA, Cache toi</li>";
                            commandList += "<li>YANA, Montre toi</li>";
                            commandList += "<li>YANA, Relance toi</li>";
                            foreach (Json command in commands)
                            {
                                commandList += "<li>" + command.fGetString("command") + "</li>";
                            }
                            mainWindow.setCommands("<ul>"+commandList+"</ul>");

                            mainWindow.addMessage("Je peux maintenant t'écouter... :)", true);
                        });
                    }
                    catch (Exception error)
                    {
                        mainWindow.Invoke((MethodInvoker)delegate
                        {
                            mainWindow.addMessage(Program.MSG_NO_SERVER_CONNEXION, true);
                        });
                        Function.error(error);
                    }
                }


            }
            catch (Exception ex)
            {
                mainWindow.Invoke((MethodInvoker)delegate
                    {
                        mainWindow.addMessage(Program.MSG_NO_SERVER_CONNEXION, true);
                    });
                Function.error(ex);
            }

        }




        public static void timing(object sender, EventArgs e)
        {
            Control.send();
        }
        /// <summary>
        /// Affichage tray icon
        /// </summary>
        public void show()
        {
            trayIcon.Visible = true;
        }
        /// <summary>
        /// Dissimulation tray icon
        /// </summary>
        public void hide()
        {
            trayIcon.Visible = false;
        }

        /// <summary>
        /// Affiche un tooltip d'infos
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        public void info(string title, string message)
        {
            trayIcon.ShowBalloonTip(1000, title, message, ToolTipIcon.Info);
        }
        /// <summary>
        /// Affiche un tooltip de warning
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        public void warning(string title, string message)
        {
            trayIcon.ShowBalloonTip(2000, title, message, ToolTipIcon.Warning);
        }
        /// <summary>
        /// Affiche un tooltip d'erreur
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        public void error(string title, string message)
        {
            trayIcon.ShowBalloonTip(2000, title, message, ToolTipIcon.Error);
        }


        private void onConfig(object sender, EventArgs e)
        {
            ConfigurationWindow config = new ConfigurationWindow();
            config.Show();
        }
        /// <summary>
        /// Lors du clic sur le menu "Historique"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onHistory(object sender, EventArgs e)
        {
            DebugWindow debug = DebugWindow.getInstance();
            debug.Show();
        }

        /// <summary>
        /// Lors du clic sur le menu "fermer"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onExit(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        /// <summary>
        /// Lors du clic simple sur le tray icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onTrayClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Récuperation de l'instance unique du tray icon
        /// </summary>
        /// <returns></returns>
        public static TrayIcon getInstance()
        {
            if (instance == null)
            {
                instance = new TrayIcon();
            }
            return instance;
        }

    }


}
