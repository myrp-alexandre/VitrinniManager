using System;
using System.Collections.Generic;
using VitrinniManager.Dominio.Contratos;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Data;
using VitrinniManager.Infra.Repositorio;

namespace VitrinniManager.Negocio.Servicos
{
    public class CategoriaServico : ICategoriaService
    {
        private readonly CategoriaRepositorio _repositorio = null;

        public CategoriaServico()
        {
            _repositorio = new CategoriaRepositorio(new AppDataContext());
        }
        public IEnumerable<Categoria> lista()
        {
            var categorias = _repositorio.lista();
            if (categorias == null)
                throw new Exception("Não existem categorias para essa loja");

            return categorias;
        }
        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
