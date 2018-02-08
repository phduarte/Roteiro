<%@ Page Title="Sobre" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sobre.aspx.cs" Inherits="Gadz.Roteiro.Web.Sobre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/css/sobre.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="sobre" class="box-center">
        <div class="logo">
            <img src="assets/img/bg/logo.png" alt="" />
        </div>
        <div class="about">
            <h3 class="titulo"><% = Gadz.Roteiro.Web.App.Nome %></h3>
            <p class="assinatura" >Desenvolvido por <a href="mailto:phduarte87@outlook.com">Paulo Duarte</a> e em Julho de 2015</p>
            <a href="Versoes.aspx" style=" display: block; width: 100%; text-align: right;" >Veja o histórico de versões</a>
        </div>
        <ul class="objetivos">
            <li>
                Interativo durante a venda, se adapta conforme as decisões do cliente.
            </li>
            <li>
                Apoia o vendedor no decorrer de seu atendimento, com argumentos e contra propostas.
            </li>
            <li>
                Facilitar a adaptação de novos vendedores.
            </li>
            <li>
                Permitir o alinhamento das informações e procedimentos de forma online entre todos os vendedores.
            </li>
            <li>
                Catálogo de planos, benefícios e ofertas atualizadas.
            </li>
            <li>
                Coleta informações durante a fase de sondagem e as usa para elaborar a proposta.
            </li>
            <li>
                Aumento da qualidade no processo de vendas
            </li>
            <li>
                Salvar os registros dos dados da venda.
            </li>
        </ul>
    </div><!-- -->
</asp:Content>