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
    public partial class LaporanForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoginID"] != null)
                {
                    string role = "";
                    if (Session["LoginRole"].ToString() == "0")
                    {
                        role = "Admin";
                        btnBuku.Visible = true;
                        btnSewa.Visible = false;
                        btnHome.Visible = true;
                        btnLogout.Visible = true;
                    }
                    else
                    {
                        role = "Penyewa";
                        btnBuku.Visible = false;
                        btnSewa.Visible = true;
                        btnHome.Visible = true;
                        btnLogout.Visible = true;
                    }

                    labelUser.Text = Session["LoginUsername"].ToString() + " As " + role;
                    GridViewSewaFill();
                }
                else
                {
                    Response.Redirect("Loginform.aspx");
                }
            }
        }

        void GridViewSewaFill()
        {
            if (Session["LoginRole"].ToString().Equals("0"))
            {
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Perpus.mdf;Integrated Security=True");
                //SqlCommand cmd1 = new SqlCommand("select * from tblSewa inner join tblBuku on tblBuku.IdBuku = tblSewa.IdBuku", con1);
                SqlCommand cmd1 = new SqlCommand("select tblSewa.IdSewa, tblSewa.IdUser," +
                    " tblSewa.IdBuku, tblSewa.tglSewa, tblSewa.LamaSewa, tblSewa.TotalHarga," +
                    " tblBuku.IdBuku, tblBuku.JudulBuku, tblBuku.Pengarang, tblBuku.JenisBuku," +
                    " tblBuku.HargaSewa, tblUser.IdUser, tblUser.Username from tblSewa join tblBuku on tblBuku.IdBuku = tblSewa.IdBuku join tblUser on tblUser.IdUser = tblSewa.IdUser", con1);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                con1.Open();
                int i1 = cmd1.ExecuteNonQuery();
                con1.Close();

                gvSewa.DataSource = dt1;
                gvSewa.DataBind();

                if (dt1.Rows.Count > 0)
                {
                    int totalSewa = 0;
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        totalSewa += Convert.ToInt32(dt1.Rows[i][5].ToString());
                    }
                    subTotal.Text = totalSewa.ToString();
                }
            }
            else
            {
                SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Perpus.mdf;Integrated Security=True");
                //SqlCommand cmd1 = new SqlCommand("select * from tblSewa inner join tblBuku on tblBuku.IdBuku = tblSewa.IdBuku", con1);
                SqlCommand cmd1 = new SqlCommand("select tblSewa.IdSewa, tblSewa.IdUser," +
                    " tblSewa.IdBuku, tblSewa.tglSewa, tblSewa.LamaSewa, tblSewa.TotalHarga," +
                    " tblBuku.IdBuku, tblBuku.JudulBuku, tblBuku.Pengarang, tblBuku.JenisBuku," +
                    " tblBuku.HargaSewa, tblUser.IdUser, tblUser.Username from tblSewa join tblBuku on tblBuku.IdBuku = tblSewa.IdBuku join tblUser on tblUser.IdUser = tblSewa.IdUser where tblSewa.IdUser = @idUser", con1);
                cmd1.Parameters.AddWithValue("@idUser", Session["LoginID"].ToString());
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                con1.Open();
                int i1 = cmd1.ExecuteNonQuery();
                con1.Close();

                gvSewa.DataSource = dt1;
                gvSewa.DataBind();

                if (dt1.Rows.Count > 0)
                {
                    int totalSewa = 0;
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        totalSewa += Convert.ToInt32(dt1.Rows[i][5].ToString());
                    }
                    subTotal.Text = totalSewa.ToString();
                }
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homeform.aspx");
        }

        protected void btnBuku_Click(object sender, EventArgs e)
        {
            Response.Redirect("BukuForm.aspx");
        }

        protected void btnSewa_Click(object sender, EventArgs e)
        {
            Response.Redirect("SewaForm.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Loginform.aspx");
        }
    }
}