using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Project.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public decimal ProdPrice { get; set; }
        public string ProdCompanyName { get; set; }
        public int CartId { get; internal set; }
        public int UserId { get; internal set; }
    }
}
