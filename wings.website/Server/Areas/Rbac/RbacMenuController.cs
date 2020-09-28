using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wings.website.Server.Models.Rbac;
using wings.website.Shared.Models;

namespace wings.website.Server.Areas.Rbac
{
    [Route("api/[controller]/[action]")]
    public class RbacMenuController
    {
        public readonly ApplicationDbContext applicationDbContext;
        public RbacMenuController(ApplicationDbContext _applicationDbContext) { applicationDbContext = _applicationDbContext; }

        [HttpGet]
        public async Task<object> load()
        {
           var rtn= await applicationDbContext.rbacMenus.ToListAsync();

            return rtn;
        }
        [HttpPost]
        public async Task<object> insert([FromBody] RbacMenuModel rbacMenuModel)
        {
           await applicationDbContext.rbacMenus.AddAsync(new RbacMenu {link=rbacMenuModel.link ,text=rbacMenuModel.text,icon=rbacMenuModel.icon,parentId=rbacMenuModel.parentId});
            await applicationDbContext.SaveChangesAsync();
            return new { ok = true };
        }

        [HttpGet]

        public async Task<RbacMenuModel> detail(long id)
        {
            return await applicationDbContext.rbacMenus.Select(item => new RbacMenuModel { id=item.id,link=item.link,text=item.text,icon=item.icon,parentId=item.parentId}).FirstAsync(menu => menu.id == id);
        }
    }
}
