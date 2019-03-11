using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_HaberPortal
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("server=MERTCELIL\\MSSQL2018; Database=HaberPortal; uid=sa; pwd=12345w");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBagla();
            }
        }

        private void DataBagla()
        {
            SqlCommand comm = new SqlCommand("select * from Haberler where Aktifmi=1", conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                repNews.DataSource = dr;
                repNews.DataBind();

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
        }

        protected void repNews_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Goruntulenme")
            {
                SqlCommand comm = new SqlCommand("update Haberler set Goruntulenme+=1 where Id=@Id", conn);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Id";
                param.Value = Convert.ToInt32(e.CommandArgument);
                comm.Parameters.Add(param);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    comm.ExecuteNonQuery();
                    Label goruntulenme = e.Item.FindControl("goruntuleme") as Label;
                    int Mevcut = Convert.ToInt32(goruntulenme.Text);
                    goruntulenme.Text = (Mevcut + 1).ToString();
                }
                catch (SqlException ex)
                {
                    string hata = ex.Message;
                }
                finally { conn.Close(); }
            }
            //Response.Redirect("https://www.google.com/",); aynı sayfada açtı
            //Response.Write("<script>window.open('https://www.google.com/','_blank');</script>"); popup yarattı

            //SIKNTI1- javascripte evalden interaktif olarak link verememek
        }

        protected void okunma_Click(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand("select * from Haberler where Aktifmi=1 order by Goruntulenme desc", conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                repNews.DataSource = dr;
                repNews.DataBind();

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
        }

        protected void yeniye_Click(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand("select * from Haberler where Aktifmi=1 order by HaberTarih desc", conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                repNews.DataSource = dr;
                repNews.DataBind();

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
        }

        protected void eskiye_Click(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand("select * from Haberler where Aktifmi=1 order by HaberTarih asc", conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                repNews.DataSource = dr;
                repNews.DataBind();

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
        }
    }
}