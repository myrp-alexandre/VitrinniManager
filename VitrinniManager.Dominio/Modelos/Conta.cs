using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitrinniManager.Dominio.Modelos
{

    public class Conta
    {
        public Conta(string _email, string _token)
        {
            this.emailLoja = emailLoja;
            this.tokenLoja = _token;
        }
        protected Conta() { }


        public string emailLoja { get; private set; }
        public string tokenLoja { get; private set; }
    }
}
