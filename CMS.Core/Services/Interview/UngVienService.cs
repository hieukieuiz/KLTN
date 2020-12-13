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
    public class UngVienService : IUngVienService
    {
        private readonly IRepository<UngVien> _ungVienRepository;
        public UngVienService(IRepository<UngVien> ungVienRepository)
        {
            _ungVienRepository = ungVienRepository;
        }
        public IQueryable<UngVien> GetUngVien(string keywords = null, int? trangThaiId = null, int? tinhThanhId = null)
        {
            var query = _ungVienRepository.TableUntracked.Include(x => x.TinhThanh).Include(x=>x.TrangThai)
               .Where(x => true).AsQueryable();

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query
                    .Where(ungvien =>
                        ungvien.HoTen.Contains(keywords) ||
                        ungvien.Sdt.Contains(keywords) ||
                        ungvien.Email.Contains(keywords)
                    );
            }
            if (tinhThanhId.HasValue)
            {
                query = query.Where(x => x.TinhThanhId == tinhThanhId);
            }
            if (trangThaiId.HasValue)
            {
                query = query.Where(x => x.TrangThaiId == trangThaiId);
            }
            return query;
        }

        public async Task<UngVien> GetUngVienById(int id)
        {
            return await _ungVienRepository.TableUntracked
                                           .Include(x => x.TinhThanh)
                                           .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<ServiceResult> CreateUngVien(UngVien ungVien)
        {
            if (_ungVienRepository.TableUntracked.Any(x => x.Email == ungVien.Email))
                return ServiceResult.Failed("Email đã được sử dụng");
            if (_ungVienRepository.TableUntracked.Any(x => x.Account == ungVien.Account))
                return ServiceResult.Failed("Account đã được sử dụng");
            await _ungVienRepository.AddAsync(ungVien);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> UpdateThongTinUngVien(UngVien ungVien)
        {
            await _ungVienRepository.UpdateAsync(ungVien);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> UpdateUngVien(UngVien ungVien)
        {
            await _ungVienRepository.UpdateAsync(ungVien);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> DeleteUngVien(int id)
        {
            var ungVien = await _ungVienRepository.GetByIdAsync(id);
            await _ungVienRepository.DeleteAsync(ungVien);
            return ServiceResult.Success;
        }
    }
}

