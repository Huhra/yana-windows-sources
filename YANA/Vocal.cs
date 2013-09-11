/**
 * Yana for Windows par Valentin CARRUESCO aka idleman <idleman@idleman.fr> 
 * Licence Creative Commons -by -sa -nc
 * Classe de gestion de la synthse vocale et de traitement des action tierces comme l'execution d'un son ou d'une commande
**/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace YANA
{
    class Vocal
    {
        public static ReadOnlyCollection<InstalledVoice> getVoices()
        {
            SpeechSynthesizer s = new SpeechSynthesizer();
            return s.GetInstalledVoices();
        }

        public void speak(String message, String styleName)
        {
            Function.log("Parler : " + message);

            MainWindow mainWindow = MainWindow.getInstance();
            mainWindow.Invoke((MethodInvoker)delegate
            {
                mainWindow.addMessage(message, true);
            });

            PromptBuilder p = new PromptBuilder();
            PromptStyle style = new PromptStyle();
            style.Volume = PromptVolume.NotSet;
            style.Rate = PromptRate.NotSet;
            style.Emphasis = PromptEmphasis.NotSet;

            switch (styleName)
            {
                case "angry":
                    style.Volume = PromptVolume.ExtraLoud;
                    style.Rate = PromptRate.Fast;
                    style.Emphasis = PromptEmphasis.Strong;
                    break;
                case "sad":
                    style.Volume = PromptVolume.Soft;
                    style.Rate = PromptRate.Slow;
                    style.Emphasis = PromptEmphasis.None;
                    break;
                case "slow":
                    style.Volume = PromptVolume.Medium;
                    style.Rate = PromptRate.Slow;
                    style.Emphasis = PromptEmphasis.None;
                    break;
            }
            p.StartStyle(style);
            p.StartParagraph();
            p.StartSentence();
            p.AppendText(message);
            p.EndSentence();
            p.EndParagraph();
            p.EndStyle();

            SpeechSynthesizer s = new SpeechSynthesizer();
            s.SelectVoice(Program.SELECTED_VOICE);
            s.Speak(p);
        }

        public void sound(string message)
        {
            Function.log("Son : " + Function.getProjectPath() + message);
            MainWindow mainWindow = MainWindow.getInstance();
            mainWindow.Invoke((MethodInvoker)delegate
            {
                mainWindow.addMessage("<i>*" + message + "*</i>", true);
            });

            try
            {
                PromptBuilder p = new PromptBuilder();
                p.StartParagraph();
                p.StartSentence();
                p.AppendAudio(new Uri(Function.getProjectPath() + message), "Il me manque le son :" + Function.getProjectPath() + message);
                p.EndSentence();
                p.EndParagraph();
                SpeechSynthesizer s = new SpeechSynthesizer();
                s.Speak(p);

            }
            catch (Exception e)
            {
                Function.error(e);
            }
        }
    }
}