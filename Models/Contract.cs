using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace AlquilerApp.Models
{
    public class Contract
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public DateTime InitialDate { get; set; }
        [Required]
        public DateTime finishDate { get; set; }
        [Required]
        public int amount { get; set; }
        [Required]
        public List<Fee> Fees { get; set; }


        [ForeignKey("Department")]
        public long DepartmentId { get; set; }
        [ForeignKey("Renter")]
        public long RenterId { get; set; }
    }
}