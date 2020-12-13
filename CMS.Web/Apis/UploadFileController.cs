using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
using CMS.Web.ApiModels;
using CMS.Web.Apis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CMS.Web.Apis
{
    [Route("api/fileupload")]
    public class UploadFileController : ControllerBase
    {
        private readonly IFileUploadService _fileUploadService;

        private IWebHostEnvironment hostingEnvironment;
        public UploadFileController(
                IWebHostEnvironment _hostingEnvironment,
               IFileUploadService fileUploadService)
        {
            this.hostingEnvironment = _hostingEnvironment;
            _fileUploadService = fileUploadService;
        }
        public static string RamdomString(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(36);
                if (temp != -1 && temp == t)
                {
                    return RamdomString(codeCount);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }

        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> UploadAnh()
        {
            string folderName = "FilesUpload\\Anh";
            string webRootPath = hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            try
            {
                int count = 0;
                foreach (var file in Request.Form.Files)
                {
                    count = count + 1;
                    var fileName = file.FileName.Replace("\"", "").Split('.');
                    var newName = RamdomString(20);
                    var destinationPath = Path.Combine(newPath, newName + '.' + fileName[fileName.Length - 1]);
                    while (System.IO.File.Exists(destinationPath))
                    {
                        newName = RamdomString(20);
                        destinationPath = Path.Combine(newPath, newName + '.' + fileName[fileName.Length - 1]);
                    }
                    using (var stream = new FileStream(destinationPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Coordinate viTri = ImageUtils.ReadImageLatitudeAndLongitude(destinationPath);
                    // ImageHelper.SaveResizeImage(destinationPath, 1024);

                    FileUpload fileUpload = new FileUpload
                    {
                        FileName = newName + "." + fileName[fileName.Length - 1],
                        FilePath = destinationPath,
                        FileSize = new FileInfo(destinationPath).Length.ToString(),
                        FileKey = newName
                    };
                    fileUpload.FileType = fileName[1];
                    await _fileUploadService.CreateFileUpload(fileUpload);
                    return new OkObjectResult(new { key = fileUpload.FileKey });
                }
                return new BadRequestObjectResult("Lỗi Gửi Ảnh");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Lỗi Gửi Ảnh");
            }
        }
        [Route("upload/file")]
        [HttpPost, Authorize]
        public async Task<IActionResult> UploadFile()
        {
            string folderName = "FilesUpload\\Documents";
            string webRootPath = hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            try
            {
                int count = 0;
                foreach (var file in Request.Form.Files)
                {
                    count = count + 1;
                    var fileName = file.FileName.Replace("\"", "").Split('.');
                    var newName = fileName[0];
                    var destinationPath = Path.Combine(newPath, fileName[0] + '.' + fileName[fileName.Length - 1]);
                    while (System.IO.File.Exists(destinationPath))
                    {
                        newName = fileName[0] + '(' + RamdomString(3) + ')';
                        destinationPath = Path.Combine(newPath, newName + '.' + fileName[fileName.Length - 1]);
                    }
                    using (var stream = new FileStream(destinationPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    FileUpload fileUpload = new FileUpload
                    {
                        FileName = newName + "." + fileName[fileName.Length - 1],
                        FilePath = destinationPath,
                        FileSize = new FileInfo(destinationPath).Length.ToString(),
                        FileKey = newName
                    };
                    fileUpload.FileType = fileName[1];
                    await _fileUploadService.CreateFileUpload(fileUpload);
                    return new OkObjectResult(new { key = fileUpload.FileKey });
                }
                return new BadRequestObjectResult("Lỗi gửi tài liệu");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Lỗi gửi tài liệu");
            }
        }
        [HttpGet]
        [Route("download/{key}")]
        public async Task<IActionResult> DownloadAsync(string key)
        {
            var path = _fileUploadService.GetFileUploads(key).ToList();
            if (path == null || path.Count() == 0)
                return new BadRequestObjectResult("Không tìm thấy ảnh");

            if (!System.IO.File.Exists(path[0].FilePath))
                return new BadRequestObjectResult("Không tìm thấy ảnh");

            var memory = new MemoryStream();
            using (var stream = new FileStream(path[0].FilePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/octet-stream", Path.GetFileName(path[0].FilePath));
        }
    }
}
