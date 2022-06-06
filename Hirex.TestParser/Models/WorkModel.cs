using System;
using System.Collections.Generic;
using System.Text;

namespace Hirex.TestParser.Models
{
    public class WorkModel
    {
        public string WorkName { get; set; }

        public string WorkLink { get; set; }

        public virtual ICollection<DesignerModel> Designers { get; set; }
        public WorkModel()
        {
            Designers = new List<DesignerModel>();
        }
    }
}
