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

public partial class Display : System.Web.UI.Page
{

    public static ArrayList Files = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (elm1 != null && !string.IsNullOrWhiteSpace(elm1.Value))
            {
                elm1.Value = HttpUtility.HtmlDecode(elm1.Value);
            }
        }

        
        SqlConnection Cn = new SqlConnection("server=WAZZUP-PC\\SQLEXPRESS; initial catalog=TestDB; integrated security=true");
        
        string com = "SELECT ID, Auteur, [Content], Tag FROM Article_Blog WHERE (ID=5)";
        SqlDataAdapter adpt = new SqlDataAdapter(com, Cn);
        DataSet myDataSet = new DataSet();
        adpt.Fill(myDataSet, "Article_Blog");
        DataTable myDataTable = myDataSet.Tables[0];
        DataRow tempRow = null;


        foreach (DataRow tempRow_Variable in myDataTable.Rows)
        {
            tempRow = tempRow_Variable;
            // ListBox1.Items.Add((tempRow["id"] + " (" + tempRow["auteur"] + ")" + " (" + tempRow["content"] + ")" + " (" + tempRow["Tag"] + ")"));

            elm1.Value = tempRow["content"].ToString();
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = Server.HtmlEncode(this.elm1.Value);
        //Label1.Text = this.elm1.Value;

        //String QueryString = "INSERT INTO Article (Id, auteur, date, categorie) VALUES ('7', 'FCW', '', 'Informatique')";

        String QueryString = "INSERT INTO Article_Blog (ID, Auteur, Content, Tag) VALUES ('" + TextBox1.Text + "', '" + TextBox2.Text + "',  '" + this.elm1.Value + "','" + TextBox3.Text + "')";
        SqlConnection Cn = new SqlConnection("server=WAZZUP-PC\\SQLEXPRESS; initial catalog=TestDB; integrated security=true");

        try
        {

            Cn.Open();
            if (Cn != null)
            {
                Label1.Text = "CONNECTER";
                Console.WriteLine("CONNECTER");
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

        LabelDebug1.Text = TextBox1.Text;
        SqlConnection Cn = null;
        SqlDataReader sdr = null;

        
        //this.elm1.Value = "<p>This is a test document. Some <span class='mceNonEditable' style=\"color: #ff0000;\">Portion</span> of this document can't be changed.</p>\r\n<p>The area with red <span class='mceNonEditable' style=\"color: #ff0000;\">background </span>can't be <span class='mceNonEditable' style=\"color: #ff0000;\">removed</span>. You can only <span class='mceNonEditable' style=\"color: #ff0000;\">change </span>the area with black.</p>\r\n<p>&nbsp;</p>"; 

        Cn = new SqlConnection("server=WAZZUP-PC\\SQLEXPRESS; initial catalog=TestDB; integrated security=true");
        Cn.Open();

        SqlCommand command = new SqlCommand("SELECT * FROM [Article_Blog] WHERE ([id] = @id)", Cn);

        //SqlParameter param = new SqlParameter();
        //param.ParameterName = "@id";
        //param.Value = TextBox1.Text;

        //command.Parameters.Add(param);

        command.Parameters.Add(new SqlParameter("id", TextBox1.Text));       

        sdr = command.ExecuteReader();

        while (sdr.Read()) 
        { 
             
             elm1.Value = sdr["content"].ToString(); 
             Label2.Text = sdr["auteur"].ToString(); 
        }

        Cn.Close();
        //string com = "SELECT * FROM [Article_Blog] WHERE ([id] = @id)";
        //SqlDataAdapter adpt = new SqlDataAdapter(com, Cn);
        //DataSet myDataSet = new DataSet();
        //adpt.Fill(myDataSet, "Article_Blog");
        //DataTable myDataTable = myDataSet.Tables[0];
        //DataRow tempRow = null;


        //foreach (DataRow tempRow_Variable in myDataTable.Rows)
        //{
        //    tempRow = tempRow_Variable;
        //    // ListBox1.Items.Add((tempRow["id"] + " (" + tempRow["auteur"] + ")" + " (" + tempRow["content"] + ")" + " (" + tempRow["Tag"] + ")"));

        //    elm1.Value = tempRow["content"].ToString();
        //}

        

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
