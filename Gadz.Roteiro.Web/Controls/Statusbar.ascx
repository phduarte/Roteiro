<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Statusbar.ascx.cs" Inherits="Gadz.Roteiro.Web.Controls.Statusbar" %>
<% if (logado) { %>
<section id="status" class="color2">
    <span class="rota">
        <asp:Literal ID="lbRota" runat="server">ROTA</asp:Literal>
    </span>
    <span class="perfil">
        <asp:Literal ID="lbPerfil" runat="server">PERFIL</asp:Literal>
    </span>
</section>
<% } %>