using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wings.website.Shared.Models.Rbac
{
    public class RbacRole
    {
        [Key]
        public long id { get; set; }

        public string menuIds { get; set; }

        public string name { get; set; }

        public string code { get; set; }

        public DateTime createAt { get; set; } = DateTime.Now;

        public long companyId { get; set; }

    }
}
