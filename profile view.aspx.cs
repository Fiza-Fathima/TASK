using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace _19_09_2022
{
    public partial class profile_view : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-IUSRELD8\SQLEXPRESS;database=DB;integrated security=true"); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s = "select name,age,address,gender,state,qulification,photo from reg where id=" + Session["id"] + "";
                SqlCommand cmd = new SqlCommand(s, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TextBox1.Text = dr["name"].ToString();
                    TextBox2.Text = dr["age"].ToString();
                    TextBox3.Text = dr["address"].ToString();
                    TextBox4.Text = dr["gender"].ToString();
                    TextBox5.Text = dr["state"].ToString();
                    TextBox6.Text = dr["qulification"].ToString();
                    Image1.ImageUrl = dr["photo"].ToString();


                }
                con.Close();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(s, con);
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = " update reg set age=" + TextBox2.Text + " , address='" + TextBox3.Text + "' where id="+Session["id"]+"";
            SqlCommand cmd = new SqlCommand(s, con);
            con.Open();
             int x=cmd.ExecuteNonQuery();
            con.Close();
            if (x == 1)
            {
               Label1.Text= "updated";
            }
        }

    }
}