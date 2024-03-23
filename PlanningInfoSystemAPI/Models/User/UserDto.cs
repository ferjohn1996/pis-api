using System.ComponentModel.DataAnnotations;

namespace PlanningInfoSystemAPI.Models.User
{
    public class UserTblDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
