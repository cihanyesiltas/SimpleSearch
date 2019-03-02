using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SimpleSearch.Api.Infrastructure.Exception;

namespace SimpleSearch.Api.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError($"{context.Exception.StackTrace}, {context.Exception},{context.Exception.Message}");

            if (context.Exception.GetType() == typeof(DomainException))
            {
                var globalResult = new GlobalResult<List<Error>>(((DomainException) context.Exception).ErrorList);
                context.Result = new ObjectResult(globalResult);
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            }
            else
            {
                var globalResult = new GlobalResult<List<Error>>(
                    new List<Error>
                    {
                        new Error
                        {
                            ErrorMessage = context.Exception.Message
                        }
                    });

                context.Result = new ObjectResult(globalResult);
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            }

            context.ExceptionHandled = true;
        }
    }
}