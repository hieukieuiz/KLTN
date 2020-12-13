using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IRepository<FileUpload> _FileUploadRepository;
        public FileUploadService(IRepository<FileUpload> FileUploadRepository)
        {
            _FileUploadRepository = FileUploadRepository;
        }
        public async Task CreateFileUpload(FileUpload fileUpload)
        {
            await _FileUploadRepository.AddAsync(fileUpload);
        }
        public IQueryable<FileUpload> GetFileUploads(string key = null)
        {
            var query = _FileUploadRepository.TableUntracked;
            var path = query.Where(x => x.FileKey == key);
            return path;
        }
    }
}
