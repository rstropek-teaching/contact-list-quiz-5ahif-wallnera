using System.ComponentModel.DataAnnotations;

namespace ASPContactsMVC.Models
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Prename Required")]
        [Display(Name ="Prename")]
        [StringLength (50)]
        public string Prename { get; set; }

        [Required(ErrorMessage = "Surname Required")]
        [Display(Name = "Surname")]
        [StringLength(50)]
        public string Surname { get; set; }

        [Display(Name = "Email")]
        [StringLength(120)]
        public string Email { get; set; }
    }
}