using System;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using VitrinniManager.Api.Seguranca;
using VitrinniManager.Dominio.Contratos;
using VitrinniManager.Negocio.Servicos;

[assembly: OwinStartup(typeof(VitrinniManager.API.Startup))]

namespace VitrinniManager.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //configuração WebApi
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app, new ContaServico());
            ConfigureWebApi(config);
 
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
            //config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private void ConfigureOAuth(IAppBuilder app, IContaService contaServico)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/security/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new AuthorizationServerProvider(contaServico)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            //configurando rotas
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );

            config.MessageHandlers.Insert(0,
                new ServerCompressionHandler(
                    new GZipCompressor(),
                    new DeflateCompressor()));
        }
    }
}
