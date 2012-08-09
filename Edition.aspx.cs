using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Collections.Generic;

public partial class Edition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection Cn = null;
        SqlDataReader sdr = null;

        Cn = new SqlConnection("server=WAZZUP-PC\\SQLEXPRESS; initial catalog=TestDB; integrated security=true");
        Cn.Open();

        SqlCommand command = new SqlCommand("SELECT * FROM [Article_Blog] WHERE ([id] = @id)", Cn);

        command.Parameters.Add(new SqlParameter("id", DropDownList2.SelectedValue));
        Label1.Text = DropDownList2.SelectedValue;
        sdr = command.ExecuteReader();

        while (sdr.Read())
        {

            elm1.Value = sdr["content"].ToString();
            TextBox1.Text = sdr["id"].ToString();
            TextBox2.Text = sdr["auteur"].ToString();
            TextBox3.Text = sdr["tag"].ToString();
        }

        Cn.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label1.Text = DropDownList3.SelectedValue;
    }
}