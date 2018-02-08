<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Beneficios.aspx.cs" Inherits="Gadz.Roteiro.Web.Passos.Beneficios" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Benefícios</title>
    <link href="../assets/css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/malinks.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body{ background-color: #fff; color: #000;}
        
        #beneficios
        {
            width: 800px;
            margin: 0px auto;
        }
                
        .icone
        {
            width: 64px;
            float: left;
        }
        
        .descricao
        {
            color: #000 !important;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="beneficios" class="malink">
        <asp:Label ID="NomeCampanha" runat="server"></asp:Label>
        <% foreach(var item in lista){ %>
            <div class="beneficio plink">
                <img src="../assets/Img/Icons/<% = item.Icone %>" alt="<% = item.Nome %>" class="icone" />
                <h5 class="titulo"><% = item.Nome %></h5>
                <p class="descricao"><% = item.Descricao %></p>
            </div>
        <% } %>
    </div>
    </form>
</body>
</html>