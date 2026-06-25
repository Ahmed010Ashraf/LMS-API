using Domain.Exceptions;
using Domain.Exceptions.NotFoundExceptions;
using Shared.Dtos;
using System.Net;

namespace LMS.Api.Middleware

{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            try
            {
                await _next(context);

                if(context.Response.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    context.Response.ContentType = "application/json";
                    var errors = new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        ErrorMessage = $"the end point with this path : {context.Request.Path} is not found"
                    };

                    await context.Response.WriteAsJsonAsync(errors);
                }
            }
            catch (Exception ex) {
                await HandleExctption(context, ex);
            }
        }

        private async Task HandleExctption(HttpContext context, Exception ex)
        {
            //type
            context.Response.ContentType = "application/json";
            //statuscode
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.StatusCode = ex switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                UnauthorizedException => (int)HttpStatusCode.Unauthorized,
                ValidationException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };
            //content
            var errors = new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                ErrorMessage = ex.Message
            };

          if(ex is ValidationException validationException)
            {
                errors.Errors = validationException._errors;
            }

            await context.Response.WriteAsJsonAsync(errors);
        }
    }
}
