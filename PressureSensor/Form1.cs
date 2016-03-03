//Pressure Sensor written by Russ Renzas, 2015
//Use without attribution.
//Purpose: Records input from Arduino board/program connected to a pressure sensor, alarms when psi > limit
//Not tested beyond the immediate application it was written for. Arduino code included in github, but no wiring diagrams
//Worked fine when everything was put together.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.IO.Ports;
using System.Media;

namespace PressureSensor
{
    public partial class Form1 : Form
    {
        bool currentlyMeasuring;
        List<string> receivedData;
        bool alarmFlag;
        DateTime startTime;
        DateTime last;
        SoundPlayer player;

        public Form1()
        {
            InitializeComponent();
            currentlyMeasuring = false;
            receivedData = new List<string>();
            numericUpDown1.Value = PressureSensor.Properties.Settings.Default.portSet;
            numericUpDownAlarm.Value = PressureSensor.Properties.Settings.Default.alarmValue;
            player = new SoundPlayer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentlyMeasuring) StopMeasurement();
            else StartMeasurement();
        }

        private void StopMeasurement()
        {
            DialogResult dialogResult = MessageBox.Show("Save Data?","Wanna save?",MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Cancel) return;
            else if (dialogResult == DialogResult.Yes)
            {
                bool saved = SaveData();
                if (!saved) return;
            }

            serialPort1.Close();
            this.pictureBox1.Image = null;
            currentlyMeasuring = false;
            labelPressure.Text = "00.0";
            alarmFlag = false;
            this.BackColor = Form1.DefaultBackColor;
            button1.Text = "Go!";
            player.Stop();
        }

        private bool StartMeasurement()
        {
            receivedData.Clear();
            serialPort1 = new System.IO.Ports.SerialPort("COM" + ((int)numericUpDown1.Value).ToString());
            try
            {
                serialPort1.BaudRate = 9600;
                serialPort1.Parity = System.IO.Ports.Parity.None;
                serialPort1.StopBits = System.IO.Ports.StopBits.One;
                serialPort1.DataBits = 8;
                serialPort1.Handshake = System.IO.Ports.Handshake.None;
                serialPort1.ReadTimeout = 5000;
                serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceivedHandler);
                serialPort1.Open();

                button1.Text = "Stop";
                numericUpDown1.Enabled = false;
                this.pictureBox1.Image = Properties.Resources.animatedPies;
                receivedData.Add("Time (min),psi");
                alarmFlag = false;
                this.BackColor = Form1.DefaultBackColor;
                currentlyMeasuring = true;
                startTime = new DateTime();
                startTime = DateTime.Now;
                last = new DateTime();
                last = DateTime.Now;
                return true;
            }
            catch
            {
                MessageBox.Show("Failed. Check connections and port.");
                serialPort1.Close();
                receivedData.Clear();
                this.pictureBox1.Image = null;
                currentlyMeasuring = false;
                button1.Text = "Go!";
                player.Stop();
            }
            return false;
            
        }
           
        private void ProcessRawData(string str)
        {
            //Add time before the string
            double psi = double.Parse(str);
            psi = psi / 1024 * 32;
            str = Math.Round(psi, 1).ToString();
            labelPressure.Text = str;
            TimeSpan between = DateTime.Now.Subtract(last);
            TimeSpan elapsed = DateTime.Now.Subtract(startTime);
            if (!alarmFlag && Convert.ToDouble(numericUpDownAlarm.Value) < psi)
            {
                alarmFlag = true;
                this.BackColor = Color.Red;
                Random rand = new Random();
                try
                {
                    player = new SoundPlayer();
                    int i = rand.Next(3);
                    if (i < 2) player.Stream = Properties.Resources.aoogah;
                    else player.Stream = Properties.Resources.damn_it;
                    player.Load();
                    player.PlayLooping();
                }
                catch { }
            }
            
            if (between.TotalSeconds >= 60)
            {
                string timeStat = Math.Round(elapsed.TotalMinutes,2,MidpointRounding.AwayFromZero).ToString();
                receivedData.Add(timeStat + "," + str);
                last = DateTime.Now;
            }
        }

        private void DataReceivedHandler(
                object sender,
                SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string s = sp.ReadLine();
            this.Invoke((MethodInvoker)delegate
            {
                ProcessRawData(s);
            });
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            PressureSensor.Properties.Settings.Default.portSet = numericUpDown1.Value;
            PressureSensor.Properties.Settings.Default.Save();
        }

        private bool SaveData()
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.FileName = "Pressure Data";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.Filter = "Comma-delimited text files (*.csv)|*.csv";
            saveFileDialog.InitialDirectory = PressureSensor.Properties.Settings.Default.saveDirectory;

            try
            {
                    if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //buttonNewSample_Click(sender, e); //necessary to avoid error where it doesn't write current line of data
                        System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog.OpenFile());
                        WriteDataToFile(file);
                        PressureSensor.Properties.Settings.Default.saveDirectory = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
                        PressureSensor.Properties.Settings.Default.Save();
                    }
                    else
                    {
                        MessageBox.Show("File not saved.");
                        return false;
                    }
            }
            catch
            {
                MessageBox.Show("File open in another program. We'll keep doing what we were doing while you fix the situation and try again.");
                return false;
            }
            return true;
        }

        private void WriteDataToFile(System.IO.StreamWriter file)
        {
            try
            {
                foreach (string s in receivedData)
                {
                    file.WriteLine(s);
                }
                file.Close();
            }
            catch { MessageBox.Show("Error. Check file name and data integrity."); return; }
        }

        private void numericUpDownAlarm_ValueChanged(object sender, EventArgs e)
        {
            PressureSensor.Properties.Settings.Default.alarmValue = numericUpDownAlarm.Value;
            PressureSensor.Properties.Settings.Default.Save();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(currentlyMeasuring) StopMeasurement();
        }

    }
}
