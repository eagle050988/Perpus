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
            if (!IsPostBack)
            {
                if (Session["LoginID"] != null)
                {
                    string role = "";
                    if (Session["LoginRole"].ToString() == "0")
                    {
                        role = "Admin";
                    }
                    else
                    {
                        role = "Penyewa";
                    }

                    labelUser.Text = Session["LoginUsername"].ToString() + " As " + role;
                    GridBukuFill();
                }
                else
                {
                    Response.Redirect("Loginform.aspx");
                }
            }
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

            GridViewSewaFill();

            btnSave.Enabled = false;
        }

        void GridViewSewaFill()
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Perpus.mdf;Integrated Security=True");
            //SqlCommand cmd1 = new SqlCommand("select * from tblSewa inner join tblBuku on tblBuku.IdBuku = tblSewa.IdBuku", con1);
            SqlCommand cmd1 = new SqlCommand("select tblSewa.IdSewa, tblSewa.IdUser," +
                " tblSewa.IdBuku, tblSewa.tglSewa, tblSewa.LamaSewa, tblSewa.TotalHarga," +
                " tblBuku.IdBuku, tblBuku.JudulBuku, tblBuku.Pengarang, tblBuku.JenisBuku," +
                " tblBuku.HargaSewa from tblSewa join tblBuku on tblBuku.IdBuku = tblSewa.IdBuku where tblSewa.IdUser = @idUser", con1);
            cmd1.Parameters.AddWithValue("@idUser", Session["LoginID"].ToString());
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            con1.Open();
            int i1 = cmd1.ExecuteNonQuery();
            con1.Close();

            gvSewa.DataSource = dt1;
            gvSewa.DataBind();

            if(dt1.Rows.Count > 0)
            {
                int totalSewa = 0;
                for(int i =0; i < dt1.Rows.Count; i++)
                {
                    totalSewa += Convert.ToInt32(dt1.Rows[i][5].ToString());
                }
                subTotal.Text = totalSewa.ToString();
            }
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

        protected void lnkRemove_OnClick(object sender, EventArgs e)
        {
            int idSewa = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Perpus.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("delete from tblSewa where IdSewa= @id", con);
            cmd.Parameters.AddWithValue("@id", idSewa);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            GridViewSewaFill();
            Clear();
            lblSuccessMessage.Text = "Deleted Successfully";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Perpus.mdf;Integrated Security=True");
                SqlCommand cmd;

                int totalHarga = Convert.ToInt32(HargaSewa.Text) * Convert.ToInt32(LamaSewa.Text);

                cmd = new SqlCommand("INSERT into tblSewa (IdUser,IdBuku,tglSewa,LamaSewa, TotalHarga) VALUES (@IdUser,@IdBuku,@tglSewa,@LamaSewa, @TotalHarga)", con);
                cmd.Parameters.AddWithValue("@IdUser", Session["LoginID"].ToString());
                cmd.Parameters.AddWithValue("@IdBuku", hfIDBuku.Value);
                cmd.Parameters.AddWithValue("@tglSewa", tglSewa.Text);
                cmd.Parameters.AddWithValue("@LamaSewa", LamaSewa.Text);
                cmd.Parameters.AddWithValue("@TotalHarga", totalHarga);
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
            JudulBuku.Text = Pengarang.Text = JenisBuku.Text = HargaSewa.Text = tglSewa.Text = LamaSewa.Text = "";

            lblErrorMessage.Text = lblSuccessMessage.Text = "";
            btnSave.Enabled = false;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btnLaporan_Click(object sender, EventArgs e)
        {
            Response.Redirect("LaporanForm.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Loginform.aspx");
        }
    }
}