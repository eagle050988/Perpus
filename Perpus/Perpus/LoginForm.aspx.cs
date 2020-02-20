using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Perpus
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Perpus.mdf;Integrated Security=True;User Instance=True");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\AspProject\Perpus\Perpus\App_Data\Perpus.mdf;Integrated Security=True");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Perpus.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from tblUser where Username=@username and Password=@word", con);
            cmd.Parameters.AddWithValue("@username", username.Text);
            cmd.Parameters.AddWithValue("@word", password.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (dt.Rows.Count > 0)
            {
                for(int id =0; id < dt.Rows.Count; id++)
                {
                    Session["LoginID"] = dt.Rows[id]["idUser"];
                    Session["LoginUsername"] = dt.Rows[id]["Username"];
                    Session["LoginRole"] = dt.Rows[id]["Role"];
                }
                Response.Redirect("Homeform.aspx");
            }
            else
            {
                Label1.Text = "Your username and word is incorrect";
                Label1.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
}