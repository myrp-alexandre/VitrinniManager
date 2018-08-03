using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VitrinniManager.Dominio.Contratos;
using VitrinniManager.Dominio.Modelos;
using VitrinniManager.Negocio.Servicos;

namespace VitrinniManager.API.Controllers
{

    [Authorize]
    [RoutePrefix("api/loja")]
    public class LojaController : BaseController
    {
        private readonly ILojaService _lojaServico;
        private readonly IEnderecoService _enderecoServico;

        public LojaController()
        {
            _lojaServico = new LojaServico();
            _enderecoServico = new EnderecoServico();
        }

        [HttpGet]
        [Route("")]
        public Task<HttpResponseMessage> obterLoja()
        {
            try
            {
                var loja = _lojaServico.bucarPorEmail(User.Identity.Name);
                return CreateResponse(HttpStatusCode.OK, loja);
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("obterLojaComEndereco")]
        public Task<HttpResponseMessage> obterLojaComEndereco()
        {
            try
            {
                var loja = _lojaServico.bucarPorEmailComEndereco(User.Identity.Name);
                return CreateResponse(HttpStatusCode.OK, loja);
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPut]
        [Route("atualizarLoja")]
        public Task<HttpResponseMessage> atualizarLoja(Loja loja)
        {
            try
            {
                _lojaServico.atualizarLoja(loja);
                return CreateResponse(HttpStatusCode.OK, "ok");
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("cadastrarEndereco")]
        public Task<HttpResponseMessage> cadastrarEndereco(Endereco endereco)
        {
            try
            {
                var loja = _lojaServico.bucarPorEmail(User.Identity.Name);
                endereco.idLoja = loja.idLoja;

                _enderecoServico.cadastrarEndereco(endereco);
                return CreateResponse(HttpStatusCode.OK, "ok");
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        [Route("excluirEndereco/{id}")]
        public Task<HttpResponseMessage> excluirEndereco(string id)
        {
            try
            {
                var endereco = _enderecoServico.buscarPorID(Convert.ToInt32(id));
                _enderecoServico.excluirEndereco(endereco);

                return CreateResponse(HttpStatusCode.OK, "ok");
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("verificarNomeLoja/{nome}")]
        public Task<HttpResponseMessage> verificarNomeLoja(string nome)
        {
            try
            {
                var loja = _lojaServico.bucarPorNome(nome);
                return CreateResponse(HttpStatusCode.OK, loja);
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
