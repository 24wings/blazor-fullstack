using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wings.website.Shared.Models.Common;
using wings.website.Shared.Models.Rbac;

namespace wings.website.Client.Services
{
    public class UserService
    {
        private readonly ConfigService configService;
        private readonly HttpClient httpClient;
        public UserService(HttpClient _httpClient, ConfigService _configService) { httpClient = _httpClient; configService = _configService; }

       public async Task<RbacUserModel> currentUser()
        {
                var rtn = await httpClient.GetJsonAsync<RbacUserModel>(configService.url + "/api/rbac/user/currentUser");
                return rtn;
        }
        public async Task<Res> updateUser(RbacUserModel rbacUserModel)
        {
            var rtn = await httpClient.PostJsonAsync<Res>(configService.url + "/api/rbac/user/updateUser",rbacUserModel);
            return rtn;
        }
    }
}
