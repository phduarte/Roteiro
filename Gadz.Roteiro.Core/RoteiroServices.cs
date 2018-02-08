using System.Collections.Generic;
using System.Linq;
using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Beneficios;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;
using Gadz.Roteiro.Core.DomainModel.Planos;
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

        #endregion

        #region singleton pattern

        static RoteiroServices _instance;
        
        public static RoteiroServices Instance => _instance = _instance ?? new RoteiroServices();

        #endregion

        private RoteiroServices() {
            _campanhas = new CampanhasRepository();
            _interacoes = new InteracoesRepository(_campanhas);
            _vendedores = new VendedoresRepository(_campanhas);
            _beneficios = new BeneficiosRepository();
            _planos = new PlanosRepository();
            _validacoes = new ValidacoesRepository();
        }

        public IList<IValidacao> ListarValidacoes(ICampanha campanha) {
            return _validacoes.GetAllOf(campanha).ToList();
        }

        public IList<IBeneficio> ListarBenfeficiosDoPlano(Identity idPlano) {
            var plano = _planos.Get(idPlano);
            return _beneficios.GetAllOf(plano).ToList();
        }

        public IList<ICampanha> ListarCampanhasDoUsuario(Identity id) {
            var vendedor = _vendedores.Get(id);
            return _campanhas.GetAllOf(vendedor).ToList();
        }

        public void Terminar(IInteracao interacao) {
            interacao.Terminar();
            //TODO SALVAR NO BANCO
        }

        public IUser PegarVendedorPorUsername(string username) {
            return _vendedores.Find(username);
        }

        public bool Validate(string username, string password) {
            return _vendedores.Validate(username, password);
        }

        public IInteracao PegarInteracao(string idInteracao) {
            return _interacoes.Get(idInteracao);
        }

        public IInteracao PegarInteracaoPendente(Identity id, string idCampanha) {
            return _interacoes.GetPending(id, idCampanha);
        }

        public IInteracao CriarNovaInteracao(Identity id, string idCampanha) {
            return _interacoes.Create(id, idCampanha);
        }

        public void SalvarInteracao(IInteracao interacao) {
            _interacoes.Save(interacao);
        }
    }
}
