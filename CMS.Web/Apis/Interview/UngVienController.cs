using CMS.Core.Entities;
using CMS.Core.Enums;
using CMS.Core.Interfaces.Services;
using CMS.Core.Interfaces.Services.Interview;
using CMS.Infrastructure;
using CMS.Infrastructure.Data;
using CMS.Web.ApiModels;
using CMS.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CMS.Web.Apis
{
    public class UngVienController : BaseApiController
    {
        private readonly IUngVienService _ungVienService;
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UngVienController(
            UserManager<ApplicationUser> userManager,
            IUserService userService,
            IUngVienService ungVienService)
        {
            _userManager = userManager;
            _ungVienService = ungVienService;
            _userService = userService;
        }

        [ProducesResponseType(typeof(PagedResult<UngVienDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet, Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> GetUngVien(
            [FromQuery] string keywords = null,
            [FromQuery] int? tinhThanhId = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _ungVienService.GetUngVien(keywords, tinhThanhId);
            var ungVien = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = ungVien.TotalCount;
            var result = new PagedResult<UngVienDTO>(pagination, ungVien.Select(UngVienDTO.FromEntity));
            return Ok(result);
        }

        [ProducesResponseType(typeof(UngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}"), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> GetUngVienById(int id)
        {
            var ungVien = await _ungVienService.GetUngVienById(id);
            var result = UngVienDTO.FromEntity(ungVien);
            return Ok(result);
        }
        [ProducesResponseType(typeof(UngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("thongtincanhan"), Authorize]
        public async Task<IActionResult> GetUngVienByUsername()
        {
            var ungVien = await _userService.GetUngVienByUsername(User.Identity.Name);
            if (ungVien != null)
            {
                var res = await _ungVienService.GetUngVienById(ungVien.Id);
                var result = UngVienDTO.FromEntity(res);
                return Ok(result);
            }
            return Unauthorized();
        }

        [ProducesResponseType(typeof(UngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("cvungvien"), Authorize]
        public async Task<IActionResult> GetUngVienByUsername1()
        {
            var ungVien = await _userService.GetUngVienByUsername(User.Identity.Name);
            if (ungVien != null)
            {
                var res = await _ungVienService.GetUngVienById(ungVien.Id);
                var result = UngVienDTO.FromEntity(res);
                return Ok(result);
            }
            return Unauthorized();
        }

        [ProducesResponseType(typeof(UngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("capnhatthongtincanhan"), Authorize]
        public async Task<IActionResult> UpdateThongTinCaNhanUngVien([FromBody] UngVienDTO ungVienDTO)
        {
            var ungVienLogin = await _userService.GetUngVienByUsername(User.Identity.Name);
            if (ungVienLogin != null && ungVienLogin.Id != ungVienDTO.Id)
           // { ungVienLogin.Id != ungVienDTO.Id }
            //else
                return BadRequest();
            var ungVien = ungVienDTO.ToEntity();
            await _ungVienService.UpdateThongTinUngVien(ungVien);
            return Ok();
        }

        [ProducesResponseType(typeof(UngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost, Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> CreateUngVien(UngVienDTO ungVienDTO)
        {
            var ungVien = ungVienDTO.ToEntity();
            var seviceResult = await _ungVienService.CreateUngVien(ungVien);
            if (!seviceResult.Succeeded)
                return BadRequest(seviceResult.Errors);
            return Ok(ungVienDTO);
        }

        [ProducesResponseType(typeof(UngVienDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}"), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> UpdateUngVien(int id, [FromBody] UngVienDTO UngVienDTO)
        {
            var ungVien = UngVienDTO.ToEntity();
            await _ungVienService.UpdateUngVien(ungVien);
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}"), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> DeleteUngVien(int id)
        {
            await _ungVienService.DeleteUngVien(id);
            return Ok();
        }
    }
}
