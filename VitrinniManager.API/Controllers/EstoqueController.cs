using System;
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
    [RoutePrefix("api/estoque")]
    public class EstoqueController : BaseController
    {
        private readonly IProdutoService _produtoServico;
        private readonly ILojaService _lojaServico;
        private readonly IEstoqueService _estoqueServico;

        public EstoqueController()
        {
            _produtoServico = new ProtutoServico();
            _lojaServico = new LojaServico();
            _estoqueServico = new EstoqueServico();
        }

        [HttpPost]
        [Route("cadastrarEstoque")]
        public Task<HttpResponseMessage> cadastrarEstoque(Estoque estoque)
        {
            try
            {
                _estoqueServico.cadastrarEstoque(estoque);
                return CreateResponse(HttpStatusCode.OK, "ok");
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("obterEstoque/{id}")]
        public Task<HttpResponseMessage> obterEstoque(int id)
        {
            try
            {
                var estoque = _estoqueServico.buscaPorIDProduto(id);
                return CreateResponse(HttpStatusCode.OK, estoque);
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
