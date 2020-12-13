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
    public class BaiTestTuyenDungService : IBaiTestTuyenDungService
    {
        private readonly IRepository<BaiTestTuyenDung> _baiTestTuyenDungRepository;
        private readonly IRepository<BaiThi> _baiThiRepository;
        private readonly IRepository<BaiTuyenDung> _baiTuyenDungRepository;
        public BaiTestTuyenDungService(IRepository<BaiThi> baiThiRepository,
                             IRepository<BaiTuyenDung> baiTuyenDungRepository,
                             IRepository<BaiTestTuyenDung> baiTestTuyenDungRepository)
        {
            _baiThiRepository = baiThiRepository;
            _baiTuyenDungRepository = baiTuyenDungRepository;
            _baiTestTuyenDungRepository = baiTestTuyenDungRepository;
        }
        public IQueryable<BaiTestTuyenDung> GetBaiTestTuyenDung(
                                           string keywords)
        {
            var query = _baiTestTuyenDungRepository.TableUntracked
                                         .AsQueryable();

            if (keywords.HasValue())
            {
                query = query
                    .Where(baiTestTuyenDung =>
                        baiTestTuyenDung.DiemPass.Contains(keywords)
                    );
            }
            return query;
        }
        public async Task<BaiTestTuyenDung> GetBaiTestTuyenDungById(int id)
        {
            return await _baiTestTuyenDungRepository.GetByIdAsync(id);
        }
        public async Task<ServiceResult> CreateBaiTestTuyenDung(BaiTestTuyenDung baiTestTuyenDung)
        {
             await _baiTestTuyenDungRepository.AddAsync(baiTestTuyenDung);
             return ServiceResult.Success; 
        }
        public async Task<ServiceResult> UpdateBaiTestTuyenDung(BaiTestTuyenDung baiTestTuyenDung)
        {
            await _baiTestTuyenDungRepository.UpdateAsync(baiTestTuyenDung);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> DeleteBaiTestTuyenDung(int id)
        {
            var baiTestTuyenDung = await _baiTestTuyenDungRepository.GetByIdAsync(id);
            await _baiTestTuyenDungRepository.DeleteAsync(baiTestTuyenDung);
            return ServiceResult.Success;
        }
    }
}
