<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Abordagem.aspx.cs" Inherits="Gadz.Roteiro.Web.Passos.Abordagem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img id="ImgOperacao" src="" class="emp-logo" alt="" runat="server" />
    <form id="Formulario" runat="server">
        
        <div class="w box-center">
            <div style=" padding:30px 0;">
                <asp:label id="Saudacao" runat="server" cssclass="s"></asp:label>
            </div>
            <div>
                <asp:label id="Texto" runat="server" cssclass="a"></asp:label>
            </div>
            <div style=" height:100px">
                <asp:button id="BtnVoltar" runat="server" CssClass="color4 t voltar" onclick="Voltar" text="Voltar" />
                <asp:button id="BtnAvancar" runat="server" CssClass="color4 t avancar" onclick="Avancar" text="Avançar" />
            </div>
        </div>
    
        <asp:HiddenField ID="TxtIdInteracao" runat="server" />
    </form>

</asp:Content>