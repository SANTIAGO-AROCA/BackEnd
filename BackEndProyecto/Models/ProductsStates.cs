using System.ComponentModel.DataAnnotations;

namespace BackEndProyecto.Models
{
    public class ProductsStates
    {
        [Key]
        public required int ProductStateId { get; set; }
        public required string ProductStateName { get; set; }
        public string ProductStateDescription { get; set; }
    }
}
