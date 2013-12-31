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

            
            
         

            switch(Program.VOICE_VOLUME){
                case 7:
                     style.Volume = PromptVolume.Default;
                break;
                case 1:
                     style.Volume = PromptVolume.Silent;
                break;
                case 2:
                     style.Volume = PromptVolume.ExtraSoft;
                break;
                case 3:
                     style.Volume = PromptVolume.Soft;
                break;
                case 4:
                     style.Volume = PromptVolume.Medium;
                break;
                case 5:
                     style.Volume = PromptVolume.Loud;
                break;
                case 6:
                     style.Volume = PromptVolume.ExtraLoud;
                break;
                default:
                    style.Volume = PromptVolume.NotSet;
                break;
            }
            switch (Program.VOICE_SPEED)
            {
                    case 1:
                    style.Rate = PromptRate.ExtraFast;
                    break;
                    case 2:
                    style.Rate = PromptRate.Fast;
                    break;
                    case 3:
                    style.Rate = PromptRate.Medium;
                    break;
                    case 4:
                    style.Rate = PromptRate.Slow;
                    break;
                    case 5:
                    style.Rate = PromptRate.ExtraSlow;
                    break;
                    default:
                    style.Rate = PromptRate.NotSet;
                    break;
            }
            switch (Program.VOICE_EMPHASIS)
            {
                    case 1:
                       style.Emphasis = PromptEmphasis.Strong;
                    break;
                    case 2:
                       style.Emphasis = PromptEmphasis.Moderate;
                    break;
                    case 3:
                       style.Emphasis = PromptEmphasis.None;
                    break;
                    case 4:
                       style.Emphasis = PromptEmphasis.Reduced;
                    break;
                    default:
                       style.Emphasis = PromptEmphasis.NotSet;
                    break;
            }

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