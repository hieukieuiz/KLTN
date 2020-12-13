using CMS.Core.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CMS.Web.Filters
{
    public static class FakeAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseFakeAuthentication(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FakeAuthenticationMiddleware>();
        }
    }
    public class FakeAuthenticationMiddleware
    {
        private readonly static string _userName = "admin@hvitclan.vn";
        private readonly ClaimsPrincipal _user = new ClaimsPrincipal(
            new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier, _userName),
                                        new Claim(ClaimTypes.Name, _userName),
                                        new Claim(ClaimTypes.Role, Roles.ADMIN),
                                        new Claim(ClaimTypes.Role,  Roles.DOANH_NGHIEP),
                                        new Claim(ClaimTypes.Role,  Roles.UNG_VIEN)
                                   }, "FakeAuthentication")
            );

        //private readonly static string _userName = "hocvien@hvitclan.vn";
        //private readonly ClaimsPrincipal _user = new ClaimsPrincipal(
        //    new ClaimsIdentity(new Claim[] {
        //                                new Claim(ClaimTypes.NameIdentifier, _userName),
        //                                new Claim(ClaimTypes.Name, _userName),
        //                                new Claim(ClaimTypes.Role,  Roles.HOC_VIEN)
        //                           }, "FakeAuthentication")
        //    );
        private readonly RequestDelegate _next;

        public FakeAuthenticationMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.User = _user;
            await _next(context);
        }
    }
}
