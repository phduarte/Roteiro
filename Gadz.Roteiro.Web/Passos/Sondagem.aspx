<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sondagem.aspx.cs" Inherits="Gadz.Roteiro.Web.Passos.Sondagem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../assets/lib/jQuery-Mask-Plugin-master/src/jquery.mask.js" type="text/javascript"></script>
    <script type="text/javascript">
        //
        function valida() {

            var _retorno = true;
            var campos = document.getElementsByClassName("obrigatorio");

            for (i = 0; i < campos.length; i++) {
                _retorno = _retorno && campos[i].value != "";

                if (!_retorno){
                    $(campos[i]).addClass("obrigatorio-err");
                    break;
                    }
            }

            return _retorno;
        }

        $(document).ready(function () {

            $(".calendario").datepicker();
            $(".data").mask("00/00/0000", { placeholder: "__/__/____" });
            $(".cpf").mask("000.000.000-00", { placeholder: "___-___-__" });
            $(".telefone").mask("(00)0000-0000");
            $(".cep").mask("00000-000");
            $(".tempo").mask("00:00:00", { placeholder: "__:__:__" });
            $('.money').mask('#.##0,00', { reverse: true });
            $('.datetime').mask('00/00/0000 00:00:00');
            $('.percent').mask('##0,00%', { reverse: true });

            //valida campos numéricos
            $(".numero").keypress(function () {
                return numeros(this);
            });
            
            $(".obrigatorio").keyup(function (e) {
                $(this).removeClass("obrigatorio-err");
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img id="ImgOperacao" src="" class="emp-logo" alt="" runat="server" />
    <form id="Formulario" runat="server" onsubmit="return valida()">
        <div class="w box-center">
            <asp:panel id="Premissas" runat="server">
    
            </asp:panel>
            <div style=" height:100px">
                <asp:button id="BtnVoltar" runat="server" CssClass="color4 t voltar" onclick="Voltar" text="Voltar" />
                <asp:button id="BtnAvancar" runat="server" CssClass="color4 t avancar" onclick="Avancar" text="Avançar" />
            </div>
        </div>
        <asp:HiddenField ID="TxtIdInteracao" runat="server" />
    </form>
</asp:Content>