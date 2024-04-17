using CrudLoginSignup.Models.user;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudLoginSignup.Models.product
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
       
        public string UID { get; set; }
        [ForeignKey("UID")]
        public User User { get; set; }

    }
}
