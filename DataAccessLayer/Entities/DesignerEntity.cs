using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class DesignerEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public virtual ICollection<WorkEntity> Works { get; set; }
        public DesignerEntity()
        {
            Works = new List<WorkEntity>();
        }
    }
}
