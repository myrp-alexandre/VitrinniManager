using System;
using System.Collections.Generic;
using VitrinniManager.Dominio.Modelos;

namespace VitrinniManager.Dominio.Contratos
{
    public interface IDepartamentoService : IDisposable
    {
        IEnumerable<Departamento> buscarPorIDLoja(int idLoja);

        void cadastrarDepartamento(Departamento departamento);
        void atualizarDepartamento(Departamento departamento);
    }
}
