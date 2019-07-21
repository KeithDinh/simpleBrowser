using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Search()
        {
            toolStripStatusLabel1.Text = "Loading";
            button1.Enabled = false;
            textBox1.Enabled = false;
            webBrowser1.Navigate("http://" + textBox1.Text);

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)ConsoleKey.Enter)
            {
                //Search();
                Button1_Click(null, null); 
            }
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Completed";
        }

        private void WebBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if(e.CurrentProgress>0 && e.MaximumProgress>0)
            {
                toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program is created by Kiet Dinh");
        }
    }
}
