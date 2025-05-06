using System;
using Microsoft.AspNetCore.Mvc;

namespace XanhNest.BackEndServer.API.Controllers
{
    public interface IController
    {
        IActionResult CreateOk();
        IActionResult CreateOkForResponse<T>(T result);
        IActionResult CreateBadRequest(string message = null);
    }
    [Produces("application/json")]
    [ApiController]
    public abstract class ControllerBase : IController
    {
        public IActionResult CreateBadRequest(string message = null)
        {
            throw new NotImplementedException();
        }

        public IActionResult CreateOk()
        {
            throw new NotImplementedException();
        }

        public IActionResult CreateOkForResponse<T>(T result)
        {
            throw new NotImplementedException();
        }
    }
}

