using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wings.Ui.Core.Grids
{
    public class DataGridAttribute:Attribute
    {
        public string title { get; set; }
        public DataGridAttribute(string _title)
        {
            title = _title;
        }
    }
}
