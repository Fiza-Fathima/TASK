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
    public partial class gridview_binding : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-IUSRELD8\SQLEXPRESS;database=DB;integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            string s = "select * from reg";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(s, con);
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}