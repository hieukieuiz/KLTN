using CMS.Core.Entities;
using CMS.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services
{
    public interface IUserService
    {
        public Task<UngVien> GetUngVienByUsername(string username);
        public Task<UngVien> GetUngVienByUsername1(string username);
        public Task<DoanhNghiep> GetDoanhNghiepByUsername(string username);

    }
}
