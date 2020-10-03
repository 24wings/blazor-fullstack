using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wings.website.Server.Models.Rbac;
using wings.website.Shared.Models.Rbac;

namespace wings.website.Server.Areas.Rbac
{

    [Route("api/rbac/[Controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<RbacUser> userManager;
        private readonly ApplicationDbContext applicationDbContext;

        public UserController(UserManager<RbacUser> _userManager, ApplicationDbContext _applicationDbContext)
        {
            userManager = _userManager;
            applicationDbContext = _applicationDbContext;
        }
        [Authorize]
        [HttpGet]
        public async Task<RbacUser> currentUser()
        {
            return await userManager.FindByNameAsync(User.Identity.Name);
        }
        [Authorize]
        [HttpPost]
        public async Task<object> updateUser([FromBody] RbacUserModel data)
        {
            var rbacuser = await userManager.FindByNameAsync(User.Identity.Name);
            rbacuser.nickname = data.nickname;
            rbacuser.Summary = data.Summary;
            rbacuser.Address = data.Address;
            rbacuser.City = data.City;
            rbacuser.Province = data.Province;
            rbacuser.Country = data.Country;
            rbacuser.Sign = data.Sign;
            await userManager.UpdateAsync(rbacuser);
            await applicationDbContext.SaveChangesAsync();
            return new { ok = true, msg = "更新成功" };

        }

        /// <summary>
        /// 获取用户的菜单
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<List<RbacMenu>> userMenus()
        {
            var rbacuser = await userManager.FindByNameAsync(User.Identity.Name);
            var role = await applicationDbContext.rbacRoles.FirstAsync(role => role.id == rbacuser.roleId);
            var menuIds = role.menuIds.Split(",").Select(id => long.Parse(id));
            return await applicationDbContext.rbacMenus.Where(menu => menuIds.Contains(menu.id)).ToListAsync();            
        }
    }
}
