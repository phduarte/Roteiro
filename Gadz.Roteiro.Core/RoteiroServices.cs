using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Beneficios;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;
using Gadz.Roteiro.Core.DomainModel.Objecoes;
using Gadz.Roteiro.Core.DomainModel.Planos;
using Gadz.Roteiro.Core.DomainModel.Premissas;
using Gadz.Roteiro.Core.DomainModel.Validacoes;
using Gadz.Roteiro.Core.DomainModel.Vendedores;
using Gadz.Roteiro.Core.Infrastructure.Data.Ado;

namespace Gadz.Roteiro.Core {

    public class RoteiroServices {

        #region repositories

        readonly IInteracoesRepository _interacoes;
        readonly IVendedoresRepository _vendedores;
        readonly ICampanhasRepository _campanhas;
        readonly IBeneficiosRepository _beneficios;
        readonly IValidacoesRepository _validacoes;
        readonly IPlanosRepository _planos;
        readonly IObjecoesRepository _objecoes;
        readonly IPremissasRepository _premissas;

        #endregion

        #region singleton pattern

        static RoteiroServices _instance;
        
        public static RoteiroServices Instance => _instance = _instance ?? new RoteiroServices();

        public IPlano PegarPlano(string idPlano) {
            return _planos.Get(idPlano);
        }

        #endregion

        #region constructors

        private RoteiroServices() {
            _campanhas = new CampanhasRepository();
            _interacoes = new InteracoesRepository(_campanhas);
            _vendedores = new VendedoresRepository(_campanhas);
            _objecoes = new ObjecoesRepository();
            _validacoes = new ValidacoesRepository();
            _beneficios = new BeneficiosRepository();
            _planos = new PlanosRepository(_beneficios);
            _premissas = new PremissasRepository();
        }

        #endregion

        public ICampanha PegarCampanha(string idCampanha) {
            return _campanhas.Get(idCampanha);
        }

        public IValidacao PegarValidacao(string idValidacao) {
            return _validacoes.Get(idValidacao);
        }

        public IObjecao PegarObjecao(string idObjecao) {
            return _objecoes.Get(idObjecao);
        }

        public IPremissa PegarPremissa(string idPremissa) {
            return _premissas.Get(idPremissa);
        }

        public IVendedor PegarVendedorPorUsername(string username) {
            return _vendedores.Find(username);
        }

        public IInteracao CriarInteracao(IVendedor vendedor, ICampanha campanha) {
            var interacao = vendedor.IniciarInteracao(campanha);
            SalvarInteracao(interacao);
            return interacao;
        }

        public void TerminarInteracao(IInteracao interacao) {
            interacao.Terminar();
        }

        public IInteracao PegarInteracao(string idInteracao) {
            return _interacoes.Get(idInteracao);
        }

        public IInteracao PegarInteracaoPendente(Identity id, string idCampanha) {
            return _interacoes.GetPending(id, idCampanha);
        }

        public void SalvarInteracao(IInteracao interacao) {
            _interacoes.Save(interacao);
        }
    }
}
