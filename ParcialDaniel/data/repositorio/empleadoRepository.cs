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
            var db = dbConnection();
            var consulta = @"select * from empleado where idEmpleado=@Id";
            return db.QueryFirstOrDefaultAsync<empleado>(consulta, new { Id = id });
        }

        public Task<IEnumerable<empleado>> getEmpleados()
        {
            var db = dbConnection();
            var consulta = @"select * from empleado";
            return db.QueryAsync<empleado>(consulta);
        }

        public async Task<bool> insertEmpleado(empleado empleado)
        {
            var db = dbConnection();
            var sql = @"insert into empleado(Nombre, Documento) values(@Documento, @Nombre)";
            var result = await db.ExecuteAsync(sql, new { empleado.Nombre, empleado.Documento });
            return result > 0;
        }

        public async Task<bool> updateEmpleado(empleado empleado)
        {
            var db = dbConnection();
            var sql = @"update empleado set
                        Nombre=@Nombre,
                        Documento=@Documento
                        where (idEmpleado=@IdEmpleado)";
            var result = await db.ExecuteAsync(sql, new { empleado.Nombre, empleado.Documento, empleado.idEmpleado });
            return result > 0;
        }
    }
}
