using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCProyectoPersAPP.Models
{
    internal class DCBebida
    {
        public int DC_BebidaID { get; set; }
        public string? DC_Nombre { get; set; }
        public decimal DC_Precio { get; set; }
        public string? DC_Tipo { get; set; }
    }
}
