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
   

    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [ProducesResponseType(typeof(PagedResult<UngVienDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet, Authorize]
        public async Task<IActionResult> GetHocVienByUsername()
        {
            var ungVien = await _userService.GetUngVienByUsername(User.Identity.Name);
            var result = UngVienDTO.FromEntity(ungVien);
            return Ok(result);
        }
    }
}
