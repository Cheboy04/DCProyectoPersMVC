using System.ComponentModel.DataAnnotations;

namespace DCProyectoPersMVC.Models
{
    public enum DC_Tipo
    {
        RON,
        WHISKY,
        VODKA,
        TEQUILA
    }
    public class DCBebida
    {
        [Key]
        public int DC_BebidaID {  get; set; }
        [Required]
        public string? DC_Nombre { get; set; }
        [Range(0.01, 1000.00)]
        public decimal DC_Precio {  get; set; }
        public DC_Tipo DC_Tipo { get; set; }

    }
}
