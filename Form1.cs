using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Algorithm8
{
    public partial class Form1 : Form
    {
        public List<string> patrick;
        public BinTree<string> bateman = new BinTree<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = bateman.Find(textBox3.Text) == null ? "<NaN>" : bateman.Find(textBox3.Text).Data.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            patrick = File.ReadAllText("1.txt").Split(' ').ToList();
            foreach (string i in patrick) {
                bateman.Add(i); // thx overloading
            }
            Program.Disp(bateman, treeView1);
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            sw.Start();
            Program.Ordered(bateman.Root, textBox1);
            sw.Stop();
            textBox1.Text += Environment.NewLine + sw.ElapsedMilliseconds;
            sw.Restart();
            sw.Start();
            Program.UnOrdered(bateman.Root, textBox2);
            sw.Stop();
            textBox2.Text += Environment.NewLine + sw.ElapsedMilliseconds;
        }
    }
}
