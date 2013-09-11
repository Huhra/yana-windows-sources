/**
 * Yana for Windows par Valentin CARRUESCO aka idleman <idleman@idleman.fr> 
 * Licence Creative Commons -by -sa -nc
 * Cette classe permet la gestion des variables de configurations de l'application.
 * Les variables sont stockées dans le fichier json dont le chemin est renseigné ci dessous (constante filepath de la classe).
 * Cette classe est un singleton, elle est donc accessible depuis l'ensemble de l'application via getInstance.
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace YANA
{
    public class Configuration
    {
        private const string fileName = "configuration.json";
        private Json datas;
        private static Configuration instance;
        private Configuration()
        {
            datas = new Json();
            this.getConfiguration();
        }


        /// <summary>
        /// Charge/Re-charge toutes les configurations depuis le fichier json associé
        /// </summary>
        public void getConfiguration()
        {
            String fileContent = "";
            try
            {
                String configurationPath = Function.getProjectPath() + fileName;
                configurationPath = Regex.Replace(configurationPath, "file:\\\\", "");
                fileContent = Regex.Replace(File.ReadAllText(configurationPath), @"[\r\n\t ]+", " ");
                fileContent = fileContent.Replace("({", "{");
                fileContent = fileContent.Replace("})", "}");

                fileContent = fileContent.Replace("\\\"", "\"");
                fileContent = fileContent.Replace("\"", "'");
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Fichier de configuration introuvable : " + e.Message);
            }

            try
            {
                datas = new Json(fileContent);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Format du fichier de configuration incorrect : " + e.Message);
            }
        }

        /// <summary>
        /// Sauvegarde toutes les configurations dans le fichier json associé
        /// </summary>
        public void save()
        {
            String file = Function.getProjectPath() + fileName;
            try
            {

                StreamWriter sw = File.CreateText(file);
                sw.WriteLine(datas.ToString());
                sw.Close();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Impossible de sauvegarder le fichier de configuration: " + ex.Message);
            }
        }


        /// <summary>
        /// Récupère la valeur de la clé "key" située dans le fichier de configuration json
        /// </summary>
        public string get(string key)
        {
            return (datas.fExist(key) ? datas.fGetString(key) : "");
        }

        /// <summary>
        /// Définit la valeur "value" à la clé "key" située dans le fichier de configuration json
        /// </summary>
        public void put(string key, string value)
        {
            datas.fPut(key, value);
        }

        /// <summary>
        /// Récupère une mobjInstance unique de la classe de configuration (cf: singleton pattern) il s'agit du seul moyen
        /// d'instancier cette classe.
        /// </summary>
        public static Configuration getInstance()
        {
            if (instance == null)
            {
                instance = new Configuration();
            }
            return instance;
        }

    }
}
