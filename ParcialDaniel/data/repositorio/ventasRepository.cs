using Dapper;
using model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public class ventasRepository : iVentasRepository
    {
        public readonly mysqlConfig _connection;
        public ventasRepository(mysqlConfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }
        public async Task<bool> insertVentas(ventas ventas)
        {
            var db = dbConnection();
            var sql = @"insert into ventas(idVentas, Cliente_idCliente, Empleado_idEmpleado, Producto_idProducto) values (@idVentas, @Cliente_idCliente, @Empleado_idEmpleado, @Producto_idProducto)";
            var result = await db.ExecuteAsync(sql, new { ventas.idVentas, ventas.Cliente_idCliente, ventas.Empleado_idEmpleado, ventas.Producto_idProducto });
            return result > 0;
        }
    }
}
