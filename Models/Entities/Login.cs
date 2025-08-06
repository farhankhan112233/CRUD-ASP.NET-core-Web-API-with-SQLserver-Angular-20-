using System.ComponentModel.DataAnnotations;

namespace Representational_State_Transfer.Models.Entities
{
    public class Login
    {
        [Required]
        public string username{ get; set; }
        [Required]
        public string password { get; set; }
    }
}
