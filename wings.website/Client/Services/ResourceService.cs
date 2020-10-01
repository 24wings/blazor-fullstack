using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wings.website.Shared.Models.Common;

namespace wings.website.Client.Services
{

    public class ResourceService
    {
        private readonly ConfigService configService;
        private readonly HttpClient httpClient;

        public ResourceService(ConfigService _configService,HttpClient _httpClient)
        {
            configService = _configService;
            httpClient = _httpClient;

        }

        public  async    Task<List<ProvinceJson>> loadProvinceJson()
        {
            return await httpClient.GetJsonAsync<List<ProvinceJson>>("/city.json");
        }

    }
}
