using CrudLoginSignup.Models.product;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CrudLoginSignup.Models.user
{
    public class User: IdentityUser
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Product> product { get; set; }
    }
}
