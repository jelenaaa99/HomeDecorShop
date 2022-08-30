using FluentValidation;
using HomeDecorShop.Application.Exceptions;
using HomeDecorShop.Application.Logging;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDecorShop.API.Core
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionLogger _logger;

        public ExceptionHandler(RequestDelegate next, IExceptionLogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {
                _logger.Log(ex);

                httpContext.Response.ContentType = "application/json";
                object response = null;
                var code = StatusCodes.Status500InternalServerError;

                if (ex is ForbiddenUseCaseExecutionException)
                {
                    code = StatusCodes.Status403Forbidden;
                    response = new { error = ex.Message };
                }

                if (ex is EntityNotFoundException)
                {
                    code = StatusCodes.Status404NotFound;
                    response = new {error = ex.Message};
                }

                if (ex is UnprocessableEntityException)
                {
                    code = StatusCodes.Status422UnprocessableEntity;
                    response = new { error = ex.Message };
                }

                if (ex is ValidationException e)
                {
                    code = StatusCodes.Status422UnprocessableEntity;
                    response = new
                    {
                        errors = e.Errors.Select(x => new
                        {
                            property = x.PropertyName,
                            error = x.ErrorMessage
                        })
                    };
                }

                if (ex is UseCaseConflictException conflictEx)
                {
                    code = StatusCodes.Status409Conflict;
                    response = new { message = conflictEx.Message };
                }


                httpContext.Response.StatusCode = code;
                if (response != null)
                {
                    await httpContext.Response.WriteAsJsonAsync(response);
                }
            }
        }
    }
}
