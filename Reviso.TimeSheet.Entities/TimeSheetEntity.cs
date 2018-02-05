using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reviso.TimeSheet.Entities
{
    [Table("TimeSheet")]
    public class TimeSheetEntity
    {
        [Key]
        [Column("TimeSheetId")]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string TaskDescription { get; set; }
        public short RegularHours { get; set; }
        public short OverTimeHours { get; set; }

        // Foreign key for Customer 
        [ForeignKey("CustomerId")]
        public virtual CustomerEntity Customer { get; set; }
        public virtual int CustomerId { get; set; }

        // Foreign key for Project
        [ForeignKey("ProjectId")]
        public virtual ProjectEntity Project { get; set; }
        public virtual int ProjectId { get; set; }

    }
}