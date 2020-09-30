using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using wings.website.Shared.Models;
using wings.website.Shared.Models.Common;
using wings.website.Shared.Models.Developer;
using wings.website.Shared.Models.Rbac;

namespace wings.website.Client.Services
{
    public class CompanyService
    {
        private readonly ConfigService configService;
        private readonly HttpClient httpClient;
        public async Task<Paged<Company>> load(CompanyQuery companyQuery)
        {
           return await httpClient.PostJsonAsync<Paged<Company>>(configService.url + "/api/developer/company/load", companyQuery);
          
        }

        public async Task<object> insert(Company company)
        {
            return await httpClient.PostJsonAsync<object>(configService.url + "/api/developer/company/insert", company);
        }
        public async Task<Company> detailById(long id)
        {
            return await httpClient.GetJsonAsync<Company>(configService.url + "/api/developer/company/detail?id=" + id);
        }


        public async Task<List<RbacRole>> loadCompanyDetail()
        {
            return await httpClient.GetJsonAsync<List< RbacRole>>(configService.url + "/api/developer/company/companyRoles");
        }



        public CompanyService(ConfigService _configService, HttpClient _httpClient)
        {
            configService = _configService;
            httpClient = _httpClient;

        }



    }
}
