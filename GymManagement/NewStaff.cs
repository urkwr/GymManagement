using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GymManagement
{
    public partial class NewStaff : Form
    {
        public NewStaff()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstname.Text;
            string lastName = txtLastName.Text;
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
            string state = txtState.Text;
            string city = txtCity.Text;
            Int64 mobile = Convert.ToInt64(txtMob.Text);

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=UROSPC\\SQLEXPRESS;Initial Catalog=Gym;Integrated Security=True;TrustServerCertificate=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "insert into NewStaff (FirstName, LastName, Gender, Dob, Mobile, Email, JoinDate, Statee, City) values ('" + firstName + "','" + lastName + "','" + gender + "','" + dob + "','" + mobile + "','" + email + "','" + joindate + "','" + state + "','" + city + "')";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MessageBox.Show("Data saved successfully.", "Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstname.Clear();
            txtLastName.Clear();
            txtCity.Clear();
            txtMob.Clear();
            txtState.Clear();
            txtEmail.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            datetimeDOB.Value = DateTime.Now;
            datetimeJoin.Value = DateTime.Now;
        }
    }
}
