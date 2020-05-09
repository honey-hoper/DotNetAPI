using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace WebAPIApp.Services
{
    public class SaveFormFileService : ISaveFormFileService
    {
        public async Task<string> Save(IFormFile formFile)
        {
            var fileName = CreateUniqueFileName(formFile.FileName);
            using (var fileStream = new FileStream(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName),
                FileMode.Create,
                FileAccess.Write
            ))
            {
                await formFile.CopyToAsync(fileStream);
            }
            return fileName;
        }

        private string CreateUniqueFileName(string currentFileName)
        {
            var uniquePrefix = Path.GetRandomFileName();
            var extension = Path.GetExtension(currentFileName);
            return $"{uniquePrefix}-{currentFileName}{extension}";
        }
    }
}
