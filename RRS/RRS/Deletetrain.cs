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
    public partial class Deletetrain : Form
    {
        public string name;
        private string src = Program.xsrc;
        public Deletetrain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Program.xstart.job == "adm")
            {
                Program.xadm.backgr();
            }
            else if (Program.xstart.job == "emp")
            {
                Program.xemp.backgr();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var command = Program.xsql.CreateCommand())
            {
                command.CommandText = "SELECT ID FROM [Train] where Name like '" + name + "'";
                if (comboBox1.Text != "")
                {
                    name = comboBox1.Text;
                }
                string q1 = Program.xsrc;
                SqlConnection cn1 = new SqlConnection(q1);
                SqlCommand cmd1 = new SqlCommand("DELETE FROM [Train] WHERE Name = '" + name + "'", cn1);
                cmd1.Parameters.AddWithValue("@comboBox1", comboBox1.Text);
                cn1.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                MessageBox.Show("You have been deleted the train successfully");
                comboBox1.Text = "";
                Deletetrain_Load(sender, e);
            }
        }

        public void Deletetrain_Load(object sender, EventArgs e)
        {
            using (SqlConnection sc = new SqlConnection())
            {
                sc.ConnectionString = src;
                sc.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Name AS Name FROM Train ORDER BY Name", sc))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    comboBox1.ValueMember = "ID";
                    comboBox1.DisplayMember = "Name";
                    comboBox1.DataSource = dt;
                }

            }
        }
    }
}
