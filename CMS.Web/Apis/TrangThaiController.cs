using CMS.Core.Entities;
using CMS.Core.Enums;
using CMS.Core.Interfaces.Services;
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
    public class TrangThaiController : BaseApiController
    {
        private readonly ITrangThaiService _trangThaiService;
        public TrangThaiController(ITrangThaiService trangThaiService)
        {
            _trangThaiService = trangThaiService;
        }

        [ProducesResponseType(typeof(PagedResult<TrangThaiDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet, Authorize]
        public async Task<IActionResult> GetTrangThai(
            [FromQuery] string keywords = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _trangThaiService.GetTrangThai(keywords);
            var trangThai = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = trangThai.TotalCount;

            var trangThaiDTO = trangThai.Select(TrangThaiDTO.FromEntity);
            var listTrangThai = trangThaiDTO.ToList();
           
            var result = new PagedResult<TrangThaiDTO>(pagination, trangThaiDTO);
            return Ok(result);
        }
        [ProducesResponseType(typeof(TrangThaiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrangThaiById(int id)
        {
            var trangThai = await _trangThaiService.GetTrangThaiById(id);
            var result = TrangThaiDTO.FromEntity(trangThai);
            return Ok(result);
        }
        [ProducesResponseType(typeof(TrangThaiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost, Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> CreateTrangThai(TrangThaiDTO trangThaiDTO)
        {
            var trangThai = trangThaiDTO.ToEntity();
            var serviceResult = await _trangThaiService.createTrangThai(trangThai);
            if (!serviceResult.Succeeded)
                return BadRequest(serviceResult.Errors);
            return Ok(trangThai);
        }

        [ProducesResponseType(typeof(TrangThaiDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}"), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> UpdateTrangThai(int id, [FromBody] TrangThaiDTO trangThaiDTO)
        {
            var trangThai = trangThaiDTO.ToEntity();
            
            await _trangThaiService.UpdateTrangThai(trangThai);
            return Ok(trangThai);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}"), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> DeleteTrangThai(int id)
        {
            await _trangThaiService.DeleteTrangThai(id);
            return Ok();
        }
    }

}
