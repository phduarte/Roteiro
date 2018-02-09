<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Terminar.aspx.cs" Inherits="Gadz.Roteiro.Web.Passos.Terminar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .w
        {
            font-size: 2em;
            color: #fff
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="Formulario" runat="server">

        <div class="w box-center">
            <span>Protocolo : </span>
            <asp:Label ID="lbProtocolo" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="txtTexto" runat="server"></asp:Label>
            <br />
            <asp:HiddenField ID="TxtIdInteracao" runat="server" />
            <div style="height: 100px">
                <asp:Button ID="BtnVoltar" runat="server" CssClass="color4 t voltar" OnClick="Voltar" Text="Voltar" />
                <asp:Button ID="BtnAvancar" runat="server" CssClass="color4 t avancar" OnClick="Avancar" Text="Avançar" />
            </div>
        </div>
    </form>

</asp:Content>
