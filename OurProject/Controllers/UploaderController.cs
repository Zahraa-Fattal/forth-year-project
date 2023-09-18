using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OurProject.Controllers
{
    public class UploaderController : Controller
    {

        public static IWebHostEnvironment _environment;
        public UploaderController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpPost]
        public async Task<string> PostAsyncFile(string path, IFormFile files)
        {
            if (files.Length > 0)
            {
                try
                {
                    string extraPath = DateTime.Now.ToString("yyyy/MM/dd");
                    path = Path.Combine(path, extraPath);
                    path = Path.Combine("uploads", path);

                    string extension = Path.GetExtension(files.FileName).ToLower();
                    List<string> Allowex = new List<string>() { ".jpg", ".png", ".jpeg", ".bmp", ".pdf", ".gif" };
                    if (!Allowex.Contains(extension))
                    {
                        return null;
                    }
                    string directoryPath = Path.Combine(@_environment.WebRootPath, @path.Replace('/', '\\'));
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    string newName = Guid.NewGuid().GetHashCode() + extension;
                    path = Path.Combine(@path, @newName);

                    using (FileStream filestream = System.IO.File.Create(Path.Combine(@_environment.WebRootPath, @path.Replace('/', '\\'))))
                    {
                        files.CopyTo(filestream);
                        filestream.Flush();

                    }
                    var url = "/" + path.Replace('\\', '/');
                    return url;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Unsuccessful";
            }

        }
    }
}
