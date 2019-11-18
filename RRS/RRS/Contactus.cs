using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RRS
{
    public partial class Contactus : Form
    {
        public Contactus()
        {
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click((object)sender, (EventArgs)e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Please enter Your email address.");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter Your message.");
            }
            else
            {
                textBox5.Clear();
                comboBox1.Text = "";
                textBox2.Clear();
                MessageBox.Show("Your email message has been sent successfully.\n\n     Thank you very much for contacting us.");
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            comboBox1.Text = "";
            textBox2.Clear();
            this.Hide();
            Program.xf.backgr();
        }

        private void Contactus_Load(object sender, EventArgs e)
        {

        }
    }
}
