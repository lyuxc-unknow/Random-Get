using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

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
                textBox1.Text = "";
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
            label1.Text = "题目:" + listBox1.Items[random.Next (a)].ToString() + ",组号:" + random.Next(int.Parse(textBox2.Text));
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
                if (e.Index < listBox1.Items.Count - 1)
                {
                    e.Graphics.DrawLine(new Pen(Color.Gray), e.Bounds.Left - 10, e.Bounds.Bottom - 1, e.Bounds.Right - 10, e.Bounds.Bottom - 1);
                }
            }
            e.DrawFocusRectangle();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(textBox1.Text == "请输入内容，回车添加")
            {
                textBox1.Text = string.Empty;
                textBox1.Font = new Font(textBox1.Font, FontStyle.Regular);
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == string.Empty || textBox1.Text == "\r\n" || textBox1.Text == "")
            {
                textBox1.Text = "请输入内容，回车添加";
                textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
                textBox1.ForeColor = Color.Gray;
            }
        }
    }
}
