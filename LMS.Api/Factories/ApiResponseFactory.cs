using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens.Experimental;
using Shared.Dtos;
using System.Net;

namespace LMS.Api.Factories
{
    public class ApiResponseFactory
    {

        public static IActionResult CustomResponse(ActionContext context) {

            var errors = context.ModelState.Where(e => e.Value.Errors.Any()).Select(e =>
                    new ValidationErrors()
                    {
                        Key = e.Key,
                        Value = e.Value.Errors.Select(e => e.ErrorMessage)
                    });

            var validationErrorResponse = new ValidationErrorResponse()
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Message = "Invalid Modelstate",
                Errors = errors

            };


            return new BadRequestObjectResult(validationErrorResponse);

        }
    }
}
