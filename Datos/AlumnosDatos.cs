using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ControlEscolar.Datos
{
    public class AlumnosDatos
    {
        public DataTable ObtenerAlumnos()
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM Alumnos";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public void AgregarAlumno(string nombre, string apellido, string matricula, int carreraId, DateTime fechaNacimiento)
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "INSERT INTO Alumnos (Nombre, Apellido, Matricula, CarreraId, FechaNacimiento) VALUES (@Nombre, @Apellido, @Matricula, @CarreraId, @FechaNacimiento)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Apellido", apellido);
                    cmd.Parameters.AddWithValue("@Matricula", matricula);
                    cmd.Parameters.AddWithValue("@CarreraId", carreraId);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarAlumno(int id, string nombre, string apellido, string matricula, int carreraId, DateTime fechaNacimiento)
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "UPDATE Alumnos SET Nombre = @Nombre, Apellido = @Apellido, Matricula = @Matricula, CarreraId = @CarreraId, FechaNacimiento = @FechaNacimiento WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Apellido", apellido);
                    cmd.Parameters.AddWithValue("@Matricula", matricula);
                    cmd.Parameters.AddWithValue("@CarreraId", carreraId);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarAlumno(int id)
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "DELETE FROM Alumnos WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
