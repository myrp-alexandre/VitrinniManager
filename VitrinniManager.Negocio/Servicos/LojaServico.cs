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

        public void atualizarLoja(Loja loja)
        {
            var objLoja = _repositorio.BuscarPorEmail(loja.emailLoja);
            if (objLoja == null)
                throw new Exception("CPF ou CNPJ não encontrado.");

            objLoja.nomeLoja = loja.nomeLoja;
            objLoja.contatoLoja = loja.contatoLoja;
            objLoja.descricaoLoja = loja.descricaoLoja;
            objLoja.linkFace = loja.linkFace;
            objLoja.linkInsta = loja.linkInsta;
            objLoja.linkWhatsapp = loja.linkWhatsapp;
            objLoja.urlLoja = loja.urlLoja;

            _repositorio.atualizarLoja(objLoja);
        }

        public Loja bucarPorCPF_CNPJ(string CPF_CNPJ)
        {
            var loja = _repositorio.BuscarPorCPF_CNPJ(CPF_CNPJ);
            if (loja == null)
                throw new Exception("CPF ou CNPJ não encontrado.");

            return loja;
        }

        public Loja bucarPorCPF_CNPJComEndereco(string CPF_CNPJ)
        {
            var loja = _repositorio.BuscarPorCPF_CNPJComEndereco(CPF_CNPJ);
            if (loja == null)
                throw new Exception("CPF ou CNPJ não encontrado.");
            return loja;
        }

        public Loja bucarPorEmail(string email)
        {
            var loja = _repositorio.BuscarPorEmail(email);
            if (loja == null)
                throw new Exception("Email não encontrado.");
            return loja;

        }

        public Loja bucarPorEmailComEndereco(string email)
        {
            var loja = _repositorio.BuscarPorEmailComEndereco(email);
            if (loja == null)
                throw new Exception("Email não encontrado.");
            return loja;
        }

        public Loja bucarPorNome(string nome)
        {
            var loja = _repositorio.BuscarPorNome(nome);

            return loja;
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
