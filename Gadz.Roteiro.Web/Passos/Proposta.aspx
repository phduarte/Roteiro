<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proposta.aspx.cs" Inherits="Gadz.Roteiro.Web.Passos.Proposta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../assets/lib/owl-carousel/owl.carousel.css" />
    <link rel="stylesheet" href="../assets/lib/owl-carousel/owl.theme.css" />
    <link href="../assets/lib/ShadownBox/Shadowbox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #sb-info {
            position: absolute;
            right: 0;
            top: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img id="ImgOperacao" src="" class="emp-logo" alt="" runat="server" />
    <form id="Formulario" runat="server">
        <div class="w box-center">
            <div style="padding: 30px 0; height: 200px;">
                <div style="color: #fff; font-size: 13pt;">
                    <% if (!TxtGastoMensal.Value.Equals("0")) { %>
                    O cliente gasta média de R$ <% = TxtGastoMensal.Value %> por mês.
                    <% } %>
                    <br />
                    <span style="font-size: 9pt; display: block; margin: 5px 0;">CLIQUE NO MELHOR PLANO PARA ELE e clique duas vezes para visualizar os benefícios de cada plano.</span>
                </div>
                <div id="planos" class="color2 owl-carousel">
                    <% foreach (var plano in planos) { %>
                    <div id="<% = plano.Id %>" class="plano plano-<% = plano.Tipo %>" ondblclick="return openTopSBX('<% = plano.Nome %>','<% = plano.Id %>')">
                        <h2 class="plano-titulo"><% = plano.Nome %></h2>
                        <p class="plano-descricao"><% = plano.Descricao %></p>
                        <span class="plano-preco">
                            <span class="simbolo">R$</span>
                            <span class="reais"><% = string.Format("{0:N0}", plano.Preco - (plano.Preco % (int)plano.Preco))%></span>
                            <sup class="centarro"><% = string.Format("{0:N00}", (plano.Preco % (int)plano.Preco) * 100)%></sup>
                        </span>
                        <p><% = plano.Descricao %></p>
                    </div>
                    <% } %>
                </div>
                <div style="clear: both; float: left; color: #fff; font-size: 11pt; border-bottom: 1px solid #fff;">
                    SCRIPT
                </div>
            </div>
            <div id="texto" class="a" style="clear: both;">
            </div>
            <div style="margin: 10px; display: inline; clear: both; float: right;">
                <div style="color: #fff; font-size: 13pt; border-bottom: 1px solid #fff;">
                </div>
                <label class="s">O cliente aceitou a proposta?</label>
                <asp:DropDownList ID="CmbAceitou" runat="server" CssClass="color3">
                    <asp:ListItem Value="1">Sim</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">Não</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="height: 100px; clear: both;">
                <asp:Button ID="BtnVoltar" runat="server" CssClass="color4 t voltar" OnClick="Voltar" Text="Voltar" />
                <asp:Button ID="BtnAvancar" runat="server" CssClass="color4 t avancar" OnClick="Avancar" Text="Avançar" />
            </div>
        </div>
        <asp:HiddenField ID="TxtLocalidade" runat="server" Value="" />
        <asp:HiddenField ID="TxtGastoMensal" runat="server" ClientIDMode="Static" Value="0" />
        <asp:HiddenField ID="TxtPlanoId" runat="server" ClientIDMode="Static" Value="0" />
        <asp:HiddenField ID="TxtOfertTipo" runat="server" ClientIDMode="Static" Value="0" />
        <asp:HiddenField ID="TxtIdInteracao" runat="server" />
    </form>
</asp:Content>
<asp:Content ContentPlaceHolderID="Scripts" runat="server">
    <script type="text/javascript" src="../assets/lib/ShadownBox/shadowbox.js"></script>
    <script>
        var sbx = Shadowbox;

        Shadowbox.init({
            handleOversize: "resize",
            modal: false
        });

        function openTopSBX(nome, id) {
            if (sbx) {
                sbx.open({ content: "Beneficios.aspx?id=" + id, player: "iframe", title: nome || "", width: 840, height: 400 });
                return false;
            } else { //no Shadowbox in parent window! 
                return true;
            }
        }
    </script>
    <script type="text/javascript" src="../assets/lib/owl-carousel/owl.carousel.min.js"></script>
    <script type="text/javascript">

        var _msg = '<% = argumentos %>';
        var x = <% = arvore %>;
        
        // TODO: criar lista
        function escolher(ob) {
            //
            $(".plano").each(function () {
                $(this).removeClass("plano-escolhido");
            });

            $(ob).addClass("plano-escolhido");

            document.getElementById("TxtPlanoId").value = ob.id;
            calcular();

            return false;
        }

        function calcular() {

            var atual = parseFloat(document.getElementById("TxtGastoMensal").value.replace(',', '.'));
            var novo = parseFloat(pegarValor(document.getElementById("TxtPlanoId").value).replace(',', '.'));
            var resultado = (atual - novo);
            var texto = document.getElementById("texto");
            var tipoOferta = document.getElementById("TxtOfertTipo");

            if (resultado > 1) {
                //alert("Oferta menor");
                texto.innerHTML = _msg[0].replace('@', resultado.toFixed(2));
                tipoOferta.value = 3;
            } else if (resultado < 0) {
                //alert("Oferta maior");
                texto.innerHTML = _msg[2].replace('@', Math.abs(resultado).toFixed(2));
                tipoOferta.value = 1;
            } else {
                //alert("Oferta igual");
                texto.innerHTML = _msg[1].replace('@', Math.abs(resultado).toFixed(2));
                tipoOferta.value = 2;
            }
        }

        function pegarValor(id) {
            var _retorno = 0.0;
            for (i = 0; i < x.length; i++) {
                if (x[i].id == id) {
                    _retorno = x[i].valor;
                    break;
                }
            }
            return _retorno;
        }

        $(document).ready(function () {
            $(".plano").click(function () { escolher(this); CenterInContent(); });
            $(".plano").each(function () {
                if (this.id == document.getElementById("TxtPlanoId").value) {
                    escolher(this);
                }
            });
        });

        try {
            $("#planos").owlCarousel({
                items: 3
            });
        } catch (e) {
        }

    </script>
</asp:Content>
