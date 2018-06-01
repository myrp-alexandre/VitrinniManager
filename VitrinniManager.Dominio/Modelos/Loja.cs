using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VitrinniManager.Common.Validacao;

namespace VitrinniManager.Dominio.Modelos
{
    [Table("tbLoja", Schema = "vitrinni")]
    public class Loja 
    {
        protected Loja() { }

        [Key]
        public int idLoja { get; set; }

        public string nomeLoja { get; set; }

        public string descricaoLoja { get; set; }

        public string emailLoja { get; set; }

        public string contatoLoja { get; set; }

        public string urlLoja { get; set; }

        public string tokenLoja { get; set; }

        public string CPFCNPJ { get; set; }

        public string linkFace { get; set; }

        public string linkInsta { get; set; }

        public string linkWhatsapp { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }

      

    }
}
