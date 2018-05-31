using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitrinniManager.Dominio.Modelos
{
    [Table("tbLoja", Schema = "vitrinni")]
    public class Loja
    {
        protected Loja() { }


        [Key]
        public int idLoja { get; private set; }

        public string nomeLoja { get; private set; }

        public string descricaoLoja { get; private set; }

        public string emailLoja { get; private set; }

        public string contatoLoja { get; private set; }

        public string urlLoja { get; private set; }

        public string tokenLoja { get; private set; }

        public string CPFCNPJ { get; private set; }

        public string linkFace { get; private set; }

        public string linkInsta { get; private set; }

        public string linkWhatsapp { get; private set; }

        public ICollection<Endereco> Enderecos { get; set; }
    }
}
