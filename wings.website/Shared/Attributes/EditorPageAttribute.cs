using System;
using System.Collections.Generic;
using System.Text;

namespace wings.website.Shared.Attributes
{
   public class EditorPageAttribute:WidgetAttribute
    {
        public override WidhetType widhetType { get; set; } = WidhetType.EditorPage;
    }
}
