using CMS.Core.Enums;
using CMS.Infrastructure;
using CMS.Core.Extensions;
using CMS.Infrastructure.Data;
using CMS.Web.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Collections.Generic;
using System;

namespace CMS.Web.Apis
{
    public class UsersController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<UsersController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("myaccount/roles"), Authorize]
        public async Task<IActionResult> GetMyRoles()
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);
            if (user == null)
                return BadRequest();
            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }

        [ProducesResponseType(typeof(PagedResult<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet(""), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> GetUsers([FromQuery] string keywords = null, [FromQuery]List<string> roles = null,
            [FromQuery] Pagination pagination = null)
        {
            var query = _userManager.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .AsNoTracking();
            if (keywords.HasValue())
                query = query.Where(x => x.UserName.Contains(keywords));
            if (!roles.IsNullOrEmpty())
                query = query.Where(x => x.UserRoles.Any(x => roles.Contains(x.Role.Name)));
            var users = PagedList.Create(query, pagination.Page - 1, pagination.ItemsPerPage);
            pagination.TotalItems = users.TotalCount;
            var results = new PagedResult<UserDTO>(pagination, users.Select(UserDTO.FromEntity));
            return Ok(results);
        }
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost(""), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> CreateUser(UserDTO user)
        {
            if (await _userManager.Users.AnyAsync(x => x.UserName == user.UserName))
                return BadRequest("Tài khoản đã được sử dụng");
            var applicationUser = user.ToEntity();
            applicationUser.Id = Guid.NewGuid().ToString();
            var result = await _userManager.CreateAsync(applicationUser, user.Password);
            if (result.Succeeded)
                await _userManager.AddToRolesAsync(applicationUser, user.Roles);
            return Ok();
        }

        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut(""), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> UpdateUser(UserDTO user)
        {
            var applicationUser = _userManager.Users.FirstOrDefault(x => x.UserName == user.UserName);
            if (applicationUser == null)
                return BadRequest("Tài khoản không tồn tại");
            if (_userManager.Users.Any(x => x.Email == user.Email && x.UserName != user.UserName))
                return BadRequest("Email đã được sử dụng");
            applicationUser.PhoneNumber = user.PhoneNumber;
            applicationUser.Email = user.Email;
            applicationUser.LockoutEnd = user.LockoutEnd;
            await _userManager.UpdateAsync(applicationUser);
            var userRoles = await _userManager.GetRolesAsync(applicationUser);
            await _userManager.RemoveFromRolesAsync(applicationUser, userRoles);
            await _userManager.AddToRolesAsync(applicationUser, user.Roles);
            return Ok();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("resetpassword"), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> ResetPassword(UserDTO user)
        {
            var applicationUser = _userManager.Users.FirstOrDefault(x => x.UserName == user.UserName);
            if (applicationUser == null)
                return BadRequest("Tài khoản không tồn tại");
            var code = await _userManager.GeneratePasswordResetTokenAsync(applicationUser);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ResetPassword",
                pageHandler: null,
                values: new { area = "Identity", code },
                protocol: Request.Scheme);

            //await _emailSender.SendEmailAsync(
            //    applicationUser.Email,
            //    "Reset Password",
            //    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
            return Ok();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{userName}"), Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            var applicationUser = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
            if (applicationUser == null)
                return BadRequest("Tài khoản không tồn tại");
            await _userManager.DeleteAsync(applicationUser);
            return Ok();
        }
    }
}