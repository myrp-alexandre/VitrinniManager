using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitrinniManager.Dominio.Modelos;

namespace VitrinniManager.Dominio.Contratos
{
    public interface IProdutoService : IDisposable
    {
        int cadastrarProduto(Produto produto);

        Produto bucarProdutoID(int id);
    }
}
