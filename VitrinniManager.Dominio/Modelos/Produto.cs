using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VitrinniManager.Common.Validacao;

namespace VitrinniManager.Dominio.Modelos
{
    [Table("tbProduto", Schema = "vitrinni")]
    public class Produto
    {
        protected Produto() { }

        public Produto(string _descricao, decimal? _valorPublico, decimal? _valorCusto, int _idLoja, int _idDepartamento, string _codForn, string _espec,
            bool _ativo, int? _altura, int? _largura, int? _comprimento, string _peso, bool _servico)
        {
            this.descricaoProduto = _descricao;
            this.valorPublicoProduto = _valorPublico;
            this.valorCustoProduto = _valorCusto;
            this.idLoja = _idLoja;
            this.idDepartamento = _idDepartamento;
            this.codigoProdutoFornecedor = _codForn;
            this.tokenProduto = Guid.NewGuid().ToString();
            this.especificacao = _espec;
            this.ativo = _ativo;
            this.Altura = _altura;
            this.largura = _largura;
            this.comprimento = _largura;
            this.peso = _peso;
            this.servico = _servico;
        }

        [Key]
        public int idProduto { get; set; }

        public string descricaoProduto { get; set; }

        public decimal? valorPublicoProduto { get; set; }

        public decimal? valorCustoProduto { get; set; }

        [ForeignKey("Loja")]
        public int idLoja { get; set; }

        [ForeignKey("Departamento")]
        public int idDepartamento { get; set; }

        public string codigoProdutoFornecedor { get; set; }

        public string tokenProduto { get; set; }

        public string especificacao { get; set; }

        public bool ativo { get; set; }

        public int? Altura { get; set; }

        public int? largura { get; set; }

        public int? comprimento { get; set; }

        public string peso { get; set; }

        public bool servico { get; set; }

        public ICollection<Estoque> Estoques { get; set; }

        public ICollection<Imagem> Imagens { get; set; }

        public virtual Loja Loja { get; set; }

        public virtual Departamento Departamento { get; set; }

        public void ValidaProduto(Produto produto)
        {
            AssertionConcern.AssertArgumentNotNull(produto.idDepartamento, "O Departamento e Obrigatório.");
            AssertionConcern.AssertArgumentNotNull(produto.descricaoProduto, "O Nome do produto e Obrigatório.");
            AssertionConcern.AssertArgumentNotNull(produto.servico, "O Tipo e Obrigatório.");
        }
    }
}
