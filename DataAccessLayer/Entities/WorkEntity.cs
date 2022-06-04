using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class WorkEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int DesignerId { get; set; }

        public string WorkName { get; set; }

        public string WorkLink { get; set; }

        public virtual ICollection<DesignerEntity> Designers { get; set; }
        public WorkEntity()
        {
            Designers = new List<DesignerEntity>();
        }
    }
}
