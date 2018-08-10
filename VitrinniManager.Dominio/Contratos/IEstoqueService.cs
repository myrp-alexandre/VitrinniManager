using System;
using VitrinniManager.Dominio.Modelos;
using System.Collections.Generic;

namespace VitrinniManager.Dominio.Contratos
{
    public interface IEstoqueService : IDisposable
    {
        void cadastrarEstoque(Estoque estoque);
        IEnumerable<Estoque> buscaPorIDProduto(int idProduto);
    }
}
