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

namespace Encryption
{
    public partial class Form1 : Form
    {
        string nfile_name = "";
        string efile_name = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try {
                if (methods.Text == "Ceaser Cipher")
                {
                    Ceaser c = new Ceaser();
                    if (nfile.Text != "")
                    {
                        efile.Text = c.enc(nfile.Text, int.Parse(key.Text));
                    }
                    else if (nfile_name != "" && efile_name != "")
                    {
                        string line = "";
                        FileStream fs = new FileStream(nfile_name, FileMode.Open, FileAccess.Read);
                        FileStream fs2 = new FileStream(efile_name, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamReader sr = new StreamReader(fs);
                        StreamWriter sw = new StreamWriter(fs2);
                        while((line = sr.ReadLine())!=null)
                        {
                            string[] tmp = line.Split(' ');
                            foreach(string i in tmp)
                            {
                                sw.Write(c.enc(i,int.Parse(key.Text)) + " ");
                            }
                            sw.Write("\r\n");
                        }
                        sw.Flush();
                        fs.Close();
                        fs2.Close();
                        MessageBox.Show("Done");
                    }
                }

            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
         }
        private void button3_Click(object sender, EventArgs e)
        {
            try {
                if (methods.Text == "Ceaser Cipher")
                {
                    Ceaser c = new Ceaser();
                    if (efile.Text != "")
                    {
                        nfile.Text = c.dec(efile.Text, int.Parse(key.Text));
                    }
                    else if (nfile_name != "" && efile_name != "")
                    {
                        string line = "";
                        FileStream fs = new FileStream(nfile_name, FileMode.Open, FileAccess.Write);
                        FileStream fs2 = new FileStream(efile_name, FileMode.OpenOrCreate, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs2);
                        StreamWriter sw = new StreamWriter(fs);
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] tmp = line.Split(' ');
                            foreach (string i in tmp)
                            {
                                sw.Write(c.dec(i, int.Parse(key.Text)) + " ");
                            }
                            sw.Write("\r\n");
                        }
                        sw.Flush();
                        sw.Flush();
                        fs.Close();
                        fs2.Close();
                        MessageBox.Show("Done");
                    }
                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fc = new OpenFileDialog();
            DialogResult res = fc.ShowDialog();
            if (res == DialogResult.Cancel)
                return;
            nfile_name = fc.FileName;
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fc = new OpenFileDialog();
            DialogResult res = fc.ShowDialog();
            if (res == DialogResult.Cancel)
                return;
            efile_name = fc.FileName;
        }
    }
}
