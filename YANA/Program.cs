/**
 * Yana for Windows par Valentin CARRUESCO aka idleman <idleman@idleman.fr> 
 * Licence Creative Commons -by -sa -nc
 * Classe d'entrée du programme
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace YANA
{
    static class Program
    {

        //Initialisation des variables globales de configuration
        public static string PROGRAM_NAME = "YANA";
        public static string PROGRAM_VERSION = "1.0.4";
        public static string API_URL;
        public static int CHECK_INTERVAL;
        public static string SOUND_DIR = "sons/";
        public static string EVENT_ACTION;
        public static string COMMAND_ACTION;
        public static string ERROR_FILE = "error.log";
        public static bool LAUNCH_AT_STARTUP;
        public static string TOKEN;
        public static string SELECTED_VOICE;
        public static int VOICE_EMPHASIS;
        public static int VOICE_VOLUME;
        public static int VOICE_SPEED;
        public static int REQUEST_TIMEOUT = 2000;
        public static string DEFAULT_CONFIG = @"({
            ""API_URL"":""http://ip-raspberry/yana-server/action.php"",
            ""SELECTED_VOICE"":""ScanSoft Virginie_Dri40_16kHz"",
            ""CHECK_INTERVAL"":""5"",
            ""REQUEST_TIMEOUT"":""2000"",
            ""PROXY_PORT"":""80"",
            ""PROXY_HOST"":"""",
            ""EVENT_ACTION"":""?action=GET_EVENT"",
            ""COMMAND_ACTION"":""?action=GET_SPEECH_COMMAND"",
            ""LAUNCH_AT_STARTUP"":""0"",
            ""VOICE_EMPHASIS"":""0"",
            ""VOICE_SPEED"":""0"",
            ""VOICE_VOLUME"":""0"",
            ""TOKEN"":""mon-token-ici""})";

        public static string MSG_NO_SERVER_CONNEXION = @"Je ne peux pas  t'écouter :(, ceci peut être du a une mauvaise communication 
        avec le serveur, vérifie que : <br/><hr/>
        <ul>
            <li>1) Tu m'a filé la bonne adresse vers yana-server</li>
            <li>2) Tu m'a filé le bon token d'identification</li>
            <li>3) Tu a bien lancé/installé/connecté yana-server</li>
            <li>4) Je suis sur le même réseau que yana-server</li>
        </ul><hr/>
        Pour acceder aux configurations, clique sur l'engrenage en haut à droite de cette fenêtre.";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            TrayIcon icon = TrayIcon.getInstance();
            icon.show();

            Application.Run();
       
        }



    }
}
