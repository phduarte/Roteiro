<%@ Page Title="" ClientIDMode="Static" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecuperarSenha.aspx.cs" Inherits="Gadz.Roteiro.Web.Acesso.RecuperarSenha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #content
        {
            background-color:#FFF;
        }
        #box-formulario
        {
            width:350px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="content">
    <div id="box-formulario" class="box-center">
	    <form id="frmFormulario" runat="server">
            <div id="top">
                <h5># Recuperar senha</h5>
                <a href="Login.aspx" class="fechar"></a>
            </div>    <!-- top -->
            <div id="center">
                <table>
                    <tr>
                        <td style="width:110px;"><label for="txtUsuario" class="rotulo">Usuário</label></td>
                        <td>
                        <input 	type="text" 
                                id="txtUsuario"
                                value=""
                                style=" width:100px;" 
                                maxlength="10"
                                runat="server" 
                                clientidmode="Static" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtUsuario" ErrorMessage="Obrigatório"></asp:RequiredFieldValidator>
                        </td>
			        </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnEntrar" CssClass="botao" Text="Recuperar" OnClick="Recuperar" runat="server" />
                        </td>
                    </tr>
			    </table>
            </div> <!-- center -->
            <div id="bottom"></div> <!-- bottom -->
        </form>
    </div><!-- box-formulario -->
</div>
</asp:Content>