using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitrinniManager.Dominio.Modelos
{
    [Table("tbProduto", Schema = "vitrinni")]
    public class Produto
    {
        protected Produto() { }

        [Key]
        public int idProduto { get; set; }

        public string descricaoProduto { get; set; }

        public decimal valorPublicoProduto { get; set; }

        public decimal valorCustoProduto { get; set; }

        [ForeignKey("Loja")]
        public int idLoja { get; set; }

        [ForeignKey("Departamento")]
        public int idDepartamento { get; set; }

        public string codigoProdutoFornecedor { get; set; }

        public string tokenProduto { get; set; }

        public string especificacao { get; set; }

        public bool ativo { get; set; }

        public int Altura { get; set; }

        public int largura { get; set; }

        public int comprimento { get; set; }

        public string peso { get; set; }

        public bool servico { get; set; }

        public ICollection<Estoque> Estoques { get; set; }

        public ICollection<Imagem> Imagens { get; set; }

        public virtual Loja Loja { get; set; }

        public virtual Departamento Departamento { get; set; }
    }
}
