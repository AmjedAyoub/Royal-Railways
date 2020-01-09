using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RRS
{
    public partial class Form1 : Form
    {
        public string job;
        public string cusstatus;
        public string empstatus;
        public string admstatus;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            label2.Text = DateTime.Now.ToLongTimeString();
            label1.Text = DateTime.Now.ToLongDateString();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to Exit ?", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                Application.Exit();
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            homeToolStripMenuItem_Click(sender, e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        int u = 0;
        List<string> stations = new List<string> {"R.R.","Welcome","To Our","Stations","In","Amman",  "Al Balqa'",  "Jarash",  "Ajlun",  "Irbid",  "Az Zarqa'",  "Al Mafraq",  "Al Karak",  "Madaba",  "At Tafilah",  "Ma'an",  "Aqaba" };
        int i = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = 10;
            if (u > 50 && u < 90)
            {
                label4.Text = "";
            }
            else
            {
                label4.Text = "Provision of safe && reliable rail transport service for passengers in Jordan, economically and efficiently.";
            }
            if (u == 100)
            {
                u = 0;
                label7.Text = stations[i];
                i++;
            }
            u++;
            if (i == 17) i = 0;
        }

        public void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }
        public void signup()
        {
            panel1.Controls.Clear();
            Program.xsignup.TopLevel = false;
            Program.xsignup.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xsignup);
        }
        

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        public void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xhome.TopLevel = false;
            Program.xhome.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xhome);
        }

        public void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xsignup.TopLevel = false;
            Program.xsignup.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xsignup); 
        }

        public void signUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.xstart.job = "cus";
            panel1.Controls.Clear();
            Program.xstart.TopLevel = false;
            Program.xstart.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xstart);
            Program.xstart.Start_Load(sender, e);
        }

        public void stationsMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xmap.TopLevel = false;
            Program.xmap.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xmap);
        }

        public void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xabout.TopLevel = false;
            Program.xabout.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xabout);
        }

        public void signUpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xsignup.TopLevel = false;
            Program.xsignup.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xsignup);
        }
        
        public void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cusstatus = Program.xstart.cusstatus;
            if (cusstatus == "in")
            {
                panel1.Controls.Clear();
                Program.xcust.TopLevel = false;
                Program.xcust.Visible = true;
                this.Controls.Add(panel1);
                panel1.Controls.Add(Program.xcust);
               
            }
            else 
            {
                Program.xstart.job = "cus";
                panel1.Controls.Clear();
                Program.xstart.TopLevel = false;
                Program.xstart.Visible = true;
                this.Controls.Add(panel1);
                panel1.Controls.Add(Program.xstart);
                Program.xstart.Start_Load(sender, e);
            }
        }

        public void signInToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.xstart.job = "emp";
            panel1.Controls.Clear();
            Program.xstart.TopLevel = false;
            Program.xstart.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xstart);
            Program.xstart.Start_Load(sender, e);
        }

        public void signInToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Program.xstart.job = "adm";
            panel1.Controls.Clear();
            Program.xstart.TopLevel = false;
            Program.xstart.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xstart);
            Program.xstart.Start_Load(sender, e);
        }

        public void profileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.xstart.job = "emp";
            empstatus = Program.xstart.empstatus;
            if (empstatus == "in")
            {
                panel1.Controls.Clear();
                Program.xemp.TopLevel = false;
                Program.xemp.Visible = true;
                this.Controls.Add(panel1);
                panel1.Controls.Add(Program.xemp);

            }
            else
            {
                Program.xstart.job = "emp";
                panel1.Controls.Clear();
                Program.xstart.TopLevel = false;
                Program.xstart.Visible = true;
                this.Controls.Add(panel1);
                panel1.Controls.Add(Program.xstart);
                Program.xstart.Start_Load(sender, e);
            }
        }

        public void profileToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Program.xstart.job = "adm";
            admstatus = Program.xstart.admstatus;
            if (admstatus == "in")
            {
                panel1.Controls.Clear();
                Program.xadm.TopLevel = false;
                Program.xadm.Visible = true;
                this.Controls.Add(panel1);
                panel1.Controls.Add(Program.xadm);

            }
            else
            {
                Program.xstart.job = "adm";
                panel1.Controls.Clear();
                Program.xstart.TopLevel = false;
                Program.xstart.Visible = true;
                this.Controls.Add(panel1);
                panel1.Controls.Add(Program.xstart);
                Program.xstart.Start_Load(sender, e);
            }
        }

        public void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xcontact.TopLevel = false;
            Program.xcontact.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xcontact);
        }

        public void guestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xguest.TopLevel = false;
            Program.xguest.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xguest);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Program.xf2.Show();
        }

        public void backgr()
        {
            panel1.Controls.Clear();
            Program.xpic.TopLevel = false;
            Program.xpic.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xpic);
        }

        private void panel5_Paint ( object sender, PaintEventArgs e )
        {

        }

    }
}
