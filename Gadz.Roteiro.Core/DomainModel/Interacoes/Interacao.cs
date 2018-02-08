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
        
        //oferta
        public string Abordagem => Campanha.Abordagem
            .Replace("<nome>", Vendedor.Nome.FirstName)
            .Replace("<campanha>", Campanha.Nome);
        public IList<IPlano> Planos => Campanha.Planos;
        public ICliente Cliente { get; set; } = new ClienteIndefinido();
        public bool Aceitou => Status.Aceite;
        public IList<IPremissa> Premissas => Campanha.Premissas;

        //venda
        public IPlano PlanoEscolhido { get; set; }
        public IList<IValidacao> Validacoes { get; set; } = new List<IValidacao>();

        //recusa
        public IObjecao Objecao { get; set; }
        public IList<IObjecao> Objecoes => Campanha.Objecoes;

        public DateTime Inicio { get; set; } = DateTime.Now;
        public DateTime? Termino { get; set; }

        public Interacao() {

        }

        public Interacao(Identity id) : base(id) {
        }

        public void IniciarConversar() {
            Status = new StatusInteracaoSondagem();
        }

        public void ResponderPremissa(Identity idPremissa, string resposta) {

            if (string.IsNullOrEmpty(resposta))
                return;

            var premissa = Premissas.FirstOrDefault(x => x.Id.Equals(idPremissa));
            premissa?.Responder(resposta);

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

        public void EscolherPlano(Identity plano) {
            Status = new StatusInteracaoProposta();
            PlanoEscolhido = Planos.FirstOrDefault(x=>x.Id.Equals(plano));
        }

        public void MarcarValidacao(Identity idValidacao) {
            //var validacao = Validacoes.FirstOrDefault(x => x.Id.Equals(idValidacao));
            Validacoes.Add(new Validacao(idValidacao));
            
            Status = new StatusInteracaoAceite();
        }

        public void ConcluirVenda() {
            Status = new StatusInteracaoVendido();
        }

        public void InformarMotivoRejeicao(Identity idObjecao) {
            Status = new StatusInteracaoRebate();
            Objecao = Objecoes.FirstOrDefault(x => x.Id.Equals(idObjecao));
        }
        
        public void AceitarProposta() {
            Status = new StatusInteracaoAceite();
        }

        public void RejeitarProposta() {
            Status = new StatusInteracaoRebate();
        }

        public override string ToString() {
            return Id.ToString();
        }
    }
}
