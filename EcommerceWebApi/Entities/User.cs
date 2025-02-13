using EcommerceWebApi.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWebApi.Entities
{
    [Table("tbl_user")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
