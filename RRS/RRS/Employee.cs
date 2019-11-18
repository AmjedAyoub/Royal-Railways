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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        public void namedisplay()
        {
            label1.Text = "Welcome " + Program.xstart.name + ".";
        }
        public void backgr()
        {
            panel1.Controls.Clear();
            Program.xpic.TopLevel = false;
            Program.xpic.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xpic);
        }
        public void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to signout ?", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                Program.xstart.job = "emp";
                this.Hide();
                Program.xstart.signout();
            }
        }

        public void addNewTrainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xaddtr.TopLevel = false;
            Program.xaddtr.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xaddtr);
        }

        public void deleteTrainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xdeltr.TopLevel = false;
            Program.xdeltr.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xdeltr);
            Program.xdeltr.Deletetrain_Load(sender, e);
        }

        public void addNewTripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xaddtrp.TopLevel = false;
            Program.xaddtrp.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xaddtrp);
            Program.xaddtrp.Addtrip_Load(sender, e);
        }

        public void viewAvailableTripsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xvtrip.TopLevel = false;
            Program.xvtrip.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xvtrip);
            Program.xvtrip.Viewtrip_Load(sender, e);
        }

        public void cancelTripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xctrp.TopLevel = false;
            Program.xctrp.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xctrp);
            Program.xctrp.Canceltrip_Load(sender, e);
        }

        public void bookReservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xf2.TopLevel = false;
            Program.xf2.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xf2);
            Program.xf2.emp();
        }
    }
}
