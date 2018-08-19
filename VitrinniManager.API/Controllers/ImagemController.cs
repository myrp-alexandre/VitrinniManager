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
    [RoutePrefix("api/imagem")]
    public class ImagemController : BaseController
    {
        private readonly IProdutoService _produtoServico;
        private readonly ILojaService _lojaServico;
        private readonly IImagemService _imagemServico;

        public ImagemController()
        {
            _produtoServico = new ProtutoServico();
            _lojaServico = new LojaServico();
            _imagemServico = new ImagemServico();
        }

        [HttpPost]
        [Route("cadastrarImagem")]
        public Task<HttpResponseMessage> cadastrarImagem(Imagem imagem)
        {
            try
            {
                int idLoja = _lojaServico.bucarPorEmailComEndereco(User.Identity.Name).idLoja;
                _imagemServico.Inserir(imagem, idLoja);

                return CreateResponse(HttpStatusCode.OK, "ok");
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpGet]
        [Route("obterImagensIDProduto/{id}")]
        public Task<HttpResponseMessage> obterImagensIDProduto(int id)
        {
            try
            {
                int idLoja = _lojaServico.bucarPorEmailComEndereco(User.Identity.Name).idLoja;
                var imagens = _imagemServico.buscarPorIDProduto(id, idLoja);
                return CreateResponse(HttpStatusCode.OK, imagens);
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


    }
}
