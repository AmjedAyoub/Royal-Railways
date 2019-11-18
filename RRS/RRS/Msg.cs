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
    public partial class Msg : Form
    {
        private string src = Program.xsrc;
        public Msg()
        {
            InitializeComponent();
        }
        public int row1 = 0;
        public bool select1 = false;
        public string id = "";
        private void Msg_Load(object sender, EventArgs e)
        {
        }
        public void start()
        {
            id = Program.xcust.id;
            row1 = 0;
            dataGridView1.Rows.Clear();
            SqlConnection con = new SqlConnection(src);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Message", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["CusID"].ToString() == id && dr["R"].ToString() == "Yes")
                {
                    dataGridView1.Rows[0].DefaultCellStyle.ForeColor=(Color.Black);
                    dataGridView1.Rows.Insert(0, dr["ID"].ToString(), dr["CusID"].ToString(), dr["Msg"].ToString(), DateTime.Parse(dr["Date"].ToString()).ToString(), dr["R"].ToString());
                    row1++;
                    select1 = true;
                }
            }
            dr.Close();
            SqlDataReader dr2 = cmd.ExecuteReader();
            while (dr2.Read())
            {
                if (dr2["CusID"].ToString() == id && dr2["R"].ToString() == "No")
                {
                    dataGridView1.Rows[0].DefaultCellStyle.ForeColor = (Color.Blue);
                    dataGridView1.Rows.Insert(0, dr2["ID"].ToString(), dr2["CusID"].ToString(), dr2["Msg"].ToString(), DateTime.Parse(dr2["Date"].ToString()).ToString(), dr2["R"].ToString());
                    row1++;
                    select1 = true;
                }
            }
            dr2.Close();
            if (row1 > 0)
            {
                if (dataGridView1.Rows[0].Cells[4].Value.ToString() == "No")
                {
                    dataGridView1.DefaultCellStyle.ForeColor = Color.Blue;
                }
                else
                {
                    dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            if (row1 == 0)
            {
                select1 = false;
                MessageBox.Show("There are no messages !!");
            }
        }
        public int rowindex1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (row1 > 0)
            {
                select1 = true;
                rowindex1 = dataGridView1.CurrentCell.RowIndex;

            }
        }
        string idm = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (select1)
            {
                if (dataGridView1.Rows[rowindex1].Cells[4].Value.ToString() == "No")
                {
                    string read = "Yes";
                    SqlConnection cn1 = new SqlConnection(src);
                    SqlCommand cmd1 = new SqlCommand("UPDATE [Message] SET R=@read WHERE ID = '" + dataGridView1.Rows[rowindex1].Cells[0].Value.ToString() + "'", cn1);
                    cmd1.Parameters.AddWithValue("@read", read);
                    cn1.Open();
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    cn1.Close();
                    
                }
                idm = dataGridView1.Rows[rowindex1].Cells[0].Value.ToString();
                dataGridView1.Rows[rowindex1].DefaultCellStyle.ForeColor = Color.Black;
                label17.Text = dataGridView1.Rows[rowindex1].Cells[1].Value.ToString();
                label18.Text = dataGridView1.Rows[rowindex1].Cells[3].Value.ToString();
                label16.Text = dataGridView1.Rows[rowindex1].Cells[2].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.xcust.backgr();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label16.Text == "****")
            {
                MessageBox.Show("No Message !");
            }
            else
            {
                MessageBox.Show("Thank you for travelling with us!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label16.Text == "****")
            {
                MessageBox.Show("No Message !");
            }
            else if ((MessageBox.Show("Are you sure you want to delete this message ?", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                string q1 = Program.xsrc;
                SqlConnection cn1 = new SqlConnection(q1);
                SqlCommand cmd1 = new SqlCommand("DELETE FROM [Message] WHERE ID = '" + idm + "'", cn1);
                cn1.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                start();
                label16.Text = "****";
                label17.Text = "****";
                label18.Text = "****";
            }
        }
    }
}
