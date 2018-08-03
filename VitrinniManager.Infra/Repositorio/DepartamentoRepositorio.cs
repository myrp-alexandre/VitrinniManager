using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Data;

namespace VitrinniManager.Infra.Repositorio
{
    public class DepartamentoRepositorio
    {
        private AppDataContext _context;

        public DepartamentoRepositorio(AppDataContext context)
        {
            _context = context;
        }

        public Departamento BuscarPorID(int idDepartamento)
        {
            var departamento = _context.Departamentos.Where(x => x.idDepartamento == idDepartamento).FirstOrDefault();
            return departamento;
        }

        public IEnumerable<Departamento> buscarPorIDLoja(int idLoja)
        {
            var departamentos = _context.Departamentos.Where(x => x.idLoja == idLoja).Include(dep => dep.Categoria).ToList();
           
            return departamentos;
        }

        public void cadastrarDepartamento(Departamento Departamento)
        {
            _context.Departamentos.Add(Departamento);
            _context.SaveChanges();
        }

        public void atualizarDepartamento(Departamento Departamento)
        {
            _context.Entry(Departamento).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
