using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RRS
{
    public partial class Addtrain : Form
    {
        public Addtrain ()
        {
            InitializeComponent ();
        }

        private void label2_Click ( object sender, EventArgs e )
        {

        }

        private void button2_Click ( object sender, EventArgs e )
        {
            textBox1.Clear ();
            textBox2.Clear ();
            textBox3.Clear ();
            textBox4.Clear ();
            this.Hide ();
            if ( Program.xstart.job == "adm" )
            {
                Program.xadm.backgr ();
            }
            else if ( Program.xstart.job == "emp" )
            {
                Program.xemp.backgr ();
            }
        }

        private void button1_Click ( object sender, EventArgs e )
        {
            if ( textBox1.Text == "" ) { MessageBox.Show ( "Please enter a train name." ); }
            else if ( textBox4.Text == "" ) { MessageBox.Show ( "Please enter number of economy class seats." ); }
            else if ( textBox2.Text == "" ) { MessageBox.Show ( "Please enter number of first class seats." ); }
            else if ( textBox3.Text == "" ) { MessageBox.Show ( "Please enter number of business class seats." ); }
            else
            {
                string src = Program.xsrc;
                SqlConnection con = new SqlConnection ( src );
                SqlCommand cmd = new SqlCommand ( "INSERT INTO [Train](Name,FClassSeats,BClassSeats,EClassSeats)VALUES (@textBox1,@textBox2,@textBox3,@textBox4)", con );
                cmd.Parameters.AddWithValue ( "@textBox1", textBox1.Text );
                cmd.Parameters.AddWithValue ( "@textBox4", textBox4.Text );
                cmd.Parameters.AddWithValue ( "@textBox2", textBox2.Text );
                cmd.Parameters.AddWithValue ( "@textBox3", textBox3.Text );
                con.Open ();
                bool found = false;
                SqlCommand cmd1 = new SqlCommand ( "select * from Train", con );
                SqlDataReader dr = cmd1.ExecuteReader ();
                while ( dr.Read () )
                {
                    if ( dr [ "Name" ].ToString () == textBox1.Text )
                    {
                        found = true;
                    }
                }
                if ( found )
                {
                    MessageBox.Show ( "This name has been used before \n please try another one." );
                    textBox1.Text = "";
                    dr.Close ();
                    con.Close ();
                }
                else
                {
                    dr.Close ();
                    SqlDataReader dr2 = cmd.ExecuteReader ();
                    MessageBox.Show ( "Your data has been altered successfully" );
                    textBox1.Clear ();
                    textBox2.Clear ();
                    textBox3.Clear ();
                    textBox4.Clear ();
                    con.Close ();
                    this.Hide ();
                    if ( Program.xstart.job == "adm" )
                    {
                        Program.xadm.backgr ();
                    }
                    else if ( Program.xstart.job == "emp" )
                    {
                        Program.xemp.backgr ();
                    }
                }
            }
        }

        private void Addtrain_Load ( object sender, EventArgs e )
        {

        }
    }
}
