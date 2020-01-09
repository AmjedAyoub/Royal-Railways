using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace RRS
{
    public partial class Newemp : Form
    {
        public Newemp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("Please enter your firstname."); }
            else if (textBox6.Text == "") { MessageBox.Show("Please enter your lastname."); }
            else if (textBox4.Text == "") { MessageBox.Show("Please enter your Email."); }
            else if (textBox8.Text == "") { MessageBox.Show("Please enter your Contact Number."); }
            else if (textBox10.Text == "") { MessageBox.Show("Please enter your Social Security Number \"SSN\"."); }
            else if (textBox7.Text == "") { MessageBox.Show("Please enter a Username."); }
            else if (comboBox2.Text == "") { MessageBox.Show("Please select a job position."); }
            else if (textBox3.Text == textBox9.Text && textBox3.Text != "")
            {
                string src = Program.xsrc;
                SqlConnection con = new SqlConnection(src);
                SqlCommand cmd = new SqlCommand("INSERT INTO [Employee](Fname,Lname,Gender,SSN,Email,Contact,City,Job,Username,Pass)VALUES (@textBox1,@textBox6,@comboBox1,@textBox10,@textBox4,@textBox8,@textBox2,@comboBox2,@textBox7,@textBox3)", con);
                cmd.Parameters.AddWithValue("@textBox1", textBox1.Text);
                cmd.Parameters.AddWithValue("@textBox6", textBox6.Text);
                cmd.Parameters.AddWithValue("@textBox10", textBox10.Text);
                cmd.Parameters.AddWithValue("@textBox4", textBox4.Text);
                cmd.Parameters.AddWithValue("@textBox2", textBox2.Text);
                cmd.Parameters.AddWithValue("@textBox8", textBox8.Text);
                cmd.Parameters.AddWithValue("@textBox7", textBox7.Text);
                cmd.Parameters.AddWithValue("@textBox3", textBox3.Text);
                cmd.Parameters.AddWithValue("@comboBox1", comboBox1.Text);
                cmd.Parameters.AddWithValue("@comboBox2", comboBox2.Text);
                con.Open();
                bool found = false;
                SqlCommand cmd1 = new SqlCommand("select * from Employee", con);
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
                    MessageBox.Show("Your data has been altered successfully");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox10.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    comboBox2.Text = "";
                    con.Close();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Password does not match");
                textBox9.Clear();
                textBox3.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox10.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox2.Text = "";
            this.Hide();
            Program.xadm.backgr();
        }

        private void Newemp_Load ( object sender, EventArgs e )
        {

        }

    }
}
