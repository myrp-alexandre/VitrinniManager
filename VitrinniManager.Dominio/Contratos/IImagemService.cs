using System;
using System.Collections.Generic;
using VitrinniManager.Dominio.Modelos;

namespace VitrinniManager.Dominio.Contratos
{
    public interface IImagemService : IDisposable
    {
        void Inserir(Imagem img, int idLoja);
        void Deletar(int id);

        IEnumerable<Imagem> buscarPorIDProduto(int id, int idLoja);
        Imagem buscarPorID(int id);
    }
}
