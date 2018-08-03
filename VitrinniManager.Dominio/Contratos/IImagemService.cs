using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitrinniManager.Dominio.Modelos;

namespace VitrinniManager.Dominio.Contratos
{
    public interface IImagemService : IDisposable
    {
        void Inserir(Imagem img);
        void Deletar(int id);

        IEnumerable<Imagem> buscarPorIDProduto(int id);
        Imagem buscarPorID(int id);
    }
}
