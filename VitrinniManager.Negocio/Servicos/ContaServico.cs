using System;
using VitrinniManager.Common.Replace;
using VitrinniManager.Common.Validacao;
using VitrinniManager.Compartilhado.Common.Email;
using VitrinniManager.Compartilhado.Common.GeraAutomatico;
using VitrinniManager.Dominio.Contratos;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Data;
using VitrinniManager.Infra.Repositorio;

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
            var loja_email = _repositorioLoja.BuscarPorEmail(registro.emailLoja);
            var loja_cpf_cnpj = _repositorioLoja.BuscarPorCPF_CNPJ(CPF_CNPJ.Replace(registro.CPFCNPJ));

            if (loja_email != null || loja_cpf_cnpj != null)
                throw new Exception("Conta já cadastrada.");


            Conta conta = new Conta(registro.emailLoja, CPF_CNPJ.Replace(registro.CPFCNPJ));
            conta.ConfirmaSenha(registro.senhaLoja, registro.confirma_senha);

            _repositorio.Create(conta);
        }

        public void RecuperarSenha(Conta registro)
        {
            var usuario = _repositorioLoja.BuscarPorCPF_CNPJ(CPF_CNPJ.Replace(registro.CPFCNPJ));

            if (usuario == null)
                throw new Exception("Cpf ou CNPJ não encontrado.");


            Conta conta = new Conta(CPF_CNPJ.Replace(registro.CPFCNPJ), registro.senhaLoja, usuario.tokenSenha);
            conta.ConfirmaSenha(registro.senhaLoja, registro.confirma_senha);


            if (registro.tokenSenha != conta.tokenSenha)
                throw new Exception("Dados não conferem, repita todo o processo.");


            _repositorio.RecuperarSenha(conta);
            _repositorio.LimpaTokenSenha(usuario.idLoja);
        }


        public string GerarTokenSenha(string email)
        {

            var usuario = _repositorioLoja.BuscarPorEmail(email);

            if (usuario == null)
                throw new Exception("Email não cadastrado.");

            var token = geraGUID.NewGuid().ToString();

            _repositorio.InsereTokenSenha(token, usuario.idLoja);

            return token;

        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public void EnviarEmailRecuperarSenha(string email)
        {
            var loja = _repositorioLoja.BuscarPorEmail(email);
            string link = "http://localhost:57934/#!/recuperarSenha/" + loja.idLoja + "/token/" + loja.tokenSenha;

            if (loja == null)
                throw new Exception("Email não cadastrado.");

            string subject = "Alteração de senha - Vitrinni";
            var body = EmailUtil.MensagemEmail_RedefinirSenha(loja.nomeLoja, link);

            EnviarEmail(loja.emailLoja, subject, body);
        }

        public void EnviarEmail(string destinatario, string assunto, string mensagem)
        {
            _repositorio.EnviarEmail(destinatario, assunto, mensagem);
        }


    }
}
