using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPIApp.Controllers
{
    public class ExceptionHandlingController : ControllerBase
    {
        private readonly ILogger<ExceptionHandlingController> logger;

        public ExceptionHandlingController(ILogger<ExceptionHandlingController> logger)
        {
            this.logger = logger;
        }
        
        [Route("exception-handler")]
        public IActionResult HandleException()
        {
            //TODO check type and generate appropriate response
            logger.LogError("Exception Occured");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}