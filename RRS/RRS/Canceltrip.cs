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
    public partial class Canceltrip : Form
    {
        private string src = Program.xsrc;
        public Canceltrip()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate2 = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            textBox8.Text = theDate2.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int row = 0;
            if (textBox1.Text != "")
            {
                dataGridView1.Rows.Clear();
                SqlConnection con2 = new SqlConnection(src);
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("select * from Trip", con2);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    if (dr2["ID"].ToString() == textBox1.Text)
                    {
                        if (DateTime.Parse(dr2["DepatureTime"].ToString()) > DateTime.Now)
                        {
                            dataGridView1.Rows.Insert(row, dr2["ID"].ToString(), dr2["FromS"].ToString(), dr2["ToS"].ToString(), DateTime.Parse(dr2["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr2["ArrivalTime"].ToString()).ToString());
                            row++;
                        }
                        else
                        {
                            MessageBox.Show("This trip has been started at\n" + DateTime.Parse(dr2["DepatureTime"].ToString()).ToString()+"\n You can NOT cancel this trip !!!");
                        }
                            
                    }
                    
                }
                dr2.Close();
                label21.Text = "Total number of Trips : " + row;
            }
            else if (textBox8.Text != "" && comboBox6.Text != "" && comboBox7.Text != "")
            {
                dataGridView1.Rows.Clear();
                SqlConnection con1 = new SqlConnection(src);
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("select * from Trip", con1);
                SqlDataReader dr1 = cmd1.ExecuteReader();
               
                string time = DateTime.Parse(textBox8.Text).AddHours(double.Parse(comboBox6.Text)).AddMinutes(double.Parse(comboBox6.Text)).ToString();
                while (dr1.Read())
                {
                    if (DateTime.Parse(dr1["DepatureTime"].ToString()) > DateTime.Now)
                    {
                        if (comboBox2.Text != "" && comboBox3.Text != "")
                        {
                            if (dr1["FromS"].ToString() == comboBox2.Text && dr1["ToS"].ToString() == comboBox3.Text)
                            {
                                dataGridView1.Rows.Insert(row, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString());
                                row++;
                            }
                        }
                        else
                        {
                            dataGridView1.Rows.Insert(row, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["TrainName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString());
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

        public void button4_Click(object sender, EventArgs e)
        {
            Canceltrip_Load(sender,e);
        }

        public void Canceltrip_Load(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            SqlConnection con = new SqlConnection(src);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Trip", con);
            SqlDataReader dr = cmd.ExecuteReader();
            int row = 0;
            while (dr.Read())
            {
                if (DateTime.Parse(dr["DepatureTime"].ToString()) > DateTime.Now)
                {
                    dataGridView1.Rows.Insert(row, dr["ID"].ToString(), dr["TripName"].ToString(), dr["FromS"].ToString(), dr["ToS"].ToString(), DateTime.Parse(dr["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr["ArrivalTime"].ToString()).ToString());
                    row++;
                }
            }
            dr.Close();
            label21.Text = "Total number of Trips : " + row;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to cancel this trip ?", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                int row = dataGridView1.CurrentCell.RowIndex;
                string id = dataGridView1.Rows[row].Cells[0].Value.ToString();
                SqlConnection con1 = new SqlConnection(src);
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("DELETE FROM [Trip] WHERE ID = '" + id + "'", con1);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                SqlConnection con = new SqlConnection(src);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from CustomerTrip", con);
                SqlDataReader dr = cmd.ExecuteReader();
                string cusid = "";
                while (dr.Read())
                {
                    if (dr["TripID"].ToString() == id)
                    {
                        cusid = dr["CustomerID"].ToString();
                        string tik=dr["ID"].ToString();
                        string trname=dr["TripName"].ToString();
                        string date = dr["DepartureTime"].ToString();
                        string read = "No";
                        string msg = "Trip Cancelation\n\nDear sir,\nPlease note that your trip  \" " + trname + " \" , with Ticket No.  \" " + tik + " \" ,\nand with Departure Time  \" "+date+" \" ,\nhas been canceled, if you have been confirmed this ticket, please\ncheck your bank account within 24 hours.\nThank you very much for travelling with us.\n\nAdministrator.\nRoyal Realways.";
                        date = DateTime.Now.ToString();
                        SqlConnection conn = new SqlConnection(src);
                        SqlCommand cmdn = new SqlCommand("INSERT INTO [Message](CusID,Msg,Date,R)VALUES (@cusid,@msg,@date,@read)", conn);
                        cmdn.Parameters.AddWithValue("@cusid", cusid);
                        cmdn.Parameters.AddWithValue("@msg", msg);
                        cmdn.Parameters.AddWithValue("@date", date);
                        cmdn.Parameters.AddWithValue("@read", read);
                        conn.Open();
                        SqlDataReader drn = cmdn.ExecuteReader();
                        conn.Close();
                        drn.Close();
                    }
                }
                dr.Close();
                SqlConnection con2 = new SqlConnection(src);
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("DELETE FROM [CustomerTrip] WHERE TripID = '" + id + "'", con2);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                dr1.Close();
                dr2.Close();
                con1.Close();
                con2.Close();
                dataGridView1.Rows.Clear();
                textBox1.Text = "";
                textBox8.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox6.Text = "";
                comboBox7.Text = "";
                MessageBox.Show("You have been deleted the trip successfully !");  
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
            textBox8.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
