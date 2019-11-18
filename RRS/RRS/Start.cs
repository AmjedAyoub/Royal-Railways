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
    public partial class Start : Form
    {
        public string name;
        public string id;
        public string job;
        public string cusstatus;
        public string empstatus;
        public string admstatus;
        public Start()
        {
            InitializeComponent();
        }
        int c = 0;
        public void Start_Load(object sender, EventArgs e)
        {
            if (c > 0)
            {
                panel2.Controls.Clear();
                panel1.Show();
                textBox1.Focus();
            }
            c++;
            
        }

        public object s;
        public EventArgs e;
         
        public void signout()
        {   if (job == "cus")
            {
                cusstatus = "out";

                panel1.Show();
                panel2.Controls.Clear();
                textBox1.Focus();
         
            }
            if (job == "emp")
            {
                empstatus = "out";

                panel1.Show();
                panel2.Controls.Clear();
                textBox1.Focus();
         
            }
            if (job == "adm")
            {
                admstatus = "out";

               panel1.Show();
                panel2.Controls.Clear();
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            textBox1.Text = "";
            textBox2.Text = "";
            Program.xf.backgr();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string src = Program.xsrc;
            SqlConnection con = new SqlConnection(src);
            bool blnfound = false;
            con.Open();
            if (job == "cus")
            {
                SqlCommand cmd = new SqlCommand("select * from Passenger", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["Username"].ToString() == textBox1.Text && textBox1.Text != "")
                    {
                        if (dr["Pass"].ToString() == textBox2.Text)
                        {
                            blnfound = true;
                            name=dr["Gender"].ToString()+" "+dr["Fname"].ToString()+" "+dr["Lname"].ToString();
                            id = dr["ID"].ToString();
                        }
                    }
                }
                if (blnfound == false)
                {
                    MessageBox.Show("wrong username or password please try again ", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                }
                else
                {
                    dr.Close();
                    con.Close();
                    cusstatus = "in";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    panel1.Hide();
                    panel2.Controls.Clear();
                    Program.xcust.TopLevel = false;
                    Program.xcust.Visible = true;
                    this.Controls.Add(panel2);
                    panel2.Controls.Add(Program.xcust);
                    Program.xcust.namedisplay();
                }
            }
            else if (job == "emp")
            {
                SqlCommand cmd = new SqlCommand("select * from Employee", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["Username"].ToString() == textBox1.Text && textBox1.Text != "")
                    {
                        if (dr["Pass"].ToString() == textBox2.Text)
                        {
                            blnfound = true;
                            name = dr["Gender"].ToString() + " " + dr["Fname"].ToString() + " " + dr["Lname"].ToString();
                        }
                    }
                }
                if (blnfound == false)
                {
                    MessageBox.Show("wrong username or password please try again ", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                }
                else
                {
                    dr.Close();
                    con.Close();
                    empstatus = "in";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    panel1.Hide();
                    panel2.Controls.Clear();
                    Program.xemp.TopLevel = false;
                    Program.xemp.Visible = true;
                    this.Controls.Add(panel2);
                    panel2.Controls.Add(Program.xemp);
                    Program.xemp.namedisplay();
                }
            }
            else if (job == "adm")
            {
                SqlCommand cmd = new SqlCommand("select * from Employee", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["Username"].ToString() == textBox1.Text && textBox1.Text != "")
                    {
                        if (dr["Pass"].ToString() == textBox2.Text)
                        {
                            name = dr["Gender"].ToString() + " " + dr["Fname"].ToString() + " " + dr["Lname"].ToString();
                            if (dr["Job"].ToString() == "Administrator")
                            { blnfound = true; }
                            else
                            {
                                MessageBox.Show(name+" you are not an administrator \nplease sign in at the \"Employee page\" \n           Thank You.", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox1.Focus();
                            }
                        }
                    }
                }
                if (blnfound == false)
                {
                    MessageBox.Show("wrong username or password please try again ", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                }
                else
                {
                    dr.Close();
                    con.Close();
                    admstatus = "in";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    panel1.Hide();
                    panel2.Controls.Clear();
                    Program.xadm.TopLevel = false;
                    Program.xadm.Visible = true;
                    this.Controls.Add(panel2);
                    panel2.Controls.Add(Program.xadm);
                    Program.xadm.namedisplay();
                }
            }
        }

        public void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click((object)sender, (EventArgs)e);
            }
        }

        

    }
}
