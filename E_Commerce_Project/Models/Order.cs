using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Project.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public decimal Price { get; set; }
        public int Quntity { get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }
    }
}
