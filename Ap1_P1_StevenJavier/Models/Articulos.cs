using System.ComponentModel.DataAnnotations;

namespace Ap1_P1_StevenJavier.Models
{
    public class Articulos
    {
        [Key]
        public int ArticulosId { get; set; }

        [Required(ErrorMessage = "Nombre del artículo necesario.")]
        public string? Descripcion { get; set; }
        
        [Required(ErrorMessage = "Valor necesario.")]
        [Range(0.1, 1000000, ErrorMessage = "Número no permitido.")]
        public double Costo { get; set; }
        
        [Required(ErrorMessage = "Valor necesario.")]
        [Range(0.1, 1000000, ErrorMessage = "Número no permitido.")]
        public double Ganancia { get; set; }

        public double Precio { get; set; }
    }
}
