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
    public partial class Viewtrip : Form
    {
        private string src = Program.xsrc;
        public Viewtrip()
        {
            InitializeComponent();
        }

        public void Viewtrip_Load(object sender, EventArgs e)
        {
            
           dataGridView1.Rows.Clear();
            SqlConnection con = new SqlConnection(src);
                    con.Open();
                  SqlCommand cmd = new SqlCommand("select * from Trip", con);
                  SqlDataReader dr = cmd.ExecuteReader();
                  int row = 0;
                         while (dr.Read())
                          {
                              if (DateTime.Parse(dr["ArrivalTime"].ToString()) >= DateTime.Now)
                              {
                                  dataGridView1.Rows.Insert(row, dr["ID"].ToString(), dr["TripName"].ToString(), dr["TrainName"].ToString(), dr["FromS"].ToString(), dr["ToS"].ToString(), DateTime.Parse(dr["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr["ArrivalTime"].ToString()).ToString(), dr["Duration"].ToString(), dr["Stops"].ToString(), dr["FClassCost"].ToString(), dr["BClassCost"].ToString(), dr["EClassCost"].ToString(), dr["Meal"].ToString(), dr["FBookedSeats"].ToString(), dr["BBookedSeats"].ToString(), dr["EBookedSeats"].ToString());
                                  row++;
                              }
                          }
                         dr.Close();
                         label21.Text = "Total number of Trips : " + row;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Viewtrip_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            textBox8.Text = "";
            dataGridView1.Rows.Clear();
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

        private void button2_Click(object sender, EventArgs e)
        {            
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            textBox8.Text = "";
            dataGridView1.Rows.Clear();
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate2 = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            textBox8.Text = theDate2.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "" && comboBox6.Text != "" && comboBox7.Text != "")
            {
                dataGridView1.Rows.Clear();
                SqlConnection con1 = new SqlConnection(src);
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("select * from Trip", con1);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                int row = 0;
                string time = DateTime.Parse(textBox8.Text).AddHours(double.Parse(comboBox6.Text)).AddMinutes(double.Parse(comboBox6.Text)).ToString();
                while (dr1.Read())
                {
                    if (DateTime.Parse(time).AddDays(-3) < DateTime.Parse(dr1["DepatureTime"].ToString()) || DateTime.Parse(dr1["DepatureTime"].ToString()) <= DateTime.Parse(time).AddDays(3))
                    {
                        if (comboBox2.Text != "" && comboBox3.Text != "")
                        {
                            if (dr1["FromS"].ToString() == comboBox2.Text && dr1["ToS"].ToString() == comboBox3.Text)
                            {
                                dataGridView1.Rows.Insert(row,dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["TrainName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Duration"].ToString(), dr1["Stops"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString());
                                row++;
                            }
                        }
                        else
                        {
                            dataGridView1.Rows.Insert(row,dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["TrainName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Duration"].ToString(), dr1["Stops"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString());
                            row++;
                        }
                    }
                }
                dr1.Close();
                label21.Text = "Total number of Trips : " + row;
            }
            else
            {
                MessageBox.Show("Please enter a depature time !!");
            }
        }
    }
}
