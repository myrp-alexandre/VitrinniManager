using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VitrinniManager.Dominio.Modelos
{
    [Table("tbEstoque", Schema = "vitrinni")]
    public class Estoque
    {
        protected Estoque() { }

        [Key]
        public int idEstoque { get; set; }

        [ForeignKey("Produto")]
        public int idProduto { get; set; }

        public int qtde { get; set; }

        public string opcao { get; set; }

        public bool mostraMesmoZerado { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
