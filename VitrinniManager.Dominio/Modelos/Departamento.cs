using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VitrinniManager.Common.Validacao;

namespace VitrinniManager.Dominio.Modelos
{
    [Table("tbDepartamentoLoja", Schema = "vitrinni")]
    public class Departamento
    {
        protected Departamento() { }

        public Departamento(string _departamento, int _idCategoria, int _idLoja)
        {
            departamento = _departamento;
            idCategoria = _idCategoria;
            idLoja = _idLoja;
        }

        [Key]
        public int idDepartamento { get; set; }

        public string departamento { get; set; }

        [ForeignKey("Loja")]
        public int idLoja { get; set; }

        public virtual Loja Loja { get; set; }

        [ForeignKey("Categoria")]
        public int idCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }

        public void ValidaDepartamento(Departamento departamento)
        {
            AssertionConcern.AssertArgumentNotNull(departamento.departamento, "Departamento Obrigatório.");
            AssertionConcern.AssertArgumentNotNull(departamento.idCategoria, "Categoria Obrigatório.");
        }
    }
}
