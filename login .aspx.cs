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
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-IUSRELD8\SQLEXPRESS;database=DB;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            string s = "select count(id) from reg where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(s, con);
            con.Open();
            string k=cmd.ExecuteScalar().ToString();
            con.Close();

            if (k == "1")
            {
                string sr = "select id from reg where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                SqlCommand cmd1 = new SqlCommand(sr, con);
                con.Open();
                string kr = cmd1.ExecuteScalar().ToString();
                con.Close();
                Session["id"] = kr;


                Response.Redirect("profile view.aspx");
                    //Label1.Text = "success";
            }
            else
            {

                Label1.Text = "invald username or password";
            }
    }
    }
}