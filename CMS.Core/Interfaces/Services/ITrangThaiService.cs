using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services
{
   public interface ITrangThaiService
    {
        public Task<TrangThai> GetTrangThaiById(int id);
        public IQueryable<TrangThai> GetTrangThai(string keywords = null);
        public Task<ServiceResult> createTrangThai(TrangThai trangThai);
        public Task<ServiceResult> UpdateTrangThai(TrangThai trangThai);
        public Task<ServiceResult> DeleteTrangThai(int id);


    }
}
