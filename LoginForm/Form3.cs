using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            txtResult.Text += "****************************************\n";
            txtResult.Text += "**            Fees Details           ***\n";
            txtResult.Text += "****************************************\n";

            txtResult.Text += "Student Name: " + txtStudentName.Text + "\n\n";
            txtResult.Text += "Email: " + txtFather.Text + "\n\n";
            txtResult.Text += "Department: " + txtBatch.Text + "\n\n";
           
            txtResult.Text += "Fees: " + txtFees.Text + "\n\n";

            txtResult.Text += "\n                                 signature";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtStudentName.Text = "";
            txtFather.Text = "";
            txtBatch.Text = "";
            txtFees.Text = "";
            txtResult.Text = "";
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtResult.Text, new Font("Microsoft sans serif", 18, FontStyle.Bold), Brushes.Black, new Point(10, 10));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void txtFees_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
