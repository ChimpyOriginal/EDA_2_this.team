using System;
using System.Data;
using System.Data.SqlClient;

namespace ControlEscolar.Datos
{
    public class MaestrosDatos
    {
        public DataTable ObtenerMaestros()
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM Maestros";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public void AgregarMaestro(string nombre, string apellido, string email, string telefono)
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "INSERT INTO Maestros (Nombre, Apellido, Email, Telefono) VALUES (@Nombre, @Apellido, @Email, @Telefono)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Apellido", apellido);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarMaestro(int id, string nombre, string apellido, string email, string telefono)
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "UPDATE Maestros SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Telefono = @Telefono WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Apellido", apellido);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarMaestro(int id)
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "DELETE FROM Maestros WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
