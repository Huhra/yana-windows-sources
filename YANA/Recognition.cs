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
            commandChoices.Add("Montre toi");
            commandChoices.Add("Cache toi");
            commandChoices.Add("Relance toi");

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
            Function.log(e.Result.Text + " - " + e.Result.Confidence);
            if (!recognizerState)
                return;
            foreach (Json command in commands)
            {
                float confidence = command.fGetFloat("confidence");
                if (command.fGetString("command") == e.Result.Text && e.Result.Confidence >= confidence)
                {
                    Function.log("Commande: " + command.fGetString("url"));
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


                if ("Montre toi" == e.Result.Text && e.Result.Confidence >= 0.85)
                {
                    MainWindow mainWindow = MainWindow.getInstance();
                    mainWindow.Invoke((MethodInvoker)delegate
                    {
                        mainWindow.Show();
                    });
                }
                if ("Cache toi" == e.Result.Text && e.Result.Confidence >= 0.85)
                {
                    MainWindow mainWindow = MainWindow.getInstance();
                    mainWindow.Invoke((MethodInvoker)delegate
                    {
                        mainWindow.Hide();
                    });
                }
                if ("Relance toi" == e.Result.Text && e.Result.Confidence >= 0.85)
                {
                    Application.Restart();
                }
            }
        }


        public static void receive(IAsyncResult result)
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
