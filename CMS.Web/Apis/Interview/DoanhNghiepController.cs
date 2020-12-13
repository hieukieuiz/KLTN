using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Entities;
using CMS.Core.Enums;
using CMS.Core.Interfaces.Services;
using CMS.Core.Interfaces.Services.Interview;
using CMS.Infrastructure;
using CMS.Infrastructure.Data;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Web.Apis.Interview
{
    public class DoanhNghiepController : BaseApiController
    {
        private readonly IDoanhNghiepService _doanhNghiepService;
        private readonly IUserService _userService;
        public DoanhNghiepController(UserManager<ApplicationUser> userManager, IDoanhNghiepService doanhNghiepService, IUserService userService)
        {
            _doanhNghiepService = doanhNghiepService;
            _userService = userService;
        }
        [ProducesResponseType(typeof(PagedResult<DoanhNghiepDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet/*, Authorize(Roles = Roles.ADMIN)*//*, Authorize(Roles = Roles.DOANH_NGHIEP)*/]
        public async Task<IActionResult> GetDoanhNghiep([FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _doanhNghiepService.GetDoanhNghiep(keywords);
            var doanhNghiep = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = doanhNghiep.TotalCount;
            var result = new PagedResult<DoanhNghiepDTO>(pagination, doanhNghiep.Select(DoanhNghiepDTO.FromEntity));
            return Ok(result);
        }
        [ProducesResponseType(typeof(DoanhNghiepDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}"), Authorize(Roles = Roles.ADMIN), Authorize(Roles = Roles.DOANH_NGHIEP), Authorize(Roles = Roles.UNG_VIEN)]
        public async Task<IActionResult> GetDoanhNghiepById(int id)
        {
            var doanhNghiep = await _doanhNghiepService.GetDoanhNghiepById(id);
            var result = DoanhNghiepDTO.FromEntity(doanhNghiep);
            return Ok(result);
        }
        [ProducesResponseType(typeof(DoanhNghiepDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost, Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> CreateDoanhNghiep(DoanhNghiepDTO doanhNghiepDTO)
        {
            var doanhNghiep = doanhNghiepDTO.ToEntity();
            await _doanhNghiepService.CreateDoanhNghiep(doanhNghiep);
            return Ok(doanhNghiep);
        }

        [ProducesResponseType(typeof(DoanhNghiepDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}"), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> UpdateDoanhNghiep(int id, [FromBody] DoanhNghiepDTO doanhNghiepDTO)
        {
            var doanhNghiep = doanhNghiepDTO.ToEntity();
            await _doanhNghiepService.UpdateDoanhNghiep(doanhNghiep);
            return Ok(doanhNghiep);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}"), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> DeleteDoanhNghiep(int id)
        {
            await _doanhNghiepService.DeleteDoanhNghiep(id);
            return Ok();
        }
        [ProducesResponseType(typeof(PagedResult<BaiTuyenDungDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("danhsachbaituyendung"), Authorize]
        public async Task<IActionResult> GetDanhSachBaiTuyenDung([FromQuery] Pagination pagination = null)
        {
            //DoanhNghiep doanhNghiep = await _userService.GetDoanhNghiepByUsername(User.Identity.Name);
            //if (doanhNghiep != null)
            {
                var query = _doanhNghiepService.GetDanhSachBaiTuyenDung();
                var danhSachBaiTuyenDung = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
                pagination.TotalItems = danhSachBaiTuyenDung.TotalCount;
                //var dangKyHocDTO = danhSachDangKyHoc.Select(DangKyHocDTO.FromEntity);
                //var temp = dangKyHocDTO.ToList();
                //for (int i = 0; i < temp.Count; i++)
                //{
                //    temp[i].TyLeHoanThanh = _khoaHocService.CalTyLeHoanThanh(temp[i].ToEntity());
                //}
                //dangKyHocDTO = temp;
                var result = new PagedResult<BaiTuyenDungDTO>(pagination, danhSachBaiTuyenDung.Select(BaiTuyenDungDTO.FromEntity));
                return Ok(result);
            }
            return Unauthorized();
        }

    }
}
