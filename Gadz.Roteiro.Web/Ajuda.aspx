<%@ Page Title="Ajuda" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ajuda.aspx.cs" Inherits="Gadz.Roteiro.Web.Ajuda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #ajuda
        {
            margin: 0 auto;
            width: 800px;
        }

        #ajuda ul
        {
            font-size: 20px;
            list-style-type: none;
            padding: 5px;
        }
        
        #ajuda ul li
        {
            background-color: #fbfbfb;
            padding: 5px;
        }
        
        #ajuda ul li p
        {
            padding: 10px;
            background-color: #fff;
            font-size: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ajuda">
        <ul>
            <li class="topico">Como acessar o sistema?
                <p>
                    Você será redirecionado à tela de login sempre que não estiver autenticado e tentar acessar um conteúdo projegido ou clicar no botão "login" no canto superior direito da aplicação.
                    <br /><br />
                    Nesta tela você poderá acessar o conteúdo protegído do aplicativo de acordo com seus previlégios.
                    <br /><br />
                    Para isto você deve utilizar o usuário e a senha da rede.
                    <br /><br />
                    Liberação de novo acesso deve ser solicitada via chamado no SysAid
                    <br /><br />
                    Os usuários e senhas são gerenciadas pelo servidor de Rede administrada pela equipe de TI, logo, a manutenção, compartilhamento e 
                    usuários e senhas podem ferir políticas de segurança da empresa.
                    <br /><br />
                    Uma vêz que os usuários são gerenciados pelo servidor de Rede, não é possível resetar, alterar nem recuperar a senha através dessa aplicação.
                </p>
            </li>
        </ul>
    </div><!-- ajuda -->
</asp:Content>