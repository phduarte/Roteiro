<%@ Page Title="Alterar Senha" ClientIDMode="Static" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlterarSenha.aspx.cs" Inherits="Gadz.Roteiro.Web.Acesso.AlterarSenha" %>
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
<div id="box-formulario" class="box-center">
	<form id="frmFormulario" runat="server">
        <div id="top">
        </div><!-- top -->
        <div id="center">
        <table>
        <tr>
            <td style="width:110px;"><label class="rotulo" for="usuario">Nova Senha</label></td>
            <td>
            <input 	type="password" 
                    id="txtSenha"
                    value=""
                    style=" width:100px;" 
                    maxlength="10"
                    runat="server"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtSenha" ErrorMessage="Obrigatório"></asp:RequiredFieldValidator>
            </td>
		</tr>
        <tr>
            <td><label class="rotulo" for="senha">Confirma</label></td>
            <td><input 	type="password" 
                        id="txtConfirmaSenha" 
                        style=" width:100px;" 
                        maxlength="10"
                        runat="server"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtConfirmaSenha" ErrorMessage="Obrigatório"></asp:RequiredFieldValidator>
            </td>
		</tr>
        <tr>
            <td><asp:TextBox ID="txtIdUsuario" Visible="false" runat="server"></asp:TextBox></td>
            <td>
                <asp:Button ID="btnEntrar" CssClass="botao" Text="Alterar" OnClick="Alterar" runat="server" />
            </td>
        </tr>
		</table>
        </div><!-- center -->
        <div id="bottom">
            Sua senha deve conter no máximo 10 caracteres.<br />
        </div><!-- bottom -->
    </form>
</div><!-- box-formulario -->
</asp:Content>