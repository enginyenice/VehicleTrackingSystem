/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        #region Fields

        private IMediator _mediator;

        #endregion Fields

        #region Properties

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        protected int NameIdentifier => int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        #endregion Properties

        #region Methods

        public IActionResult ActionResultInstance<T>(IResponse<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }

        #endregion Methods
    }
}