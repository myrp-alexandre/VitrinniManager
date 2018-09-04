using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using VitrinniManager.Dominio.Contratos;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Data;
using VitrinniManager.Infra.Repositorio;
using static System.Net.Mime.MediaTypeNames;

namespace VitrinniManager.Negocio.Servicos
{
    public class ImagemServico : IImagemService
    {
        private readonly ImagemRepositorio _repositorio = null;

        public ImagemServico()
        {
            _repositorio = new ImagemRepositorio(new AppDataContext());
        }

        public Imagem buscarPorID(int id)
        {
            var imagem = _repositorio.buscarPorID(id);

            if (imagem == null)
                throw new Exception("Imagem não encontrada, tente novamente.");

            return imagem;
        }

        public IEnumerable<Imagem> buscarPorIDProduto(int id, int idLoja)
        {
            List<Imagem> list = new List<Imagem>();
            var imagens = _repositorio.buscarPorIDProduto(id);

            foreach (var item in imagens)
            {
                Imagem imagem = new Imagem(item.IdProdutoImagem,item.nome, item.idProduto, Convert.ToInt32(item.principal), item.ativa, idLoja);
                list.Add(imagem);
            }

            if (imagens == null)
                throw new Exception("Produto sem imagens.");

            return list;
        }

        public void Inserir(Imagem img, int idLoja)
        {
            Imagem imagem = new Imagem(img.idProduto, idLoja, img.nome);

            if (string.IsNullOrEmpty(imagem.diretorio))
                throw new Exception("Não foi possível criar a pasta da loja, tente novamente.");

            Imagem.Comprimir(new MemoryStream(imagem.base64), imagem.pathCompleta);
            
            _repositorio.Inserir(imagem);
        }

        public void Deletar(int id)
        {
            var imagem = buscarPorID(id);
            imagem.ativa = false;

            _repositorio.Deletar(imagem);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
