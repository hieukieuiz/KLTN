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
    public class BaiTuyenDungService : IBaiTuyenDungService
    {
        private readonly IRepository<BaiTuyenDung> _baiTuyenDungRepository;
        private readonly IRepository<DoanhNghiep> _doanhNghiepRepository;
        private readonly IRepository<UngTuyen> _ungTuyenRepository;
        private readonly IRepository<YeuCau> _yeuCauRepository;
        public BaiTuyenDungService(IRepository<DoanhNghiep> doanhNghiepRepository,
                             IRepository<UngTuyen> ungTuyenRepository,
                             IRepository<YeuCau> yeuCauRepository,
                             IRepository<BaiTuyenDung> baiTuyenDungRepository)
        {
            _baiTuyenDungRepository = baiTuyenDungRepository;
            _doanhNghiepRepository = doanhNghiepRepository;
            _ungTuyenRepository = ungTuyenRepository;
            _yeuCauRepository = yeuCauRepository;
        }
        public IQueryable<BaiTuyenDung> GetBaiTuyenDung(
                                           string keywords/*, int? doanhNghiepId = null*/)
        {
            var query = _baiTuyenDungRepository.TableUntracked/*.Include(x => x.DoanhNghiep)*/
                                         .AsQueryable();

            if (keywords.HasValue())
            {
                query = query
                    .Where(baiTuyenDung =>
                        baiTuyenDung.TieuDe.Contains(keywords) ||
                        baiTuyenDung.NgayDang.Contains(keywords) ||
                        baiTuyenDung.SoLuongTuyen.Contains(keywords) ||
                        baiTuyenDung.ThanhPho.Contains(keywords) ||
                        baiTuyenDung.MucLuong.Contains(keywords) ||
                        baiTuyenDung.KinhNghiem.Contains(keywords) ||
                        baiTuyenDung.GioiTinh.Contains(keywords) ||
                        baiTuyenDung.TrinhDo.Contains(keywords) ||
                        baiTuyenDung.TinhChatCongViec.Contains(keywords) ||
                        baiTuyenDung.HinhThuc.Contains(keywords) ||
                        baiTuyenDung.ThoiGianThuViec.Contains(keywords) ||
                        baiTuyenDung.NganhNghe.Contains(keywords) ||
                        baiTuyenDung.MoTa.Contains(keywords) ||
                        baiTuyenDung.QuyenLoi.Contains(keywords) 
                    );
            }
            //if (doanhNghiepId.HasValue && doanhNghiepId != 0)
            //    query = query.Where(x => x.DoanhNghiep.Id == doanhNghiepId);
            return query;
        }
        public async Task<BaiTuyenDung> GetBaiTuyenDungById(int id)
        {
            return await _baiTuyenDungRepository.GetByIdAsync(id);
        }
        public async Task<ServiceResult> CreateBaiTuyenDung(BaiTuyenDung baiTuyenDung)
        {
            await _baiTuyenDungRepository.AddAsync(baiTuyenDung);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> UpdateBaiTuyenDung(BaiTuyenDung baiTuyenDung)
        {
            await _baiTuyenDungRepository.UpdateAsync(baiTuyenDung);
            return ServiceResult.Success;
        }
        public async Task<ServiceResult> DeleteBaiTuyenDung(int id)
        {
            var baiTuyenDung = await _baiTuyenDungRepository.GetByIdAsync(id);
            await _baiTuyenDungRepository.DeleteAsync(baiTuyenDung);
            return ServiceResult.Success;
        }
    }
}