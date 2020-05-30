using System.ComponentModel.DataAnnotations;

namespace Zedx.Models.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}