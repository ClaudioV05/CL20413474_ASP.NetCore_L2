using System.ComponentModel.DataAnnotations;

namespace Store.Management.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int SubCategoryID { get; set; }
    }
}
