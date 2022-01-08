using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notes_Taking_App
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // create an instance of the table
            table = new DataTable();

            //  create 2 columns for the table
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Messages", typeof(String));

            //connect the dataGridView to the table
            dataGridView1.DataSource = table;

            dataGridView1.Columns["Messages"].Visible = false;
            dataGridView1.Columns["Title"].Width = 140;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // make the new button clear the text in the message field
            textTitle.Clear();
            textMessage.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // make the save button save contents in the title and message box
            table.Rows.Add(textTitle.Text, textMessage.Text);

            // clear the fields after savings
            textTitle.Clear();
            textMessage.Clear();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            // get the index of the row the user wants to view
            int index = dataGridView1.CurrentCell.RowIndex;

            // if a row is selected, that is the index is not zero
            if (index > -1)
            {
                //set the title and message fields to the index of the selected row
                textTitle.Text = table.Rows[index].ItemArray[0].ToString();
                textMessage.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // get the index of the row the user wants to delete
            int index = dataGridView1.CurrentCell.RowIndex;

            // delete the row from the table
            table.Rows[index].Delete();

            // clear the fields after deleting
            textTitle.Clear();
            textMessage.Clear();
        }

    }
}
