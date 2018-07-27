using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitrinniManager.Dominio.Modelos
{
    [Table("tbCategoriaProduto", Schema = "vitrinni")]
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        public string descricaoCategoria { get; set; }

    }
}
