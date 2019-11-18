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
    public partial class Form2 : Form
    {
        private string src = Program.xsrc;
        public Form2 ()
        {
            InitializeComponent ();
        }

        public int row1 = 0;
        public bool select1 = false;
        public string name;
        public string id;
        public void Form2_Load ( object sender, EventArgs e )
        {
        }

        public void start ()
        {
            em = false;
            label11.Visible = true;
            label2.Visible = false;
            panel2.Visible = false;
            row1 = 0;
            name = Program.xcust.name;
            id = Program.xcust.id;
            dataGridView1.Rows.Clear ();
            SqlConnection con = new SqlConnection ( src );
            con.Open ();
            SqlCommand cmd = new SqlCommand ( "select * from CustomerTrip", con );
            SqlDataReader dr = cmd.ExecuteReader ();
            while ( dr.Read () )
            {
                if ( DateTime.Parse ( dr [ "DepartureTime" ].ToString () ) >= DateTime.Now && dr [ "CustomerName" ].ToString () == name )
                {
                    dataGridView1.Rows.Insert ( row1, dr [ "ID" ].ToString (), dr [ "TripID" ].ToString (), dr [ "TrainID" ].ToString (), dr [ "TripName" ].ToString (), dr [ "CustomerName" ].ToString (), dr [ "FromS" ].ToString (), dr [ "ToS" ].ToString (), dr [ "Path" ].ToString (), DateTime.Parse ( dr [ "DepartureTime" ].ToString () ).ToString (), DateTime.Parse ( dr [ "ArrivalTime" ].ToString () ).ToString (), dr [ "Stops" ].ToString (), dr [ "Meal" ].ToString (), dr [ "SeatClass" ].ToString (), dr [ "Cost" ].ToString (), dr [ "IsConfirmed" ].ToString () );
                    row1++;
                    select1 = true;
                }
            }
            if ( row1 == 0 )
            {
                select1 = false;
                MessageBox.Show ( "There are no booked trips !!,\n Please try to book trips." );
            }
            dr.Close ();

            label21.Text = "Total number of Resevations : " + row1;
        }
        public string seat;
        public bool em = false;
        public void emp ()
        {
            em = true;
            label11.Visible = false;
            label2.Visible = true;
            panel2.Visible = true;
            row1 = 0;
            dataGridView1.Rows.Clear ();
            SqlConnection con5 = new SqlConnection ( src );
            con5.Open ();
            SqlCommand cmd = new SqlCommand ( "select * from CustomerTrip", con5 );
            SqlDataReader dr = cmd.ExecuteReader ();
            while ( dr.Read () )
            {
                if ( DateTime.Parse ( dr [ "DepartureTime" ].ToString () ) >= DateTime.Now )
                {
                    dataGridView1.Rows.Insert ( row1, dr [ "ID" ].ToString (), dr [ "TripID" ].ToString (), dr [ "TrainID" ].ToString (), dr [ "TripName" ].ToString (), dr [ "CustomerName" ].ToString (), dr [ "FromS" ].ToString (), dr [ "ToS" ].ToString (), dr [ "Path" ].ToString (), DateTime.Parse ( dr [ "DepartureTime" ].ToString () ).ToString (), DateTime.Parse ( dr [ "ArrivalTime" ].ToString () ).ToString (), dr [ "Stops" ].ToString (), dr [ "Meal" ].ToString (), dr [ "SeatClass" ].ToString (), dr [ "Cost" ].ToString (), dr [ "IsConfirmed" ].ToString () );
                    row1++;
                    select1 = true;
                }
            }
            if ( row1 == 0 )
            {
                select1 = false;
                MessageBox.Show ( "There are no booked trips !!" );
            }
            dr.Close ();
            con5.Close ();

            label21.Text = "Total number of Resevations : " + row1;
        }
        public void confirm ()
        {
            string confirm = "Confirmed";
            SqlConnection cn1 = new SqlConnection ( src );
            SqlCommand cmd1 = new SqlCommand ( "UPDATE [CustomerTrip] SET IsConfirmed=@fbooked1 WHERE ID = '" + label113.Text + "'", cn1 );
            cmd1.Parameters.AddWithValue ( "@fbooked1", confirm );
            cn1.Open ();
            SqlDataReader dr1 = cmd1.ExecuteReader ();
            cn1.Close ();
            MessageBox.Show ( "You have been confirmed this trip successfully!" );
            label112.Text = confirm;
            if ( em )
            {
                emp ();
            }
            else
            {
                start ();
            }
        }
        private void button4_Click ( object sender, EventArgs e )
        {
            if ( select1 )
            {
                this.panel3.Visible = true;
                label113.Text = dataGridView1.Rows [ rowindex ].Cells [ 0 ].Value.ToString ();
                label101.Text = dataGridView1.Rows [ rowindex ].Cells [ 1 ].Value.ToString ();
                label103.Text = dataGridView1.Rows [ rowindex ].Cells [ 2 ].Value.ToString ();
                label102.Text = dataGridView1.Rows [ rowindex ].Cells [ 3 ].Value.ToString ();
                label100.Text = dataGridView1.Rows [ rowindex ].Cells [ 4 ].Value.ToString ();
                label104.Text = dataGridView1.Rows [ rowindex ].Cells [ 5 ].Value.ToString ();
                label105.Text = dataGridView1.Rows [ rowindex ].Cells [ 6 ].Value.ToString ();
                label106.Text = dataGridView1.Rows [ rowindex ].Cells [ 7 ].Value.ToString ();
                label107.Text = dataGridView1.Rows [ rowindex ].Cells [ 8 ].Value.ToString ();
                label108.Text = dataGridView1.Rows [ rowindex ].Cells [ 9 ].Value.ToString ();
                label109.Text = dataGridView1.Rows [ rowindex ].Cells [ 10 ].Value.ToString ();
                label110.Text = dataGridView1.Rows [ rowindex ].Cells [ 11 ].Value.ToString ();
                label111.Text = dataGridView1.Rows [ rowindex ].Cells [ 13 ].Value.ToString ();
                label112.Text = dataGridView1.Rows [ rowindex ].Cells [ 14 ].Value.ToString ();
                seat = dataGridView1.Rows [ rowindex ].Cells [ 12 ].Value.ToString ();
                label5.Text = seat;
            }
        }
        public int rowindex;
        private void dataGridView1_CellClick ( object sender, DataGridViewCellEventArgs e )
        {
            if ( row1 > 0 )
            {
                select1 = true;
                rowindex = dataGridView1.CurrentCell.RowIndex;
            }
        }

        private void button2_Click ( object sender, EventArgs e )
        {
            if ( label113.Text != "****" )
            {
                Program.xone.PrintOneWayt ( label100.Text, label101.Text, label102.Text, label103.Text, label104.Text, label105.Text, label106.Text, label107.Text, label108.Text, label109.Text, label110.Text, label111.Text, label112.Text, label113.Text, label5.Text );
                Program.xone.Show ();
            }
            else
            {
                MessageBox.Show ( "Please select a trip !!" );
            }
        }

        private void button1_Click ( object sender, EventArgs e )
        {
            if ( label113.Text != "****" )
            {
                if ( label112.Text == "Not Confirmed" )
                {
                    if ( ( MessageBox.Show ( "Are you sure you want to confirm this trip ?", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes ) )
                    {
                        if ( em )
                        {
                            confirm ();
                        }
                        else
                        {
                            Program.xconf.Show ();
                        }
                    }
                }
                else
                {
                    MessageBox.Show ( "This trip is already confirmed\n Please select another one !!" );
                }
            }
            else
            {
                MessageBox.Show ( "Please select a trip !!" );
            }
        }

        private void button7_Click ( object sender, EventArgs e )
        {
            this.Hide ();
            if ( panel2.Visible == true )
            {
                if ( Program.xstart.job == "adm" )
                {
                    Program.xadm.backgr ();
                }
                else if ( Program.xstart.job == "emp" )
                {
                    Program.xemp.backgr ();
                }
            }
            else
            {
                Program.xcust.backgr ();
            }
        }

        private void button3_Click ( object sender, EventArgs e )
        {
            dataGridView1.Rows.Clear ();
            SqlConnection con1 = new SqlConnection ( src );
            con1.Open ();
            SqlCommand cmd1 = new SqlCommand ( "select * from CustomerTrip", con1 );
            SqlDataReader dr1 = cmd1.ExecuteReader ();
            if ( comboBox2.Text == "" && textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" )
            {
                MessageBox.Show ( "Please insert a valid information to help you for quick search!!" );
            }
            else
            {
                row1 = 0;
                while ( dr1.Read () )
                {
                    if ( comboBox2.Text != "" && textBox1.Text != "" && textBox2.Text != "" )
                    {
                        name = comboBox2.Text + " " + textBox1.Text + " " + textBox2.Text;

                        if ( dr1 [ "CustomerName" ].ToString () == name && DateTime.Parse ( dr1 [ "DepartureTime" ].ToString () ) >= DateTime.Now )
                        {
                            dataGridView1.Rows.Insert ( row1, dr1 [ "ID" ].ToString (), dr1 [ "TripID" ].ToString (), dr1 [ "TrainID" ].ToString (), dr1 [ "TripName" ].ToString (), dr1 [ "CustomerName" ].ToString (), dr1 [ "FromS" ].ToString (), dr1 [ "ToS" ].ToString (), dr1 [ "Path" ].ToString (), DateTime.Parse ( dr1 [ "DepartureTime" ].ToString () ).ToString (), DateTime.Parse ( dr1 [ "ArrivalTime" ].ToString () ).ToString (), dr1 [ "Stops" ].ToString (), dr1 [ "Meal" ].ToString (), dr1 [ "SeatClass" ].ToString (), dr1 [ "Cost" ].ToString (), dr1 [ "IsConfirmed" ].ToString () );
                            row1++;
                            select1 = true;
                        }
                    }

                    if ( textBox3.Text != "" )
                    {
                        if ( dr1 [ "ID" ].ToString () == textBox3.Text && DateTime.Parse ( dr1 [ "DepartureTime" ].ToString () ) >= DateTime.Now )
                        {

                            dataGridView1.Rows.Insert ( row1, dr1 [ "ID" ].ToString (), dr1 [ "TripID" ].ToString (), dr1 [ "TrainID" ].ToString (), dr1 [ "TripName" ].ToString (), dr1 [ "CustomerName" ].ToString (), dr1 [ "FromS" ].ToString (), dr1 [ "ToS" ].ToString (), dr1 [ "Path" ].ToString (), DateTime.Parse ( dr1 [ "DepartureTime" ].ToString () ).ToString (), DateTime.Parse ( dr1 [ "ArrivalTime" ].ToString () ).ToString (), dr1 [ "Stops" ].ToString (), dr1 [ "Meal" ].ToString (), dr1 [ "SeatClass" ].ToString (), dr1 [ "Cost" ].ToString (), dr1 [ "IsConfirmed" ].ToString () );
                            row1++;
                            select1 = true;
                        }
                    }

                }
                if ( row1 == 0 )
                {
                    select1 = false;
                    MessageBox.Show ( "There are no trips match !!,\n Please try to search again." );
                }
                dr1.Close ();
                con1.Close ();

                label21.Text = "Total number of Resevations : " + row1;
            }
        }

        private void button5_Click ( object sender, EventArgs e )
        {
            row1 = 0;
            dataGridView1.Rows.Clear ();
            SqlConnection con2 = new SqlConnection ( src );
            con2.Open ();
            SqlCommand cmd = new SqlCommand ( "select * from CustomerTrip", con2 );
            SqlDataReader dr = cmd.ExecuteReader ();
            while ( dr.Read () )
            {
                if ( DateTime.Parse ( dr [ "DepartureTime" ].ToString () ) >= DateTime.Now )
                {
                    dataGridView1.Rows.Insert ( row1, dr [ "ID" ].ToString (), dr [ "TripID" ].ToString (), dr [ "TrainID" ].ToString (), dr [ "TripName" ].ToString (), dr [ "CustomerName" ].ToString (), dr [ "FromS" ].ToString (), dr [ "ToS" ].ToString (), dr [ "Path" ].ToString (), DateTime.Parse ( dr [ "DepartureTime" ].ToString () ).ToString (), DateTime.Parse ( dr [ "ArrivalTime" ].ToString () ).ToString (), dr [ "Stops" ].ToString (), dr [ "Meal" ].ToString (), dr [ "SeatClass" ].ToString (), dr [ "Cost" ].ToString (), dr [ "IsConfirmed" ].ToString () );
                    row1++;
                    select1 = true;
                }
            }
            if ( row1 == 0 )
            {
                select1 = false;
                MessageBox.Show ( "There are no booked trips !!" );
            }
            dr.Close ();
            con2.Close ();

            label21.Text = "Total number of Resevations : " + row1;
        }

        private void panel2_Paint ( object sender, PaintEventArgs e )
        {

        }
    }
}
