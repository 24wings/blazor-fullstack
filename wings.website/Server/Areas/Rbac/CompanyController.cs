using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wings.website.Server.Models.Rbac;
using wings.website.Shared.Models;
using wings.website.Shared.Models.Common;
using wings.website.Shared.Models.Developer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using wings.website.Shared.Models.Rbac;

namespace wings.website.Server.Areas.Rbac
{
    [Route("api/developer/[controller]/[action]")]
    public class CompanyController : ControllerBase
    {
        public readonly ApplicationDbContext applicationDbContext;
        private readonly UserManager<RbacUser> userManager;
        public CompanyController(ApplicationDbContext _applicationDbContext, UserManager<RbacUser> _userManager) { applicationDbContext = _applicationDbContext; userManager = _userManager; }


        [HttpPost]
        public async Task<Paged<Company>> load([FromBody] CompanyQuery companyQuery)
        {
            List<Company> companys;
            if (companyQuery.keywords != null)
            {
                companys = await applicationDbContext.companys.Where(company => company.name.Contains(companyQuery.keywords)).Skip(companyQuery.pageIndex * companyQuery.pageSize).Take(companyQuery.pageSize).ToListAsync();
            }
            else
            {
                companys = await applicationDbContext.companys.Skip(companyQuery.pageIndex * companyQuery.pageSize).Take(companyQuery.pageSize).ToListAsync();
            }
            var total = await applicationDbContext.companys.CountAsync();
            return new Paged<Company> { data = companys, total = total };
        }
        [HttpPost]
        public async Task<object> insert([FromBody] Company company)
        {
            await applicationDbContext.companys.AddAsync(company);
            await applicationDbContext.SaveChangesAsync();
            return new { ok = true };
        }
        [HttpGet]
        public async Task<Company> detail(long id)
        {
            return await applicationDbContext.companys.FirstAsync(company => company.id == id);
        }

        [Authorize]

        [HttpGet]
        public async Task<List<RbacRole>> companyRoles()
        {

            if (User.Identity.IsAuthenticated)
            {
                var rbacUser = await userManager.GetUserAsync(User);
                var roles = await applicationDbContext.rbacRoles.Where(role => role.companyId == rbacUser.companyId).ToListAsync();
                return roles;
            }
            else
            {
                return new List<RbacRole> { };
            }

        }

        [HttpGet]
        public async Task<List<RbacMenu>> companyMenu()
        {

            if (User.Identity.IsAuthenticated)
            {
                var rbacUser = await userManager.GetUserAsync(User);
                var company = await applicationDbContext.companys.Where(company => company.id == rbacUser.companyId).FirstOrDefaultAsync();
                var menuIds= company.menuIds.Split(",");
                 return await applicationDbContext.rbacMenus.Where(menu => menuIds.Contains(menu.id.ToString())).ToListAsync();
            }
            else
            {
                return new List<RbacMenu> { };
            }

        }
    }
}
