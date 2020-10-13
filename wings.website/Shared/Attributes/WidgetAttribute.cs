using System;
using System.Collections.Generic;
using System.Text;

namespace wings.website.Shared.Attributes
{
  public   class WidgetAttribute:Attribute
    {
        public virtual WidhetType widhetType { get; set; }
       
    }

    public enum WidhetType
    {
        DataGrid,
        QueryToolbar,
        EditorPage,
        EditorModel
    }
}
