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
    public partial class BukuForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();
                GridBukuFill();
            }
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

            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Perpus.mdf;Integrated Security=True");
                SqlCommand cmd;
                if (hfIDBuku.Value == "")
                {
                    cmd = new SqlCommand("INSERT into tblBuku (JudulBuku,Pengarang,JenisBuku,HargaSewa) VALUES (@jdlBuku,@pengarang,@jnsBuku,@HrgSewa)", con);
                    cmd.Parameters.AddWithValue("@jdlBuku", JudulBuku.Text);
                    cmd.Parameters.AddWithValue("@pengarang", Pengarang.Text);
                    cmd.Parameters.AddWithValue("@jnsBuku", JenisBuku.Text);
                    cmd.Parameters.AddWithValue("@HrgSewa", HargaSewa.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    cmd = new SqlCommand("UPDATE tblBuku SET JudulBuku=@jdlBuku, Pengarang=@pengarang, JenisBuku=@jnsBuku, HargaSewa=@HrgSewa WHERE IdBuku=@idBuku", con);
                    cmd.Parameters.AddWithValue("@idBuku", Convert.ToInt32(hfIDBuku.Value == "" ? "0" : hfIDBuku.Value));
                    cmd.Parameters.AddWithValue("@jdlBuku", JudulBuku.Text);
                    cmd.Parameters.AddWithValue("@pengarang", Pengarang.Text);
                    cmd.Parameters.AddWithValue("@jnsBuku", JenisBuku.Text);
                    cmd.Parameters.AddWithValue("@HrgSewa", Convert.ToInt32(HargaSewa.Text));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                

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
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            lblErrorMessage.Text = lblSuccessMessage.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Perpus.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("delete from tblBuku where IdBuku= @id", con);
            cmd.Parameters.AddWithValue("@id", hfIDBuku.Value);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            GridBukuFill();
            Clear();
            lblSuccessMessage.Text = "Deleted Successfully";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homeform.aspx");
        }
    }
}