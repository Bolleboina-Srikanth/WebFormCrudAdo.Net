using EmployeesListWebForms.Content;
using EmployeesListWebForms.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Drawing;

namespace EmployeesListWebForms
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        //private EmployeeContext db = new EmployeeContext();
        private string connectionString = ConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            WebForm1 employeeedb = new WebForm1();

            GridView1.DataSource = employeeedb.GetAllEmployees();
            GridView1.DataBind();
        }

        protected void addnewEmployee(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Salary", TextBox2.Text);
                cmd.Parameters.AddWithValue("@Department", TextBox3.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            BindGrid();
        }
        public DataTable GetAllEmployees()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            // Store the Employee ID in a hidden field or ViewState for later use
            int empid = Convert.ToInt32(GridView1.Rows[rowindex].Cells[0].Text);
            ViewState["SelectedEmployeeId"] = empid;
            TextBox1.Text = (GridView1.Rows[rowindex].Cells[1].Text);
            TextBox2.Text = (GridView1.Rows[rowindex].Cells[2].Text);
            TextBox3.Text = (GridView1.Rows[rowindex].Cells[3].Text);



        }

        protected void btndelete_click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int empID = Convert.ToInt32(GridView1.Rows[rowindex].Cells[0].Text);
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", empID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            // Rebind the GridView to reflect the updated data
            BindGrid();
        }

        protected void UpdateEmployee(object sender, EventArgs e)
        {
            int empid = (int)ViewState["SelectedEmployeeId"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", empid);
                cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
                cmd.Parameters.AddWithValue("@Salary", TextBox2.Text);
                cmd.Parameters.AddWithValue("@Department", TextBox3.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            BindGrid();
        }


    }
}