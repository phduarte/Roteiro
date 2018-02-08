<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rebate.aspx.cs" Inherits="Gadz.Roteiro.Web.Passos.Rebate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img id="ImgOperacao" src="" class="emp-logo" alt="" runat="server" />
    <form id="Formulario" runat="server">
        <div class="w box-center">
            <div style=" margin:30px;">
                <label class="s">Por qual motivo o cliente não quer aceitar?</label>
                <asp:dropdownlist id="CmbMotivo" runat="server" CssClass="color2" onselectedindexchanged="Preencher" autopostback="true">
        
                </asp:dropdownlist>
            </div>
            <div class="p a">
                <asp:label id="LbContraArgumento" runat="server"></asp:label>
            </div>
            <div style=" margin:30px;">
                <label class="s">Após o contra-argumento o cliente aceitou a proposta?</label>
                <asp:DropDownList ID="CmbAceitou"  CssClass="color2" runat="server">
                    <asp:ListItem Value="1">Sim</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">Não</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <asp:button id="BtnVoltar" CssClass="color4 t voltar" runat="server" onclick="Voltar" text="Voltar" />
                <asp:button id="BtnAvancar" CssClass="color4 t avancar" runat="server" onclick="Avancar" text="Avançar" />
            </div>
        </div>
        <asp:HiddenField ID="TxtIdInteracao" runat="server" />
    </form>
</asp:Content>