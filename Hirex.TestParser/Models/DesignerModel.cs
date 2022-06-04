using System;
using System.Collections.Generic;
using System.Text;

namespace Hirex.TestParser.Models
{
    public class DesignerModel
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public virtual ICollection<WorkModel> Works { get; set; }
        public DesignerModel()
        {
            Works = new List<WorkModel>();
        }
    }
}
