/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Core.Application.Responses;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ExceptionMiddleware
    {
        #region Fields

        private RequestDelegate _next;

        #endregion Fields

        #region Constructors

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion Constructors

        #region Methods

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            //if (exception.GetType() == typeof(ValidationException))
            //{
            //    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //    errors = ((ValidationException)exception).Errors;

            //    return context.Response.WriteAsync(new ValidationProblemDetails
            //    {
            //        Status = StatusCodes.Status400BadRequest,
            //        Type = "https://example.com/probs/validation",
            //        Title = "Validation error(s)",
            //        Detail = "",
            //        Instance = "",
            //        Errors = errors
            //    }.ToString());
            //}

            if (exception.GetType() == typeof(BusinessException))
            {
                BusinessException businessException = (BusinessException)exception;
                context.Response.StatusCode = businessException.StatusCode;
                return context.Response.WriteAsync(
                    Response<NoDataDto>
                    .Fail(exception.Message, businessException.StatusCode, true)
                    .ToString());
            }
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return context.Response.WriteAsync(
                Response<NoDataDto>
                    .Fail(exception.Message, StatusCodes.Status400BadRequest, true)
                    .ToString());
        }

        #endregion Methods
    }
}