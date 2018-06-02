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
    [RoutePrefix("api/conta")]
    public class ContaController : BaseController
    {
        private readonly IContaService _contaServico;
        public ContaController()
        {
            _contaServico = new ContaServico();
        }

        [HttpPost]
        [Route("registrar")]
        [AllowAnonymous]
        public Task<HttpResponseMessage> registrar(Conta registro)
        {
            try
            {
                _contaServico.Registrar(registro);
                return CreateResponse(HttpStatusCode.OK, registro);
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("gerarTokenSenha")]
        public Task<HttpResponseMessage> gerarTokenSenha(string email)
        {

            try
            {
                var token = _contaServico.GerarTokenSenha(email);
                _contaServico.EnviarEmailRecuperarSenha(email);

                return CreateResponse(HttpStatusCode.OK, token);
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }

        }

    }
}
