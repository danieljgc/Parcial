using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class ventas
    {
        public int idVentas { get; set; }
        public int Cliente_idCliente { get; set; }
        public int Empleado_idEmpleado { get; set; }
        public int Producto_idProducto { get; set; }
    }
}
