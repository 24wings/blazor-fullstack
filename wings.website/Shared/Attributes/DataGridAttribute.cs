using System;
using System.Collections.Generic;
using System.Text;

namespace wings.website.Shared.Attributes
{
   public class DataGridAttribute:WidgetAttribute
    {
        public string Title { get; set; }
        public override WidhetType widhetType { get; set; } = WidhetType.DataGrid;
    }
}
