using System;
using VitrinniManager.Dominio.Modelos;

namespace VitrinniManager.Dominio.Contratos
{
    public interface IContaService : IDisposable
    {
        Conta Autenticar(string email, string senha);
    }
}
