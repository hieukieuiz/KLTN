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
    public class DoanhNghiepService : IDoanhNghiepService
    {
        private readonly IRepository<DoanhNghiep> _doanhNghiepRepository;
        private readonly IRepository<BaiTuyenDung> _baiTuyenDungRepository;
        public DoanhNghiepService(IRepository<DoanhNghiep> doanhNghiepRepository, 
            IRepository<BaiTuyenDung> baiTuyenDungRepository)
        {
            _doanhNghiepRepository = doanhNghiepRepository;
            _baiTuyenDungRepository = baiTuyenDungRepository;
        }
        public IQueryable<DoanhNghiep> GetDoanhNghiep(string keywords)
        {
            var query = _doanhNghiepRepository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(doanhnghiep =>
                        doanhnghiep.TenDoanhNghiep.Contains(keywords) ||
                        doanhnghiep.Account.Contains(keywords) ||
                        doanhnghiep.SĐT.Contains(keywords) ||
                        doanhnghiep.Email.Contains(keywords) ||
                        doanhnghiep.DiaChi.Contains(keywords) ||
                        doanhnghiep.GioiThieu.Contains(keywords)
                    );
            }
            return query;
        }

        public async Task<DoanhNghiep> GetDoanhNghiepById(int id)
        {
            return await _doanhNghiepRepository.GetByIdAsync(id);
        }
        public async Task<ServiceResult> CreateDoanhNghiep(DoanhNghiep doanhNghiep)
        {
            await _doanhNghiepRepository.AddAsync(doanhNghiep);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> UpdateDoanhNghiep(DoanhNghiep doanhNghiep)
        {
            await _doanhNghiepRepository.UpdateAsync(doanhNghiep);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> DeleteDoanhNghiep(int id)
        {
            var doanhNghiep = await _doanhNghiepRepository.GetByIdAsync(id);
            await _doanhNghiepRepository.DeleteAsync(doanhNghiep);
            return ServiceResult.Success;
        }
        public IQueryable<BaiTuyenDung> GetDanhSachBaiTuyenDung(/*int doanhNghiepId*/)
        {
            var danhSachBaiTuyenDung = _baiTuyenDungRepository.TableUntracked
                .Include(x => x.DoanhNghiep);
                //.Where(x => x.DoanhNghiep.Id == doanhNghiepId);
            return danhSachBaiTuyenDung;
        }
    }
}
