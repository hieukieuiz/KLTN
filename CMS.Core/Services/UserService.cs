using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Enums;
using CMS.Core.Extensions;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
using CMS.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace CMS.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UngVien> _ungVienRepository;
        private readonly IRepository<DoanhNghiep> _doanhNghiepRepository;
        public UserService(IRepository<UngVien> ungVienRepository,
            IRepository<DoanhNghiep> doanhNghiepRepository)
        {
            _ungVienRepository = ungVienRepository;
            _doanhNghiepRepository = doanhNghiepRepository;
        }
        public async Task<UngVien> GetUngVienByUsername(string username)
        {
            return await _ungVienRepository.TableUntracked.Include(x=>x.TinhThanh).FirstOrDefaultAsync(x => x.Account == username);
        }
        public async Task<UngVien> GetUngVienByUsername1(string username)
        {
            return await _ungVienRepository.TableUntracked.Include(x => x.TinhThanh).FirstOrDefaultAsync(x => x.Account == username);
        }
        public async Task<DoanhNghiep> GetDoanhNghiepByUsername(string username)
        {
            return await _doanhNghiepRepository.TableUntracked.FirstOrDefaultAsync(x => x.Account == username);
        }
    }
}
