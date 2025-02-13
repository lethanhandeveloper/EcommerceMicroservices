using EcommerceWebApi.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWebApi.Entities
{
    [Table("tbl_category")]
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> products { get; set; }
        }
}
