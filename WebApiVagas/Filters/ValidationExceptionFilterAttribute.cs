using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WebApiVagas.Filters
{
    public class ValidationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /*Esse filtro vai interceptar a resposta da aplicaçao sempre que ocorrer uma exceção
         * do tipo ValidationException*/

        //Se a exceção lançada for do tipo ValidationException
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is ValidationException)
            {
                var resultado = new ResultadoValidacao("Ocorreram erros de validação nessa requisição. Verifique a lista de erros.");
                
                //precorre a lista de erros do ValidationException, e para cada erro ele adiciona o erro ao resultado
                (actionExecutedContext.Exception as ValidationException).Errors
                                                                        .ToList()
                                                                        .ForEach(e => resultado.AdicionarErro(e.PropertyName, e.ErrorMessage));

                //Retorna como resultado passando o status badrequest
                var resposta = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    Content = new System.Net.Http.ObjectContent<ResultadoValidacao>(
                        resultado,
                        new System.Net.Http.Formatting.JsonMediaTypeFormatter())
                };

                actionExecutedContext.Response = resposta;
            }
        }
    }
}