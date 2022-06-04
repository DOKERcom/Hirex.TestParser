using System;
using System.Collections.Generic;
using System.Text;

namespace Hirex.TestParser.Models
{
    public class WorkModel
    {
        public int DesignerId { get; set; }

        public string WorkName { get; set; }

        public string WorkLink { get; set; }

        public virtual ICollection<DesignerModel> Designers { get; set; }
        public WorkModel()
        {
            Designers = new List<DesignerModel>();
        }
    }
}
