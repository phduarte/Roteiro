<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gadz.Roteiro.Web.Vendedores.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="malink">
        <div id="Usuarios" class="plink" runat="server">
            <a href="Pesquisar.aspx">
            	<img src="../../assets/img/icons/user.png" alt=""/>
                <h5>Usuários</h5>
                <p>Gerencie o acesso de todos os usuários do sistema</p>
            </a>
        </div>
    </div><!-- main-box-links -->
</asp:Content>