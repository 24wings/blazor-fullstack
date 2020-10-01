using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wings.website.Server.Models.Rbac;

namespace wings.website.Server.Areas.Rbac
{

    [Route("api/rbac/[Controller]/[action]")]
    public class UserController: ControllerBase
    {
        private readonly UserManager<RbacUser> userManager;

        public UserController(UserManager<RbacUser> _userManager)
        {
            userManager = _userManager;
        }
        [Authorize]
        [HttpGet]
        public async Task<RbacUser> currentUser()
        {
            return await userManager.FindByNameAsync(User.Identity.Name);
        }
    }
}
