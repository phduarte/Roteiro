<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gadz.Roteiro.Web.Campanhas.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <% if (campanhas.Count == 0) { %>
    <div class="box-center">
        <span>Usuário não possui campanhas disponíveis.</span>
    </div>
    <% } else { %>
	<div class="malink">
        <% foreach (var c in campanhas) { %>
        <div class="plink">
            <a href="<% = ResolveUrl("~/Passos/Iniciar.aspx?c=" + c.Id) %>" >
            	<img src="<%= ResolveUrl("~/assets/img/icons/" + c.Icone) %>" alt=""/>
                <h5><%= c.Nome%></h5>
                <p><%= c.Descricao%></p>
            </a>
        </div>
        <% } %>
    </div>
    <% } %>
</asp:Content>