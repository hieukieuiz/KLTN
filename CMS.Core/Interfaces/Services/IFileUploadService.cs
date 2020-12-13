using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services
{
    public interface IFileUploadService
    {
        public Task CreateFileUpload(FileUpload fileUpload);
        public IQueryable<FileUpload> GetFileUploads(string key = null);
    }
}
