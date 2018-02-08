<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pesquisar.aspx.cs" Inherits="Gadz.Roteiro.Web.Vendedores.Pesquisar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .bloco
        {
            height:70px;
        }
        #box-agenda
        {
            width:880px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
    <div id="box-agenda">
        <div id="box-filtro">
            <fieldset class="bloco">
                <legend>Ferramentas</legend>
                <table>
                    <tr>
                        <td></td>
                        <td>
                            <div class="link">
                                <a href="Cadastrar.aspx" rel="Subsection">
                                    <img src="../../assets/img/controls/add.gif" style="border:none;width:16px; height:16px;" alt="" />
                                    <span style="line-height:16px;">Adicionar</span>
                                </a>
                            </div>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset class="bloco">
                <legend>Filtro</legend>
                <table>
                    <tr>
                        <td class="style1">Grupo</td>
                        <td class="style2">
                            <asp:DropDownList ID="CmbGrupo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ListarSupervisores">
                            </asp:DropDownList>
                        </td>
                        <td class="style1">Supervisor</td>
                        <td class="style2">
                            <asp:DropDownList ID="CmbSupervisor" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                        <td class="style1">Critério</td>
                        <td>
                            <asp:TextBox ID="TxtCriterio" runat="server"></asp:TextBox>
                            <asp:Button ID="BtnPesquisar" runat="server" OnClick="Preencher" 
                                CssClass="botao" Text="Pesquisar" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div id="box-tabela">
        <asp:GridView   ID="Tabela" 
                        AutoGenerateColumns="False" 
                        runat="server" 
                        ForeColor="#333333" 
                        GridLines="None" CellPadding="4">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="id_usuario" ItemStyle-Width="50" />
                <asp:BoundField HeaderText="Usuário" DataField="usuario" ItemStyle-Width="80" />
                <asp:BoundField HeaderText="Nome" DataField="nome" ItemStyle-Width="200" />
                <asp:BoundField HeaderText="Supervisor" DataField="superior1" ItemStyle-Width="200" />
                <asp:BoundField HeaderText="Grupo" DataField="grupo" ItemStyle-Width="150" />
                <asp:BoundField HeaderText="Cargo" DataField="cargo" ItemStyle-Width="150" />
                <asp:BoundField HeaderText="Perfil" DataField="perfil" ItemStyle-Width="50" />
                <asp:BoundField HeaderText="Status" DataField="status" ItemStyle-Width="50" />
                <asp:HyperLinkField Text="<img src='../../assets/img/controls/tools.gif' style=' border: none; width: 18px;' />" DataNavigateUrlFields="id_usuario" DataNavigateUrlFormatString="UsuariosCadastrar.aspx?i={0}" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </div>
    </div>
    </form>
</asp:Content>