using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlquilerApp.Models
{
    public class AditionalAmount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double amount { get; set; }


        [Required]
        [ForeignKey("Fee")]
        public long FeeId { get; set; }
    }
}