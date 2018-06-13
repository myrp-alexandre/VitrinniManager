using System;
using System.Threading.Tasks;
using System.Web.Http;
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
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;



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
            //var formatters = config.Formatters;
            //formatters.Remove(formatters.XmlFormatter);

            //var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            //jsonSettings.Formatting = Formatting.Indented;
            //jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;


            //configurando rotas
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );
        }
    }
}
