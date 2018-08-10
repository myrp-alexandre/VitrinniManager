﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Data;

namespace VitrinniManager.Infra.Repositorio
{
    public class ProdutoRepositorio
    {
        private AppDataContext _context;

        public ProdutoRepositorio(AppDataContext context)
        {
            _context = context;
        }

        public int cadastrarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return produto.idProduto;
        }

        public Produto buscarProdutoID(int id)
        {
            return _context.Produtos.FirstOrDefault(x => x.idProduto == id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
