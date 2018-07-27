using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VitrinniManager.Common.Validacao;
using VitrinniManager.Common.Replace;

namespace VitrinniManager.Dominio.Modelos
{
    [Table("tbEnderecoLoja", Schema = "vitrinni")]
    public class Endereco
    {
        protected Endereco() { }
        public Endereco(int _id, int _idLoja, string _cep, string _logradouro, string _complemento, string _localidade, string _bairro, string _uf)
        {
            this.idEndereco = _id;
            this.idLoja = _idLoja;
            this.CEP = StringReplace.Replace(_cep);
            this.logradouro = _logradouro;
            this.complemento = _complemento;
            this.localidade = _localidade;
            this.bairro = _bairro;
            this.UF = _uf;
        }

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

        public void ValidaEndereco(Endereco endereco)
        {
            AssertionConcern.AssertArgumentNotNull(endereco.CEP, "CEP Obrigatório.");
            AssertionConcern.AssertArgumentNotNull(endereco.logradouro, "Logradouro Obrigatório.");
            AssertionConcern.AssertArgumentNotNull(endereco.localidade, "Localidade Obrigatório.");
            AssertionConcern.AssertArgumentNotNull(endereco.bairro, "Bairro Obrigatório.");
            AssertionConcern.AssertArgumentNotNull(endereco.UF, "UF Obrigatório.");
            AssertionConcern.AssertArgumentNotNull(endereco.idLoja, "Erro ao cadastrar, tente novamente.");
        }

    }
}
