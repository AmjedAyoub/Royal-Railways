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
    public partial class PrintReturn : Form
    {
        private string src = Program.xsrc;
        public PrintReturn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for travelling with us!");
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void Printtwo(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13, string r1, string r2, string r3, string r4, string r5, string r6, string r7, string r8, string r9, string r10, string rc1, string rc2)
        {
            SqlConnection con = new SqlConnection(src);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from CustomerTrip", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["CustomerName"].ToString() == s1 && dr["TripID"].ToString() == s2)
                    {
                        label113.Text = dr["ID"].ToString();
                    }
                    if (dr["CustomerName"].ToString() == s1 && dr["TripID"].ToString() == r1)
                    {
                        label32.Text = dr["ID"].ToString();
                    }
                }
                dr.Close();
                con.Close();
            label100.Text = s1;
            label101.Text = s2;
            label102.Text = s3;
            label103.Text = s4;
            label104.Text = s5;
            label105.Text = s6;
            label106.Text = s7;
            label107.Text = s8;
            label108.Text = s9;
            label109.Text = s10;
            label110.Text = s11;
            label111.Text = s12;
            label112.Text = s13;
            label53.Text = r1;
            label30.Text = r2;
            label52.Text = r3;
            label47.Text = r4;
            label48.Text = r5;
            label46.Text = r6;
            label41.Text = r7;
            label42.Text = r8;
            label40.Text = r9;
            label38.Text = s11;
            label36.Text = r10;
            label58.Text = s13;
            label8.Text = rc1;
            label9.Text = rc2;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void PrintReturn_Load ( object sender, EventArgs e )
        {

        }
    
    }
}
