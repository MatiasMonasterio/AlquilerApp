using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlquilerApp.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public string provincia { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public bool state { get; set; }
        public string description { get; set; }


        [Required]
        [ForeignKey("Lessee")]
        public long LesseeId { get; set; }
    }
}