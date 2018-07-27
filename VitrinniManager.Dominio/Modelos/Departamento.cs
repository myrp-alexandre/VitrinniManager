using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitrinniManager.Dominio.Modelos
{
    [Table("tbDepartamentoLoja", Schema = "vitrinni")]
    public class Departamento
    {
        [Key]
        public int idDepartamento { get; set; }

        public string departamento { get; set; }

        [ForeignKey("Loja")]
        public int idLoja { get; set; }

        public virtual Loja Loja { get; set; }

        [ForeignKey("Categoria")]
        public int idCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
