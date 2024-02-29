using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != textBox3.Text.Length && label4.Enabled)
            {
                label4.Visible = true;
                button1.Enabled = false;
            }
            else
            {
                label4.Visible = false;
                button1.Enabled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != textBox3.Text.Length && label4.Enabled)
            {
                label4.Visible = true;
                button1.Enabled = false;
            }
            else
            {
                label4.Visible = false;
                button1.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && !label4.Enabled)
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String mess = textBox1.Text;
            String k = textBox2.Text;
            String vi = textBox3.Text;
            String txtsr;
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            sw.Start();

            byte[] txt = Program.NormalizeMessage(mess, k);
            byte[] key = Encoding.ASCII.GetBytes(k);
            byte[] iv = Encoding.ASCII.GetBytes(vi);
            byte[] enc = Program.EncryptionFunc(txt, key, iv);
            txtsr = Program.NormalizeOutPut(enc);

            textBox1.Text = txtsr;
            label1.Visible = false;
            label5.Visible = true;

            sw.Stop();
            TimeSpan time = sw.Elapsed;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length != 0 && textBox5.Text.Length != 0)
            {
                button2.Enabled = true;
                label10.Visible = false;
            }
            else
            {
                button2.Enabled = false;
                label10.Visible = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length != 0 && textBox5.Text.Length != 0)
            {
                button2.Enabled = true;
                label10.Visible = false;
            }
            else
            {
                button2.Enabled = false;
                label10.Visible = true;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text.Length !=0 && textBox8.Text.Length != 0)
            {
                button3.Enabled = true;
                label12.Visible = false;
            }
            else
            {
                button3.Enabled = false;
                label12.Visible = true;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text.Length != 0 && textBox8.Text.Length != 0)
            {
                button3.Enabled = true;
                label12.Visible = false;
            }
            else
            {
                button3.Enabled = false;
                label12.Visible = true;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text.Length == 0)
            {
                button3.Enabled = false;
            }
            else 
            {
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] iv = Encoding.ASCII.GetBytes(textBox8.Text);
            byte[] message = Program.ReadEncry(textBox10.Text);
            byte[] kt = Encoding.ASCII.GetBytes(textBox9.Text);
            byte[] fif = Program.DecryptionFunc(message, kt, iv);
            textBox10.Text = System.Text.Encoding.ASCII.GetString(fif, 0, fif.Length);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Text = "Keys are:";
            Task<string>[] threads = new Task<string>[6];
            Stopwatch sw = new Stopwatch();

            byte[] sig = Encoding.ASCII.GetBytes(textBox6.Text);
            byte[] iv = Encoding.ASCII.GetBytes(textBox5.Text);
            byte[] message = Program.ReadEncry(textBox4.Text);
            byte[] kt = new byte[iv.Length];

            sw.Restart();
            sw.Start();

            for (int i = 0; i < threads.Length; i++)
            {
                ulong bg = (ulong)i * (ulong)Math.Pow(255, iv.Length) / (ulong)threads.Length + 1;
                ulong end = (ulong)(Math.Pow(255, iv.Length))/(ulong)(threads.Length) * (ulong)(i + 1);
                threads[i] = Task.Factory.StartNew( () => Program.SerchForKey(bg, end, sig, message, iv));
            }
            Task.WaitAll(Task.WhenAll(threads));
            for (int i = 0; i < threads.Length; i++)
            {
                textBox7.Text += threads[i].Result;
            } 
            sw.Stop();
            TimeSpan time = sw.Elapsed;
            double xc = time.TotalSeconds;
        }
    }
}