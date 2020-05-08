using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace WebAPIApp.Controllers
{
    [Authorize]
    [ApiController]
    public class StaticContentController : ControllerBase
    {
        [HttpGet("doggy")]
        public IActionResult GetDoggy()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "dog.jpg");
            return PhysicalFile(filePath, "image/jpeg");
        }
    }
}