using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlquilerApp.Models
{
    public class Renter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        public string Telephone { get; set; }
        [Required]
        public string Password { get; set; }


        // Configuraciones, no estoy seguro de dejarlas aca
        [Required]
        [DefaultValue("true")]
        public bool Theme { get; set; }
        [Required]
        [DefaultValue("false")]
        public bool FeeEmitAlert { get; set; }
        [Required]
        [DefaultValue("true")]
        public bool FeeOverdueAlert { get; set; }
        [Required]
        [DefaultValue("true")]
        public bool PaymentTicket { get; set; } 

    }
}