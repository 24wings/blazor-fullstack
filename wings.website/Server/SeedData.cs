﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wings.website.Server.Models.Rbac;
using wings.website.Shared.Models;
using wings.website.Shared.Models.Developer;
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
             new RbacMenu{id=200,parentId=0,code="rbac",text="角色权限",icon="cloud"},
             new RbacMenu{id=201,parentId=200,code="role",text="角色管理",icon="cloud",link="/rbac/role"},
             new RbacMenu{id=202,parentId=200,code="menu",text="菜单管理",icon="cloud",link="/rbac/menu"},
             new RbacMenu{id=300,parentId=0,code="person-center",text="个人中心",icon="cloud"},
             new RbacMenu{id=301,parentId=300,code="person-summary",text="个人简介",icon="cloud",link="/per-center/person-summary"},
             new RbacMenu{id=302,parentId=300,code="person-setting",text="个人设置",icon="cloud",link="/person-center/user-setting"},
             new RbacMenu{id=400,parentId=0,code="developer",text="开发者",icon="cloud"},
             new RbacMenu{id=401,parentId=300,code="company-manage",text="公司管理",icon="cloud",link="/developer/company-manage"},
                       new RbacMenu{id=402,parentId=300,code="developer-codegen",text="开发者代码生成",icon="cloud",link="/developer/codegen"}

         };
        public static readonly List<RbacMenu> dingdingMenus =
        new List<RbacMenu>
        {
             new RbacMenu{id=1,parentId=0,code="dingding",text="钉钉群信息报表",icon="cloud"},
             new RbacMenu{id=3,parentId=1,code="dingding-report",text="工作台",icon="cloud"},
             new RbacMenu{id=200,parentId=0,code="rbac",text="角色权限",icon="cloud"},
             new RbacMenu{id=201,parentId=200,code="role",text="角色管理",icon="cloud",link="/rbac/role"},
             new RbacMenu{id=202,parentId=200,code="menu",text="菜单管理",icon="cloud",link="/rbac/menu"},
             new RbacMenu{id=300,parentId=0,code="person-center",text="个人中心",icon="cloud"},
             new RbacMenu{id=301,parentId=300,code="person-summary",text="个人简介",icon="cloud",link="/per-center/person-summary"},
             new RbacMenu{id=302,parentId=300,code="person-setting",text="个人设置",icon="cloud",link="/person-center/user-setting"},
        
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
            await context.companys.AddAsync(new Company { id = 1, name = "开发者公司", status = CompanyStatus.Approve, code = "developer", description = "负责开发,运维不同公司的业务系统", menuIds = string.Join(",", allMenus.Select(m => m.id)) });
            await context.rbacRoles.AddAsync(new RbacRole { id = 1, name = "开发者",companyId=1, menuIds =string.Join(",",allMenus.Select(m => m.id)) });
            await context.rbacMenus.AddRangeAsync(allMenus);

            // 创建丁丁公司
            await context.companys.AddAsync(new Company { id = 2, name = "钉钉公司", status = CompanyStatus.Approve, code = "dingding", description = "钉钉群扫描", menuIds = string.Join(",", dingdingMenus.Select(m => m.id)) });
            await context.rbacRoles.AddAsync(new RbacRole { id = 200, name = "钉钉管理员", companyId = 2, menuIds = string.Join(",", dingdingMenus.Select(m => m.id)) });

            if (!await context.Users.AnyAsync())
            {
                var userStore = serviceProvider.GetRequiredService<UserManager<RbacUser>>();
                // 初始化开发者
                var result = await userStore.CreateAsync(new RbacUser { Email = "developer", UserName = "developer",roleId=1,companyId=1 }, "Shadow2016..");
                var result2 = await userStore.CreateAsync(new RbacUser { Email = "dingding", UserName = "dingding", roleId = 200, companyId = 2 }, "Dingding1234..");


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
