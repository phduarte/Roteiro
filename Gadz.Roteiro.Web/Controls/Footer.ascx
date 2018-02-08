<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Gadz.Roteiro.Web.Controls.Footer" %>
<footer id="footer" class="color2">
    <div class="legal">
        <span class="duvida"><a href="mailto:<% = Email %>">Dúvidas ou sugestões</a></span>
        <span class="separator">|</span>
        <span class="copyright"><% = Powered %> &copy;</span>
    </div>
    <div class="assinatura">
        <a href="<% = ResolveUrl("~/Sobre.aspx") %>"><% = Autor %></a>
        <span class="developer">Desenvolvido por</span>
        <span class="separator">|</span>
        <span class="versao"><a href="<% = ResolveUrl("~/Versoes.aspx") %>">Versão <% = Versao %></a></span>
    </div>
</footer>