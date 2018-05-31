using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using VitrinniManager.Dominio.Contratos;

namespace VitrinniManager.Api.Seguranca
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IContaService _service;

        public AuthorizationServerProvider(IContaService service)
        {
            _service = service;
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await  Task.FromResult(context.Validated());
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var usuario = _service.Autenticar(context.UserName, context.Password);

                if (usuario == null)
                {
                    context.SetError("invalid_grant", "Email ou Senha inválidos.");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, usuario.emailLoja));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, usuario.tokenLoja));

                GenericPrincipal principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;

                await Task.FromResult(context.Validated(identity));
            }
            catch
            {
                context.SetError("invalid_grant", "Email ou Senha inválidos.");
            }
        }
    }
}