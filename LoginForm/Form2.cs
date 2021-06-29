using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginForm
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-153RETS; Initial Catalog=admin; Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int Studentid;

        public Form2()
        {
            InitializeComponent();
            displayData();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

      

        private void btnSava_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("insert into Student values('" + txtUserName.Text + "','" + txtEmail.Text + "','" + txtDesignation.Text + "','" + txtSalary.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your data has been saved in the database ");
          
            con.Close();
            displayData();
            Clear();
        }
        public void displayData()
        {
            con.Open();

            adpt = new SqlDataAdapter("select * from Student", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public void Clear()
        {
            txtUserName.Text = "";
            txtSalary.Text = "";
            txtDesignation.Text = "";
            txtEmail.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Studentid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtUserName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDesignation.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSalary.Text =dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("update Student set Name='" + txtUserName.Text + "',Email='" + txtEmail.Text + "',Department='" + txtDesignation.Text + "',fee='" + txtSalary.Text + "',where Student_ID='" + Studentid + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data has been updated ");
                con.Close();

                displayData();
            }
            catch(Exception )
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("delete from Student where Student_ID='" + Studentid + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("The Data has been Deleted ");
            con.Close();
            displayData();
        }
    }
}
