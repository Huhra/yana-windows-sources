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
        public static string PROGRAM_VERSION = "1.0.1";
        public static string API_URL;
        public static int CHECK_INTERVAL;
        public static string SOUND_DIR = "sons/";
        public static string EVENT_ACTION;
        public static string COMMAND_ACTION;
        public static string ERROR_FILE = "error.log";
        public static bool LAUNCH_AT_STARTUP;
        public static string TOKEN;
        public static string SELECTED_VOICE;
        
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
