using System;
using System.Collections.Generic;
using System.IO;
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
                throw new Exception("Imagem não encontrada.");

            return imagem;
        }

        public IEnumerable<Imagem> buscarPorIDProduto(int id)
        {
            var imagens = _repositorio.buscarPorIDProduto(id);

            if (imagens == null)
                throw new Exception("Produto sem imagens.");

            return imagens;
        }

        public void Inserir(Imagem img, int idLoja)
        {

            string diretorio = Imagem.CriarPasta(idLoja);

            if (string.IsNullOrEmpty(diretorio))
                throw new Exception("Não foi possível criar a pasta da loja, tente novamente.");


            byte[] data = Convert.FromBase64String(img.nome);

            string nomeImagem = Guid.NewGuid().ToString() + ".png";
            string pathCompleta = Path.Combine(diretorio, nomeImagem);


            MemoryStream stream = new MemoryStream(data);

            Imagem.Comprimir(stream, pathCompleta);

        }

        public void Deletar(int id)
        {
            var imagem = _repositorio.buscarPorID(id);
            _repositorio.Deletar(imagem);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
