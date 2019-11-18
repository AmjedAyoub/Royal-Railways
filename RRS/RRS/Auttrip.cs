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
    public partial class Auttrip : Form
    {
        public Auttrip ()
        {
            InitializeComponent ();
        }

        private void button1_Click ( object sender, EventArgs e )
        {
            this.Hide ();
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button7_Click ( object sender, EventArgs e )
        {
            if ( comboBox1.Text == "" || textBox1.Text == "" || textBox2.Text == "" )
            {
                MessageBox.Show ( "Invalid Card\nPlease check your bank account\nOR\nTry with another one." );
            }
            else
            {
                this.Hide ();
                Program.xf2.confirm ();
				comboBox1.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void Auttrip_Load ( object sender, EventArgs e )
        {

        }
    }
}
