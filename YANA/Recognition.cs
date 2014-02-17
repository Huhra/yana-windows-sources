/**
 * Yana for Windows par Valentin CARRUESCO aka idleman <idleman@idleman.fr> 
 * Licence Creative Commons -by -sa -nc
 * Classe de gestion de l'écoute et de la reconnaissance vocale
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Globalization;

namespace YANA
{
    class Recognition
    {
        public SpeechRecognitionEngine recognizer;
        public Thread recThread;
        public Boolean recognizerState = true;
        public List<Json> commands;

        public Recognition(List<Json> cmd)
        {
            this.commands = cmd;
            Choices commandChoices = new Choices();
            commandChoices.Add("Yana, Montre toi");
            commandChoices.Add("Yana, Cache toi");
            commandChoices.Add("Yana, Relance toi");

            foreach (Json command in commands)
            {
                commandChoices.Add(command.fGetString("command"));
            }

            GrammarBuilder grammarBuilder = new GrammarBuilder();
            CultureInfo culture = new CultureInfo("fr-FR");
            grammarBuilder.Culture = culture;
            grammarBuilder.Append(commandChoices);


            //GrammarBuilder grammarBuilder2 = new GrammarBuilder("test", SubsetMatchingMode.OrderedSubset);
            //grammarBuilder2.Culture = culture;
            //grammarBuilder2.AppendDictation();


            // grammarBuilder.Append(new SemanticResultKey("StartDictation", new SemanticResultValue("ecoute", true)));
            // grammarBuilder.AppendDictation();
            // grammarBuilder.Append(new SemanticResultKey("StopDictation", new SemanticResultValue("terminé", false)));


            Grammar grammar = new Grammar(grammarBuilder);
            grammar.Name = "Available programs";


            recognizer = new SpeechRecognitionEngine();
            recognizer.LoadGrammar(grammar);
            try
            {
                recognizer.SetInputToDefaultAudioDevice();
            }
            catch
            {
                throw new InvalidOperationException("Micro ou source audio d'entrée par défaut introuvable");
            }

            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(speechRecognized);
            recThread = new Thread(new ThreadStart(speechThread));
            recThread.IsBackground = true;
            recThread.Start();
        }

        public void speechRecognized(Object Sender, SpeechRecognizedEventArgs e)
        {
            
            if (!recognizerState)
                return;
            foreach (Json command in commands)
            {
                float confidence = command.fGetFloat("confidence");
                if (command.fGetString("command") == e.Result.Text)
                {
                    Function.log(e.Result.Text + " - reconnue à " + e.Result.Confidence + " sur " + confidence + " : " + (e.Result.Confidence >= confidence ? "Validée" : "Invalidée (<a class='definition' title='Si la commande était bonne, le micro ne doit pas être assez sensible ou de bonne qualité, tu peux changer ton micro ou baisser les seuils de tolérances sous yana-server'>En savoir plus</a>) "));
                 
                    if (e.Result.Confidence >= confidence)
                    {
                        Function.log("Url à lancer : " + command.fGetString("url"));
                        MainWindow mainWindow = MainWindow.getInstance();
                        mainWindow.Invoke((MethodInvoker)delegate
                        {
                            mainWindow.addMessage(e.Result.Text, false);
                        });
                        if (command.fGetString("preAction") != null)
                        {
                            Json preAction = new Json(command.fGetString("preAction"));
                            Control.handleResponse(preAction);
                        }
                        if (command.fGetString("url") != null) Http.get(command.fGetString("url") + "&token=" + Program.TOKEN, new AsyncCallback(receive));
                    }
                }
            }

                if ("Yana, Montre toi" == e.Result.Text && e.Result.Confidence >= 0.85)
                {
                    MainWindow mainWindow = MainWindow.getInstance();
                    mainWindow.Invoke((MethodInvoker)delegate
                    {
                        mainWindow.Show();
                    });
                }
                if ("Yana, Cache toi" == e.Result.Text && e.Result.Confidence >= 0.85)
                {
                    MainWindow mainWindow = MainWindow.getInstance();
                    mainWindow.Invoke((MethodInvoker)delegate
                    {
                        mainWindow.Hide();
                    });
                }
                if ("Yana, Relance toi" == e.Result.Text && e.Result.Confidence >= 0.85)
                {
                    Application.Restart();
                }
            
        }


        public static void receive(IAsyncResult result)
        {
            //MadItNerd : J'ai rajouté un try ici pour éviter les plantages
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
                        MainWindow mainWindow = MainWindow.getInstance();
                        Json jsonResponse = new Json(responseText);
                        Control.handleResponse(jsonResponse);
                    }
                    catch (Exception error)
                    {
                        Function.error(error);
                    }
                }
            }
            catch (WebException e)
            {
                MainWindow mainWindow = MainWindow.getInstance();
                mainWindow.Invoke((MethodInvoker)delegate
                {
                    mainWindow.addMessage("Le serveur n'a pas répondu/ou trop lentement!", true);
                });
                Function.error("yana-server inactif/trop lent à répondre)");
            }
        }

        public void speechThread()
        {
            while (true)
            {
                try
                {
                    recognizer.Recognize();
                }
                catch (Exception e)
                {
                    Function.log(e.ToString());
                }
            }
        }

    }
}
