using CMS.Core.Entities;
using CMS.Core.Interfaces;
using CMS.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CMS.Core.Enums;
using CMS.Core.Extensions;

using CMS.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CMS.Core.Services
{
    public class TrangThaiService : ITrangThaiService
    {
        private readonly IRepository<TrangThai> _trangThaiRepository;
        //private readonly IRepository<TrangThaiDuAn> _trangThaiDuAnRepository;
        //private readonly IRepository<LichSuChiTietCongViec> _lichSuChiTietCongViecRepository;
        //private readonly IRepository<ChiTietCongViec> _chiTietCongViecRepository;
        //private readonly IRepository<BaoCao> _baoCaoRepository;
        //private readonly IRepository<CongViec> _congViecRepository;
        //private readonly IRepository<PhanViec> _phanViecRepository;
        public TrangThaiService(IRepository<TrangThai> trangThaiRepository)
            //IRepository<CongViec> congViecRepository,
            //IRepository<TrangThaiDuAn> trangThaiDuAnRepository,
            //IRepository<LichSuChiTietCongViec> lichSuChiTietCongViecRepository,
            //IRepository<ChiTietCongViec> chiTietCongViecRepository,
            //IRepository<BaoCao> baoCaoRepository,
           // IRepository<PhanViec> phanViecRepository)
        {
            _trangThaiRepository = trangThaiRepository;
           // _trangThaiDuAnRepository = trangThaiDuAnRepository;
           // _lichSuChiTietCongViecRepository = lichSuChiTietCongViecRepository;
           // _chiTietCongViecRepository = chiTietCongViecRepository;
           // _baoCaoRepository = baoCaoRepository;
           // _congViecRepository = congViecRepository;
           // _phanViecRepository = phanViecRepository;
        }

        public IQueryable<TrangThai> GetTrangThai(string keywords = null)
        {
            var query = _trangThaiRepository.TableUntracked.AsQueryable();
            if (keywords.HasValue())
            {
                keywords = keywords.ToLower();
                query = query.Where(trangThai => trangThai.TenTrangThai.ToLower().Contains(keywords));
            }
            return query;
        }

        public async Task<TrangThai> GetTrangThaiById(int id)
        {
            return await _trangThaiRepository.GetByIdAsync(id);
        }

        public async Task<ServiceResult> createTrangThai(TrangThai trangThai)
        {
             
            if (_trangThaiRepository.TableUntracked.Any(x => x.TenTrangThai == trangThai.TenTrangThai))
            {
                return ServiceResult.Failed("ten trang thai da ton tai");
            }
            await _trangThaiRepository.AddAsync(trangThai);
            return ServiceResult.Success;
        }


        public async Task<ServiceResult> UpdateTrangThai(TrangThai trangThai)
        {
            await _trangThaiRepository.UpdateAsync(trangThai);
            return ServiceResult.Success;
        }

        public async Task<ServiceResult> DeleteTrangThai(int id)
        {
            var  trangThai = await _trangThaiRepository.GetByIdAsync(id);

            //var trangThaiDuAn = _trangThaiDuAnRepository.TableUntracked.Where(x => x.TrangThaiId == id);
            //await _trangThaiDuAnRepository.DeleteRangeAsync(trangThaiDuAn);
            //var lichSuChiTietCongViec = _lichSuChiTietCongViecRepository.TableUntracked.Where(x => x.TrangThaiId == id);
            //await _lichSuChiTietCongViecRepository.DeleteRangeAsync(lichSuChiTietCongViec);
            //var chiTietCongViec = _chiTietCongViecRepository.TableUntracked.Where(x => x.TrangThaiId == id).ToList();
            //    for(int i = 0; i < chiTietCongViec.Count; i++)
            //{
            //    var baoCao = _baoCaoRepository.TableUntracked.Where(x => x.ChiTietCongViecId == chiTietCongViec[i].Id);
            //    await _baoCaoRepository.DeleteRangeAsync(baoCao);
            //}
            //await _chiTietCongViecRepository.DeleteRangeAsync(chiTietCongViec);
           // var congViec = _congViecRepository.TableUntracked.Where(x => x.TrangThaiId == id).ToList();
           // for(int j = 0; j < congViec.Count; j++)
            //{
            //    var phanViec = _phanViecRepository.TableUntracked.Where(x => x.CongViecId == congViec[j].Id);
            //    await _phanViecRepository.DeleteRangeAsync(phanViec);
            //}
            //await _congViecRepository.DeleteRangeAsync(congViec);

             await _trangThaiRepository.DeleteAsync(trangThai);
            return ServiceResult.Success;
        }

    }
}
