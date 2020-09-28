using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace wings.website.Shared.Models
{
   public class RbacMenuModel
    {
        public long id { get; set; }
        [Required]
        public string text { get; set; }

        public string link { get; set; }

        public long parentId { get; set; }

        public string icon { get; set; }

        

    }
}
