﻿using System.Collections.Generic;
using Gadz.Common.Model;
using Gadz.Roteiro.Core.DomainModel.Objecoes;
using Gadz.Roteiro.Core.DomainModel.Planos;
using Gadz.Roteiro.Core.DomainModel.Premissas;
using Gadz.Roteiro.Core.DomainModel.Vendedores;

namespace Gadz.Roteiro.Core.DomainModel.Campanhas {
    public interface ICampanha : IEntity {
        string Abordagem { get; set; }
        string Descricao { get; set; }
        string Icone { get; set; }
        string Nome { get; set; }
        IList<IObjecao> Objecoes { get; }
        IList<IPlano> Planos { get; }
        IList<IPremissa> Premissas { get; }
        //IList<IVendedor> Vendedores { get; }
    }
}