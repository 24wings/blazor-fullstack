using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wings.website.Server.Models.Rbac
{
    public class RbacUser:IdentityUser
    {
        public string nickname { get; set; }

        public long companyId { get; set; }

        public long roleId { get; set; }
    }
}
