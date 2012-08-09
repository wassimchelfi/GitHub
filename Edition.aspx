<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edition.aspx.cs" Inherits="Edition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<script type="text/javascript" src="tinymce/jscripts/tiny_mce/tiny_mce.js"></script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7/jquery.min.js"></script>

    <script type="text/javascript">
        tinyMCE.init({
            // General options
            mode: "textareas",
            theme: "advanced",
            encoding: "xml",
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,wordcount,advlist,autosave",

            setup: function (ed) {

                ed.onSaveContent.add(function (i, o) {
                    o.content = o.content.replace(/&#39/g, "&apos");
                });

                //                ed.onKeyPress.add(
                //                    function(ed, evt) {
                //                        //                        alert(ed.selection.getNode);
                //                        p = ed.selection.getNode();
                //                        alert(p.style.backgroundColor);
                //                        //                        if (p = ed.dom.getParent(ed.selection.getNode(), 'span'))
                //                        //                            v = p.style.backgroundColor;

                //                        //alert(ed.selection.getContent());
                //                        //alert(ed.selection.getStart().childNodes.getContent());
                //                        //var s = $(ed.id + "_preview").getStyle()
                //                        //alert(s);


                //                        //alert(inputColor);
                //                        //                        f = tinyMCEPopup.getWindowArg('func')
                //                        //                        alert(f);
                //                        // alert("Editor-ID: " + ed.id + "\nEvent: " + evt + evt.keyCode.attr('color'));
                //                        // Do some great things here...
                //                    }
                //                );
            },
            // Theme options
            theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect",
            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
            theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak,restoredraft",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom",
            theme_advanced_resizing: true,

            // Example content CSS (should be your site CSS)
            content_css: "css/content.css",

            // Drop lists for link/image/media/template dialogs
            template_external_list_url: "lists/template_list.js",
            external_link_list_url: "lists/link_list.js",
            external_image_list_url: "lists/image_list.js",
            media_external_list_url: "lists/media_list.js",

            // Style formats
            style_formats: [
			{ title: 'Bold text', inline: 'b' },
			{ title: 'Red text', inline: 'span', styles: { color: '#ff0000'} },
			{ title: 'Red header', block: 'h1', styles: { color: '#ff0000'} },
			{ title: 'Example 1', inline: 'span', classes: 'example1' },
			{ title: 'Example 2', inline: 'span', classes: 'example2' },
			{ title: 'Table styles' },
			{ title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
		],

            // Replace values for the template plugin
            template_replace_values: {
                username: "Some User",
                staffid: "991234"
            }
        });
        

    </script>

    <!-- /TinyMCE -->
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList3_SelectedIndexChanged">
            <asp:ListItem>Tag</asp:ListItem>
            <asp:ListItem>ID</asp:ListItem>
            <asp:ListItem>Auteur</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource1" DataTextField="Tag" DataValueField="Tag">
        </asp:DropDownList>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="Data Source=WAZZUP-PC\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True" 
            ProviderName="System.Data.SqlClient" 
            SelectCommand="SELECT DISTINCT [tag] FROM [Article_Blog]">
            <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList3" Name="tag" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    <br />
    <br />
    <br />
    <br />
    <asp:DropDownList ID="DropDownList2" runat="server" 
        DataSourceID="SqlDataSource2" DataTextField="id" DataValueField="id" 
        onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
        AutoPostBack="True">
    </asp:DropDownList>
    
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="Data Source=WAZZUP-PC\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT DISTINCT [id] FROM [Article_Blog] WHERE ([tag] = @tag)">
        <SelectParameters>
        <asp:ControlParameter ControlID="DropDownList1" Name="tag" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <textarea id="elm1" name="element1" rows="15" cols="80" style="width: 80%" runat="server" onclick="return elm1_onclick()"></textarea>
    <div>
        &nbsp;<br />
        <br />
        ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        Auteur&nbsp; :
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        Tag&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource3">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Auteur" HeaderText="Auteur" 
                    SortExpression="Auteur" />
                <asp:BoundField DataField="Content" HeaderText="Content" 
                    SortExpression="Content" />
                <asp:BoundField DataField="Tag" HeaderText="Tag" SortExpression="Tag" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="Data Source=WAZZUP-PC\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True" 
            ProviderName="System.Data.SqlClient" 
            SelectCommand="SELECT * FROM [Article_Blog]" 
            UpdateCommand =""
            DeleteCommand ="">

        </asp:SqlDataSource>
        <br />
        <br />
        <br />
        <br />
        <br />

    </div>
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
