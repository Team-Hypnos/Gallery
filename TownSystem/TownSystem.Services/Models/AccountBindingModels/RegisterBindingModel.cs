namespace TownSystem.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }

        [MinLength(4)]
        [MaxLength(50)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [MinLength(4)]
        [MaxLength(50)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        //[Required]
        //[MinLength(4)]
        //[MaxLength(50)]
        //[Display(Name = "Username")]
        //public string Username { get; set; }
    }
}