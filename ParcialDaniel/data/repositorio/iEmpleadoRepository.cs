using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public interface iEmpleadoRepository
    {
        Task<IEnumerable<empleado>> getEmpleados();
        Task<empleado> getEmpleadoById(int id);
        Task<bool> insertEmpleado(empleado empleado);
        Task<bool> updateEmpleado(empleado empleado);
        Task<bool> deleteEmpleado(int id);
    }
}
