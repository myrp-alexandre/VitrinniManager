using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitrinniManager.Dominio.Modelos
{
    [Table("tbEnderecoLoja", Schema = "vitrinni")]
    public class Endereco
    {
        protected Endereco() { }

        [Key]
        public int idEndereco { get; set; }
        public string CEP { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string localidade { get; set; }
        public string bairro { get; set; }
        public string UF { get; set; }

        [ForeignKey("Loja")]
        public int idLoja { get; set; }

        public virtual Loja Loja { get; set; }

    }
}
