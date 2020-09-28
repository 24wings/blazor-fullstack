using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wings.website.Server.Models.Rbac;
using wings.website.Shared.Models;

namespace wings.website.Server
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<RbacMenu> rbacMenus { get; set; }
        public DbSet<Company> companys { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
