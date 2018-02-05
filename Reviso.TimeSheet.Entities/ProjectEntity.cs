using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reviso.TimeSheet.Entities
{
    [Table("Project")]
    public class ProjectEntity
    {
        [Key]
        [Column("ProjectId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}