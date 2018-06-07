using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VitrinniManager.Dominio.Contratos;
using VitrinniManager.Negocio.Servicos;

namespace VitrinniManager.API.Controllers
{

    [Authorize]
    [RoutePrefix("api/loja")]
    public class LojaController : BaseController
    {
        private readonly ILojaService _lojaServico;

        public LojaController()
        {
             _lojaServico = new LojaServico();
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
    }
}
