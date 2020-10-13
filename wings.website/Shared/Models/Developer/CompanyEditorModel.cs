using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using wings.website.Shared.Attributes;

namespace wings.website.Shared.Models.Developer
{
    [EditorPage]
    public class CompanyEditorModel
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
