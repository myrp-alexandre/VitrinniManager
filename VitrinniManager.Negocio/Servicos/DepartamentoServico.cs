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


        public Departamento bucarPorID(int idDepartamento)
        {
            var departamento = _repositorio.BuscarPorID(idDepartamento);

            if (departamento == null)
                throw new Exception("Departamento não encontrado.");

            return departamento;
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
            Departamento d = new Departamento(departamento.departamento, departamento.idCategoria, departamento.idLoja);
            d.ValidaDepartamento(departamento);

            _repositorio.cadastrarDepartamento(d);
        }

        public void atualizarDepartamento(Departamento departamento)
        {
            var objDepartamento = _repositorio.BuscarPorID(departamento.idDepartamento);
            if (objDepartamento == null)
                throw new Exception("Departamento não encontrado.");

            objDepartamento.departamento = departamento.departamento;
            objDepartamento.idCategoria = departamento.idCategoria;
       

            _repositorio.atualizarDepartamento(objDepartamento);
        }


        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
