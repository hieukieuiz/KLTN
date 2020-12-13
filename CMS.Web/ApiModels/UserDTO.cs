using CMS.Core.Entities;
using CMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CMS.Web.ApiModels
{
    public class UserDTO
    {
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string SecurityStamp { get; set; }
        public string PasswordHash { get; set; }
        public bool EmailConfirmed { get; set; }
        public string NormalizedEmail { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public string UserName { get; set; }
        public string Id { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
        public static UserDTO FromEntity(ApplicationUser item)
        {
            return new UserDTO()
            {
                Id = item.Id,
                AccessFailedCount = item.AccessFailedCount,
                Email = item.Email,
                EmailConfirmed = item.EmailConfirmed,
                LockoutEnabled = item.LockoutEnabled,
                LockoutEnd = item.LockoutEnd,
                NormalizedEmail = item.NormalizedEmail,
                NormalizedUserName = item.NormalizedUserName,
                PhoneNumber = item.PhoneNumber,
                PhoneNumberConfirmed = item.PhoneNumberConfirmed,
                TwoFactorEnabled = item.TwoFactorEnabled,
                UserName = item.UserName,
                Roles = item.UserRoles?.Select(x=>x.Role?.Name).ToList()
            };
        }
        public ApplicationUser ToEntity()
        {
            return new ApplicationUser()
            {
                Id = this.Id,
                AccessFailedCount = this.AccessFailedCount,
                Email = this.Email,
                EmailConfirmed = this.EmailConfirmed,
                LockoutEnabled = this.LockoutEnabled,
                LockoutEnd = this.LockoutEnd,
                NormalizedEmail = this.NormalizedEmail,
                NormalizedUserName = this.NormalizedUserName,
                PhoneNumber = this.PhoneNumber,
                PhoneNumberConfirmed = this.PhoneNumberConfirmed,
                SecurityStamp = this.SecurityStamp,
                TwoFactorEnabled = this.TwoFactorEnabled,
                UserName = this.UserName
            };
        }
    }
}