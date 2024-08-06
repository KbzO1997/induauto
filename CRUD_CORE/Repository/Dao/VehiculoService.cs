using Repository.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dao
{
    public class VehiculoService : Conexion.Conexion, IVehiculo
    {

        public VehiculoService(string connectionString) { }


        public Respuesta Insertar(Vehiculo model)
        {
            var respuesta = new Respuesta();
            try
            {
                using (var cmd = new SqlCommand("sp_insertarVehiculo", Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo", model.codigo);
                    cmd.Parameters.AddWithValue("@chasis", model.chasis);
                    cmd.Parameters.AddWithValue("@marca", model.marca);
                    cmd.Parameters.AddWithValue("@modelo", model.modelo);
                    cmd.Parameters.AddWithValue("@anio_modelo", model.anio_modelo);
                    cmd.Parameters.AddWithValue("@color", model.color);
                    cmd.Parameters.AddWithValue("@estado", model.estado);
                    cmd.Parameters.AddWithValue("@fecha_registro", model.fecha_registro);
                    cmd.ExecuteNonQuery();
                    respuesta.Exitoso = true;
                    respuesta.Mensaje = "Vehículo insertado con éxito.";
                }
            }
            catch (Exception ex)
            {
                respuesta.Exitoso = false;
                respuesta.Mensaje = $"Error al insertar vehículo: {ex.Message}";
            }
            return respuesta;
        }

        public Respuesta Actualizar(Vehiculo model)
        {
            var respuesta = new Respuesta();
            try
            {
                using (var cmd = new SqlCommand("sp_actualizarVehiculo", Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", model.id);
                    cmd.Parameters.AddWithValue("@codigo", model.codigo);
                    cmd.Parameters.AddWithValue("@chasis", model.chasis);
                    cmd.Parameters.AddWithValue("@marca", model.marca);
                    cmd.Parameters.AddWithValue("@modelo", model.modelo);
                    cmd.Parameters.AddWithValue("@anio_modelo", model.anio_modelo);
                    cmd.Parameters.AddWithValue("@color", model.color);
                    cmd.Parameters.AddWithValue("@estado", model.estado);
                    cmd.Parameters.AddWithValue("@fecha_registro", model.fecha_registro);

                    cmd.ExecuteNonQuery();
                    respuesta.Exitoso = true;
                    respuesta.Mensaje = "Vehículo actualizado con éxito.";
                }
            }
            catch (Exception ex)
            {
                respuesta.Exitoso = false;
                respuesta.Mensaje = $"Error al actualizar vehículo: {ex.Message}";
            }
            return respuesta;
        }

        public int Eliminar(Vehiculo model)
        {
            try
            {
                using (var cmd = new SqlCommand("sp_eliminarVehiculo", Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", model.id);

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar vehículo: {ex.Message}");
                return -1; // Indica error
            }
        }

        public List<Vehiculo> Consultar(int id)
        {
            var vehiculos = new List<Vehiculo>();
            try
            {
                using (var cmd = new SqlCommand("sp_consultarVehiculo", Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var vehiculo = new Vehiculo
                            {
                                id = reader.GetInt32(reader.GetOrdinal("id")),
                                codigo = reader.GetString(reader.GetOrdinal("codigo")),
                                chasis = reader.GetString(reader.GetOrdinal("chasis")),
                                marca = reader.GetString(reader.GetOrdinal("marca")),
                                modelo = reader.GetString(reader.GetOrdinal("modelo")),
                                anio_modelo = reader.GetInt32(reader.GetOrdinal("anio_modelo")),
                                color = reader.GetString(reader.GetOrdinal("color")),
                                estado = reader.GetString(reader.GetOrdinal("estado")),
                                fecha_registro = reader.GetDateTime(reader.GetOrdinal("fecha_registro"))
                            };

                            vehiculos.Add(vehiculo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar vehículos: {ex.Message}");
            }
            return vehiculos;
        }
    }
}
