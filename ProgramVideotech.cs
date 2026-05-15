// Ejercicio 2
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // 2.1a
        List<Pelicula> lista = new List<Pelicula>();
        lista.Add(new Pelicula("Interstellar", "Mateo", 2013, true));
        lista.Add(new Pelicula("El Padrino", "pacheco", 1980, false));
        lista.Add(new Pelicula("Avengers", "Mateo", 2020, true));

        // 2.1b
        Console.WriteLine("=== Todas las peliculas ===");
        foreach (Pelicula p in lista)
        {
            Console.WriteLine(p.ToString());
        }

        // 2.1c
        Console.WriteLine("\n=== Peliculas de Mateo ===");
        foreach (Pelicula p in lista)
        {
            if (p.getDirector().Contains("Mateo"))
            {
                Console.WriteLine(p.ToString());
            }
        }

        // 2.2
        Console.WriteLine("\nFecha actual: " + DateTime.Now.ToShortDateString());

        // 2.3
        GuardarPeliculas(lista, "peliculas.txt");
        Console.WriteLine("Peliculas guardadas en peliculas.txt");

          // Ejercicio 3
        GestorBD gestor = new GestorBD();
        foreach (Pelicula p in lista)
        {
            gestor.Insertar(p);
        }
        Console.WriteLine("\n=== Peliculas en BD ===");
        foreach (Pelicula p in gestor.ObtenerTodos())
        {
            Console.WriteLine(p.ToString());
        }

        Console.ReadLine();
    }

    static void GuardarPeliculas(List<Pelicula> lista, string ruta)
    {
        StreamWriter escritor = new StreamWriter(ruta);
        foreach (Pelicula p in lista)
        {
            escritor.WriteLine(p.getTitulo() + ";" + p.getDirector() + ";" + p.getAnyo() + ";" + p.isDisponible());
        }
        escritor.Close();
    }
}
