<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Aceite.aspx.cs" Inherits="Gadz.Roteiro.Web.Passos.Aceite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img id="ImgOperacao" src="" class="emp-logo" alt="" runat="server" />
    <form id="Formulario" runat="server">
        <div class="w box-center">
            <div style=" max-height: 400px; overflow-y: scroll;">
                <asp:CheckBoxList ID="Validacoes" runat="server" ClientIDMode="Static">
    
                </asp:CheckBoxList>
            </div>
            <div>
                <asp:button id="BtnVoltar" CssClass="color4 t voltar" runat="server" onclick="Voltar" text="Voltar" />
                <asp:button id="BtnAvancar" CssClass="color4 t avancar" runat="server" onclick="Avancar" text="Avançar" />
            </div>
        </div>
        <asp:HiddenField ID="TxtIdInteracao" runat="server" />
    </form>
</asp:Content>