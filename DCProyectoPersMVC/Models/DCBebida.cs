using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [EnumDataType(typeof(DC_Tipo))]
        [Column(TypeName = "nvarchar(20)")]
        public string? DC_Tipo { get; set; }


    }
}
