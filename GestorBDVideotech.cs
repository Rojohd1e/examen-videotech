// Ejercicio 3
using MySql.Data.MySqlClient;
using System.Collections.Generic;

public class GestorBD
{
    private MySqlConnection conexion;

    public GestorBD()
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        builder.Server = "localhost";
        builder.UserID = "root";
        builder.Password = "";
        builder.Database = "videotech";

        conexion = new MySqlConnection(builder.ToString());
    }

    public void Insertar(Pelicula p)
    {
        conexion.Open();
        string sql = "INSERT INTO pelicula (titulo, director, anyo, disponible) VALUES (@titulo, @director, @anyo, @disponible)";
        MySqlCommand comando = new MySqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@titulo", p.getTitulo());
        comando.Parameters.AddWithValue("@director", p.getDirector());
        comando.Parameters.AddWithValue("@anyo", p.getAnyo());
        comando.Parameters.AddWithValue("@disponible", p.isDisponible());
        comando.ExecuteNonQuery();
        conexion.Close();
    }

    public List<Pelicula> ObtenerTodos()
    {
        List<Pelicula> lista = new List<Pelicula>();
        conexion.Open();
        MySqlCommand comando = new MySqlCommand("SELECT * FROM pelicula", conexion);
        MySqlDataReader lector = comando.ExecuteReader();
        while (lector.Read())
        {
            string titulo = lector["titulo"].ToString();
            string director = lector["director"].ToString();
            int anyo = Convert.ToInt32(lector["anyo"]);
            bool disponible = Convert.ToBoolean(lector["disponible"]);
            lista.Add(new Pelicula(titulo, director, anyo, disponible));
        }
        lector.Close();
        conexion.Close();
        return lista;
    }
}
