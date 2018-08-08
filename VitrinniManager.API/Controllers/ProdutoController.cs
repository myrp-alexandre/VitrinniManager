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
    [RoutePrefix("api/produto")]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService _produtoServico;
        private readonly ILojaService _lojaServico;

        public ProdutoController()
        {
            _produtoServico = new ProtutoServico();
            _lojaServico = new LojaServico();
        }

        [HttpPost]
        [Route("cadastrarProduto")]
        public Task<HttpResponseMessage> cadastrarProduto(Produto produto)
        {
            try
            {
                produto.idLoja = _lojaServico.bucarPorEmail(User.Identity.Name).idLoja;
                _produtoServico.cadastrarProduto(produto);

                return CreateResponse(HttpStatusCode.OK, "ok");
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
