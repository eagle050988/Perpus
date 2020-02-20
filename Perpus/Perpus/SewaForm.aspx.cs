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
    public partial class SewaForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                GridBukuFill();
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homeform.aspx");
        }

        void GridBukuFill()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Perpus.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from tblBuku", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            gvBuku.DataSource = dt;
            gvBuku.DataBind();

            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Perpus.mdf;Integrated Security=True");
            SqlCommand cmd1 = new SqlCommand("select tblSewa.IdSewa, tblSewa.IdUser," +
                " tblSewa.IdBuku, tblSewa.tglSewa, tblSewa.LamaSewa," +
                " tblBuku.IdBuku, tblBuku.JudulBuku, tblBuku.Pengarang, tblBuku.JenisBuku," +
                " tblBuku.HargaSewa from tblSewa join tblBuku on tblBuku.IdBuku = tblSewa.IdBuku", con1);
            //SqlCommand cmd1 = new SqlCommand("select * from tblSewa inner join tblBuku on tblBuku.IdBuku = tblSewa.IdBuku", con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);
            con1.Open();
            int i1 = cmd1.ExecuteNonQuery();
            con1.Close();

            gvSewa.DataSource = dt1;
            gvSewa.DataBind();
            btnSave.Enabled = false;
        }

        protected void lnkSelect_OnClick(object sender, EventArgs e)
        {
            int productID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Perpus.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from tblBuku where IdBuku= @id", con);
            cmd.Parameters.AddWithValue("@id", productID);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);

            JudulBuku.Text = dtbl.Rows[0][1].ToString();
            Pengarang.Text = dtbl.Rows[0][2].ToString();
            JenisBuku.Text = dtbl.Rows[0][3].ToString();
            HargaSewa.Text = dtbl.Rows[0][4].ToString();

            hfIDBuku.Value = dtbl.Rows[0][0].ToString();
            btnSave.Enabled = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Perpus.mdf;Integrated Security=True");
                SqlCommand cmd;

                cmd = new SqlCommand("INSERT into tblSewa (IdUser,IdBuku,tglSewa,LamaSewa) VALUES (@IdUser,@IdBuku,@tglSewa,@LamaSewa)", con);
                cmd.Parameters.AddWithValue("@IdUser", Session["LoginID"].ToString());
                cmd.Parameters.AddWithValue("@IdBuku", hfIDBuku.Value);
                cmd.Parameters.AddWithValue("@tglSewa", tglSewa.Text);
                cmd.Parameters.AddWithValue("@LamaSewa", LamaSewa.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                


                GridBukuFill();
                Clear();
                lblSuccessMessage.Text = "Submitted Successfully";

            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        void Clear()
        {
            hfIDBuku.Value = "";
            JudulBuku.Text = Pengarang.Text = JenisBuku.Text = HargaSewa.Text = "";

            lblErrorMessage.Text = lblSuccessMessage.Text = "";
            btnSave.Enabled = false;
        }
    }
}