using System;
using VitrinniManager.Common.Validacao;
using VitrinniManager.Dominio.Contratos;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Data;
using VitrinniManager.Infra.Repositorio;

namespace VitrinniManager.Negocio.Servicos
{
    public class ContaServico : IContaService
    {
        private readonly ContaRepositorio _repositorio = null;

        public ContaServico()
        {
            _repositorio = new ContaRepositorio(new AppDataContext());
        }

        public Conta Autenticar(string email, string senha)
        {
            var usuario = _repositorio.Autenticar(email, PasswordAssertionConcern.Encrypt(senha));

            if (usuario == null)
                throw new Exception("Email ou Senha inválidos.");



            return usuario;
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
