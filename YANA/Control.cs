/**
 * Yana for Windows par Valentin CARRUESCO aka idleman <idleman@idleman.fr> 
 * Licence Creative Commons -by -sa -nc
 * Classe d'ecoute des évenements, sa méthode "send" est executée par un timer toutes les "x" secondes (x = parametre de configuration CHECK_INTERVAL)
 * Un evenement retourné par le serveur peut être une synthése vocale OU une execution commande OU un lancement de bruitage
**/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Net;
using System.IO;

namespace YANA
{
    class Control
    {
        public static bool LAUNCHED = false;

        /// <summary>
        /// Interroge le serveur et recupere les nouveaux évenements
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public static void send()
        {
            try
            {
                Configuration config = Configuration.getInstance();
                Function.log("Ecoute évenement sur :" + Program.API_URL);
                if (!LAUNCHED)
                {
                    LAUNCHED = true;
                    Http.get(Program.API_URL + Program.EVENT_ACTION + "&token=" + Program.TOKEN, new AsyncCallback(receive));
                    /* 
                     * Http request = new Http();
                     request.Url = Program.API_URL + Program.EVENT_ACTION;
                     */

                }
                else
                {
                    Function.log("Ecoute évenement avortée, processus déjà lancé et non terminé");
                }

            }
            catch (Exception err)
            {
                Function.error(err);
            }
        }

        public static void receive(IAsyncResult result)
        {
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
                        Json jsonResponse = new Json(responseText);
                        Control.handleResponse(jsonResponse);
                    }
                    catch (Exception error)
                    {
                        Function.error(error);
                    }
                }

                LAUNCHED = false;
            }
            catch (Exception e)
            {
                Function.error(e);
            }
        }

        /// <summary>
        /// Traite un evenement JSON retourné par le serveur
        /// </summary>
        /// <param name="jsonResponse"></param>
        public static void handleResponse(Json jsonRoughResponse)
        {

            List<Json> jsonResponseList = jsonRoughResponse.fGetList("responses");
            Vocal vocalManager = new Vocal();
            foreach (Json jsonResponse in jsonResponseList)
            {

                if (jsonResponse.fExist("type"))
                {
                    Function.log(jsonResponse.fGetString("type"));
                    switch (jsonResponse.fGetString("type"))
                    {
                        case "talk":
                            try
                            {
                                String style = (jsonResponse.fExist("style") ? jsonResponse.fGetString("style") : "");
                                vocalManager.speak(jsonResponse.fGetString("sentence"), style);
                            }
                            catch (Exception e)
                            {
                                Function.error(e);
                            }
                            break;
                        case "sound":
                            try
                            {
                                vocalManager.sound(Program.SOUND_DIR + jsonResponse.fGetString("file"));
                            }
                            catch (Exception e2)
                            {
                                Function.error(e2);
                            }
                            break;
                        case "command":
                            try
                            {
                                String program = null;
                                String arguments = null;

                                bool hideprocess = false;
                                if (jsonResponse.fExist("program")) program = jsonResponse.fGetString("program");
                                if (jsonResponse.fExist("arguments")) program = jsonResponse.fGetString("arguments");
                                if (jsonResponse.fExist("hideprocess")) hideprocess = jsonResponse.fGetBool("hideprocess");
                                Function.execute(program, arguments, hideprocess);
                            }
                            catch (Exception e3)
                            {
                                Function.error(e3);
                            }
                            break;
                    }
                }
            }
        }
    }
}
