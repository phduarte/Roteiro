<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Gadz.Roteiro.Web.Acesso.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Assets/css/login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="content">
    <div id="login" class="box-center">
	    <form id="frmFormulario" runat="server">
        	<div class="vetrina">
				<img src="../assets/img/bg/logo.png" class="logo" alt="" />
        		<div class="caracteristicas">
                    <ul>
                        <!-- <li>Script de Televendas</li> -->
                    </ul>
				</div><!-- caracteristicas -->
            </div><!-- box_left -->
			<div class="login">
                <div class="top">
                    <h5># Acesso</h5>
                </div><!-- top -->
                <div class="center">
                <table>
                <tr>
                	<td style="width:110px;"><label for="usuario">Usuário</label></td>
                    <td>
                    <input 	type="text" 
                            id="txtUsuario"
                            value=""
                            style=" width:100px;" 
                            runat="server" 
                            maxlength="20"
                            clientidmode="Static" class="color3 input text border4" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtUsuario" ErrorMessage="Obrigatório"></asp:RequiredFieldValidator>
                    </td>
				</tr>
                <tr>
                	<td><label for="senha">Senha</label></td>
                    <td><input 	type="password" 
                                id="txtSenha" 
                                style=" width:100px;" 
                                maxlength="20"
                                runat="server" 
                                clientidmode="Static" class="color3 input text border4"/>
                        <!--<a href="RecuperarSenha.aspx" title="Esqueci minha senha" rel="Subsection">[?]</a>-->
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtSenha" ErrorMessage="Obrigatório"></asp:RequiredFieldValidator>
                    </td>
				</tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnEntrar" CssClass="botao color4" Text="Entrar" OnClick="Entrar" runat="server" />
                    </td>
                </tr>
				</table>
                </div><!-- center -->
               	<div class="bottom">
                </div><!-- bottom -->
			</div> <!-- box_right -->
        </form>
    </div>
</div>
</asp:Content>