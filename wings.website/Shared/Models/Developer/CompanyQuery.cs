using System;
using System.Collections.Generic;
using System.Text;

namespace wings.website.Shared.Models.Developer
{
   public  class CompanyQuery
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
       public string keywords { get; set; }
    }
}
