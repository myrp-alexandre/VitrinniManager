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

    public class Conta
    {
        public Conta(string _email, string _CPFCNPJ)
        {
            this.emailLoja = _email;
            this.CPFCNPJ = _CPFCNPJ;
        }
        protected Conta() { }


        public string emailLoja { get; set; }
        public string tokenLoja { get; set; }
        public string confirma_senha { get; set; }
        public string CPFCNPJ { get; set; }
        public string senhaLoja { get; set; }

        public void ConfirmaSenha(string senha, string confirmasenha)
        {
            AssertionConcern.AssertArgumentNotNull(senha, "Senha inválida.");
            AssertionConcern.AssertArgumentNotNull(confirmasenha, "Confirmação de Senha inválida.");
            AssertionConcern.AssertArgumentEquals(senha, confirmasenha, "As senhas digitadas não conferem.");
            AssertionConcern.AssertArgumentLength(senha, 6, 20, "Senha inválida.");

            this.senhaLoja = PasswordAssertionConcern.Encrypt(senha);
        }


    }
}
