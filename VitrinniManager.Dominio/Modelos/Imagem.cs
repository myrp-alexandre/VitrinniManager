using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitrinniManager.Common.Validacao;

namespace VitrinniManager.Dominio.Modelos
{
    [Table("tbImagemProduto", Schema = "vitrinni")]
    public class Imagem
    {
        [Key]
        public int IdProdutoImagem { get; set; }

        public int IdProduto { get; set; }

        public string imagem { get; set; }

        public int principal { get; set; }

        public bool ativa { get; set; }

        public DateTime dataCadastramento { get; set; }

        [ForeignKey("Produto")]
        public int idProduto { get; set; }

        public virtual Produto Produto { get; set; }

        public void ValidaImagem(Imagem img)
        {
            AssertionConcern.AssertArgumentNotNull(img.imagem, "Não foi possível definir um nome para imagem, tente novamente.");
            AssertionConcern.AssertArgumentNotNull(img.ativa, "E obrigatório definir uma imagem principal.");
        }
    }
}
