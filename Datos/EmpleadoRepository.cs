using System.Data.SqlClient;

namespace Datos
{
    public class EmpleadoRepository
    {
        // 1. Registrar
        public void Insertar(string cedula, string nombre, string apellido, string cargo, decimal salario)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Empleados VALUES (@Cedula,@Nombre,@Apellido,@Cargo,@Salario,GETDATE())", cn);

                cmd.Parameters.AddWithValue("@Cedula", cedula);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@Cargo", cargo);
                cmd.Parameters.AddWithValue("@Salario", salario);

                cmd.ExecuteNonQuery();
            }
        }

        // 2. Buscar por cédula
        public SqlDataReader BuscarPorCedula(string cedula)
        {
            SqlConnection cn = Conexion.ObtenerConexion();
            cn.Open();

            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Empleados WHERE Cedula = @Cedula", cn);
            cmd.Parameters.AddWithValue("@Cedula", cedula);

            return cmd.ExecuteReader();
        }

        // 3. Listar todos
        public SqlDataReader Listar()
        {
            SqlConnection cn = Conexion.ObtenerConexion();
            cn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Empleados", cn);
            return cmd.ExecuteReader();
        }

        // 4. Actualizar
        public void Actualizar(string cedula, string nombre, string apellido, string cargo, decimal salario)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE Empleados 
                      SET Nombre=@Nombre, Apellido=@Apellido, Cargo=@Cargo, Salario=@Salario
                      WHERE Cedula=@Cedula", cn);

                cmd.Parameters.AddWithValue("@Cedula", cedula);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@Cargo", cargo);
                cmd.Parameters.AddWithValue("@Salario", salario);

                cmd.ExecuteNonQuery();
            }
        }

        // 5. Eliminar
        public void Eliminar(string cedula)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Empleados WHERE Cedula=@Cedula", cn);
                cmd.Parameters.AddWithValue("@Cedula", cedula);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
