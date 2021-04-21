using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace TradingTester.Api.Controllers
{
    [Route("file")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private static IWebHostEnvironment _environment;
        private static readonly string[] AvailableExtensions = new [] { ".py" };

        public FileUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public async Task<string> UploadFile(IFormFile objFile)
        {
            try
            {
                if (objFile != null && objFile.Length > 0)
                {
                    var fileExtension = objFile.FileName.Substring(objFile.FileName.IndexOf('.'));
                    if (!AvailableExtensions.Contains(fileExtension))
                    {
                        return JsonSerializer.Serialize("Unsupported Extension");
                    }

                    if (!Directory.Exists(_environment.WebRootPath + "\\Strategy\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Strategy\\");
                    }

                    await using FileStream fileStream =
                        System.IO.File.Create(_environment.WebRootPath + "\\Strategy\\strategy.py");

                    objFile.CopyTo(fileStream);
                    fileStream.Flush();
                    return JsonSerializer.Serialize("Successful uploading an .py file to upload folder");
                }
                return JsonSerializer.Serialize("Bad input file");
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
