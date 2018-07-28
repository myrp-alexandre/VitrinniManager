using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Data;

namespace VitrinniManager.Infra.Repositorio
{
    public class CategoriaRepositorio
    {
        private AppDataContext _context;

        public CategoriaRepositorio(AppDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> lista()
        {
            var categorias = _context.Categorias.ToList();
            return categorias;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
