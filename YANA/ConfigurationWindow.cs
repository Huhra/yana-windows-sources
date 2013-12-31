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
            for (int i = 0; i < voices.Count; i++)
            {
                InstalledVoice voice = voices[i];
                VoiceInfo info = voice.VoiceInfo;
                ComboboxItem item = new ComboboxItem();
                item.Value = info.Name;
                item.Text = info.Name + " (" + info.Gender + " " + info.Culture + ")";
                comboSELECTED_VOICE.Items.Add(item);
                if (config.get("SELECTED_VOICE") == info.Name) comboSELECTED_VOICE.SelectedIndex = i;
            }



            Dictionary<String,String> speedValues = new Dictionary<String,String>();
            speedValues.Add("0","Non définis");
            speedValues.Add("1","Très rapide");
            speedValues.Add("2","Rapide");
            speedValues.Add("3","Moyen");
            speedValues.Add("4","Lent");
            speedValues.Add("5","Très lent");

            Dictionary<String, String> volumeValues = new Dictionary<String, String>();
            volumeValues.Add("0", "Non définis");
            volumeValues.Add("1", "Silencieux");
            volumeValues.Add("2", "Très doux");
            volumeValues.Add("3", "Doux");
            volumeValues.Add("4", "Moyen");
            volumeValues.Add("5", "Fort");
            volumeValues.Add("6", "Très Fort");
            volumeValues.Add("7", "Défaut");

            Dictionary<String, String> emphasisValues = new Dictionary<String, String>();
            emphasisValues.Add("0", "Non définis");
            emphasisValues.Add("1", "Forte");
            emphasisValues.Add("2", "Moyenne");
            emphasisValues.Add("3", "Aucune");
            emphasisValues.Add("4", "Réduite");

            foreach( KeyValuePair<string, string> val in speedValues)
            {
                ComboboxItem item = Function.addItem(val.Value,val.Key);
                comboVOICE_SPEED.Items.Add(item);
                if (config.get("VOICE_SPEED") == val.Key) comboVOICE_SPEED.SelectedItem = item;
            }
            foreach (KeyValuePair<string, string> val in volumeValues)
            {
                ComboboxItem item = Function.addItem(val.Value, val.Key);
                comboVOICE_VOLUME.Items.Add(item);
                if (config.get("VOICE_VOLUME") == val.Key) comboVOICE_VOLUME.SelectedItem = item;
            }
            foreach (KeyValuePair<string, string> val in emphasisValues)
            {
                ComboboxItem item = Function.addItem(val.Value, val.Key);
                comboVOICE_EMPHASIS.Items.Add(item);
                if (config.get("VOICE_EMPHASIS") == val.Key) comboVOICE_EMPHASIS.SelectedItem = item;
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

            item = (ComboboxItem)comboVOICE_EMPHASIS.SelectedItem;
            config.put("VOICE_EMPHASIS", item.Value);
            item = (ComboboxItem)comboVOICE_SPEED.SelectedItem;
            config.put("VOICE_SPEED", item.Value);
            item = (ComboboxItem)comboVOICE_VOLUME.SelectedItem;
            config.put("VOICE_VOLUME", item.Value);

            config.save();
            Program.CHECK_INTERVAL = int.Parse(config.get("CHECK_INTERVAL"));
            Program.API_URL = config.get("API_URL");
            Program.SELECTED_VOICE = config.get("SELECTED_VOICE");
            Program.EVENT_ACTION = config.get("EVENT_ACTION");
            Program.COMMAND_ACTION = config.get("COMMAND_ACTION");
            Program.TOKEN = config.get("TOKEN");
            Program.LAUNCH_AT_STARTUP = (config.get("LAUNCH_AT_STARTUP") == "1" ? true : false);


            Program.VOICE_EMPHASIS = config.get("VOICE_EMPHASIS") != "" ? int.Parse(config.get("VOICE_EMPHASIS")) : 0;
            Program.VOICE_SPEED = config.get("VOICE_SPEED") != "" ? int.Parse(config.get("VOICE_SPEED")) : 0;
            Program.VOICE_VOLUME = config.get("VOICE_VOLUME") != "" ? int.Parse(config.get("VOICE_VOLUME")) : 0;

            this.Hide();
            Application.Restart();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboVOICE_SPEED_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ConfigurationWindow_Load(object sender, EventArgs e)
        {

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
