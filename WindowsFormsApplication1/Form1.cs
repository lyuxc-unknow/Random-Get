using System;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1 ()
        {
            InitializeComponent ();
        }

        private void textBox1_KeyPress (object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                listBox1.Items.Add (textBox1.Text);
                FileStream fs = new FileStream ("./Books.txt", FileMode.Create);
                StreamWriter sr = new StreamWriter (fs);
                int a = listBox1.Items.Count;
                for (int i = 0; i < a; i++)
                {
                    sr.WriteLine (listBox1.Items[i].ToString ());
                }
                sr.Close ();
                fs.Close ();
            }
        }

        private void Form1_Load (object sender, EventArgs e)
        {
            FileStream fs = new FileStream ("./Books.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader (fs);
            string a;
            while((a = sr.ReadLine()) != null)
            {
                listBox1.Items.Add (a);
            }
            sr.Close ();
            fs.Close ();
        }

        private void button1_Click (object sender, EventArgs e)
        {
            int a = listBox1.Items.Count;
            Random random = new Random ();
            label1.Text = listBox1.Items[random.Next (a)].ToString ();
        }
    }
}
