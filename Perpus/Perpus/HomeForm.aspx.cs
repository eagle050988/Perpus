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
    public partial class HomeForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["LoginID"] != null)
            {
                Username.Text = "Welcome " + Session["LoginUsername"].ToString();
                if(Session["LoginRole"].ToString() == "0")
                {
                    btnBuku.Visible = true;
                    btnSewa.Visible = false;
                    btnLaporan.Visible = true;
                    btnLogout.Visible = true;
                }
                else
                {
                    btnBuku.Visible = false;
                    btnSewa.Visible = true;
                    btnLaporan.Visible = true;
                    btnLogout.Visible = true;
                }
            }
            else
            {
                Response.Redirect("Loginform.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Loginform.aspx");
        }

        protected void btnBuku_Click(object sender, EventArgs e)
        {
            Response.Redirect("BukuForm.aspx");
        }

        protected void btnLaporan_Click(object sender, EventArgs e)
        {
            Response.Redirect("LaporanForm.aspx");
        }

        protected void btnSewa_Click(object sender, EventArgs e)
        {
            Response.Redirect("SewaForm.aspx");
        }
    }
}