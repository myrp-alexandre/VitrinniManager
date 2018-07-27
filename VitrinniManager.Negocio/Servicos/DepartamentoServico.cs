using System;
using System.Collections.Generic;
using VitrinniManager.Dominio.Contratos;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Data;
using VitrinniManager.Infra.Repositorio;

namespace VitrinniManager.Negocio.Servicos
{

    public class DepartamentoServico : IDepartamentoService
    {
        private readonly DepartamentoRepositorio _repositorio = null;

        public DepartamentoServico()
        {
            _repositorio = new DepartamentoRepositorio(new AppDataContext());
        }


        public IEnumerable<Departamento> buscarPorIDLoja(int idLoja)
        {
            var departamentos = _repositorio.buscarPorIDLoja(idLoja);

            if (departamentos == null)
                throw new Exception("Departamentos não encontrados.");

            return departamentos;
        }

        public void cadastrarDepartamento(Departamento departamento)
        {
            throw new NotImplementedException();
        }

        public void atualizarDepartamento(Departamento departamento)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
