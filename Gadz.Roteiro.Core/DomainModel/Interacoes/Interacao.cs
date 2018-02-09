using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Clientes;
using Gadz.Roteiro.Core.DomainModel.Objecoes;
using Gadz.Roteiro.Core.DomainModel.Planos;
using Gadz.Roteiro.Core.DomainModel.Premissas;
using Gadz.Roteiro.Core.DomainModel.Validacoes;
using Gadz.Roteiro.Core.DomainModel.Vendedores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gadz.Roteiro.Core.DomainModel.Interacoes {

    internal class Interacao : Entity, IInteracao {

        public IVendedor Vendedor { get; set; }
        public IStatusInteracao Status { get; set; } = new StatusInteracaoAbordagem();
        public ICampanha Campanha { get; set; }

        //sondagem
        public IList<IPremissa> Premissas { get; set; } = new List<IPremissa>();

        //oferta
        public string Abordagem => Campanha.Abordagem
            .Replace("<nome>", Vendedor.Nome.FirstName)
            .Replace("<campanha>", Campanha.Nome);
        public IList<IPlano> Planos { get; set; } = new List<IPlano>();
        public ICliente Cliente { get; set; } = new ClienteIndefinido();
        public bool Aceitou => Status.Aceite;

        //venda
        public IList<IValidacao> Validacoes { get; set; } = new List<IValidacao>();

        //recusa
        public IList<IObjecao> Objecoes { get; set; } = new List<IObjecao>();

        public DateTime Inicio { get; set; } = DateTime.Now;
        public DateTime? Termino { get; set; }

        public Interacao() {

        }

        public Interacao(Identity id) : base(id) {

        }

        public void IniciarConversar() {
            Status = new StatusInteracaoSondagem();
        }

        public void ResponderPremissa(IPremissa premissa) {
            Premissas.Clear();
            Premissas.Add(premissa);
            Status = new StatusInteracaoProposta();
        }

        public void Terminar() {
            if (Aceitou) {
                Status = new StatusInteracaoVendido();
            } else {
                Status = new StatusInteracaoRecusada();
            }
            Termino = DateTime.Now;
        }

        public string PegarContraArgumento(Identity idObjecao) {

            Status = new StatusInteracaoRebate();

            var objecao = Objecoes.FirstOrDefault(x => x.Id.Equals(idObjecao));
            return objecao?.ContraArgumento;
        }

        public void EscolherPlano(IPlano plano) {
            Status = new StatusInteracaoProposta();
            Planos.Clear();
            Planos.Add(plano);
        }

        public void MarcarValidacao(IValidacao validacao) {
            Status = new StatusInteracaoAceite();
            Validacoes.Add(validacao);
        }

        public void ConcluirVenda() {
            Status = new StatusInteracaoVendido();
        }

        public void InformarMotivoRejeicao(IObjecao objecao) {
            Status = new StatusInteracaoRebate();
            Objecoes.Clear();
            Objecoes.Add(objecao);
        }
        
        public void AceitarProposta() {
            Status = new StatusInteracaoAceite();
        }

        public void RejeitarProposta() {
            Status = new StatusInteracaoRebate();
        }

        public void RecusarContraProposta() {
            Status = new StatusInteracaoRecusada();
        }

        public override string ToString() {
            return Id.ToString();
        }
    }
}
