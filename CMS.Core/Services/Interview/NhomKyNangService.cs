using CMS.Core.Entities;
using CMS.Core.Extensions;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services.Interview;
using CMS.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CMS.Core.Services.Interview
{
    public class NhomKyNangService : INhomKyNangService
    {
        private readonly IRepository<NhomKyNang> _nhomKyNangRepository;
        public NhomKyNangService(IRepository<NhomKyNang> nhomKyNangRepository)
        {
            _nhomKyNangRepository = nhomKyNangRepository;
        }
        public IQueryable<NhomKyNang> GetNhomKyNang(string keywords)
        {
            var query = _nhomKyNangRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(nhomkynang =>
                        nhomkynang.TenNhomKyNang.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<NhomKyNang> GetNhomKyNangById(int id)
        {
            return await _nhomKyNangRepository.GetByIdAsync(id);
        }
        public async Task<ServiceResult> CreateNhomKyNang(NhomKyNang nhomKyNang)
        {
            await _nhomKyNangRepository.AddAsync(nhomKyNang);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> UpdateNhomKyNang(NhomKyNang nhomKyNang)
        {
            await _nhomKyNangRepository.UpdateAsync(nhomKyNang);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> DeleteNhomKyNang(int id)
        {
            var nhomKyNang = await _nhomKyNangRepository.GetByIdAsync(id);
            await _nhomKyNangRepository.DeleteAsync(nhomKyNang);
            return ServiceResult.Success;
        }
    }
}