using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace AlquilerApp.Models
{
    public class Fee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Key]
        [ForeignKey("Contract")]
        public long ContractId { get; set; }

        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime EmitDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public DateTime PaymentDate { get; set; }
        [Required]
        public bool Sign { get; set; }
        public double ExpiryAmount { get; set; }

        public List<AditionalAmount> AditionalAmounts { get; set; }
    }
}