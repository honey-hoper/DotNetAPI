using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebAPIApp.Services
{
    public interface ISaveFormFileService
    {
        public Task<string> Save(IFormFile formFile);
    }
}
