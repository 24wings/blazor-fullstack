using System;
using System.Collections.Generic;
using System.Text;

namespace wings.website.Shared.Models.Rbac
{
    public class RbacUserModel
    {
        public string Email { get; set; }

        public string nickname { get; set; }

        public long companyId { get; set; }

        public long roleId { get; set; }

        public string Sign { get; set; }
        public string Summary { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }

        public string Province { get; set; }
        public string City { get; set; }

        public string AvatarUrl { get; set; }

    }
}
