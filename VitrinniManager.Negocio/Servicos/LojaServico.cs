using System;
using VitrinniManager.Dominio.Contratos;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Data;
using VitrinniManager.Infra.Repositorio;

namespace VitrinniManager.Negocio.Servicos
{

    public class LojaServico : ILojaService
    {
        private readonly LojaRepositorio _repositorio = null;

        public LojaServico()
        {
            _repositorio = new LojaRepositorio(new AppDataContext());
        }

        public Loja bucarPorEmail(string email)
        {
            var loja = _repositorio.BuscarPorEmail(email);
            if (loja == null)
                throw new Exception("Email não encontrado.");
            return loja;

        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
