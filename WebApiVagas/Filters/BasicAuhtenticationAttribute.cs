using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApiVagas.Filters
{
    //Filtro de autenticação
    public class BasicAuhtenticationAttribute : AuthorizationFilterAttribute
    {
        private const string TOKEN = "admin";

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //verifica no cabeçalho da requisição se tem o autorization
            //Captura o HeaderAutohrization da requisição
            var authorizationHeader = actionContext.Request.Headers.Authorization;

            //HeaderAuthorization possui dois campos o Scheme e Parameter
            if(authorizationHeader == null || authorizationHeader.Scheme != "Bearer" || authorizationHeader.Parameter != TOKEN)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
        }
    }
}