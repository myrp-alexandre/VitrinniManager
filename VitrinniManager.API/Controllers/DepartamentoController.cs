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
    [RoutePrefix("api/departamento")]
    public class DepartamentoController : BaseController
    {
        private readonly ILojaService _lojaServico;
        private readonly IEnderecoService _enderecoServico;
        private readonly IDepartamentoService _departamentoServico;

        public DepartamentoController()
        {
            _lojaServico = new LojaServico();
            _enderecoServico = new EnderecoServico();
            _departamentoServico = new DepartamentoServico();
        }

        [HttpGet]
        [Route("obterDepartamentos")]
        public Task<HttpResponseMessage> obterDepartamentos()
        {
            try
            {
                var loja = _lojaServico.bucarPorEmail(User.Identity.Name);
                var departamentos = _departamentoServico.buscarPorIDLoja(loja.idLoja);

                return CreateResponse(HttpStatusCode.OK, departamentos);
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
    }
}
