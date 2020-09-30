using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wings.website.Server.Models.Rbac
{
    public class RbacMenu
    {
        [Key]
        public long id { get; set; }
        public string text { get; set; }

        public string link { get; set; }
        public string icon { get; set; }
        public long parentId { get; set; }

        public DateTime createAt { get; set; } = DateTime.Now;

        public string code { get; set; }
        

    }
}
