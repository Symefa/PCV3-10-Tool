using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace HashFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private int hash(string name)
        {
            int hash = 0;
            for (int x = 0; x < name.Length; x++)
            {
                hash += name[x];
            }
            return hash;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < textBox1.Lines.Length; i++)
            {
                label3.Text = i.ToString() + "/" + textBox1.Lines.Length.ToString();
                textBox2.AppendText(hash(textBox1.Lines[i]).ToString());
                textBox2.AppendText(Environment.NewLine);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }
    }
}
