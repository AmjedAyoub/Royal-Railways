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
    public partial class Addtrip : Form
    {
        public bool info=false;
        public bool stationfound;
        public string str1 = "";
        public string str2 = "";
        public string time = "";
        public string duration;
        private string src = Program.xsrc;
        public Addtrip()
        {
            InitializeComponent();
        }

        public void Addtrip_Load(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            info=false;
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate1 = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            textBox8.Text = theDate1.ToString();
        }
        public string fcost;
        public string bcost;
        public string ecost;
        public string meal;
        private void button3_Click(object sender, EventArgs e)
        {

            bool ok = true;
            if (comboBox2.Text == comboBox3.Text) 
            {
                if (comboBox2.Text == "") { MessageBox.Show("Please select source and distanation !!"); }
                else
                {
                    MessageBox.Show("You have been selected same source and distanation !!");
                    comboBox3.Text = "";
                    comboBox2.Text = "";
                }
            }
            else if(textBox8.Text == ""||comboBox6.Text == ""||comboBox7.Text==""){MessageBox.Show("Please select a departure time");}
                else if(textBox2.Text==""||textBox3.Text==""||textBox7.Text==""){MessageBox.Show("Please insert costs");}
            else
            {
                SqlConnection con = new SqlConnection(src);
                SqlConnection con1 = new SqlConnection(src);
                con.Open();
                bool found = false;
                SqlCommand cmd1 = new SqlCommand("select * from Trip", con);
                SqlDataReader dr = cmd1.ExecuteReader();
                time =DateTime.Parse(textBox8.Text).AddHours(double.Parse(comboBox6.Text)).AddMinutes(double.Parse(comboBox7.Text)).ToString();
                bool tn = false;
                    while (dr.Read())
                {
                        if(dr["TripName"].ToString()==textBox5.Text)
                        { MessageBox.Show("Please select another name for the trip !!"); tn = true; textBox5.Text = ""; found = true; ok = false; break; }
                    if (dr["TrainName"].ToString() == comboBox1.Text)
                    {
                        if (DateTime.Parse(dr["ArrivalTime"].ToString()) >= DateTime.Parse(time) || (DateTime.Parse(time) <= DateTime.Now))
                        {
                            found = true;
                        }
                    }
                }
                if (found)
                {
                    if (!tn)
                    {
                        MessageBox.Show("This train is busy at that departure time\n please select another train !!\n *OR select another depature time !!");
                        comboBox1.Text = "";
                    }
                    dr.Close();
                    con.Close();
                }
                else
                {
                    dr.Close();
                        con.Close();
                        info = true;
                    con1.Open();
                    if(comboBox4.Text!="")
                            {
                                  time=(DateTime.Parse(time).AddMinutes(20.0)).ToString();
                            }
                            
                    SqlCommand cmd = new SqlCommand("select * from Stations", con1);
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    while (dr1.Read())
                    {
                        if (dr1["FromS"].ToString() == comboBox2.Text && dr1["ToS"].ToString() == comboBox3.Text)
                        {
                            stationfound = true;
                            time=(DateTime.Parse(time).AddMinutes(double.Parse(dr1["Duration"].ToString()))).ToString();
                            duration=dr1["Duration"].ToString();
                            str1 = dr1["Path"].ToString();
                        }
                    }
                    dr1.Close();
                    con1.Close();
                    SqlConnection con2 = new SqlConnection(src);
                    con2.Open();
                   if (stationfound==false)
                   {
                       duration = "0.0";
                        SqlCommand cmd2 = new SqlCommand("select * from Stations", con2);
                         SqlDataReader dr2 = cmd2.ExecuteReader();
                         while (dr2.Read())
                          {
                              if (dr2["FromS"].ToString() == comboBox2.Text && dr2["ToS"].ToString() == "Amman")
                             {
                                 time=(DateTime.Parse(time).AddMinutes(double.Parse(dr2["Duration"].ToString()))).ToString();
                                 if (dr2["Path"].ToString() != "No") { str1 = comboBox2.Text + '>' + dr2["Path"].ToString() + '>' + "Amman"; }
                                 else { str1 = comboBox2.Text + '>' + "Amman"; }
                                 duration = (double.Parse(duration) + double.Parse(dr2["Duration"].ToString())).ToString();
                              }
                            if (dr2["FromS"].ToString() == "Amman" && dr2["ToS"].ToString() == comboBox3.Text)
                            {
                                time=(DateTime.Parse(time).AddMinutes(double.Parse(dr2["Duration"].ToString()))).ToString();
                                if (dr2["Path"].ToString() != "No") { str2 = '>' + dr2["Path"].ToString() + '>' + comboBox3.Text; }
                                else { str2 =  '>' + comboBox3.Text ; }
                                duration = (double.Parse(duration) + double.Parse(dr2["Duration"].ToString())).ToString();
                            }
                        }

                         dr2.Close();
                         
                   }
                   string d = duration;
                   if (comboBox4.Text != "")
                   {
                       d = (double.Parse(d) + 20.0).ToString();
                   }
                   fcost = (double.Parse(textBox2.Text) / double.Parse(d)).ToString();
                   bcost = (double.Parse(textBox7.Text) / double.Parse(d)).ToString();
                   ecost = (double.Parse(textBox3.Text) / double.Parse(d)).ToString();
                   con2.Close();
                    info = true;
                    bool r = false;
                    string t="";
                    if (checkBox1.Checked)
                    {
                        t=DateTime.Parse(textBox4.Text).AddHours(double.Parse(comboBox8.Text)).AddMinutes(double.Parse(comboBox5.Text)).ToString();
                        if (DateTime.Parse(t) <= DateTime.Parse(time) || DateTime.Parse(t) < DateTime.Now)
                        {
                            MessageBox.Show("Please select another return time !!");
                            textBox4.Text = "";
                            comboBox5.Text = "";
                            comboBox8.Text = "";
                            ok = false;
                        }
                        else { r = true; ok = true; }
                    }
                    if (ok)
                    {
                        MessageBox.Show("You have been filled up information successfully \n You can submit to create the trip.");
                        textBox1.Text = time;
                        if (textBox9.Text == "" || textBox9.Text == " ")
                        {
                            meal = "No";
                        }
                        else
                        {
                            meal = textBox9.Text;
                        }
                            if (stationfound)
                        {
                            string pathS;
                            if (str1 != "No")
                            {
                                pathS = comboBox2.Text + '>' + str1 + '>' + comboBox3.Text;
                               
                            }
                            else
                            {
                                pathS = comboBox2.Text + '>' + comboBox3.Text;
                            }
                            string[] path1 = pathS.Split('>');
                            Stime(path1,r,t);
                        }
                        else
                        {
                            string pathS = str1 + str2;
                            string[] path1 = pathS.Split('>');
                            Stime(path1,r,t);
                        }
                        
                    }

                   }
            }
        }
        public string depsttime;
        private void button1_Click(object sender, EventArgs e)
        {
            if (!info)
            {
                MessageBox.Show("Please press the \"Check\" button to check your information\n before submiting the trip");
            }
            else
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    SqlConnection con6 = new SqlConnection(src);
                    SqlCommand cmd6 = new SqlCommand("INSERT INTO [Trip](TripName,TrainName,FromS,ToS,Path,Stops,DepatureTime,ArrivalTime,Duration,FClassCost,BClassCost,EClassCost,Meal,FClassSeats,BClassSeats,EClassSeats,FBookedSeats,BBookedSeats,EBookedSeats)VALUES (@tid,@combBox1,@combBox2,@combBox3,@pathS,@stop,@Deptime,@time,@dur,@textBox2,@textBox7,@textBox3,@textBox9,@bcs,@fcs,@ecs,@fbs,@bbs,@ebs)", con6);
                    cmd6.Parameters.AddWithValue("@tid", dataGridView1.Rows[i].Cells[0].Value.ToString());
                    cmd6.Parameters.AddWithValue("@combBox1", dataGridView1.Rows[i].Cells[1].Value.ToString());
                    cmd6.Parameters.AddWithValue("@combBox2", dataGridView1.Rows[i].Cells[2].Value.ToString());
                    cmd6.Parameters.AddWithValue("@combBox3", dataGridView1.Rows[i].Cells[3].Value.ToString());
                    cmd6.Parameters.AddWithValue("@pathS", dataGridView1.Rows[i].Cells[7].Value.ToString());
                    cmd6.Parameters.AddWithValue("@stop", dataGridView1.Rows[i].Cells[8].Value.ToString());
                    cmd6.Parameters.AddWithValue("@Deptime", dataGridView1.Rows[i].Cells[4].Value.ToString());
                    cmd6.Parameters.AddWithValue("@time", dataGridView1.Rows[i].Cells[5].Value.ToString());
                    cmd6.Parameters.AddWithValue("@dur", dataGridView1.Rows[i].Cells[6].Value.ToString());
                    cmd6.Parameters.AddWithValue("@textBox2", dataGridView1.Rows[i].Cells[9].Value.ToString());
                    cmd6.Parameters.AddWithValue("@textBox7", dataGridView1.Rows[i].Cells[10].Value.ToString());
                    cmd6.Parameters.AddWithValue("@textBox3", dataGridView1.Rows[i].Cells[11].Value.ToString());
                    cmd6.Parameters.AddWithValue("@textBox9", dataGridView1.Rows[i].Cells[12].Value.ToString());
                    cmd6.Parameters.AddWithValue("@fcs", dataGridView1.Rows[i].Cells[13].Value.ToString());
                    cmd6.Parameters.AddWithValue("@bcs", dataGridView1.Rows[i].Cells[14].Value.ToString());
                    cmd6.Parameters.AddWithValue("@ecs", dataGridView1.Rows[i].Cells[15].Value.ToString());
                    cmd6.Parameters.AddWithValue("@fbs", dataGridView1.Rows[i].Cells[16].Value.ToString());
                    cmd6.Parameters.AddWithValue("@bbs", dataGridView1.Rows[i].Cells[17].Value.ToString());
                    cmd6.Parameters.AddWithValue("@ebs", dataGridView1.Rows[i].Cells[18].Value.ToString());

                    con6.Open();
                    SqlDataReader dr6 = cmd6.ExecuteReader();
                    con6.Close();

                } MessageBox.Show("You have been added trips successfully !");
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                textBox5.Text = "";
                comboBox5.Text = "";
                comboBox6.Text = "";
                comboBox7.Text = "";
                comboBox8.Text = "";
                textBox1.Text = ""; 
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                checkBox1.Checked = false;
                dataGridView1.Rows.Clear();
            }
        }

        public static List<string> DTime=new List<string>();
        public static List<string> ATime = new List<string>();
        public static List<string> RDTime = new List<string>();
        public static List<string> RATime = new List<string>();
        public static string trainid;
        public static string fseats;
        public static string bseats;
        public static string eseats;
        private void Stime(string[] p, bool ret, string rt)
        {
            dataGridView1.Rows.Clear();
            SqlConnection con5 = new SqlConnection(src);
            con5.Open();
            SqlCommand cmd5 = new SqlCommand("select * from Train", con5);
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                if (dr5["Name"].ToString() == comboBox1.Text)
                {
                    trainid = dr5["ID"].ToString();
                    fseats = dr5["FClassSeats"].ToString();
                    bseats = dr5["BClassSeats"].ToString();
                    eseats = dr5["EClassSeats"].ToString();
                }
            }
            con5.Close();
            string DT = DateTime.Parse(textBox8.Text).AddHours(double.Parse(comboBox6.Text)).AddMinutes(double.Parse(comboBox7.Text)).ToString();
            string Dura="0.0";
            string AT;
            string tname = textBox5.Text;
            for (int i = 0; i < p.Length - 1; i++)
            {
                if (i == 0) 
                {
                    DTime.Add(DT);
                    ATime.Add("0");
                }
                SqlConnection con4 = new SqlConnection(src);
                con4.Open();
                SqlCommand cmd4 = new SqlCommand("select * from Stations", con4);
                SqlDataReader dr4 = cmd4.ExecuteReader();
                while (dr4.Read())
                {
                    if (dr4["FromS"].ToString() == p[i] && dr4["ToS"].ToString() == p[i + 1])
                    {
                        Dura = dr4["Duration"].ToString();
                    }
                }
                con4.Close();
                AT= DateTime.Parse(DT).AddMinutes(double.Parse(Dura)).ToString();
                ATime.Add(AT);
                if (i + 1 != p.Length - 1)
                {
                    if (p[i + 1] == comboBox4.Text)
                    {
                        DT = DateTime.Parse(AT).AddMinutes(20.0).ToString();
                        DTime.Add(DT);
                    }
                    else
                    {
                        DT = AT;
                        DTime.Add(DT);
                    }
                }
                else { DTime.Add("0"); }
            }
            int row = 0;
            for (int s = 0; s < p.Length-1; s++)
            {
                for (int j = s + 1; j < p.Length; j++)
                {
                    string pa = "";
                    int c=s;
                    string dur = "";
                    string sto = "";
                    while (c <= j)
                    {
                        if (p[c] == comboBox4.Text) { sto = p[c]; }
                        pa = pa + '>' + p[c];
                        c++;
                    }
                    dur = DateTime.Parse(ATime[j]).Subtract(DateTime.Parse(DTime[s])).TotalMinutes.ToString();
                    string f = Math.Round((double.Parse(fcost) * double.Parse(dur)), 2).ToString();
                    string b = Math.Round((double.Parse(bcost) * double.Parse(dur)), 2).ToString();
                    string e = Math.Round((double.Parse(ecost) * double.Parse(dur)), 2).ToString();
                    dataGridView1.Rows.Insert(row, tname, comboBox1.Text, p[s], p[j], DTime[s], ATime[j], dur, pa, sto, f, b, e, meal, fseats, bseats, eseats, "0", "0" ,"0");
                    row++;
                }

            }
            if (ret)
            {
                tname = "R-" + tname;
                string RDT = DateTime.Parse(rt).ToString();
                string RDura = "0.0";
                string RAT;
                string[] rp=new string[p.Length];
                int x = 0 ;
                for (int i = p.Length - 1; i >= 0; i--)
                {
                    rp[x] = p[i];
                    x++;
                }
                for (int i = 0; i < rp.Length - 1; i++)
                {
                    if (i == 0)
                    {
                        RDTime.Add(RDT);
                        RATime.Add("0");
                    }
                    SqlConnection con3 = new SqlConnection(src);
                    con3.Open();
                    SqlCommand cmd3 = new SqlCommand("select * from Stations", con3);
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    while (dr3.Read())
                    {
                        if (dr3["FromS"].ToString() == rp[i] && dr3["ToS"].ToString() == rp[i + 1])
                        {
                            RDura = dr3["Duration"].ToString();
                        }
                    }
                    con3.Close();
                    RAT = DateTime.Parse(RDT).AddMinutes(double.Parse(RDura)).ToString();
                    RATime.Add(RAT);
                    if (i + 1 != rp.Length - 1)
                    {
                        if (rp[i + 1] == comboBox4.Text)
                        {
                            RDT = DateTime.Parse(RAT).AddMinutes(20.0).ToString();
                            RDTime.Add(RDT);
                        }
                        else
                        {
                            RDT = RAT;
                            RDTime.Add(RDT);
                        }
                    }
                    else { RDTime.Add("0"); }
                }
                for (int s = 0; s < rp.Length - 1; s++)
                {
                    for (int j = s + 1; j < rp.Length; j++)
                    {
                        string rpa = "";
                        int rc = s;
                        string rdur = "";
                        string rsto = "";
                        while (rc <= j)
                        {
                            if (p[rc] == comboBox4.Text) { rsto = p[rc]; }
                            rpa = rpa + '>' + p[rc] ;
                            rc++;
                        }
                        rdur = DateTime.Parse(RATime[j]).Subtract(DateTime.Parse(RDTime[s])).TotalMinutes.ToString();
                        string rf = Math.Round((double.Parse(fcost) * double.Parse(rdur)), 2).ToString();
                        string rb = Math.Round((double.Parse(bcost) * double.Parse(rdur)), 2).ToString();
                        string re = Math.Round((double.Parse(ecost) * double.Parse(rdur)), 2).ToString();

                        dataGridView1.Rows.Insert(row, tname, comboBox1.Text, rp[s], rp[j], RDTime[s], RATime[j], rdur, rpa, rsto, rf, rb, re, meal, fseats, bseats, eseats, "0", "0", "0");
                        row++;
                    }

                }
            }
            label21.Text = "Total number of Trips : " + row;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                panel2.Enabled = true;
            }
            else
            {
                panel2.Enabled = false;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string theDate2 = dateTimePicker2.Value.ToString("MM/dd/yyyy");
            textBox4.Text = theDate2.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            textBox5.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            checkBox1.Checked = false;
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

       
        
    }
}