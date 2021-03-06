﻿using Gadz.Common.Model;

namespace Gadz.Roteiro.Core.DomainModel.Objecoes {
    internal class Objecao : Entity, IObjecao {
        public string Motivo { get; set; }
        public string ContraArgumento { get; set; }

        public Objecao() {

        }

        public Objecao(Identity id) : base(id) {

        }

        public override string ToString() {
            return Motivo;
        }
    }
}
