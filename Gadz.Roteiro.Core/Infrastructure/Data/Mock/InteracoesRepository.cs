using System.Collections.Generic;
using System.Linq;
using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Interacoes;

namespace Gadz.Roteiro.Core.Infrastructure.Data.Mock {

    internal class InteracoesRepository : IInteracoesRepository {

        readonly CampanhasRepository _campanhaRepository;
        readonly VendedoresRepository _vendedorRepository;

        static IList<IInteracao> _cache = new List<IInteracao>();

        public InteracoesRepository() {
            _campanhaRepository = new CampanhasRepository();
            _vendedorRepository = new VendedoresRepository();
        }

        public IInteracao Create(Identity idUsuario, Identity idCampanha) {

            var vendedor = _vendedorRepository.Get(idUsuario);
            var campanha = _campanhaRepository.Get(idCampanha);

            var interacao = new Interacao { Campanha = campanha, Vendedor = vendedor };

            _cache.Add(interacao);

            return interacao;
        }

        public string PegarAbordagem(Identity idInteracao) {

            //using (conn = new Connection()) {

            //    string sql = @"select b.Abordagem 
            //                   from Interacoes a with(nolock) inner join Campanhas b with(nolock) on a.Campanha_Id = b.Id 
            //                   where a.Id = {0}";

            //    using (SqlDataReader rec = conn.Query(sql, TxtIdInteracao.Value)) {
            //        if (rec != null && rec.HasRows && rec.Read()) {
            //            Texto.Text = rec["abordagem"].ToString().Replace("<nome>", _nome);
            //        }
            //    }
            //}

            var interacao = Get(idInteracao);

            return interacao.Abordagem;
        }

        public void Terminar(Identity id) {

            //using (conn = new Connection()) {
            //    _retorno = conn.Execute("update Interacoes set Situacao = 'F', DataTermino = getdate() where Id = {0}", Request.QueryString["id"]);
            //}
            var interacao = Get(id);
            interacao.Terminar();
        }

        public IInteracao GetPending(Identity idUsuario, Identity idCampanha) {

            //using (conn = new Connection()) {

            //    string sql = @"select isnull(min(Id),0) as Id 
            //                   from Interacoes with(nolock) 
            //                   where Usuario_Id = {0} and Campanha_Id = {1} and Situacao = 'P'";

            //    using (SqlDataReader rec = conn.Query(sql, sessao.IdUsuario, idCampanha)) {
            //        if (rec != null && rec.HasRows && rec.Read()) {
            //            _retorno = int.Parse(rec[0].ToString());
            //        }
            //    }
            //}
            return _cache.FirstOrDefault(x => x.Vendedor.Id.Equals(idUsuario) && x.Campanha.Id.Equals(idCampanha) && !x.Status.Concluida);
        }

        public void Save(IInteracao interacao) {
            var x = Get(interacao.Id);
            _cache.Remove(x);
            _cache.Add(interacao);
        }

        public string UltimaPagina(Identity idUsuario, Identity idInteracao) {

            //using (conn = new Connection()) {
            //    string sql = @"select Arquivo from fn_InteracaoUltimaPagina({0},{1})";
            //    using (SqlDataReader rec = conn.Query(sql, idInteracao, sessao.IdUsuario)) {
            //        if (rec != null && rec.HasRows && rec.Read())
            //            _retorno = rec[0].ToString();
            //    }
            //}

            return string.Empty;
        }

        public IInteracao Get(Identity id) {

            //using (conn = new Connection()) {

            //    string sql = @"select a.Objecao_Id, a.Aceitou, b.ContraArgumento
            //                   from Interacoes a with(nolock) 
            //                   left join Objecoes b with(nolock) on a.Objecao_Id = b.Id
            //                   where a.Id = {0}";

            //    using (SqlDataReader rec = conn.Query(sql, id)) {
            //        if (rec != null && rec.HasRows && rec.Read()) {
            //            CmbMotivo.SelectedValue = rec["Objecao_Id"].ToString();
            //            LbContraArgumento.Text = rec["ContraArgumento"].ToString();
            //            CmbAceitou.SelectedValue = rec["Aceitou"].ToString().ToLower() == "true" ? "1" : "0";
            //        }
            //    }
            //}

            return _cache.FirstOrDefault(x=>x.Id.Equals(id));
        }

        public void SalvarObjecao() {

            //using (conn = new Connection()) {
            //    string sql = @"update Interacoes 
            //                   set Objecao_Id = {0}, 
            //                       Aceitou = {1} 
            //                   where Id = {2}";
            //    _ret = conn.Execute(sql, CmbMotivo.SelectedValue, CmbAceitou.SelectedValue, TxtIdInteracao.Value);
            //}

        }

        public void Salvar(int idInteracao, int idPlano, int idOfertaTipo, bool aceitou) {

            //using (conn = new Connection()) {
            //    string sql = @"update Interacoes 
            //                   set  Plano_Id = {0},
            //                        OfertaTipo_Id = {1},
            //                        Aceitou = {2} 
            //                   where Id = {3}";

            //    _retorno = conn.Execute(sql, TxtPlanoId.Value, TxtOfertTipo.Value, CmbAceitou.SelectedValue, TxtIdInteracao.Value);
            //}
        }
    }
}
