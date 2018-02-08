using System;
using System.Collections.Generic;
using Gadz.Roteiro.Core.DomainModel.Planos;

namespace Gadz.Roteiro.Web.Passos {
    public partial class Proposta : Passo {

        protected string argumentos = "";
        protected string arvore = "";
        protected IList<IPlano> planos = new List<IPlano>();

        protected void Page_Load(object sender, EventArgs e) {

            if (Interacao == null)
                Response.Redirect("~");

            if (!IsPostBack) {

                Rota.Definir($"<a href='../Default.aspx'>Início</a> > {CampanhaAtual} > Proposta");

                TxtGastoMensal.Value = "0";
                TxtPlanoId.Value = "0";
                CmbAceitou.SelectedValue = "0";
                TxtLocalidade.Value = "";
                Preencher();
                PreencherArvore();
            }
        }
        //
        protected override void Avancar(object sender, EventArgs e) {
            if (TxtPlanoId.Value.Equals("0")) {
                Msgbox.Show("Clique sobre o plano que foi ofertado.");
                Preencher();
                PreencherArvore();
            } else {

                Interacao.EscolherPlano(TxtPlanoId.Value);

                Salvar();
                Response.Redirect($"~/Passos/{Interacao.Status}.aspx?.id={Interacao.Id}");
            }
        }
        //
        protected void Preencher() {

            planos = Interacao.Planos;
            TxtPlanoId.Value = Interacao.PlanoEscolhido?.Id;
            CmbAceitou.SelectedValue = Interacao.Aceitou ? "1" : "0";

            //using(conn = new Connection()){

            //    sql = @"select convert(decimal(9,2),total) as total
            //            from vw_InteracoesGastoMensal 
            //            where Interacao_Id = {0}";

            //    using (SqlDataReader rec = conn.Query(sql, TxtIdInteracao.Value)) {
            //        if (rec != null && rec.HasRows && rec.Read()) {
            //            TxtGastoMensal.Value = rec[0].ToString().ToMoney();
            //        }
            //    }

            //    //localidade
            //    sql = @"select Resposta
            //            from vw_InteracoesLocalidade
            //            where Interacao_Id = {0}";

            //    using (SqlDataReader rec = conn.Query(sql, TxtIdInteracao.Value)) {
            //        if (rec != null && rec.HasRows && rec.Read()) {
            //            TxtLocalidade.Value = rec["Resposta"].ToString();
            //        }
            //    }

            //    sql = @"select a.ArgumentoMenor,a.ArgumentoIgual, a.ArgumentoMaior
            //            from Campanhas a with(nolock) 
            //            where a.Id = (select top 1 Campanha_Id from Interacoes with(nolock) where Id = {0})";

            //    using (SqlDataReader rec = conn.Query(sql, TxtIdInteracao.Value)) {
            //        if (rec != null && rec.HasRows && rec.Read()) {
            //            argumentos = "[\"" + rec[0].ToString() + "\",\"" + rec[1].ToString() + "\",\"" + rec[2].ToString() + "\"]";
            //        }
            //    }

            //    sql = @"select Id,Nome,Descricao,Preco,PlanoTipo_Id,Localidade,Tipo
            //            from fn_InteracaoPlanos({0},'{1}','{2}')
            //            where Visivel = 1 
            //            order by Preco desc;";

            //    using (SqlDataReader rec = conn.Query(sql, TxtIdInteracao.Value, TxtLocalidade.Value, TxtGastoMensal.Value)) {
            //        if (rec != null && rec.HasRows) {
            //            while (rec.Read()) {
            //                planos.Add(new Plano() {
            //                    Id = rec["Id"].ToString().ToInt(),
            //                    Nome = rec["Nome"].ToString(),
            //                    Descricao = rec["Descricao"].ToString(),
            //                    Preco = decimal.Parse(rec["Preco"].ToString().ToMoney()) / 100,
            //                    Tipo = (PlanoTipo)rec["PlanoTipo_Id"].ToString().ToInt(),
            //                    Localidade = rec["Localidade"].ToString()
            //                });
            //            }
            //        }
            //    }
            //}
        }
        //
        protected void PreencherArvore() {

            string[] _campos = { };

            foreach (IPlano plano in planos) {
                Array.Resize(ref _campos, _campos.Length + 1);
                _campos[_campos.Length - 1] = "{\"id\" : \"" + plano.Id + "\",\"valor\" : \"" + plano.Preco + "\"}";
            }

            arvore = "[" + string.Join(",", _campos) + "]";
        }
        //
        protected override bool Salvar() {

            if (CmbAceitou.SelectedValue.Equals("1")) {
                Interacao.AceitarProposta();
            } else {
                Interacao.RejeitarProposta();
            }

            return base.Salvar();
        }
    }
}