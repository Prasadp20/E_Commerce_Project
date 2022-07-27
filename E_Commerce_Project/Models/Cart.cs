using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Project.Models
{
    [Table("ViewCart")]
    public class Cart
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public decimal ProdPrice { get; set; }
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int Quntity { get; set; }

    }
}
