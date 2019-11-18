using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;//for the SQL connection
using System.Data.Sql;//for the SQL connection

namespace RRS
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        public void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//The Cancel button hide the form in background.
        {
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("Please enter your firstname."); }// If the first name field is empty, then show the MessageBox.
            else if (textBox6.Text == "") { MessageBox.Show("Please enter your lastname."); }// If the Last name field is empty, then show the MessageBox.
            else if (textBox5.Text == "") { MessageBox.Show("Please enter your Email."); }// If the email field is empty, then show the MessageBox.
            else if (textBox4.Text == "") { MessageBox.Show("Please enter your Contact Number."); }// If the contact number field is empty, then show the MessageBox.
            else if (textBox8.Text == "") { MessageBox.Show("Please enter your Social Security Number \"SSN\"."); }// If the SSN field is empty, then show the MessageBox.
            else if (textBox7.Text == "") { MessageBox.Show("Please enter a Username."); }// If the username field is empty, then show the MessageBox.
            else if (textBox3.Text == textBox9.Text && textBox3.Text != "")// If the password tow fields did not match.
            {
                string counter = "0";
                string src = Program.xsrc;
                SqlConnection con = new SqlConnection(src);
                SqlCommand cmd = new SqlCommand("INSERT INTO [Passenger](Fname,Lname,Gender,SSN,Email,Contact,City,Counter,Username,Pass)VALUES (@textBox1,@textBox6,@comboBox1,@textBox8,@textBox5,@textBox4,@textBox2,@counter,@textBox7,@textBox3)", con);
                cmd.Parameters.AddWithValue("@textBox1", textBox1.Text);
                cmd.Parameters.AddWithValue("@textBox6", textBox6.Text);
                cmd.Parameters.AddWithValue("@textBox5", textBox5.Text);
                cmd.Parameters.AddWithValue("@textBox4", textBox4.Text);
                cmd.Parameters.AddWithValue("@textBox2", textBox2.Text);
                cmd.Parameters.AddWithValue("@textBox8", textBox8.Text);
                cmd.Parameters.AddWithValue("@textBox7", textBox7.Text);
                cmd.Parameters.AddWithValue("@textBox3", textBox3.Text);
                cmd.Parameters.AddWithValue("@comboBox1", comboBox1.Text);
                cmd.Parameters.AddWithValue("@counter", counter);
                con.Open();
                bool found = false;
                SqlCommand cmd1 = new SqlCommand("select * from Passenger", con);
                SqlDataReader dr = cmd1.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["Username"].ToString() == textBox7.Text)
                    {
                        found = true;
                    }
                }
                if (found)
                {
                    MessageBox.Show("This username has been used before \n please try another one.");
                    textBox7.Text = "";
                    textBox9.Text = "";
                    textBox3.Text = "";
                    dr.Close();
                    con.Close();
                }
                else
                {
                    dr.Close();
                    SqlDataReader dr2 = cmd.ExecuteReader();
                    MessageBox.Show("You have been signed up successfully \n please sign in.");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    comboBox1.Text = "";
                    con.Close();
                    this.Hide();
                    Program.xf.backgr();
                }
            }
            else
            {
                MessageBox.Show("Password does not match");
                textBox9.Clear();
                textBox3.Clear();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox1.Text = "";
            this.Hide();
            Program.xf.backgr();
        }
    }
}
