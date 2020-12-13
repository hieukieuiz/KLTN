using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Data
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext dbContext,
            UserManager<ApplicationUser> userManager,
             ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                dbContext.Database.Migrate();
                if (!dbContext.Users.Any())
                {
                    var adminUser = new ApplicationUser { UserName = "admin@hvitclan.vn", Email = "admin@hvitclan.vn" };
                    var doanhNghiepUser = new ApplicationUser { UserName = "doanhnghiep@hvitclan.vn", Email = "doanhnghiep@hvitclan.vn" };
                    var ungVienUser = new ApplicationUser { UserName = "ungvien@hvitclan.vn", Email = "ungvien@hvitclan.vn" };
                    //var ungVienUser1 = new ApplicationUser { UserName = "ungvien1@hvitclan.vn", Email = "ungvien1@hvitclan.vn" };
                    await userManager.CreateAsync(adminUser, "Abc@123");
                    await userManager.CreateAsync(doanhNghiepUser, "Abc@123");
                    await userManager.CreateAsync(ungVienUser, "Abc@123");
                    //await userManager.CreateAsync(ungVienUser1, "Abc@123");
                }
                if (!dbContext.Roles.Any())
                {
                    await dbContext.Roles.AddAsync(new ApplicationRole() { Name = "Admin", NormalizedName = "ADMIN" });
                    await dbContext.Roles.AddAsync(new ApplicationRole() { Name = "DoanhNghiep", NormalizedName = "DOANHNGHIEP" });
                    await dbContext.Roles.AddAsync(new ApplicationRole() { Name = "UngVien", NormalizedName = "UNGVIEN" });
                    //await dbContext.Roles.AddAsync(new ApplicationRole() { Name = "UngVien", NormalizedName = "UNGVIEN" });
                    dbContext.SaveChanges();
                }
                if (!dbContext.UserRoles.Any())
                {
                    var adminUser = await dbContext.Users.FirstOrDefaultAsync(x => x.UserName == "admin@hvitclan.vn");
                    var doanhNghiepUser = await dbContext.Users.FirstOrDefaultAsync(x => x.UserName == "doanhnghiep@hvitclan.vn");
                    var ungVienUser = await dbContext.Users.FirstOrDefaultAsync(x => x.UserName == "ungvien@hvitclan.vn");
                    //var ungVienUser1 = await dbContext.Users.FirstOrDefaultAsync(x => x.UserName == "ungvien1@hvitclan.vn");
                    //var ungVienUser = await dbContext.Users.FirstOrDefaultAsync(x => x.UserName == "ungvien@hvitclan.vn");
                    await userManager.AddToRolesAsync(adminUser, new List<string> { "Admin" });
                    await userManager.AddToRolesAsync(doanhNghiepUser, new List<string> { "DoanhNghiep" });
                    await userManager.AddToRolesAsync(ungVienUser, new List<string> { "UngVien" });
                    //await userManager.AddToRolesAsync(ungVienUser, new List<string> { "UngVien" });
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    dbContext.Database.CloseConnection();
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<AppDbContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(dbContext, userManager, loggerFactory, retryForAvailability);
                }
            }
        }
    }

}
