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
    public partial class _19_09_2022 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-IUSRELD8\SQLEXPRESS;database=DB;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Label1.Visible = true;
            string s = "";
            for (int i = 0; i < CheckBoxList1.Items.Count; i++) 
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    s = s + CheckBoxList1.Items[i].Text + ",";
                }
            }


            string p = "~/PHS/" +FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));

            string k = "insert into reg values('" + TextBox1.Text + "'," + TextBox2.Text + ",'" + TextBox3.Text + "','" + RadioButtonList1.SelectedItem + "','" + DropDownList1.SelectedItem + "','" + s + "','" + p + "','" + TextBox4.Text + "','" + TextBox5.Text + "')";
            SqlCommand cmd= new SqlCommand(k, con);
            con.Open();
             int x=cmd.ExecuteNonQuery();
            con.Close();

            if (x == 1)
            {
                Label1.Text = "registerd";
            }
                   
        }
    }
}