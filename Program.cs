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

        public class Factura
        {
            private int numero;
            public int Numero { get; set; }
            private string concepto;
            public string Concepto { get; set; }
            private double importe;
            public double Importe { get; set; }

            public Factura(int numero, string concepto, double importe)
            {
                Numero = numero;
                Concepto = concepto;
                Importe = importe;
            }
        }

        public class GestionFacturas
        {
            private List<Factura> facturas = new List<Factura>();

            public void AgregarFactura(Factura factura)
            {
                facturas.Add(factura);
            }

            public void EliminarFactura(int numero)
            {
                Factura facturaAEliminar = null;
                foreach (var factura in facturas)
                {
                    if (factura.Numero.Equals(numero))
                    {
                        facturaAEliminar = factura;
                        break;
                    }
                }
                if (facturaAEliminar != null)
                {
                    facturas.Remove(facturaAEliminar);
                }
            }

            public void ListarFacturas()
            {
                foreach (var factura in facturas)
                {
                    Console.WriteLine($"Número: {factura.Numero}, Concepto: {factura.Concepto}, Importe: {factura.Importe}");
                }
            }

            public double CalcularImporteTotal()
            {
                double suma = 0;
                foreach (var factura in facturas)
                {
                    suma += factura.Importe;
                }
                return suma;
            }
        }

        static void eje07()
        {
            GestionFacturas gestionFacturas = new GestionFacturas();

            Factura factura1 = new Factura(1, "Compra de materiales", 1500);
            Factura factura2 = new Factura(2, "Servicios de limpieza", 750);
            Factura factura3 = new Factura(3, "Mantenimiento", 1200);

            gestionFacturas.AgregarFactura(factura1);
            gestionFacturas.AgregarFactura(factura2);
            gestionFacturas.AgregarFactura(factura3);

            Console.WriteLine("Lista de Facturas:");
            gestionFacturas.ListarFacturas();

            Console.WriteLine("\nEliminar Factura número 2:");
            gestionFacturas.EliminarFactura(2);

            Console.WriteLine("\nLista de Facturas después de la eliminación:");
            gestionFacturas.ListarFacturas();

            Console.WriteLine($"\nImporte Total de todas las facturas: {gestionFacturas.CalcularImporteTotal()}");
        }

        public class Estudiante
        {
            private string nombre;
            public string Nombre { get; set; }
            private double calificacion;
            public double Calificacion { get; set; }

            public Estudiante(string nombre, double calificacion)
            {
                Nombre = nombre;
                Calificacion = calificacion;
            }
        }

        public class Curso
        {
            private string nombre;
            public string Nombre { get; set; }
            private List<Estudiante> estudiantes = new List<Estudiante>();

            public Curso(string nombre)
            {
                Nombre = nombre;
            }

            public void AgregarEstudiante(Estudiante estudiante)
            {
                estudiantes.Add(estudiante);
            }

            public void EliminarEstudiante(string nombre)
            {
                Estudiante estudianteAEliminar = null;
                foreach (var estudiante in estudiantes)
                {
                    if (estudiante.Nombre.Equals(nombre))
                    {
                        estudianteAEliminar = estudiante;
                        break;
                    }
                }
                if (estudianteAEliminar != null)
                {
                    estudiantes.Remove(estudianteAEliminar);
                }
            }

            public double CalcularCalificacionMedia()
            {
                double suma = 0;
                int totalEstudiantes = 0;
                foreach (var estudiante in estudiantes)
                {
                    suma += estudiante.Calificacion;
                    totalEstudiantes++;
                }
                return totalEstudiantes > 0 ? suma / totalEstudiantes : 0;
            }

            public void ListarEstudiantes()
            {
                foreach (var estudiante in estudiantes)
                {
                    Console.WriteLine($"Nombre: {estudiante.Nombre}, Calificación: {estudiante.Calificacion}");
                }
            }
        }

        static void eje08()
        {
            Curso curso = new Curso("Matemáticas");

            Estudiante estudiante1 = new Estudiante("Pedro", 85);
            Estudiante estudiante2 = new Estudiante("María", 90);
            Estudiante estudiante3 = new Estudiante("Luis", 78);

            curso.AgregarEstudiante(estudiante1);
            curso.AgregarEstudiante(estudiante2);
            curso.AgregarEstudiante(estudiante3);

            Console.WriteLine("Lista de Estudiantes:");
            curso.ListarEstudiantes();

            Console.WriteLine("\nEliminar Estudiante 'Luis':");
            curso.EliminarEstudiante("Luis");

            Console.WriteLine("\nLista de Estudiantes después de la eliminación:");
            curso.ListarEstudiantes();

            Console.WriteLine($"\nCalificación Media del curso: {curso.CalcularCalificacionMedia()}");
        }

        public class Coche
        {
            private string matricula;
            public string Matricula { get; set; }
            private string marca;
            public string Marca { get; set; }
            private bool estado;
            public bool Estado { get; set; }

            public Coche(string matricula, string marca)
            {
                Matricula = matricula;
                Marca = marca;
                Estado = false; 
            }
        }

        public class Taller
        {
            private List<Coche> coches = new List<Coche>();

            public void AgregarCoche(Coche coche)
            {
                coches.Add(coche);
            }

            public void EliminarCoche(string matricula)
            {
                Coche cocheAEliminar = null;
                foreach (var coche in coches)
                {
                    if (coche.Matricula.Equals(matricula))
                    {
                        cocheAEliminar = coche;
                        break;
                    }
                }
                if (cocheAEliminar != null)
                {
                    coches.Remove(cocheAEliminar);
                }
            }

            public void RepararCoche(string matricula)
            {
                foreach (var coche in coches)
                {
                    if (coche.Matricula.Equals(matricula))
                    {
                        coche.Estado = true; 
                        break;
                    }
                }
            }

            public void ListarCoches()
            {
                foreach (var coche in coches)
                {
                    string estadoTexto = coche.Estado ? "Reparado" : "No reparado";
                    Console.WriteLine($"Matrícula: {coche.Matricula}, Marca: {coche.Marca}, Estado: {estadoTexto}");
                }
            }
        }

        static void eje09()
        {
            Taller taller = new Taller();

            Coche coche1 = new Coche("1234ABC", "Toyota");
            Coche coche2 = new Coche("5678DEF", "Honda");
            Coche coche3 = new Coche("9101GHI", "Ford");

            taller.AgregarCoche(coche1);
            taller.AgregarCoche(coche2);
            taller.AgregarCoche(coche3);

            Console.WriteLine("Lista de Coches en el Taller:");
            taller.ListarCoches();

            Console.WriteLine("\nReparar Coche con matrícula '5678DEF':");
            taller.RepararCoche("5678DEF");

            Console.WriteLine("\nLista de Coches después de la reparación:");
            taller.ListarCoches();

            Console.WriteLine("\nEliminar Coche con matrícula '1234ABC':");
            taller.EliminarCoche("1234ABC");

            Console.WriteLine("\nLista de Coches después de la eliminación:");
            taller.ListarCoches();
        }

        public class Asiento
        {
            private int fila;
            public int Fila { get; set; }
            private int columna;
            public int Columna { get; set; }
            private bool reservado;
            public bool Reservado { get; set; }

            public Asiento(int fila, int columna)
            {
                Fila = fila;
                Columna = columna;
                Reservado = false; // Por defecto, el asiento no está reservado
            }
        }

        public class SalaCine
        {
            private Asiento[,] asientos;

            public SalaCine(int filas, int columnas)
            {
                asientos = new Asiento[filas, columnas];
                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        asientos[i, j] = new Asiento(i, j);
                    }
                }
            }

            public void ReservarAsiento(int fila, int columna)
            {
                if (asientos[fila, columna].Reservado)
                {
                    Console.WriteLine($"El asiento en fila {fila + 1}, columna {columna + 1} ya está reservado.");
                }
                else
                {
                    asientos[fila, columna].Reservado = true;
                    Console.WriteLine($"Asiento en fila {fila + 1}, columna {columna + 1} reservado con éxito.");
                }
            }

            public void CancelarReserva(int fila, int columna)
            {
                if (!asientos[fila, columna].Reservado)
                {
                    Console.WriteLine($"El asiento en fila {fila + 1}, columna {columna + 1} no está reservado.");
                }
                else
                {
                    asientos[fila, columna].Reservado = false;
                    Console.WriteLine($"Reserva de asiento en fila {fila + 1}, columna {columna + 1} cancelada.");
                }
            }

            public void MostrarAsientos()
            {
                for (int i = 0; i < asientos.GetLength(0); i++)
                {
                    for (int j = 0; j < asientos.GetLength(1); j++)
                    {
                        string estado = asientos[i, j].Reservado ? "Reservado" : "Disponible";
                        Console.Write($"[{estado}] ");
                    }
                    Console.WriteLine();
                }
            }

            public void ReservarAsientosGrupo(int numAsientos)
            {
                for (int i = 0; i < asientos.GetLength(0); i++)
                {
                    int count = 0;
                    for (int j = 0; j < asientos.GetLength(1); j++)
                    {
                        if (!asientos[i, j].Reservado)
                        {
                            count++;
                            if (count == numAsientos)
                            {
                                for (int k = j; k > j - numAsientos; k--)
                                {
                                    asientos[i, k].Reservado = true;
                                }
                                Console.WriteLine($"Grupo de {numAsientos} asientos reservados en fila {i + 1}.");
                                return;
                            }
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                }
                Console.WriteLine($"No hay suficientes asientos disponibles para un grupo de {numAsientos}.");
            }
        }

        static void eje10()
        {
            SalaCine salaCine = new SalaCine(5, 8);

            salaCine.MostrarAsientos();

            Console.WriteLine("\nReservar asiento en fila 1, columna 2:");
            salaCine.ReservarAsiento(0, 1);

            Console.WriteLine("\nMostrar estado de los asientos:");
            salaCine.MostrarAsientos();

            Console.WriteLine("\nCancelar reserva de asiento en fila 1, columna 2:");
            salaCine.CancelarReserva(0, 1);

            Console.WriteLine("\nMostrar estado de los asientos:");
            salaCine.MostrarAsientos();

            Console.WriteLine("\nReservar grupo de 4 asientos:");
            salaCine.ReservarAsientosGrupo(4);

            Console.WriteLine("\nMostrar estado de los asientos:");
            salaCine.MostrarAsientos();

            Console.WriteLine("\nReservar grupo de 3 asientos:");
            salaCine.ReservarAsientosGrupo(3);

            Console.WriteLine("\nMostrar estado de los asientos:");
            salaCine.MostrarAsientos();
        }

        public class Archivo
        {
            private string nombre;
            public string Nombre { get; set; }
            private string tipo;
            public string Tipo { get; set; }
            private double tamano; 
            public double Tamano { get; set; }

            public Archivo(string nombre, string tipo, double tamano)
            {
                Nombre = nombre;
                Tipo = tipo;
                Tamano = tamano;
            }
        }

        public class NubeAlmacenamiento
        {
            private List<Archivo> archivos = new List<Archivo>();
            private const double limiteAlmacenamiento = 500.0;

            public void SubirArchivo(Archivo archivo)
            {
                if (CalcularEspacioUtilizado() + archivo.Tamano <= limiteAlmacenamiento)
                {
                    archivos.Add(archivo);
                    Console.WriteLine($"Archivo '{archivo.Nombre}' subido con éxito.");
                }
                else
                {
                    Console.WriteLine("No hay suficiente espacio en la nube para subir el archivo.");
                }
            }

            public void EliminarArchivo(string nombre)
            {
                Archivo archivoAEliminar = null;
                foreach (var archivo in archivos)
                {
                    if (archivo.Nombre.Equals(nombre))
                    {
                        archivoAEliminar = archivo;
                        break;
                    }
                }
                if (archivoAEliminar != null)
                {
                    archivos.Remove(archivoAEliminar);
                    Console.WriteLine($"Archivo '{nombre}' eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine($"No se encontró el archivo '{nombre}'.");
                }
            }

            public void ListarArchivos()
            {
                if (archivos.Count == 0)
                {
                    Console.WriteLine("No hay archivos en la nube.");
                    return;
                }

                foreach (var archivo in archivos)
                {
                    Console.WriteLine($"Nombre: {archivo.Nombre}, Tipo: {archivo.Tipo}, Tamaño: {archivo.Tamano} MB");
                }
            }

            public void BuscarArchivo(string nombre)
            {
                foreach (var archivo in archivos)
                {
                    if (archivo.Nombre.Equals(nombre))
                    {
                        Console.WriteLine($"Archivo encontrado: Nombre: {archivo.Nombre}, Tipo: {archivo.Tipo}, Tamaño: {archivo.Tamano} MB");
                        return;
                    }
                }
                Console.WriteLine($"No se encontró el archivo '{nombre}'.");
            }

            public double CalcularEspacioDisponible()
            {
                return limiteAlmacenamiento - CalcularEspacioUtilizado();
            }

            private double CalcularEspacioUtilizado()
            {
                double total = 0;
                foreach (var archivo in archivos)
                {
                    total += archivo.Tamano;
                }
                return total;
            }
        }

        static void eje11()
        {
            NubeAlmacenamiento nube = new NubeAlmacenamiento();

            Archivo archivo1 = new Archivo("documento1.txt", "documento", 20);
            Archivo archivo2 = new Archivo("imagen1.png", "imagen", 15);
            Archivo archivo3 = new Archivo("video.mp4", "video", 480);

            nube.SubirArchivo(archivo1);
            nube.SubirArchivo(archivo2);
            nube.SubirArchivo(archivo3); // Este archivo no debería poder subirse debido al límite

            Console.WriteLine("\nListar archivos en la nube:");
            nube.ListarArchivos();

            Console.WriteLine("\nBuscar archivo 'documento1.txt':");
            nube.BuscarArchivo("documento1.txt");

            Console.WriteLine("\nEliminar archivo 'imagen1.png':");
            nube.EliminarArchivo("imagen1.png");

            Console.WriteLine("\nListar archivos después de la eliminación:");
            nube.ListarArchivos();

            Console.WriteLine($"\nEspacio disponible en la nube: {nube.CalcularEspacioDisponible()} MB");
        }

        public class Obra
        {
            private string titulo;
            public string Titulo { get; set; }
            private string autor;
            public string Autor { get; set; }
            private string genero;
            public string Genero { get; set; }
            private double valoracion; // de 0 a 5
            public double Valoracion { get; set; }

            public Obra(string titulo, string autor, string genero, double valoracion)
            {
                Titulo = titulo;
                Autor = autor;
                Genero = genero;
                Valoracion = valoracion;
            }
        }

        public class SistemaRecomendacionObras
        {
            private List<Obra> obras = new List<Obra>();

            public void AgregarObra(Obra obra)
            {
                obras.Add(obra);
                Console.WriteLine($"Obra '{obra.Titulo}' agregada al sistema.");
            }

            public void ListarObrasPorGenero(string genero)
            {
                var obrasPorGenero = obras.Where(o => o.Genero.Equals(genero));
                if (!obrasPorGenero.Any())
                {
                    Console.WriteLine($"No hay obras disponibles en el género '{genero}'.");
                    return;
                }

                foreach (var obra in obrasPorGenero)
                {
                    Console.WriteLine($"Título: {obra.Titulo}, Autor: {obra.Autor}, Valoración: {obra.Valoracion} estrellas");
                }
            }

            public void ListarMejoresObras(int cantidad)
            {
                var mejoresObras = obras.OrderByDescending(o => o.Valoracion).Take(cantidad);
                if (!mejoresObras.Any())
                {
                    Console.WriteLine("No hay obras disponibles en el sistema.");
                    return;
                }

                foreach (var obra in mejoresObras)
                {
                    Console.WriteLine($"Título: {obra.Titulo}, Autor: {obra.Autor}, Valoración: {obra.Valoracion} estrellas");
                }
            }

            public void RecomendarObra(string genero)
            {
                var obrasPorGenero = obras.Where(o => o.Genero.Equals(genero)).ToList();
                if (!obrasPorGenero.Any())
                {
                    Console.WriteLine($"No hay obras disponibles en el género '{genero}' para recomendar.");
                    return;
                }

                Random random = new Random();
                int indiceAleatorio = random.Next(obrasPorGenero.Count);
                var obraRecomendada = obrasPorGenero[indiceAleatorio];

                Console.WriteLine($"Te recomendamos la obra: '{obraRecomendada.Titulo}' de {obraRecomendada.Autor}, Valoración: {obraRecomendada.Valoracion} estrellas.");
            }
        }

        static void eje12()
        {
            SistemaRecomendacionObras sistema = new SistemaRecomendacionObras();

            Obra obra1 = new Obra("Cien años de soledad", "Gabriel García Márquez", "Ficción", 4.5);
            Obra obra2 = new Obra("1984", "George Orwell", "Ficción", 4.8);
            Obra obra3 = new Obra("El Principito", "Antoine de Saint-Exupéry", "Infantil", 4.7);
            Obra obra4 = new Obra("La sombra del viento", "Carlos Ruiz Zafón", "Ficción", 4.6);
            Obra obra5 = new Obra("El arte de la guerra", "Sun Tzu", "No ficción", 4.4);

            sistema.AgregarObra(obra1);
            sistema.AgregarObra(obra2);
            sistema.AgregarObra(obra3);
            sistema.AgregarObra(obra4);
            sistema.AgregarObra(obra5);

            Console.WriteLine("\nListar obras de género 'Ficción':");
            sistema.ListarObrasPorGenero("Ficción");

            Console.WriteLine("\nListar las 3 mejores obras:");
            sistema.ListarMejoresObras(3);

            Console.WriteLine("\nRecomendar una obra del género 'Ficción':");
            sistema.RecomendarObra("Ficción");
        }

        static void Main(string[] args)
        {
            eje12();
        }
    }
}
