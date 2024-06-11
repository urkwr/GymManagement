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

namespace GymManagement
{
    public partial class newMember : Form
    {

        public newMember()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstname.Text;
            string lastName = txtLastname.Text;
            string email = txtEmail.Text;
            string gender = "";
            bool isChecked = radioButton1.Checked;
            if (isChecked)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }
            string dob = datetimeDOB.Text;
            string joindate = datetimeJoin.Text;
            string gymtime = comboBox1.Text;
            string address = txtAddress.Text;
            Int64 mobile = Convert.ToInt64(txtMob.Text);
            string membership = comboBox2.Text;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=UROSPC\\SQLEXPRESS;Initial Catalog=Gym;Integrated Security=True;TrustServerCertificate=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "insert into NewMember (FirstName, LastName, Gender, DOB, Mobile, Email, JoinDate, GymTime, Address, Membership) values ('" + firstName + "','" + lastName + "','" + gender + "','" + dob + "','" + mobile + "','" + email + "','" + joindate + "','" + gymtime + "','" + address + "','" + membership + "')";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MessageBox.Show("Data saved successfully.", "Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstname.Clear();
            txtLastname.Clear();
            txtAddress.Clear();
            txtMob.Clear();
            txtEmail.Clear();
            datetimeDOB.Value = DateTime.Now;
            datetimeJoin.Value = DateTime.Now;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboBox1.ResetText();
            comboBox2.ResetText();
        }
    }
}
