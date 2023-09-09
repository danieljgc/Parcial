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
    public class empleadoRepository : iEmpleadoRepository
    {
        public readonly mysqlConfig _connection;
        public empleadoRepository(mysqlConfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }

        public Task<bool> deleteEmpleado(int id)
        {
            throw new NotImplementedException();
        }

        public Task<empleado> getEmpleadoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<empleado>> getEmpleados()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> insertEmpleado(empleado empleado)
        {
            var db = dbConnection();
            var sql = @"insert into empleado(Nombre, Documento) values(@Documento, @Nombre)";
            var result = await db.ExecuteAsync(sql, new { empleado.Nombre, empleado.Documento });
            return result > 0;
        }

        public Task<bool> updateEmpleado(empleado empleado)
        {
            throw new NotImplementedException();
        }
    }
}
