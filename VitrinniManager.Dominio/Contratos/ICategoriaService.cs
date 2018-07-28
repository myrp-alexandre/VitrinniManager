using System;
using System.Collections.Generic;
using VitrinniManager.Dominio.Modelos;

namespace VitrinniManager.Dominio.Contratos
{
    public interface ICategoriaService : IDisposable
    {
        IEnumerable<Categoria> lista();
    }
}
