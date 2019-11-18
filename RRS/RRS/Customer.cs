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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        public void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to signout ?", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                Program.xstart.job = "cus";
                this.Hide();
                Program.xstart.signout();
            } 
        }
        public string name = "";
        public string id = "";
        public void namedisplay()
        {
            label1.Text = "Welcome "+Program.xstart.name+".";
            name = Program.xstart.name;
            id = Program.xstart.id;
        }
        public void backgr()
        {
            panel1.Controls.Clear();
            Program.xpic.TopLevel = false;
            Program.xpic.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xpic);
        }
        private void Customer_Load(object sender, EventArgs e)
        {

        }

        public void viewAvailableTripsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xcvt.TopLevel = false;
            Program.xcvt.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xcvt);
            Program.xcvt.Viewcustrip_Load(sender, e);
        }

        public void bookReservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xbook.TopLevel = false;
            Program.xbook.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xbook);
            Program.xbook.Cusbook_Load(sender, e);
        }

        public void cancelReservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xf2.TopLevel = false;
            Program.xf2.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xf2);
            Program.xf2.start();
        }

        public void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xmsg.TopLevel = false;
            Program.xmsg.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xmsg);
            Program.xmsg.start();
        }
    }
}
