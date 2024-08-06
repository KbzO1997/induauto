using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Conexion
{
    public class Conexion : IDisposable
    {
        private SqlConnection _conection;
        private string conexionDB = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=K_Bastidas_CRUD_BD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private string conexionDB = @"Data Source=192.168.30.5;Initial Catalog=K_Bastidas_CRUD_BD;User ID=desarrollo;Password=Desa1234+$;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Conexion()
        {
            Connect();
        }

        public void Connect()
        {
            try
            {
                _conection = new SqlConnection(conexionDB);
                _conection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                throw;
            }
        }

        public void desconectar()
        {
            if (conexionDB != null || _conection.State == System.Data.ConnectionState.Open)
            {
                _conection.Close();
            }
        }

        public SqlConnection Connection
        {
            get { return _conection; }
        }

        public void Dispose()
        {
            desconectar();
            _conection?.Dispose();
        }

    }
}
