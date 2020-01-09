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
    public partial class Cusbook : Form
    {
        public Cusbook()
        {
            InitializeComponent();
        }
        private string src = Program.xsrc;
        public bool ifview = false;
        public int rowindex1;
        public int rowindex2;
        public int row1 = 0;
        public int row2 = 0;
        int showcounter = 0;
        public void Cusbook_Load(object sender, EventArgs e)
        {
            row1 = 0;
            panel6.Enabled = false;
            panel7.Enabled = false;
            panel8.Enabled = false;
            panel9.Enabled = false;
            checkBox5.Enabled = false;
            ifview = Program.xcvt.fromview;
            if (ifview)
            {
                this.panel3.Visible = true;
                if (Program.xcvt.ret)
                {
                    this.panel5.Visible = true;
                    this.panel4.Visible = true;
                }
                else
                {
                    this.panel5.Visible = false;
                    this.panel4.Visible = false;
                }
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                SqlConnection con = new SqlConnection(src);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Trip", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (DateTime.Parse(dr["DepatureTime"].ToString()) >= DateTime.Now)
                    {
                        dataGridView1.Rows.Insert(row1, dr["ID"].ToString(), dr["TripName"].ToString(), dr["FromS"].ToString(), dr["ToS"].ToString(), DateTime.Parse(dr["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr["ArrivalTime"].ToString()).ToString(), dr["Path"].ToString(), dr["Stops"].ToString(), dr["Duration"].ToString(), dr["FClassCost"].ToString(), dr["BClassCost"].ToString(), dr["EClassCost"].ToString(), dr["Meal"].ToString(), dr["FBookedSeats"].ToString(), dr["BBookedSeats"].ToString(), dr["EBookedSeats"].ToString(), dr["TrainName"].ToString(), dr["FClassSeats"].ToString(), dr["BClassSeats"].ToString(), dr["EClassSeats"].ToString());
                        row1++;
                    }
                }
                dr.Close();
                label21.Text = "Total number of Trips : " + row1;
            }
            else
            {
                row1 = 0;
                this.panel3.Visible = false;
                this.panel5.Visible = false;
                this.panel4.Visible = false;
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                SqlConnection con = new SqlConnection(src);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Trip", con);
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    if (DateTime.Parse(dr["DepatureTime"].ToString()) >= DateTime.Now)
                    {
                        dataGridView1.Rows.Insert(row1, dr["ID"].ToString(), dr["TripName"].ToString(), dr["FromS"].ToString(), dr["ToS"].ToString(), DateTime.Parse(dr["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr["ArrivalTime"].ToString()).ToString(), dr["Path"].ToString(), dr["Stops"].ToString(), dr["Duration"].ToString(), dr["FClassCost"].ToString(), dr["BClassCost"].ToString(), dr["EClassCost"].ToString(), dr["Meal"].ToString(), dr["FBookedSeats"].ToString(), dr["BBookedSeats"].ToString(), dr["EBookedSeats"].ToString(), dr["TrainName"].ToString(), dr["FClassSeats"].ToString(), dr["BClassSeats"].ToString(), dr["EClassSeats"].ToString());
                        row1++;
                    }
                }
                dr.Close();
                label21.Text = "Total number of Trips : " + row1;
            }
            if (row1 == 0 && showcounter>0)
            {
                s1 = false; s2 = false;
                MessageBox.Show("WE ARE VERY SORRY!\nThere are no available trips right now!!,\n Please try again later.");
            }
            showcounter++;
        }
        string fbooked1;
        string bbooked1;
        string ebooked1;
        string fbooked2;
        string bbooked2;
        string ebooked2;
        string fSeats1;
        string bSeats1;
        string eSeats1;
        string fSeats2;
        string bSeats2;
        string eSeats2;
        public void view(string a1, string a2, string a3, string a4, string a5, string a6, string a7, string a8, string a9, string a10, string a11, string a12, string a13, string a14, string a15, string a16, string a17, string ra18, string ra19, string ra20, string ra1, string ra2, string ra3, string ra4, string ra5, string ra6, string ra7, string ra8, string ra9, string ra10, string ra11, string ra12, string ra13, string ra14, string ra15, string ra16, string ra17, string ra21, string ra22, string ra23)
        {
            ret=Program.xcvt.ret;
            if (ret)
            {
                label61.Text = ra1;
                label62.Text = ra2;
                label55.Text = ra3;
                label56.Text = ra4;
                label49.Text = ra5;
                label50.Text = ra6;
                label54.Text = ra7;
                label48.Text = ra8;
                label69.Text = ra9;
                label44.Text = ra10;
                label42.Text = ra11;
                label40.Text = ra12;
                label46.Text = ra13;
                label60.Text = ra17;
                fbooked2 = a14;
                bbooked2 = a15;
                ebooked2 = a16;
                fSeats2 = ra21;
                bSeats2 = ra22;
                eSeats2 = ra23;
                label90.Text = fSeats2;
                label91.Text = bSeats2;
                label89.Text = eSeats2;
            }
            label9.Text = a1;
            label8.Text = a2;
            label17.Text = a3;
            label18.Text = a4;
            label20.Text = a5;
            label22.Text = a6;
            label16.Text = a7;
            label19.Text = a8;
            label71.Text = a9;
            label28.Text = a10;
            label30.Text = a11;
            label32.Text = a12;
            label26.Text = a13;
            label10.Text = a17;
            fbooked1 = a14;
            bbooked1 = a15;
            ebooked1 = a16;
            fSeats1 = ra18;
            bSeats1 = ra19;
            eSeats1 = ra20;
            label84.Text = fSeats1;
            label85.Text = bSeats1;
            label83.Text = eSeats1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (s1)
            {
                this.panel3.Visible = true;
                label9.Text = dataGridView1.Rows[rowindex1].Cells[0].Value.ToString();
                label8.Text = dataGridView1.Rows[rowindex1].Cells[1].Value.ToString();
                label17.Text = dataGridView1.Rows[rowindex1].Cells[2].Value.ToString();
                label18.Text = dataGridView1.Rows[rowindex1].Cells[3].Value.ToString();
                label20.Text = dataGridView1.Rows[rowindex1].Cells[4].Value.ToString();
                label22.Text = dataGridView1.Rows[rowindex1].Cells[5].Value.ToString();
                label16.Text = dataGridView1.Rows[rowindex1].Cells[6].Value.ToString();
                label19.Text = dataGridView1.Rows[rowindex1].Cells[7].Value.ToString();
                label71.Text = dataGridView1.Rows[rowindex1].Cells[8].Value.ToString();
                label28.Text = dataGridView1.Rows[rowindex1].Cells[9].Value.ToString();
                label30.Text = dataGridView1.Rows[rowindex1].Cells[10].Value.ToString();
                label32.Text = dataGridView1.Rows[rowindex1].Cells[11].Value.ToString();
                label26.Text = dataGridView1.Rows[rowindex1].Cells[12].Value.ToString();
                label10.Text = dataGridView1.Rows[rowindex1].Cells[16].Value.ToString();
                fbooked1 = dataGridView1.Rows[rowindex1].Cells[13].Value.ToString();
                bbooked1 = dataGridView1.Rows[rowindex1].Cells[14].Value.ToString();
                ebooked1 = dataGridView1.Rows[rowindex1].Cells[15].Value.ToString();
                fSeats1 = (int.Parse(dataGridView1.Rows[rowindex1].Cells[17].Value.ToString()) - int.Parse(fbooked1)).ToString();
                bSeats1 = (int.Parse(dataGridView1.Rows[rowindex1].Cells[18].Value.ToString()) - int.Parse(bbooked1)).ToString();
                eSeats1 = (int.Parse(dataGridView1.Rows[rowindex1].Cells[19].Value.ToString()) - int.Parse(ebooked1)).ToString();
                label84.Text = fSeats1;
                label85.Text = bSeats1;
                label83.Text = eSeats1;
                s1 = false;
            }
        }

        public void button4_Click(object sender, EventArgs e)
        {
            ifview = false;
            Cusbook_Load(sender, e);
        }
        bool ret = false;
        private void button3_Click(object sender, EventArgs e)
        {
            s1 = false;
            s2 = false;
            panel6.Enabled = false;
            panel7.Enabled = false;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            SqlConnection con1 = new SqlConnection(src);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Trip", con1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
         
            if (comboBox2.Text == "" && comboBox3.Text == "" && textBox8.Text == "")
            {
                MessageBox.Show("Please insert date or cities to help you for quick search!!");
            }
            else
            {
                row1 = 0;
                row2 = 0;
                while (dr1.Read())
                {
                    if (comboBox2.Text != "" && comboBox3.Text != "" && textBox8.Text != "")
                    {
                        if (dr1["FromS"].ToString() == comboBox2.Text && dr1["ToS"].ToString() == comboBox3.Text && ((DateTime.Parse(textBox8.Text).AddDays(-3) < DateTime.Parse(dr1["DepatureTime"].ToString()) || DateTime.Parse(dr1["DepatureTime"].ToString()) <= DateTime.Parse(textBox8.Text).AddDays(3)) && DateTime.Parse(dr1["DepatureTime"].ToString()) > DateTime.Now))
                        {
                            dataGridView1.Rows.Insert(row1, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Path"].ToString(), dr1["Stops"].ToString(), dr1["Duration"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString(), dr1["TrainName"].ToString(), dr1["FClassSeats"].ToString(), dr1["BClassSeats"].ToString(), dr1["EClassSeats"].ToString());
                            row1++;
                            s1 = true;
                        }
                    }

                    if (comboBox2.Text != "" && comboBox3.Text != "" && textBox8.Text == "")
                    {
                        if (dr1["FromS"].ToString() == comboBox2.Text && dr1["ToS"].ToString() == comboBox3.Text && DateTime.Parse(dr1["DepatureTime"].ToString()) > DateTime.Now)
                        {
                            dataGridView1.Rows.Insert(row1, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Path"].ToString(), dr1["Stops"].ToString(), dr1["Duration"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString(), dr1["TrainName"].ToString(), dr1["FClassSeats"].ToString(), dr1["BClassSeats"].ToString(), dr1["EClassSeats"].ToString());
                            row1++;
                            s1 = true;
                        }
                    }
                    if (comboBox2.Text != "" && comboBox3.Text == "" && textBox8.Text == "")
                    {
                        if (dr1["FromS"].ToString() == comboBox2.Text && DateTime.Parse(dr1["DepatureTime"].ToString()) > DateTime.Now)
                        {
                            dataGridView1.Rows.Insert(row1, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Path"].ToString(), dr1["Stops"].ToString(), dr1["Duration"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString(), dr1["TrainName"].ToString(), dr1["FClassSeats"].ToString(), dr1["BClassSeats"].ToString(), dr1["EClassSeats"].ToString());
                            row1++;
                            s1 = true;
                        }
                    }
                    if (comboBox2.Text == "" && comboBox3.Text == "" && textBox8.Text != "")
                    {
                        if (DateTime.Parse(dr1["DepatureTime"].ToString()) > DateTime.Now && (DateTime.Parse(textBox8.Text).AddDays(-3) < DateTime.Parse(dr1["DepatureTime"].ToString()) || DateTime.Parse(dr1["DepatureTime"].ToString()) <= DateTime.Parse(textBox8.Text).AddDays(3)))
                        {
                            dataGridView1.Rows.Insert(row1, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Path"].ToString(), dr1["Stops"].ToString(), dr1["Duration"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString(), dr1["TrainName"].ToString(), dr1["FClassSeats"].ToString(), dr1["BClassSeats"].ToString(), dr1["EClassSeats"].ToString());
                            row1++;
                            s1 = true;
                        }
                    }
                    if (checkBox1.Checked)
                    {
                        ret = true;
                        panel5.Visible = true;
                        if (comboBox2.Text != "" && comboBox3.Text != "" && textBox8.Text != "")
                        {
                            if (dr1["FromS"].ToString() == comboBox3.Text && dr1["ToS"].ToString() == comboBox2.Text && ((DateTime.Parse(textBox8.Text).AddDays(-3) < DateTime.Parse(dr1["DepatureTime"].ToString()) || DateTime.Parse(dr1["DepatureTime"].ToString()) <= DateTime.Parse(textBox8.Text).AddDays(3)) && DateTime.Parse(dr1["DepatureTime"].ToString()) > DateTime.Now))
                            {
                                dataGridView2.Rows.Insert(row2, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Path"].ToString(), dr1["Stops"].ToString(), dr1["Duration"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString(), dr1["TrainName"].ToString(), dr1["FClassSeats"].ToString(), dr1["BClassSeats"].ToString(), dr1["EClassSeats"].ToString());
                                row2++;
                                s2 = true;
                            }
                        }

                        if (comboBox2.Text != "" && comboBox3.Text != "" && textBox8.Text == "")
                        {
                            if (dr1["FromS"].ToString() == comboBox3.Text && dr1["ToS"].ToString() == comboBox2.Text && DateTime.Parse(dr1["DepatureTime"].ToString()) > DateTime.Now)
                            {
                                dataGridView2.Rows.Insert(row2, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Path"].ToString(), dr1["Stops"].ToString(), dr1["Duration"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString(), dr1["TrainName"].ToString(), dr1["FClassSeats"].ToString(), dr1["BClassSeats"].ToString(), dr1["EClassSeats"].ToString());
                                row2++;
                                s2 = true;
                            }
                        }
                        if (comboBox2.Text != "" && comboBox3.Text == "" && textBox8.Text == "")
                        {
                            if (dr1["ToS"].ToString() == comboBox2.Text && DateTime.Parse(dr1["DepatureTime"].ToString()) > DateTime.Now)
                            {
                                dataGridView2.Rows.Insert(row2, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Path"].ToString(), dr1["Stops"].ToString(), dr1["Duration"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString(), dr1["TrainName"].ToString(), dr1["FClassSeats"].ToString(), dr1["BClassSeats"].ToString(), dr1["EClassSeats"].ToString());
                                row2++;
                                s2 = true;
                            }
                        }
                        if (comboBox2.Text == "" && comboBox3.Text == "" && textBox8.Text != "")
                        {
                            if (DateTime.Parse(dr1["DepatureTime"].ToString()) > DateTime.Now && (DateTime.Parse(textBox8.Text).AddDays(-3) < DateTime.Parse(dr1["DepatureTime"].ToString()) || DateTime.Parse(dr1["DepatureTime"].ToString()) <= DateTime.Parse(textBox8.Text).AddDays(3)))
                            {
                                dataGridView2.Rows.Insert(row2, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Path"].ToString(), dr1["Stops"].ToString(), dr1["Duration"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString(), dr1["TrainName"].ToString(), dr1["FClassSeats"].ToString(), dr1["BClassSeats"].ToString(), dr1["EClassSeats"].ToString());
                                row2++;
                                s2 = true;
                            }
                        }
                    }

                } if (row1 == 0)
                {
                    s1 = false;
                    MessageBox.Show("There are no available trips at that time!!,\n Please try to search again.");
                }

                if (row2 == 0)
                {
                    s2 = false;
                }
            } label21.Text = "Total number of Trips : " + row1;
            label67.Text = "Total number of Trips : " + row2;
            dr1.Close();                
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate1 = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            textBox8.Text = theDate1.ToString();
        }
        public string total = "0.0";

        private void button7_Click(object sender, EventArgs e)
        {
            total = "0.00";
            if (!fclass && !bclass && !eclass)
            {
                MessageBox.Show("Please select a class.");
            }
            else
            {
                        if (label26.Text != "No" && checkBox4.Checked == true)
                        {
                            total = double.Parse(label26.Text).ToString();
                        }
                        if (fclass)
                        {
                            if (label84.Text != "0")
                            {
                                seatclass1 = "F-Class";
                                total = (double.Parse(total) + (double.Parse(label28.Text))).ToString();
                                panel6.Enabled = true;
                                label43.Text = total;
                                if (ret)
                                {
                                    checkBox5.Enabled = true;
                                }
                                else
                                {
                                    checkBox5.Enabled = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("There are NO available seats at F-class! \n Please select another class!");
                            }
                        }
                        if (bclass)
                        {
                            if (label85.Text != "0")
                            {
                                seatclass1 = "B-Class";
                                total = (double.Parse(total) + (double.Parse(label30.Text))).ToString();
                                panel6.Enabled = true;
                                label43.Text = total;
                                if (ret)
                                {
                                    checkBox5.Enabled = true;
                                }
                                else
                                {
                                    checkBox5.Enabled = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("There are NO available seats at B-class! \n Please select another class!");
                            }
                        }
                        if (eclass)
                        {
                            if (label83.Text != "0")
                            {
                                seatclass1 = "E-Class";
                                total = (double.Parse(total) + (double.Parse(label32.Text))).ToString();
                                panel6.Enabled = true;
                                label43.Text = total;
                                if (ret)
                                {
                                    checkBox5.Enabled = true;
                                }
                                else
                                {
                                    checkBox5.Enabled = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("There are NO available seats at E-class! \n Please select another class!");
                            }
                        }
                        total = "0.00";
            }
        }
        public bool fclass = false;
        public bool bclass = false;
        public bool eclass = false;
        public bool rfclass = false;
        public bool rbclass = false;
        public bool reclass = false;
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                fclass = true;
            }
            else
            {
                fclass = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                bclass = true;
            }
            else
            {
                bclass = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                eclass = true;
            }
            else
            {
                eclass = false;
            }
        }
        public string confirm = "";
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                panel8.Enabled = true;
            }
            else
            {
                panel8.Enabled = false;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            panel7.Enabled = false;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                rfclass = true;
            }
            else
            {
                rfclass = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                rbclass = true;
            }
            else
            {
                rbclass = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                reclass = true;
            }
            else
            {
                reclass = false;
            }
        }
        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
            {
                panel9.Enabled = true;
            }
            else
            {
                panel9.Enabled = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            total = "0.00";
            if (!rfclass && !rbclass && !reclass)
            {
                MessageBox.Show("Please select a class.");
            }
            else
            {

                if (label46.Text != "No" && checkBox11.Checked == true)
                {
                    total = double.Parse(label46.Text).ToString();
                }
                if (rfclass)
                {
                    if (label90.Text != "0")
                    {
                        total = (double.Parse(total) + (double.Parse(label44.Text))).ToString();
                        panel7.Enabled = true;
                        label75.Text = total;
                    }
                    else
                    {
                        MessageBox.Show("There are NO available seats at F-class! \n Please select another class!");
                    }
                }
                if (rbclass)
                {
                    if (label91.Text != "0")
                    {
                        total = (double.Parse(total) + (double.Parse(label42.Text))).ToString();
                        panel7.Enabled = true;
                        label75.Text = total;
                        
                    }
                    else
                    {
                        MessageBox.Show("There are NO available seats at B-class! \n Please select another class!");
                    }
                }
                if (reclass)
                {
                    if (label89.Text != "0")
                    {
                        total = (double.Parse(total) + (double.Parse(label40.Text))).ToString();
                        panel7.Enabled = true;
                        label75.Text = total;
                    }
                    else
                    {
                        MessageBox.Show("There are NO available seats at E-class! \n Please select another class!");
                    }
                }
                total = "0.00";
            }
        }
        bool s1=false;
        bool s2 = false;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (row1 > 0)
            {
                s1 = true;
                rowindex1 = dataGridView1.CurrentCell.RowIndex;

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (row2 > 0)
            {
                s2 = true;
                rowindex2 = dataGridView2.CurrentCell.RowIndex;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            s1 = false;
            this.panel3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (s2)
            {
                this.panel4.Visible = true;
                label61.Text = dataGridView2.Rows[rowindex2].Cells[0].Value.ToString();
                label62.Text = dataGridView2.Rows[rowindex2].Cells[1].Value.ToString();
                label55.Text = dataGridView2.Rows[rowindex2].Cells[2].Value.ToString();
                label56.Text = dataGridView2.Rows[rowindex2].Cells[3].Value.ToString();
                label49.Text = dataGridView2.Rows[rowindex2].Cells[4].Value.ToString();
                label50.Text = dataGridView2.Rows[rowindex2].Cells[5].Value.ToString();
                label54.Text = dataGridView2.Rows[rowindex2].Cells[6].Value.ToString();
                label48.Text = dataGridView2.Rows[rowindex2].Cells[7].Value.ToString();
                label69.Text = dataGridView2.Rows[rowindex2].Cells[8].Value.ToString();
                label44.Text = dataGridView2.Rows[rowindex2].Cells[9].Value.ToString();
                label42.Text = dataGridView2.Rows[rowindex2].Cells[10].Value.ToString();
                label40.Text = dataGridView2.Rows[rowindex2].Cells[11].Value.ToString();
                label46.Text = dataGridView2.Rows[rowindex2].Cells[12].Value.ToString();
                label60.Text = dataGridView2.Rows[rowindex2].Cells[16].Value.ToString();
                fbooked2 = dataGridView2.Rows[rowindex2].Cells[13].Value.ToString();
                bbooked2 = dataGridView2.Rows[rowindex2].Cells[14].Value.ToString();
                ebooked2 = dataGridView2.Rows[rowindex2].Cells[15].Value.ToString();
                fSeats2 = (int.Parse(dataGridView2.Rows[rowindex2].Cells[17].Value.ToString()) - int.Parse(fbooked2)).ToString();
                bSeats2 = (int.Parse(dataGridView2.Rows[rowindex2].Cells[18].Value.ToString()) - int.Parse(bbooked2)).ToString();
                eSeats2 = (int.Parse(dataGridView2.Rows[rowindex2].Cells[19].Value.ToString()) - int.Parse(ebooked2)).ToString();
                label90.Text = fSeats2;
                label91.Text = bSeats2;
                label89.Text = eSeats2;
                s2 = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            s2 = false;
            this.panel4.Visible = false;
        }
        public string name;
        public string id;
        public string meal;
        public string seatclass1;
        public string seatclass2;
        private void button8_Click(object sender, EventArgs e)
        {
            confirm = "";
            if ((MessageBox.Show("Are you sure you want to book ONE WAY trip ?", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {

                if (radioButton8.Checked)
                {
                    if (comboBox1.Text == "" || textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("Invalid Card\nPlease check your bank account\nOR\nTry with another one.");
                    }
                    else
                    {
                        confirm = "Confirmed";
                    }
                }
                else
                {
                    confirm = "Not Confirmed";
                }
                if (confirm != "")
                {
                    name = Program.xcust.name;
                    id = Program.xcust.id;
                    if (label26.Text != "No" && checkBox4.Checked == true)
                    {
                        meal = "Yes";
                    }
                    else
                    {
                        meal = "No";
                    }
                    if (fclass)
                    {
                        fbooked1 = (int.Parse(fbooked1) + 1).ToString();
                        seatclass1 = "F-Class";
                    }
                    else if (bclass)
                    {
                        bbooked1 = (int.Parse(bbooked1) + 1).ToString();
                        seatclass1 = "B-Class";
                    }
                    else
                    {
                        ebooked1 = (int.Parse(ebooked1) + 1).ToString();
                        seatclass1 = "E-Class";
                    }
                    SqlConnection con3 = new SqlConnection(src);
                    SqlCommand cmd3 = new SqlCommand("INSERT INTO [CustomerTrip](CustomerID,CustomerName,TripID,TripName,TrainID,FromS,ToS,Path,Stops,DepartureTime,ArrivalTime,Meal,SeatClass,Cost,IsConfirmed)VALUES (@id,@name,@label9,@label8,@label10,@label17,@label18,@label16,@label19,@label20,@label22,@meal,@seatclass,@label43,@confirm)", con3);
                    cmd3.Parameters.AddWithValue("@id", id);
                    cmd3.Parameters.AddWithValue("@name", name);
                    cmd3.Parameters.AddWithValue("@label9", label9.Text);
                    cmd3.Parameters.AddWithValue("@label8", label8.Text);
                    cmd3.Parameters.AddWithValue("@label10", label10.Text);
                    cmd3.Parameters.AddWithValue("@label17", label17.Text);
                    cmd3.Parameters.AddWithValue("@label18", label18.Text);
                    cmd3.Parameters.AddWithValue("@label19", label19.Text);
                    cmd3.Parameters.AddWithValue("@label16", label16.Text);
                    cmd3.Parameters.AddWithValue("@label20", label20.Text);
                    cmd3.Parameters.AddWithValue("@label22", label22.Text);
                    cmd3.Parameters.AddWithValue("@label43", label43.Text);
                    cmd3.Parameters.AddWithValue("@meal", meal);
                    cmd3.Parameters.AddWithValue("@seatclass", seatclass1);
                    cmd3.Parameters.AddWithValue("@confirm", confirm);
                    con3.Open();
                    MessageBox.Show(id + "@@" + name + "@@" + label9.Text + "@@\n\n" + label8.Text + "@@" + label10.Text + "@@" + label17.Text + "@@\n\n" + label18.Text + "@@" + label19.Text + "@@" + label16.Text + "@@\n\n" + label20.Text + "@@" + label22.Text + "@@" + label43.Text + "@@\n\n" + meal + "@@" + seatclass1 + "@@" + confirm);
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    con3.Close();
                    SqlConnection cn1 = new SqlConnection(src);
                    SqlCommand cmd1 = new SqlCommand("UPDATE [Trip] SET FBookedSeats=@fbooked1, BBookedSeats=@bbooked1, EBookedSeats=@ebooked1 WHERE TripName = '" + label8.Text + "'", cn1);

                    cmd1.Parameters.AddWithValue("@fbooked1", fbooked1);
                    cmd1.Parameters.AddWithValue("@bbooked1", bbooked1);
                    cmd1.Parameters.AddWithValue("@ebooked1", ebooked1);
                    cn1.Open();
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    cn1.Close();
                    string tik = "No";
                    MessageBox.Show("You have been booked this trip successfully!");
                    Program.xone.PrintOneWayt(name, label9.Text, label8.Text, label10.Text, label17.Text, label18.Text, label16.Text, label20.Text, label22.Text, label19.Text, meal, label43.Text, confirm, tik, seatclass1);
                    Program.xone.Show();
                    label43.Text = "0.00";
                    panel6.Enabled = false;
                    panel8.Enabled = false;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            name = Program.xcust.name;
            id = Program.xcust.id;
            confirm = "";
            if (radioButton9.Checked)
            {
                if (comboBox4.Text == "" || textBox4.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Invalid Card\nPlease check your bank account\nOR\nTry with another one.");
                }
                else
                {
                    confirm = "Confirmed";
                }
            }
            else
            {
                confirm = "Not Confirmed";
            }
            if (panel6.Enabled && checkBox5.Enabled && checkBox5.Checked)
            {
                if ((MessageBox.Show("Are you sure you want to book trip with RETURN ?", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (confirm != "")
                    {
                        
                        if (label46.Text != "No" && checkBox11.Checked == true)
                        {
                            meal = "Yes";
                        }
                        else
                        {
                            meal = "No";
                        }
                        if (rfclass)
                        {
                            fbooked1 = (int.Parse(fbooked1) + 1).ToString();
                            fbooked2 = (int.Parse(fbooked2) + 1).ToString();
                            seatclass2 = "F-Class";
                        }
                        else if (rbclass)
                        {
                            bbooked2 = (int.Parse(bbooked2) + 1).ToString();
                            bbooked1 = (int.Parse(bbooked1) + 1).ToString();
                            seatclass2 = "B-Class";
                        }
                        else
                        {
                            ebooked2 = (int.Parse(ebooked2) + 1).ToString();
                            ebooked1 = (int.Parse(ebooked1) + 1).ToString();
                            seatclass2 = "E-Class";
                        }
                        SqlConnection con4 = new SqlConnection(src);
                        SqlCommand cmd4 = new SqlCommand("INSERT INTO [CustomerTrip](CustomerID,CustomerName,TripID,TripName,TrainID,FromS,ToS,Path,Stops,DepartureTime,ArrivalTime,Meal,SeatClass,Cost,IsConfirmed)VALUES (@id,@name,@label9,@label8,@label10,@label17,@label18,@label16,@label19,@label20,@label22,@meal,@seatclass,@label43,@confirm)", con4);
                        cmd4.Parameters.AddWithValue("@id", id);
                        cmd4.Parameters.AddWithValue("@name", name);
                        cmd4.Parameters.AddWithValue("@label9", label9.Text);
                        cmd4.Parameters.AddWithValue("@label8", label8.Text);
                        cmd4.Parameters.AddWithValue("@label10", label10.Text);
                        cmd4.Parameters.AddWithValue("@label17", label17.Text);
                        cmd4.Parameters.AddWithValue("@label18", label18.Text);
                        cmd4.Parameters.AddWithValue("@label19", label19.Text);
                        cmd4.Parameters.AddWithValue("@label16", label16.Text);
                        cmd4.Parameters.AddWithValue("@label20", label20.Text);
                        cmd4.Parameters.AddWithValue("@label22", label22.Text);
                        cmd4.Parameters.AddWithValue("@label43", label75.Text);
                        cmd4.Parameters.AddWithValue("@meal", meal);
                        cmd4.Parameters.AddWithValue("@seatclass", seatclass1);
                        cmd4.Parameters.AddWithValue("@confirm", confirm);
                        con4.Open();
                        SqlDataReader dr3 = cmd4.ExecuteReader();
                        con4.Close();
                        SqlConnection cn2 = new SqlConnection(src);
                        SqlCommand cmd22 = new SqlCommand("UPDATE [Trip] SET FBookedSeats=@fbooked1, BBookedSeats=@bbooked1, EBookedSeats=@ebooked1 WHERE TripName = '" + label8.Text + "'", cn2);

                        cmd22.Parameters.AddWithValue("@fbooked1", fbooked1);
                        cmd22.Parameters.AddWithValue("@bbooked1", bbooked1);
                        cmd22.Parameters.AddWithValue("@ebooked1", ebooked1);
                        cn2.Open();
                        SqlDataReader dr1 = cmd22.ExecuteReader();
                        cn2.Close();
                        SqlConnection con5 = new SqlConnection(src);
                        SqlCommand cmd5 = new SqlCommand("INSERT INTO [CustomerTrip](CustomerID,CustomerName,TripID,TripName,TrainID,FromS,ToS,Path,Stops,DepartureTime,ArrivalTime,Meal,SeatClass,Cost,IsConfirmed)VALUES (@id,@name,@label9,@label8,@label10,@label17,@label18,@label16,@label19,@label20,@label22,@meal,@seatclass,@label43,@confirm)", con5);
                        cmd5.Parameters.AddWithValue("@id", id);
                        cmd5.Parameters.AddWithValue("@name", name);
                        cmd5.Parameters.AddWithValue("@label9", label61.Text);
                        cmd5.Parameters.AddWithValue("@label8", label62.Text);
                        cmd5.Parameters.AddWithValue("@label10", label60.Text);
                        cmd5.Parameters.AddWithValue("@label17", label55.Text);
                        cmd5.Parameters.AddWithValue("@label18", label56.Text);
                        cmd5.Parameters.AddWithValue("@label19", label48.Text);
                        cmd5.Parameters.AddWithValue("@label16", label54.Text);
                        cmd5.Parameters.AddWithValue("@label20", label49.Text);
                        cmd5.Parameters.AddWithValue("@label22", label50.Text);
                        cmd5.Parameters.AddWithValue("@label43", label75.Text);
                        cmd5.Parameters.AddWithValue("@meal", meal);
                        cmd5.Parameters.AddWithValue("@seatclass", seatclass2);
                        cmd5.Parameters.AddWithValue("@confirm", confirm);
                        con5.Open();
                        SqlDataReader dr5 = cmd5.ExecuteReader();
                        con5.Close();
                        SqlConnection cn3 = new SqlConnection(src);
                        SqlCommand cmd33 = new SqlCommand("UPDATE [Trip] SET FBookedSeats=@fbooked1, BBookedSeats=@bbooked1, EBookedSeats=@ebooked1 WHERE TripName = '" + label62.Text + "'", cn3);
                        cmd33.Parameters.AddWithValue("@fbooked1", fbooked2);
                        cmd33.Parameters.AddWithValue("@bbooked1", bbooked2);
                        cmd33.Parameters.AddWithValue("@ebooked1", ebooked2);
                        cn3.Open();
                        SqlDataReader dr6 = cmd33.ExecuteReader();
                        cn3.Close();
                        MessageBox.Show("You have been booked this trip successfully!");
                        Program.xtwo.Printtwo(name, label9.Text, label8.Text, label10.Text, label17.Text, label18.Text, label16.Text, label20.Text, label22.Text, label19.Text, meal, label43.Text, confirm, label61.Text, label62.Text, label60.Text, label55.Text, label56.Text, label54.Text, label49.Text, label50.Text, label48.Text, label75.Text,seatclass1,seatclass2);
                        Program.xtwo.Show();
                        label43.Text = "0.00";
                        panel6.Enabled = false;
                        panel8.Enabled = false;
                        label75.Text = "0.00";
                        panel7.Enabled = false;
                        panel11.Enabled = true;
                    }
                }
            }
            else
            {
                if ((MessageBox.Show("Do you want to book this trip as ONE WAY trip ?", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (confirm != "")
                    {
                        if (label46.Text != "No" && checkBox11.Checked == true)
                        {
                            meal = "Yes";
                        }
                        else
                        {
                            meal = "No";
                        }
                        if (rfclass)
                        {
                            fbooked2 = (int.Parse(fbooked2) + 1).ToString();
                            seatclass1 = "F-Class";
                        }
                        else if (rbclass)
                        {
                            bbooked2 = (int.Parse(bbooked2) + 1).ToString();
                            seatclass1 = "B-Class";
                        }
                        else
                        {
                            ebooked2 = (int.Parse(ebooked2) + 1).ToString();
                            seatclass1 = "E-Class";
                        }
                        SqlConnection con5 = new SqlConnection(src);
                        SqlCommand cmd5 = new SqlCommand("INSERT INTO [CustomerTrip](CustomerID,CustomerName,TripID,TripName,TrainID,FromS,ToS,Path,Stops,DepartureTime,ArrivalTime,Meal,SeatClass,Cost,IsConfirmed)VALUES (@id,@name,@label9,@label8,@label10,@label17,@label18,@label16,@label19,@label20,@label22,@meal,@seatclass,@label43,@confirm)", con5);
                        cmd5.Parameters.AddWithValue("@id", id);
                        cmd5.Parameters.AddWithValue("@name", name);
                        cmd5.Parameters.AddWithValue("@label9", label61.Text);
                        cmd5.Parameters.AddWithValue("@label8", label62.Text);
                        cmd5.Parameters.AddWithValue("@label10", label60.Text);
                        cmd5.Parameters.AddWithValue("@label17", label55.Text);
                        cmd5.Parameters.AddWithValue("@label18", label56.Text);
                        cmd5.Parameters.AddWithValue("@label19", label48.Text);
                        cmd5.Parameters.AddWithValue("@label16", label54.Text);
                        cmd5.Parameters.AddWithValue("@label20", label49.Text);
                        cmd5.Parameters.AddWithValue("@label22", label50.Text);
                        cmd5.Parameters.AddWithValue("@label43", label75.Text);
                        cmd5.Parameters.AddWithValue("@meal", meal);
                        cmd5.Parameters.AddWithValue("@seatclass", seatclass1);
                        cmd5.Parameters.AddWithValue("@confirm", confirm);
                        con5.Open();
                        SqlDataReader dr5 = cmd5.ExecuteReader();
                        con5.Close();
                        SqlConnection cn3 = new SqlConnection(src);
                        SqlCommand cmd33 = new SqlCommand("UPDATE [Trip] SET FBookedSeats=@fbooked1, BBookedSeats=@bbooked1, EBookedSeats=@ebooked1 WHERE TripName = '" + label62.Text + "'", cn3);

                        cmd33.Parameters.AddWithValue("@fbooked1", fbooked2);
                        cmd33.Parameters.AddWithValue("@bbooked1", bbooked2);
                        cmd33.Parameters.AddWithValue("@ebooked1", ebooked2);
                        cn3.Open();
                        SqlDataReader dr6 = cmd33.ExecuteReader();
                        cn3.Close();
                        MessageBox.Show("You have been booked this trip successfully!");
                        string tik = "No";
                        Program.xone.PrintOneWayt(name, label61.Text, label62.Text, label60.Text, label55.Text, label56.Text, label54.Text, label49.Text, label50.Text, label48.Text, meal, label75.Text, confirm, tik,seatclass1);
                        Program.xone.Show();
                        label43.Text = "0.00";
                        panel6.Enabled = false;
                        panel8.Enabled = false;
                        label75.Text = "0.00";
                        panel7.Enabled = false;
                    }
                }
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                panel11.Enabled = false;
            }
            else
            {
                panel11.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            panel6.Enabled = false;
        }

        private void checkBox3_CheckedChanged ( object sender, EventArgs e )
        {

        }

    }
}
