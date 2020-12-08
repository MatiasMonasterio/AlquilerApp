using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlquilerApp.Models
{
    public class Contract
    {
        [Key]
        [ForeignKey("Lessee")]
        public long LesseeId { get; set; }
        public Lessee Lessee { get; set; }

        [Key]
        [ForeignKey("Department")]
        public long DepartmentId { get; set; }
        public Department Department { get; set; }
        

        [ForeignKey("Renter")]
        public long RenterId { get; set; }
        [Required]
        public Renter Renter { get; set; }

        public DateTime InitialDate { get; set; }
    }
}