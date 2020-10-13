using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
    public class ApplicationDbContext : IdentityDbContext<RbacUser>
    {
        //public DbSet<RbacUser> rbacUsers { get; set; }
        public DbSet<RbacMenu> rbacMenus { get; set; }

        public DbSet<RbacRole> rbacRoles { get; set; }
        public DbSet<Company> companys { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
