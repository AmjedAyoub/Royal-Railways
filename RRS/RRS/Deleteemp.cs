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
    public partial class Deleteemp : Form
    {
        public string first;
        public string last;
        public string id;
        public Deleteemp()
        {
            InitializeComponent();
        }
        
        private string src = Program.xsrc;

        public void Deleteemp_Load(object sender, EventArgs e)
        {
            using (SqlConnection sc = new SqlConnection())
            {
                sc.ConnectionString = src;
                sc.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Fname + ' ' + Lname AS Employee_Full_Name FROM Employee ORDER BY Fname", sc))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    comboBox1.ValueMember = "ID";
                    comboBox1.DisplayMember = "Employee_Full_Name";
                    comboBox1.DataSource = dt;
                }

            }
       
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (var command = Program.xsql.CreateCommand())
            {
                command.CommandText = "SELECT ID FROM [Employee] where Fname like '" + first + "'";
                int i = 0;
                int s = comboBox1.Text.Length;
                if (comboBox1.Text != "")
                {
                    while (comboBox1.Text[i].ToString() != " ")
                        i++;
                    first = comboBox1.Text.Substring(0, i);
                    last = comboBox1.Text.Substring(i + 1, s - 1 - i);
                }
                string q1 = Program.xsrc;
                SqlConnection cn1 = new SqlConnection(q1);
                SqlCommand cmd1 = new SqlCommand("DELETE FROM [Employee] WHERE Fname = '" + first + "'", cn1);
                cmd1.Parameters.AddWithValue("@comboBox1", comboBox1.Text);
                cn1.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                MessageBox.Show("You have been deleted the employee successfully");
                comboBox1.Text = "";
                Deleteemp_Load(sender,e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.xadm.backgr();
        }
        








    }
}
