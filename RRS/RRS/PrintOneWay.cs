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
    public partial class PrintOneWay : Form
    {
        private string src = Program.xsrc;
        public PrintOneWay()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

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

        public void PrintOneWay_Load(object sender, EventArgs e)
        {

        }
        public void PrintOneWayt(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13, string s14, string clas)
        {
            if (s14 == "No")
            {
                button7.Text = "Ok";
                SqlConnection con = new SqlConnection(src);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from CustomerTrip", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["CustomerName"].ToString() == s1 && dr["TripID"].ToString() == s2)
                    {
                        s14 = dr["ID"].ToString();
                    }
                }
                dr.Close();
                con.Close();
            }
            else
            {
                button7.Text = "Cancel";
            }
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
            label113.Text = s14;
            label8.Text = clas;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
