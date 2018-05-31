using System;
using VitrinniManager.Dominio.Modelos;

namespace VitrinniManager.Dominio.Contratos
{
    public interface ILojaService : IDisposable
    {
        Loja bucarPorEmail(string email);
    }
}
