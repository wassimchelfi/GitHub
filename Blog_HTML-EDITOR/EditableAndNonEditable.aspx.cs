using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditableAndNonEditable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.elm1.Value = "<p>This is a test document. Some <span class='mceNonEditable' style=\"color: #ff0000;\">Portion</span> of this document can't be changed.</p>\r\n<p>The area with red <span class='mceNonEditable' style=\"color: #ff0000;\">background </span>can't be <span class='mceNonEditable' style=\"color: #ff0000;\">removed</span>. You can only <span class='mceNonEditable' style=\"color: #ff0000;\">change </span>the area with black.</p>\r\n<p>&nbsp;</p>";

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write(this.elm1.Value);
    }
}
