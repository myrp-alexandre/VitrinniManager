using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitrinniManager.Dominio.Modelos;

namespace VitrinniManager.Dominio.Contratos
{
    public interface IEnderecoService : IDisposable
    {
        Endereco buscarPorID(int id);
        IEnumerable<Endereco> buscarPorIDLoja(int idLoja);
        
        void atualizarEndereco(Endereco endereco);
        void cadastrarEndereco(Endereco endereco);
        void excluirEndereco(Endereco endereco);
    }
}
