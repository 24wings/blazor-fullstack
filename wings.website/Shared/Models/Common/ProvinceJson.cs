using System;
using System.Collections.Generic;
using System.Text;

namespace wings.website.Shared.Models.Common
{
  public  class ProvinceJson
    {
        public string name { get; set; }
        public List<CityJson> city { get; set; }

    }

    public class CityJson
    {
        public string name { get; set; }

        public List<string > area { get; set; }

    }
}
