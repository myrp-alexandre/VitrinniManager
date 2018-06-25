using System;
using VitrinniManager.Dominio.Modelos;

namespace VitrinniManager.Dominio.Contratos
{
    public interface ILojaService : IDisposable
    {
        Loja bucarPorEmail(string email);
        Loja bucarPorCPF_CNPJ(string CPF_CNPJ);

        Loja bucarPorEmailComEndereco(string email);
        Loja bucarPorCPF_CNPJComEndereco(string CPF_CNPJ);

        void atualizarLoja(Loja loja);
    }
}
