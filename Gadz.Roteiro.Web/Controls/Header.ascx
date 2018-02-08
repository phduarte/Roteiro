<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Gadz.Roteiro.Web.Controls.Header" %>
<header id="header" class="color1">
    <a href="~/Default.aspx" target="_top" class="titulo" runat="server">
        <% = AppName %>
    </a>
    <a href="~/Acesso/Logout.aspx" target="_top" runat="server">
        <img class="botao"
            src="~/assets/img/buttons/btn_sair.png" alt="botão sair"
            runat="server" id="imgLogout" visible="false" />
    </a>
    <a href="~/Default.aspx" runat="server">
        <img class="botao"
            src="~/assets/img/buttons/btn_adm.png" alt="botão administrador"
            runat="server" id="imgAdm" visible="false" />
    </a>
</header>