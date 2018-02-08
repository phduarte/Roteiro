<%@ Page Title="Versões" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Versoes.aspx.cs" Inherits="Gadz.Roteiro.Web.Versoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/css/versoes.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="versoes">
        <% foreach (var versao in versoes) { %>
        <div>
            <h1><% = versao.Nome %></h1>
            <span><% = versao.Data %></span>
            <ul>
                <% foreach (string solucao in versao.Solucoes) { %>
                <li><% = solucao %></li>
                <% } %>
            </ul>
        </div>
        <% } %>
    </div>
</asp:Content>