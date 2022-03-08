using System.ComponentModel.DataAnnotations;

namespace ContactControl.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter contact name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter contact email")]
        [EmailAddress(ErrorMessage = "This email is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter contact telephone")]
        [Phone(ErrorMessage = "This telephone is not valid")]
        public string Telephone { get; set; }
    }
}
