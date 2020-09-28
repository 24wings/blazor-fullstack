using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wings.website.Shared.Models;
using wings.website.Shared.Models.Common;
using wings.website.Shared.Models.Developer;

namespace wings.website.Server.Areas
{
    [Route("api/[controller]/[action]")]
    public class CompanyController
    {
        public readonly ApplicationDbContext applicationDbContext;
        public CompanyController(ApplicationDbContext _applicationDbContext) { applicationDbContext = _applicationDbContext; }


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
                companys = await applicationDbContext.companys.Where(company => company.name.Contains(companyQuery.keywords)).Skip(companyQuery.pageIndex * companyQuery.pageSize).Take(companyQuery.pageSize).ToListAsync();
            }
            var total = await applicationDbContext.companys.CountAsync();
            return new Paged<Company> { data = companys, total = total };
        }

        //public async Task<>
    }
}
