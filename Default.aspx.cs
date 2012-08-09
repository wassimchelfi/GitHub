using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (elm1 != null && !string.IsNullOrWhiteSpace(elm1.Value))
            {
                elm1.Value = HttpUtility.HtmlDecode(elm1.Value);
            }
        }
    }

    
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text =  Server.HtmlEncode(this.elm1.Value);
        //Label1.Text = this.elm1.Value;

        //String QueryString = "INSERT INTO Article (Id, auteur, date, categorie) VALUES ('7', 'FCW', '', 'Informatique')";

        String QueryString = "INSERT INTO Article_Blog (id, auteur, tag, content) VALUES ('" + TextBox1.Text + "', '" + TextBox2.Text + "','" + TextBox3.Text + "', '" + this.elm1.Value + "')";
        SqlConnection Cn = new SqlConnection("server=WAZZUP-PC\\SQLEXPRESS; initial catalog=TestDB; integrated security=true");
        
        try
        {

            Cn.Open();
            if (Cn != null)
            {
                Label1.Text = "CONNECTER";
            }

            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandText = QueryString;
            //Cmd.CommandType = CommandType.Text;
            Cmd.Connection = Cn;

            Cmd.ExecuteNonQuery();

            Cn.Close();
        }
        catch (Exception Ex)
        {
            Label1.Text = Ex.ToString();
            Cn.Close();
        };


    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        //this.elm1.Value = "<p>This is a test document. Some <span class='mceNonEditable' style=\"color: #ff0000;\">Portion</span> of this document can't be changed.</p>\r\n<p>The area with red <span class='mceNonEditable' style=\"color: #ff0000;\">background </span>can't be <span class='mceNonEditable' style=\"color: #ff0000;\">removed</span>. You can only <span class='mceNonEditable' style=\"color: #ff0000;\">change </span>the area with black.</p>\r\n<p>&nbsp;</p>"; 

        SqlConnection Cn = new SqlConnection("server=WAZZUP-PC\\SQLEXPRESS; initial catalog=TestDB; integrated security=true");

        try
        {

            Cn.Open();
            if (Cn != null)
            {
                Label1.Text = "CONNECTER";
                 Console.WriteLine("CONNECTER");
            }

            string strRequete = "SELECT ID, Auteur, Content, Tag  FROM Art_Blog;";

            SqlCommand Cmd = new SqlCommand(strRequete, Cn);
            SqlDataReader oReader = Cmd.ExecuteReader();
            
            do
            {
                Console.WriteLine("\t{0}\t{1}", oReader.GetName(0), oReader.GetName(1));
                while (oReader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}", oReader.GetInt32(0), oReader.GetString(1));
                }
            }
            while (oReader.NextResult());
            oReader.Close();
           

            Cn.Close();
        }
        catch (Exception Ex)
        {
            Label1.Text = Ex.ToString();
            Cn.Close();
        };
    }

    public String SystemText
    {
        get
        {
            return HttpUtility.HtmlDecode(elm1.Value);
        }
        set
        {
            elm1.Value = value;
        }
    }
}
