/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Microsoft.AspNetCore.Builder;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
        #region Methods

        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        #endregion Methods
    }
}