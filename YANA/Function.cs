/**
 * Yana for Windows par Valentin CARRUESCO aka idleman <idleman@idleman.fr> 
 * Licence Creative Commons -by -sa -nc
 * Classe de stockages des méthodes utiles pour l'ensemble du programme en static
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Collections;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace YANA
{
    class Function
    {

        public static void log(String s)
        {
            Console.WriteLine(DateTime.Now.ToString() + " | " + s);
            DebugWindow.message("<small>" + DateTime.Now.ToString() + "</small><p class='notice'>" + s + "</p>");
        }

        public static void execute(string program)
        {
            Function.execute(program, null, false);
        }

        public static void execute(string program, string arguments)
        {
            Function.execute(program, arguments, false);
        }

        public static void execute(string program, string arguments, bool hideprocess)
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                if (hideprocess) startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = program;
                if (arguments != null) startInfo.Arguments = arguments;
                process.StartInfo = startInfo;
                process.Start();
            }
            catch (Exception e)
            {
                Function.error(e);
            }

        }



        public static String getProjectPath()
        {
            return Regex.Replace(Path.GetDirectoryName(Assembly.GetAssembly(typeof(Function)).CodeBase) + "\\", "file:\\\\", "");
        }
        public static String getExecutablePath()
        {
            return Regex.Replace(Regex.Replace(Assembly.GetExecutingAssembly().GetName().CodeBase, "file:///", ""), "/", "\\");
        }
        public static void error(String e)
        {
            String error = "<!> ERREUR: " + e;
            Function.log("\n\n" + error + "\n\n");

            DebugWindow.message("<small>" + DateTime.Now.ToString() + "</small><p class='error'>" + error + "</p>");
            writeFile(Program.ERROR_FILE, DateTime.Now.ToString() + " | " + error);
        }
        public static void error(Exception e)
        {
            String error = "<!> ERREUR: " + e.Message;
            var st = new StackTrace(e, true);
            var frame = st.GetFrame(0);
            var line = frame.GetFileLineNumber();
            Function.log("\n\n" + error + "\n\n");
            writeFile(Program.ERROR_FILE, DateTime.Now.ToString() + " | " + error + "\n L: " + line + " | " + e.StackTrace);

        }

        public static void launchAtStartup(bool launch)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            String value = key.GetValue(Program.PROGRAM_NAME, "false").ToString();
            bool exist = (value == "false" ? false : true);

            if (launch)
            {
                if (!exist)
                {
                    key.SetValue(Program.PROGRAM_NAME, "\"" + Function.getExecutablePath() + "\"");
                }
            }
            else
            {
                if (exist)
                {
                    key.DeleteValue(Program.PROGRAM_NAME);
                }
            }

            key.Close();
        }

        public static void writeFile(string file, string message)
        {
            try
            {
                // Instanciation du StreamWriter avec passage du nom du fichier 
                StreamWriter monStreamWriter = File.AppendText(file);

                //Ecriture du texte
                monStreamWriter.WriteLine(message);
                // Fermeture du StreamWriter
                monStreamWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static ComboboxItem addItem(string name, string id)
        {
            ComboboxItem item = new ComboboxItem();
            item.Value = id;
            item.Text = name;
            return item;
        }
    }
}
