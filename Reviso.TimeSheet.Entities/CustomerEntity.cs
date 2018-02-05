using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reviso.TimeSheet.Entities
{
    [Table("Customer")]
    public class CustomerEntity
    {
        [Key]
        [Column("CustomerId")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

    }
}