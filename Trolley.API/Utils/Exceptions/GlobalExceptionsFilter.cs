using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace Trolley.API.Utils.Exceptions
{
    public class GlobalExceptionsFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Log.Error(context.Exception, "Ein Fehler ist in einer Controller-Action aufgetreten");

            var problemDetails = new ProblemDetails
            {
                Status = 500,
                Title = "Ein interner Serverfehler ist aufgetreten",
                Detail = context.Exception.Message
            };


            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = problemDetails.Status
            };

            context.ExceptionHandled = true;
        }
    }
}
