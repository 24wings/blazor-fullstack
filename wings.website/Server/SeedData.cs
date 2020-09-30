using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wings.website.Server.Models.Rbac;
using wings.website.Shared.Models;
using wings.website.Shared.Models.Rbac;

namespace wings.website.Server
{
    public static class SeedData
    {
        public static readonly List<RbacMenu> allMenus =
         new List<RbacMenu>
         {
             new RbacMenu{id=1,parentId=0,code="dingding",text="钉钉群信息报表",icon="cloud"},
             new RbacMenu{id=3,parentId=1,code="dingding-report",text="工作台",icon="cloud"},

         };


        /// <summary>
        /// 初始化开发者
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static async Task InitializeDefaultDeveloperResource(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            // 删除数据库
            await context.Database.EnsureDeletedAsync();
            // 确认数据库已经创建
            await context.Database.EnsureCreatedAsync();



            // 创建开发者公司
            await context.companys.AddAsync(new Shared.Models.Company { id = 1, name = "开发者公司", status = CompanyStatus.Approve, code = "developer", description = "负责开发,运维不同公司的业务系统", menuIds = string.Join(",", allMenus.Select(m => m.id)) });
            await context.rbacRoles.AddAsync(new RbacRole { id = 1, name = "开发者",companyId=1, menuIds =string.Join(",",allMenus.Select(m => m.id)) });
            await context.rbacMenus.AddRangeAsync(allMenus);

            if (!await context.Users.AnyAsync())
            {
                var userStore = serviceProvider.GetRequiredService<UserManager<RbacUser>>();
                // 初始化开发者
                var result = await userStore.CreateAsync(new RbacUser { Email = "2121718893@qq.com", UserName = "developer",roleId=1,companyId=1 }, "Shadow2016..");

              
            }
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 初始化开发者公司
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static async Task InitializeDeveloperCompany(IServiceProvider serviceProvider)
        {

        }
    }
}
