<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_var.aspx.cs" Inherits="Gadz.Roteiro.Web._var" %>
<!DOCTYPE html>
<html>
    <head runat="server">
        <title>WATCHER</title>
        <style type="text/css">
            body
            {
	            background-color:#000;
	            color:#093;
	            font-family:Arial, Helvetica, sans-serif;
	            font-size:12px;
	            margin:10px;
            }
            .value
            {
	            color:#999;
	            font-weight:normal;
	            font-style:italic;
            }
            .botao
            {
	            height:20px;
	            width:120px;
	            background-color:#390;
	            color:#000;
	            font-size:12px;
	            border:none;
            }
        </style>
    </head>
    <body>
    <form action="_var.aspx" method="post" target="_top" enctype="application/x-www-form-urlencoded">
        <input type="submit" name="crack" value="atualizar" class="botao"/>
        <input type="submit" name="crack" value="break" class="botao"/>
    </form>
    <%
    
    Response.Buffer = true;
    Response.Write("<h4>Application Variables</h4>");

    foreach(object i in Application.Contents)
        Response.Write("<strong>" + i.ToString() + "</strong> = <span class='value'>" + ((char)34).ToString() + Application[i.ToString()] + ((char)34).ToString() + "</span><br>");

    Response.Write("<h4>Auto Session Variables</h4>");

    Response.Write("<strong>SessionID</strong> = <span class='value'>" + ((char)34).ToString() +  Session.SessionID + ((char)34).ToString() + "</span><br>");
    Response.Write("<strong>CodePage</strong> = <span class='value'>" + ((char)34).ToString() +  Session.CodePage + ((char)34).ToString() + "</span><br>");
    Response.Write("<strong>LCID</strong> = <span class='value'>" + ((char)34).ToString() +  Session.LCID + ((char)34).ToString() + "</span><br>");
    Response.Write("<strong>Timeout</strong> = <span class='value'>" + ((char)34).ToString() +  Session.Timeout + ((char)34).ToString() + "</span><br>");

    Response.Write("<h4>Custom Session Variables</h4>");

    foreach(var i in Session.Contents)
	    Response.Write("<strong>" + i + "</strong> = <span class='value'>" + ((char)34).ToString() +  Session.Contents[i.ToString()] + ((char)34).ToString() + "</span><br>");

    foreach(var i in Session.StaticObjects)
        Response.Write("<strong>StaticObjects " + i + "</strong> = <span class='value'>" + ((char)34).ToString() + Session.StaticObjects[i.ToString()] + ((char)34).ToString() + "</span><br>");

    Response.Write("<h4>Cookies</h4>");

    foreach(var i in Request.Cookies)
        Response.Write("<strong>" + i + "</strong> = <span class='value'>" + ((char)34).ToString() + Request.Cookies[i.ToString()].Value + ((char)34).ToString() + "</span><br>");
    
    Response.Write("<h4>ServerVariables</h4>");

    foreach(var i in Request.ServerVariables)
        Response.Write("<strong>" + i + "</strong> = <span class='value'>" + ((char)34).ToString() + Request.ServerVariables[i.ToString()] + ((char)34).ToString() + "</span><br>");

    %>
    </body>
</html>