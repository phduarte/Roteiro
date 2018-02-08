<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastrar.aspx.cs" Inherits="Gadz.Roteiro.Web.Vendedores.Cadastrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #box-formulario
        {
            width:500px;
        }
        .style1
        {
            width: 98px;
        }
        .style2
        {
            width: 98px;
            height: 80px;
        }
        .style3
        {
            height: 80px;
        }
        .style4
        {
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="box-formulario">
        <form id="form1" runat="server">
        <div id="top">
            <h5># Usuário</h5>
            <a href="UsuariosPesquisar.aspx" class="fechar"></a>
        </div><!-- box-top -->
        <div id="center">
            <table>
                <tr>
                    <td class="style1"><label class="rotulo">Usuário</label></td>
                    <td><asp:TextBox ID="TxtUsuario" runat="server" BackColor="#FFFFCC" Width="84px" 
                            MaxLength="10"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="Obrigatório" ControlToValidate="TxtUsuario"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1"><label class="rotulo">Nome</label></td>
                    <td><asp:TextBox ID="TxtNome" runat="server" BackColor="#FFFFCC" Width="280px" 
                            MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="Obrigatório" ControlToValidate="TxtNome"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1"><label class="rotulo">Cargo</label></td>
                    <td><asp:TextBox ID="TxtCargo" runat="server" BackColor="#FFFFCC" Width="250px" 
                            MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="Obrigatório" ControlToValidate="TxtCargo"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1"><label class="rotulo">Email</label></td>
                    <td><asp:TextBox ID="TxtEmail" runat="server" BackColor="#FFFFCC" Width="250px" 
                            MaxLength="75"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ErrorMessage="Obrigatório" ControlToValidate="TxtEmail"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1"><label class="rotulo">Gestor</label></td>
                    <td>
                        <asp:DropDownList ID="CmbGestor" runat="server" BackColor="#FFFFCC" 
                            Height="22px" Width="250px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ErrorMessage="Obrigatório" ControlToValidate="CmbGestor"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1"><label class="rotulo">Grupo</label></td>
                    <td>
                        <asp:DropDownList ID="CmbGrupo" runat="server" BackColor="#FFFFCC" 
                            Height="22px" Width="135px">
                            <asp:ListItem >Selecione...</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ErrorMessage="Obrigatório" ControlToValidate="CmbGrupo"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1"><label class="rotulo">Perfil</label></td>
                    <td>
                        <asp:DropDownList ID="CmbPerfil" runat="server" BackColor="#FFFFCC" 
                            Height="22px" Width="135px">
                            <asp:ListItem >Selecione...</asp:ListItem>
                            <asp:ListItem Value="A" Text="Analista"></asp:ListItem>
                            <asp:ListItem Value="B" Text="Operador"> </asp:ListItem>
                            <asp:ListItem Value="C" Text="Supervisor" ></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ErrorMessage="Obrigatório" ControlToValidate="CmbPerfil"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1"><label class="rotulo">Skills</label></td>
                    <td>
                        <asp:CheckBoxList ID="ChkSkills" runat="server">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="style1"><label class="rotulo">Status</label></td>
                    <td>
                        <asp:DropDownList ID="CmbStatus" runat="server" BackColor="#FFFFCC" 
                            Height="22px" Width="135px">
                            <asp:ListItem Value="A" >Ativo</asp:ListItem>
                            <asp:ListItem Value="I" >Inativo</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style2"> 
                    <asp:TextBox ID="IdUsuario" runat="server" Visible="false" ReadOnly="True" 
                        Text="0" Width="40px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSalvar" CssClass="botao" Text="Salvar" OnClick="Salvar" runat="server"/>
                    </td>
                </tr>
            </table>
        </div><!-- box-center -->
        <div id="bottom"></div><!-- box-bottom -->
        </form>
</div>
</asp:Content>