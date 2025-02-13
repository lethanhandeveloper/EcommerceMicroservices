using EcommerceWebApi.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWebApi.Entities
{
    [Table("tbl_order")]
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}
