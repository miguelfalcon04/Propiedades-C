using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedades_C_
{
    internal class Program
    {
        public class Producto
        {
            private string nombre;
            private double precio;
            private int cantidad;

            public Producto(string nombre, double precio = 0, int cantidad = 0)
            {
                this.nombre = nombre;
                this.precio = precio;
                this.cantidad = cantidad;
            }

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            public double Precio
            {
                get { return precio; }
                set { precio = value; }
            }

            public int Cantidad
            {
                get { return cantidad; }
                set { cantidad = value; }
            }

            public override string ToString()
            {
                return $"Producto: {nombre}, Precio: {precio}, Cantidad: {cantidad}";
            }

            public void AumentarCantidad(int cantidad)
            {
                this.cantidad += cantidad;
            }

            public void ReducirCantidad(int cantidad)
            {
                if (this.cantidad - cantidad < 0)
                {
                    Console.WriteLine("Error: La cantidad no puede quedar negativa.");
                }
                else
                {
                    this.cantidad -= cantidad;
                }
            }
        }

        static void eje01()
        {
            Producto producto1 = new Producto("ManzNoelia", 1.5, 10);
            Console.WriteLine(producto1);

            producto1.AumentarCantidad(5);
            Console.WriteLine("Después de aumentar la cantidad: " + producto1);

            producto1.ReducirCantidad(8);
            Console.WriteLine("Después de reducir la cantidad: " + producto1);

            producto1.ReducirCantidad(10); 
        }

        public class Tarea
        {
            public string Titulo { get; set; }
            public bool Completada { get; set; }

            public Tarea(string titulo)
            {
                Titulo = titulo;
                Completada = false;
            }

            public override string ToString()
            {
                return $"{Titulo} - {(Completada ? "Completada" : "Pendiente")}";
            }
        }

        public class AgendaTareas
        {
            private List<Tarea> tareas;

            public AgendaTareas()
            {
                tareas = new List<Tarea>();
            }

            public void AgregarTarea(Tarea tarea)
            {
                tareas.Add(tarea);
            }

            public void EliminarTarea(string titulo)
            {
                Tarea tareaAEliminar = null;
                foreach (var tarea in tareas)
                {
                    if (tarea.Titulo.Equals(titulo))
                    {
                        tareaAEliminar = tarea;
                        break;
                    }
                }

                if (tareaAEliminar != null)
                {
                    tareas.Remove(tareaAEliminar);
                    Console.WriteLine($"Tarea '{titulo}' eliminada.");
                }
                else
                {
                    Console.WriteLine($"Tarea '{titulo}' no encontrada.");
                }
            }

            public void CompletarTarea(string titulo)
            {
                foreach (var tarea in tareas)
                {
                    if (tarea.Titulo.Equals(titulo))
                    {
                        tarea.Completada = true;
                        Console.WriteLine($"Tarea '{titulo}' marcada como completada.");
                        return;
                    }
                }

                Console.WriteLine($"Tarea '{titulo}' no encontrada.");
            }

            public void ListarTareas()
            {
                Console.WriteLine("Lista de Tareas:");
                foreach (var tarea in tareas)
                {
                    Console.WriteLine(tarea.ToString());
                }
            }

            public void BuscarTarea(string titulo)
            {
                foreach (var tarea in tareas)
                {
                    if (tarea.Titulo.Equals(titulo))
                    {
                        Console.WriteLine($"Tarea '{titulo}' está {(tarea.Completada ? "completada" : "pendiente")}.");
                        return;
                    }
                }

                Console.WriteLine($"Tarea '{titulo}' no encontrada.");
            }
        }

        static void eje02()
        {
            AgendaTareas agenda = new AgendaTareas();

            agenda.AgregarTarea(new Tarea("Comprar leche"));
            agenda.AgregarTarea(new Tarea("Llamar al dentista"));
            agenda.AgregarTarea(new Tarea("Estudiar para el examen"));

            Console.WriteLine("Lista inicial de tareas:");
            agenda.ListarTareas();

            agenda.CompletarTarea("Comprar leche");

            Console.WriteLine("\nLista de tareas después de completar 'Comprar leche':");
            agenda.ListarTareas();

            agenda.BuscarTarea("Llamar al dentista");

            agenda.EliminarTarea("Estudiar para el examen");

            Console.WriteLine("\nLista de tareas después de eliminar 'Estudiar para el examen':");
            agenda.ListarTareas();
        }

        public class Libro
        {
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public bool Disponible { get; set; }

            public Libro(string titulo, string autor)
            {
                Titulo = titulo;
                Autor = autor;
                Disponible = true; 
            }

            public override string ToString()
            {
                return $"{Titulo} por {Autor} - {(Disponible ? "Disponible" : "Prestado")}";
            }
        }

        public class Biblioteca
        {
            private List<Libro> libros;

            public Biblioteca()
            {
                libros = new List<Libro>();
            }

            public void AgregarLibro(Libro libro)
            {
                libros.Add(libro);
                Console.WriteLine($"Libro '{libro.Titulo}' agregado a la biblioteca.");
            }

            public void EliminarLibro(string titulo)
            {
                Libro libroAEliminar = null;
                foreach (var libro in libros)
                {
                    if (libro.Titulo.Equals(titulo))
                    {
                        libroAEliminar = libro;
                        break;
                    }
                }

                if (libroAEliminar != null)
                {
                    libros.Remove(libroAEliminar);
                    Console.WriteLine($"Libro '{titulo}' eliminado de la biblioteca.");
                }
                else
                {
                    Console.WriteLine($"Libro '{titulo}' no encontrado.");
                }
            }

            public void ListarLibrosDisponibles()
            {
                Console.WriteLine("Libros disponibles:");
                foreach (var libro in libros)
                {
                    if (libro.Disponible)
                    {
                        Console.WriteLine(libro.ToString());
                    }
                }
            }

            public void PrestarLibro(string titulo)
            {
                foreach (var libro in libros)
                {
                    if (libro.Titulo.Equals(titulo))
                    {
                        if (libro.Disponible)
                        {
                            libro.Disponible = false;
                            Console.WriteLine($"Libro '{titulo}' prestado.");
                        }
                        else
                        {
                            Console.WriteLine($"Libro '{titulo}' ya está prestado.");
                        }
                        return;
                    }
                }

                Console.WriteLine($"Libro '{titulo}' no encontrado.");
            }

            public void DevolverLibro(string titulo)
            {
                foreach (var libro in libros)
                {
                    if (libro.Titulo.Equals(titulo))
                    {
                        if (!libro.Disponible)
                        {
                            libro.Disponible = true;
                            Console.WriteLine($"Libro '{titulo}' devuelto a la biblioteca.");
                        }
                        else
                        {
                            Console.WriteLine($"Libro '{titulo}' ya estaba disponible.");
                        }
                        return;
                    }
                }

                Console.WriteLine($"Libro '{titulo}' no encontrado.");
            }
        }

        static void eje03()
        {
            Biblioteca biblioteca = new Biblioteca();

            biblioteca.AgregarLibro(new Libro("2024", "Paquillo"));
            biblioteca.AgregarLibro(new Libro("DAM", "MiguelArrow"));
            biblioteca.AgregarLibro(new Libro("El Principito", "El Reycito"));

            Console.WriteLine("\nLibros disponibles al inicio:");
            biblioteca.ListarLibrosDisponibles();

            biblioteca.PrestarLibro("2024");

            biblioteca.PrestarLibro("2024");

            Console.WriteLine("\nLibros disponibles después de prestar '2024':");
            biblioteca.ListarLibrosDisponibles();

            biblioteca.DevolverLibro("2024");

            biblioteca.DevolverLibro("2024");

            biblioteca.EliminarLibro("El Principito");

            Console.WriteLine("\nLibros disponibles al final:");
            biblioteca.ListarLibrosDisponibles();
        }

        public class VideoJuego
        {
            private string nombre;
            public string Nombre { get; set; }
            public string Plataforma { get; set; }
            public bool Jugado { get; set; }

            public VideoJuego(string nombre, string plataforma) {
                Nombre = nombre;
                Plataforma = plataforma;
                Jugado = false;
            }

            public override string ToString()
            {
                return $"{Nombre} en {Plataforma} - {(Jugado ? "Jugado" : "No Jugado")}";
            }
        }

        public class ColeccionVideojuegos
        {
            private List<VideoJuego> videoJuegos;

            public ColeccionVideojuegos()
            {
                videoJuegos = new List<VideoJuego>();
            }

            public void AgregarJuego(VideoJuego juego)
            {
                videoJuegos.Add(juego);
            }

            public void EliminarJuego(string nombre)
            {
                bool encontrado = false;
                foreach (var juego in videoJuegos)
                {
                    if (juego.Nombre.Equals(nombre))
                    {
                        videoJuegos.Remove(juego);
                        encontrado = true;
                    }
                }

                if (encontrado)
                {
                    Console.WriteLine($"{nombre} Eliminado");
                }
                else
                {
                    Console.WriteLine($"{nombre} No encontrado");
                }
            }

            public void ListarVideojuegos()
            {
                foreach (var juego in videoJuegos)
                {
                    Console.WriteLine(juego.ToString());
                }
            }

            public void MarcarComoJugado(string nombre)
            {
                bool encontrado = false;
                foreach (var juego in videoJuegos)
                {
                    if (juego.Nombre.Equals(nombre))
                    {
                        juego.Jugado=true;
                        encontrado = true;
                    }
                }

                if (encontrado)
                {
                    Console.WriteLine($"{nombre} Marcado como jugado");
                }
                else
                {
                    Console.WriteLine($"{nombre} No encontrado");
                }
            }

            public void ListarVideojuegosJugados()
            {
                foreach (var juego in videoJuegos)
                {
                    if (juego.Jugado)
                    {
                        Console.WriteLine(juego.ToString() );
                    }
                }
            }
        }

        static void eje04()
        {
            ColeccionVideojuegos coleccion = new ColeccionVideojuegos();
            coleccion.AgregarJuego(new VideoJuego("GTA 5", "PS4"));
            coleccion.AgregarJuego(new VideoJuego("Fortnite", "PC"));
            coleccion.AgregarJuego(new VideoJuego("Barbie 64", "Nintendo"));

            coleccion.ListarVideojuegos();

            coleccion.MarcarComoJugado("GTA 5");
            coleccion.ListarVideojuegosJugados();

            coleccion.EliminarJuego("Fortnite");
            coleccion.ListarVideojuegos();
        }

        public class Alumno
        {
            private string nombre;
            public string Nombre { get; set; }
            private int edad;
            public int Edad { get; set; }
            private double notaMedia;
            public double NotaMedia { get; set; }
        }

        public class ClaseAlumnos
        {
            private List<Alumno> alumnos = new List<Alumno>();

            public void AgregarAlumno(Alumno alumno)
            {
                alumnos.Add(alumno);
            }

            public void EliminarAlumno(string nombre)
            {
                Alumno alumnoAEliminar = null;
                foreach (var alumno in alumnos)
                {
                    if (alumno.Nombre.Equals(nombre))
                    {
                        alumnoAEliminar = alumno;
                        break;
                    }
                }
                if (alumnoAEliminar != null)
                {
                    alumnos.Remove(alumnoAEliminar);
                }
            }

            public void ListarAlumnos()
            {
                foreach (var alumno in alumnos)
                {
                    Console.WriteLine($"Nombre: {alumno.Nombre}, Edad: {alumno.Edad}, Nota Media: {alumno.NotaMedia}");
                }
            }

            public void BuscarAlumno(string nombre)
            {
                foreach (var alumno in alumnos)
                {
                    if (alumno.Nombre.Equals(nombre))
                    {
                        Console.WriteLine($"Nombre: {alumno.Nombre}, Edad: {alumno.Edad}, Nota Media: {alumno.NotaMedia}");
                        return;
                    }
                }
                Console.WriteLine("Alumno no encontrado");
            }

            public double CalcularNotaMedia()
            {
                double suma = 0;
                int totalAlumnos = 0;
                foreach (var alumno in alumnos)
                {
                    suma += alumno.NotaMedia;
                    totalAlumnos++;
                }
                return totalAlumnos > 0 ? suma / totalAlumnos : 0;
            }
        }

        static void eje05()
        {
            ClaseAlumnos claseAlumnos = new ClaseAlumnos();

            Alumno alumno1 = new Alumno { Nombre = "Miguel", Edad = 20, NotaMedia = 8.5 };
            Alumno alumno2 = new Alumno { Nombre = "Noelia", Edad = 22, NotaMedia = 9.0 };
            Alumno alumno3 = new Alumno { Nombre = "Bernardo", Edad = 21, NotaMedia = 7.5 };

            claseAlumnos.AgregarAlumno(alumno1);
            claseAlumnos.AgregarAlumno(alumno2);
            claseAlumnos.AgregarAlumno(alumno3);

            Console.WriteLine("Lista de Alumnos:");
            claseAlumnos.ListarAlumnos();

            Console.WriteLine("\nBuscar Alumno 'Noelia':");
            claseAlumnos.BuscarAlumno("Noelia");

            Console.WriteLine("\nEliminar Alumno 'Bernardo':");
            claseAlumnos.EliminarAlumno("Bernardo");

            Console.WriteLine("\nLista de Alumnos después de la eliminación:");
            claseAlumnos.ListarAlumnos();

            Console.WriteLine($"\nNota Media de todos los alumnos: {claseAlumnos.CalcularNotaMedia()}");
        }

        public class Empleado
        {
            private string nombre;
            public string Nombre { get; set; }
            private string puesto;
            public string Puesto { get; set; }
            private double salario;
            public double Salario { get; set; }

            public Empleado(string nombre, string puesto, double salario)
            {
                nombre = nombre;
                puesto = puesto;
                salario = salario;
            }
        }

        public class Empresa
        {
            private List<Empleado> empleados = new List<Empleado>();

            public void AgregarEmpleado(Empleado empleado)
            {
                empleados.Add(empleado);
            }

            public void EliminarEmpleado(string nombre)
            {
                Empleado empleadoAEliminar = null;
                foreach (var empleado in empleados)
                {
                    if (empleado.Nombre.Equals(nombre))
                    {
                        empleadoAEliminar = empleado;
                        break;
                    }
                }
                if (empleadoAEliminar != null)
                {
                    empleados.Remove(empleadoAEliminar);
                }
            }

            public void ListarEmpleados()
            {
                foreach (var empleado in empleados)
                {
                    Console.WriteLine($"Nombre: {empleado.Nombre}, Puesto: {empleado.Puesto}, Salario: {empleado.Salario}");
                }
            }

            public double CalcularSalarioPromedio()
            {
                double suma = 0;
                int totalEmpleados = 0;
                foreach (var empleado in empleados)
                {
                    suma += empleado.Salario;
                    totalEmpleados++;
                }
                return totalEmpleados > 0 ? suma / totalEmpleados : 0;
            }
        }

        static void eje06()
        {
            Empresa empresa = new Empresa();

            Empleado empleado1 = new Empleado("Carlos", "Desarrollador", 3000);
            Empleado empleado2 = new Empleado("Noelia", "Diseñadora", 3500);
            Empleado empleado3 = new Empleado("Miguel", "Gerente", 5000);

            empresa.AgregarEmpleado(empleado1);
            empresa.AgregarEmpleado(empleado2);
            empresa.AgregarEmpleado(empleado3);

            Console.WriteLine("Lista de Empleados:");
            empresa.ListarEmpleados();

            Console.WriteLine("\nEliminar Empleado 'Miguel':");
            empresa.EliminarEmpleado("Miguel");

            Console.WriteLine("\nLista de Empleados después de la eliminación:");
            empresa.ListarEmpleados();

            Console.WriteLine($"\nSalario Promedio de todos los empleados: {empresa.CalcularSalarioPromedio()}");
        }

        static void Main(string[] args)
        {
            eje06();
        }
    }
}
