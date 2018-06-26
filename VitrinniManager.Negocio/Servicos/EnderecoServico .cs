using System;
using System.Collections.Generic;
using VitrinniManager.Dominio.Contratos;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Infra.Data;
using VitrinniManager.Infra.Repositorio;

namespace VitrinniManager.Negocio.Servicos
{

    public class EnderecoServico : IEnderecoService
    {
        private readonly EnderecoRepositorio _repositorio = null;

        public EnderecoServico()
        {
            _repositorio = new EnderecoRepositorio(new AppDataContext());
        }

       
        public Endereco buscarPorID(int id)
        {
            var endereco = _repositorio.buscarPorID(id);

            if (endereco == null)
                throw new Exception("Endereço não encontrado.");

            return endereco;
        }

        public IEnumerable<Endereco> buscarPorIDLoja(int idLoja)
        {
            var enderecos = _repositorio.buscarPorIDLoja(idLoja);

            if (enderecos == null)
                throw new Exception("Endereços não encontrados.");

            return enderecos;
        }

        public void atualizarEndereco(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public void cadastrarEndereco(Endereco endereco)
        {

             Endereco end = new Endereco(endereco.idEndereco, endereco.idLoja, endereco.CEP, endereco.logradouro, endereco.complemento, endereco.localidade, endereco.bairro, endereco.UF);
             end.ValidaEndereco(end);



            _repositorio.cadastrarEndereco(end);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        
    }
}
