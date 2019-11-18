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
 public partial class Viewcustrip : Form
 {
     private string src = Program.xsrc;
     public Viewcustrip()
     {
         InitializeComponent();
     }

     public int row1 = 0;
     public int row2 = 0;
         
     public int rowindex;
     public bool select1 = false;
     public bool select2 = false;
     string fbooked1;
     string bbooked1;
     string ebooked1;
     string fcSeats;
     string bcSeats;
     string ecSeats;
     int showcounter = 0;
     public void Viewcustrip_Load(object sender, EventArgs e)
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
                 select1 = true;
             }
         }
         if (row1 == 0 && showcounter>0)
         {
             select1 = false; select2 = false;
             MessageBox.Show("WE ARE VERY SORRY!\nThere are no available trips right now!!,\n Please try again later.");
         }
         dr.Close();
         label21.Text = "Total number of Trips : " + row1;
         showcounter++;
     }

     private void button4_Click(object sender, EventArgs e)
     {
         Viewcustrip_Load(sender, e);
     }

     private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
     {

     }

     private void checkBox2_CheckedChanged(object sender, EventArgs e)
     {

     }
     private void button1_Click(object sender, EventArgs e)
     {
         if (select1)
         {
             this.panel3.Visible = true;
             label9.Text = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
             label8.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
             label17.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
             label18.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
             label20.Text = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
             label22.Text = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();
             label16.Text = dataGridView1.Rows[rowindex].Cells[6].Value.ToString();
             label19.Text = dataGridView1.Rows[rowindex].Cells[7].Value.ToString();
             label71.Text = dataGridView1.Rows[rowindex].Cells[8].Value.ToString();
             label28.Text = dataGridView1.Rows[rowindex].Cells[9].Value.ToString();
             label30.Text = dataGridView1.Rows[rowindex].Cells[10].Value.ToString();
             label32.Text = dataGridView1.Rows[rowindex].Cells[11].Value.ToString();
             label26.Text = dataGridView1.Rows[rowindex].Cells[12].Value.ToString();
             label10.Text = dataGridView1.Rows[rowindex].Cells[16].Value.ToString();
             fbooked1 = dataGridView1.Rows[rowindex].Cells[13].Value.ToString();
             bbooked1 = dataGridView1.Rows[rowindex].Cells[14].Value.ToString();
             ebooked1 = dataGridView1.Rows[rowindex].Cells[15].Value.ToString();
             fcSeats = (int.Parse(dataGridView1.Rows[rowindex].Cells[17].Value.ToString()) - int.Parse(fbooked1)).ToString();
             bcSeats = (int.Parse(dataGridView1.Rows[rowindex].Cells[18].Value.ToString()) - int.Parse(bbooked1)).ToString();
             ecSeats = (int.Parse(dataGridView1.Rows[rowindex].Cells[19].Value.ToString()) - int.Parse(ebooked1)).ToString();
             label78.Text = fcSeats;
             label79.Text = bcSeats;
             label77.Text = ecSeats;
             select1 = false;
         }
     }

     private void button2_Click(object sender, EventArgs e)
     {
         select1 = false;
         this.panel3.Visible = false;
     }

     private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
     {
         string theDate1 = dateTimePicker1.Value.ToString("MM/dd/yyyy");
         textBox8.Text = theDate1.ToString();
     }
     public bool ret = false;
     private void button3_Click(object sender, EventArgs e)
     {
         select1 = false;
         select2 = false;
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
                         select1 = true;
                     }
                 }

                 if (comboBox2.Text != "" && comboBox3.Text != "" && textBox8.Text == "")
                 {
                     if (dr1["FromS"].ToString() == comboBox2.Text && dr1["ToS"].ToString() == comboBox3.Text && DateTime.Parse(dr1["DepatureTime"].ToString()) > DateTime.Now)
                     {
                         dataGridView1.Rows.Insert(row1, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Path"].ToString(), dr1["Stops"].ToString(), dr1["Duration"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString(), dr1["TrainName"].ToString(), dr1["FClassSeats"].ToString(), dr1["BClassSeats"].ToString(), dr1["EClassSeats"].ToString());
                         row1++;
                         select1 = true;
                     }
                 }
                 if (comboBox2.Text != "" && comboBox3.Text == "" && textBox8.Text == "")
                 {
                     if (dr1["FromS"].ToString() == comboBox2.Text && DateTime.Parse(dr1["DepatureTime"].ToString()) > DateTime.Now)
                     {
                         dataGridView1.Rows.Insert(row1, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Path"].ToString(), dr1["Stops"].ToString(), dr1["Duration"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString(), dr1["TrainName"].ToString(), dr1["FClassSeats"].ToString(), dr1["BClassSeats"].ToString(), dr1["EClassSeats"].ToString());
                         row1++;
                         select1 = true;
                     }
                 }
                 if (comboBox2.Text == "" && comboBox3.Text == "" && textBox8.Text != "")
                 {
                     if (DateTime.Parse(dr1["DepatureTime"].ToString()) > DateTime.Now && (DateTime.Parse(textBox8.Text).AddDays(-3) < DateTime.Parse(dr1["DepatureTime"].ToString()) || DateTime.Parse(dr1["DepatureTime"].ToString()) <= DateTime.Parse(textBox8.Text).AddDays(3)))
                     {
                         dataGridView1.Rows.Insert(row1, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Path"].ToString(), dr1["Stops"].ToString(), dr1["Duration"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString(), dr1["TrainName"].ToString(), dr1["FClassSeats"].ToString(), dr1["BClassSeats"].ToString(), dr1["EClassSeats"].ToString());
                         row1++;
                         select1 = true;
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
                             select2 = true;
                         }
                     }

                     if (comboBox2.Text != "" && comboBox3.Text != "" && textBox8.Text == "")
                     {
                         if (dr1["FromS"].ToString() == comboBox3.Text && dr1["ToS"].ToString() == comboBox2.Text && DateTime.Parse(dr1["DepatureTime"].ToString()) > DateTime.Now)
                         {
                             dataGridView2.Rows.Insert(row2, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Path"].ToString(), dr1["Stops"].ToString(), dr1["Duration"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString(), dr1["TrainName"].ToString(), dr1["FClassSeats"].ToString(), dr1["BClassSeats"].ToString(), dr1["EClassSeats"].ToString());
                             row2++;
                             select2 = true;
                         }
                     }
                     if (comboBox2.Text != "" && comboBox3.Text == "" && textBox8.Text == "")
                     {
                         if (dr1["ToS"].ToString() == comboBox2.Text && DateTime.Parse(dr1["DepatureTime"].ToString()) > DateTime.Now)
                         {
                             dataGridView2.Rows.Insert(row2, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Path"].ToString(), dr1["Stops"].ToString(), dr1["Duration"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString(), dr1["TrainName"].ToString(), dr1["FClassSeats"].ToString(), dr1["BClassSeats"].ToString(), dr1["EClassSeats"].ToString());
                             row2++;
                             select2 = true;
                         }
                     }
                     if (comboBox2.Text == "" && comboBox3.Text == "" && textBox8.Text != "")
                     {
                         if (DateTime.Parse(dr1["DepatureTime"].ToString()) > DateTime.Now && (DateTime.Parse(textBox8.Text).AddDays(-3) < DateTime.Parse(dr1["DepatureTime"].ToString()) || DateTime.Parse(dr1["DepatureTime"].ToString()) <= DateTime.Parse(textBox8.Text).AddDays(3)))
                         {
                             dataGridView2.Rows.Insert(row2, dr1["ID"].ToString(), dr1["TripName"].ToString(), dr1["FromS"].ToString(), dr1["ToS"].ToString(), DateTime.Parse(dr1["DepatureTime"].ToString()).ToString(), DateTime.Parse(dr1["ArrivalTime"].ToString()).ToString(), dr1["Path"].ToString(), dr1["Stops"].ToString(), dr1["Duration"].ToString(), dr1["FClassCost"].ToString(), dr1["BClassCost"].ToString(), dr1["EClassCost"].ToString(), dr1["Meal"].ToString(), dr1["FBookedSeats"].ToString(), dr1["BBookedSeats"].ToString(), dr1["EBookedSeats"].ToString(), dr1["TrainName"].ToString(), dr1["FClassSeats"].ToString(), dr1["BClassSeats"].ToString(), dr1["EClassSeats"].ToString());
                             row2++;
                             select2 = true;
                         }
                     }

                 }

             }
             if (row1==0)
             {
                 select1 = false;
                 MessageBox.Show("There are no available trips at that time!!,\n Please try to search again.");
             }

             if (row2 == 0)
             {
                 select2 = false;
             }
         } label21.Text = "Total number of Trips : " + row1;
         label67.Text = "Total number of Trips : " + row2;
             dr1.Close();
         
     }

     public void button4_Click_1(object sender, EventArgs e)
     {
         Viewcustrip_Load(sender, e);
     }

     private void panel4_Paint(object sender, PaintEventArgs e)
     {

     }
     public int row2index;
     string fbooked2;
     string bbooked2;
     string ebooked2;
     private void button5_Click(object sender, EventArgs e)
     {
         if (select2)
         {
             this.panel4.Visible = true;
             label61.Text = dataGridView2.Rows[row2index].Cells[0].Value.ToString();
             label62.Text = dataGridView2.Rows[row2index].Cells[1].Value.ToString();
             label55.Text = dataGridView2.Rows[row2index].Cells[2].Value.ToString();
             label56.Text = dataGridView2.Rows[row2index].Cells[3].Value.ToString();
             label49.Text = dataGridView2.Rows[row2index].Cells[4].Value.ToString();
             label50.Text = dataGridView2.Rows[row2index].Cells[5].Value.ToString();
             label54.Text = dataGridView2.Rows[row2index].Cells[6].Value.ToString();
             label48.Text = dataGridView2.Rows[row2index].Cells[7].Value.ToString();
             label69.Text = dataGridView2.Rows[row2index].Cells[8].Value.ToString();
             label44.Text = dataGridView2.Rows[row2index].Cells[9].Value.ToString();
             label42.Text = dataGridView2.Rows[row2index].Cells[10].Value.ToString();
             label40.Text = dataGridView2.Rows[row2index].Cells[11].Value.ToString();
             label46.Text = dataGridView2.Rows[row2index].Cells[12].Value.ToString();
             label60.Text = dataGridView2.Rows[row2index].Cells[16].Value.ToString();
             fbooked2 = dataGridView2.Rows[row2index].Cells[13].Value.ToString();
             bbooked2 = dataGridView2.Rows[row2index].Cells[14].Value.ToString();
             ebooked2 = dataGridView2.Rows[row2index].Cells[15].Value.ToString();
             fcSeats = (int.Parse(dataGridView2.Rows[rowindex].Cells[17].Value.ToString()) - int.Parse(fbooked2)).ToString();
             bcSeats = (int.Parse(dataGridView2.Rows[rowindex].Cells[18].Value.ToString()) - int.Parse(bbooked2)).ToString();
             ecSeats = (int.Parse(dataGridView2.Rows[rowindex].Cells[19].Value.ToString()) - int.Parse(ebooked2)).ToString();
             label84.Text = fcSeats;
             label85.Text = bcSeats;
             label83.Text = ecSeats;
             select2 = false;
         }
     }

     private void button6_Click(object sender, EventArgs e)
     {
         select2 = false;
         this.panel4.Visible = false;
     }

     private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
     {
         if (row1 > 0)
         {
             select1 = true;
             rowindex = dataGridView1.CurrentCell.RowIndex;
         }
     }
     public bool fromview = false;
     private void button7_Click(object sender, EventArgs e)
     {
         fromview = true;
         Program.xcust.bookReservationsToolStripMenuItem_Click(sender,e);
         Program.xbook.view(label9.Text, label8.Text, label17.Text, label18.Text, label20.Text, label22.Text, label16.Text, label19.Text, label71.Text, label28.Text, label30.Text, label32.Text, label26.Text, fbooked1, bbooked1, ebooked1, label10.Text, label78.Text, label79.Text, label77.Text, label61.Text, label62.Text, label55.Text, label56.Text, label49.Text, label50.Text, label54.Text, label48.Text, label69.Text, label44.Text, label42.Text, label40.Text, label46.Text, fbooked2, bbooked2, ebooked2, label60.Text, label84.Text, label85.Text, label83.Text);
         fromview = false;
     }

     private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
     {
         if (row2 > 0)
         {
             select2 = true;
             row2index = dataGridView2.CurrentCell.RowIndex;
         }
     }

     private void checkBox1_CheckedChanged(object sender, EventArgs e)
     {

     }

     private void label17_Click(object sender, EventArgs e)
     {

     }

     private void button8_Click(object sender, EventArgs e)
     {
         fromview = true;
         Program.xcust.bookReservationsToolStripMenuItem_Click(sender, e);
         Program.xbook.view(label9.Text, label8.Text, label17.Text, label18.Text, label20.Text, label22.Text, label16.Text, label19.Text, label71.Text, label28.Text, label30.Text, label32.Text, label26.Text, fbooked1, bbooked1, ebooked1, label10.Text, label78.Text, label79.Text, label77.Text, label61.Text, label62.Text, label55.Text, label56.Text, label49.Text, label50.Text, label54.Text, label48.Text, label69.Text, label44.Text, label42.Text, label40.Text, label46.Text, fbooked2, bbooked2, ebooked2, label60.Text, label84.Text, label85.Text, label83.Text);
         fromview = false;
     }

     private void label78_Click(object sender, EventArgs e)
     {

     }

     private void label79_Click(object sender, EventArgs e)
     {

     }

     private void label77_Click(object sender, EventArgs e)
     {

     }

     private void panel2_Paint(object sender, PaintEventArgs e)
     {

     }

     private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
     {

     }
 }
}