using System;
using VitrinniManager.Dominio.Contratos;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Data;
using VitrinniManager.Infra.Repositorio;
using VitrinniManager.Common.Validacao;

namespace VitrinniManager.Negocio.Servicos
{
    public class ContaServico : IContaService
    {
        private readonly ContaRepositorio _repositorio = null;
        private readonly LojaRepositorio _repositorioLoja = null;

        public ContaServico()
        {
            _repositorio = new ContaRepositorio(new AppDataContext());
            _repositorioLoja = new LojaRepositorio(new AppDataContext());
        }

        public Conta Autenticar(string email, string senha)
        {
            var usuario = _repositorio.Autenticar(email, PasswordAssertionConcern.Encrypt(senha));

            if (usuario == null)
                throw new Exception("Email ou Senha inválidos.");

            return usuario;
        }

        public void Registrar(Conta registro)
        {
            var reg = _repositorioLoja.BuscarPorEmail(registro.emailLoja);


            if (reg != null)
                throw new Exception("Email já cadastrado.");

            Conta conta = new Conta(registro.emailLoja, registro.CPFCNPJ);

            conta.ConfirmaSenha(registro.senhaLoja, registro.confirma_senha);

            _repositorio.Create(conta);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }


    }
}
