using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class FileUploadDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileSize { get; set; }
        public string FilePath { get; set; }
        public string FileKey { get; set; }
        public string FileDescription { get; set; }
        public static FileUploadDTO FromEntity(FileUpload item)
        {
            return new FileUploadDTO()
            {
                Id = item.Id,
                FileName = item.FileName,
                FileType = item.FileType,
                FileSize = item.FileSize,
                FilePath = item.FilePath,
                FileKey = item.FileKey,
                FileDescription = item.FileDescription,
            };
        }
        public FileUpload ToEntity()
        {
            return new FileUpload()
            {
                Id = this.Id,
                FileName = this.FileName,
                FileType = this.FileType,
                FileSize = this.FileSize,
                FilePath = this.FilePath,
                FileKey = this.FileKey,
                FileDescription = this.FileDescription,
            };
        }
    }
}