using Datos;
using System.Data.SqlClient;

namespace Negocio
{
    public class EmpleadoService
    {
        EmpleadoRepository repo = new EmpleadoRepository();

        public void Registrar(string cedula, string nombre, string apellido, string cargo, decimal salario)
        {
            repo.Insertar(cedula, nombre, apellido, cargo, salario);
        }

        public SqlDataReader Buscar(string cedula)
        {
            return repo.BuscarPorCedula(cedula);
        }

        public SqlDataReader Listar()
        {
            return repo.Listar();
        }

        public void Actualizar(string cedula, string nombre, string apellido, string cargo, decimal salario)
        {
            repo.Actualizar(cedula, nombre, apellido, cargo, salario);
        }

        public void Eliminar(string cedula)
        {
            repo.Eliminar(cedula);
        }
    }
}
