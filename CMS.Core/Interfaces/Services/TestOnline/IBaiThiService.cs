using CMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces.Services.TestOnline
{
    public interface IBaiThiService
    {
        public IQueryable<BaiThi> GetBaiThi(string keywords, int deThiId);
        public int DemCauTracNghiemDaLam(int baiThiId);
        public int DemCauTuLuanDaLam (int baiThiId);
        public int DemCauTuLuanChuaCham (int baiThiId);
        public double? TinhDiemCham(int baiThiId);
        public Task ScanBaiThi(int deThiId);
    }
}
