using System;
using System.Collections.Generic;
using System.Text;

namespace wings.website.Shared.Models.Common
{
   public class Paged<T>
    {
        public List<T> data { get; set; }
        public long total { get; set; }
    }
}
