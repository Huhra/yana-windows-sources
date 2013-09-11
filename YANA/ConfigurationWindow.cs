using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Speech.Synthesis;

namespace YANA
{
    public partial class ConfigurationWindow : Form
    {
        public ConfigurationWindow()
        {
            InitializeComponent();
            this.Text = Program.PROGRAM_NAME + " V" + Program.PROGRAM_VERSION + " : Configuration";
            Configuration config = Configuration.getInstance();
            textAPI_URL.Text = config.get("API_URL");
           
            textTOKEN.Text = config.get("TOKEN");
            for (int i = 1; i < 60; i++)
            {
                comboCHECK_INTERVAL.Items.Add(i);
                if (config.get("CHECK_INTERVAL") == i + "") comboCHECK_INTERVAL.SelectedIndex = i - 1;
            }
            if (config.get("LAUNCH_AT_STARTUP") == "1")
            {
                checkLAUNCH_AT_STARTUP.Checked = true;
            }
            else
            {
                checkLAUNCH_AT_STARTUP.Checked = false;
            }

            ReadOnlyCollection<InstalledVoice> voices = Vocal.getVoices();
            for (int i=0;i<voices.Count;i++)
            {
                InstalledVoice voice = voices[i];
                VoiceInfo info = voice.VoiceInfo;
                ComboboxItem item = new ComboboxItem();
                item.Value = info.Name;
                item.Text = info.Name + " (" + info.Gender+" "+info.Culture + ")";
                comboSELECTED_VOICE.Items.Add(item);
                if (config.get("SELECTED_VOICE") == info.Name) comboSELECTED_VOICE.SelectedIndex = i;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Configuration config = Configuration.getInstance();
            config.put("CHECK_INTERVAL", comboCHECK_INTERVAL.Text);
            config.put("API_URL", textAPI_URL.Text);
            ComboboxItem item = (ComboboxItem)comboSELECTED_VOICE.SelectedItem;
            config.put("SELECTED_VOICE", item.Value);
            config.put("TOKEN", textTOKEN.Text);

            if (checkLAUNCH_AT_STARTUP.Checked)
            {
                config.put("LAUNCH_AT_STARTUP", "1");
            }
            else
            {
                config.put("LAUNCH_AT_STARTUP", "0");
            }
            config.save();
            Program.CHECK_INTERVAL = int.Parse(config.get("CHECK_INTERVAL"));
            Program.API_URL = config.get("API_URL");
            Program.SELECTED_VOICE = config.get("SELECTED_VOICE");
            Program.EVENT_ACTION = config.get("EVENT_ACTION");
            Program.COMMAND_ACTION = config.get("COMMAND_ACTION");
            Program.TOKEN = config.get("TOKEN");
            Program.LAUNCH_AT_STARTUP = (config.get("LAUNCH_AT_STARTUP") == "1" ? true : false);
            this.Hide();
            Application.Restart();
        }
    }
}

public class ComboboxItem
{
    public string Text { get; set; }
    public string Value { get; set; }

    public override string ToString()
    {
        return Text;
    }
}
