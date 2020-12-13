using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CMS.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CMS.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class ConfirmLogoutModel : PageModel
    {

        public ConfirmLogoutModel()
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
