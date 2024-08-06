using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dao
{
    public interface IVehiculo
    {
        Respuesta Insertar(Vehiculo model);
        Respuesta Actualizar(Vehiculo model);
        int Eliminar(Vehiculo model);

        List<Vehiculo> Consultar(int id);
    }
}
