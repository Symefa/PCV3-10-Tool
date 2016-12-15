using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace hashtable
{
   
    public partial class Form1 : Form
    {
        public static int stop = 1;
        private static uint last = 1;
        private static uint hasil = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stop == 1)
            {
                last = Convert.ToUInt32(textBox2.Text);
                label3.Text = last.ToString();
                stop = 0;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                textBox2.Text = last.ToString();
                stop = 1;
                backgroundWorker1.CancelAsync();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(folderBrowserDialog1.SelectedPath + "\\hash.csv", textBox1.Text);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            sequencer(last);
        }

        private void sequencer(uint next)
        {
            if (stop==0) 
            {
                label3.Text = last.ToString();
                hasil = code(last);
                if (hasil <= 1028 && hasil >= 482)
                {
                    textBox1.AppendText(last.ToString() + "," + hasil.ToString());
                    textBox1.AppendText(Environment.NewLine);
                }
                last = next + 1;
                sequencer(last);
            }
        }

        private uint code(uint passwd)
        {
            uint r = 1, p = 35467, n = 54031;
            for (; p >= 1; p--)
                r = (r * passwd) % n;
            return r;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }
    }
}
