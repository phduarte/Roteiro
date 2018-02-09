using System;
using System.Collections.Generic;
using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Campanhas;
using Gadz.Roteiro.Core.DomainModel.Interacoes;

namespace Gadz.Roteiro.Core.DomainModel.Vendedores {
    internal class Vendedor : Entity, IUser, IVendedor {

        public string Username { get; set; }
        public string Password { get; set; }
        public Name Nome { get; set; }
        public string Perfil { get; set; }
        public IList<ICampanha> Campanhas { get; set; } = new List<ICampanha>();

        public Vendedor() {
        }

        public Vendedor(Identity id) : base(id) {
        }

        public IInteracao IniciarInteracao(ICampanha campanha) {

            if (!Campanhas.Contains(campanha))
                throw new InvalidOperationException("");

            return new Interacao { Campanha = campanha, Vendedor = this };
        }

        public bool Validar(string pass) {
            return pass.Equals(Password);
        }

        public override string ToString() {
            return Nome;
        }
    }
}
