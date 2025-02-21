using System;

using System.Collections.Generic;

using System.Linq; // Se investigó sobre el uso de la librería System.Linq, con la cual encontramos una forma más sencilla para calcular el promedio utilizando el método Average. 



class Program

{

    class Estudiante

    // Se trabaja una lista única en lugar de dos separadas para nombre y calificación. 

    // Se utilizó la clase Estudiante para encapsular datos que están relacionados (nombre y calificación), 

    // ya que con la lógica en Main era más difícil de leer y mantener. 

    {

        public string Nombre { get; set; }

        public double Calificacion { get; set; }

    }

    // get permite leer el valor de la propiedad, y set permite asignarle un valor. 



    static List<Estudiante> estudiantes = new List<Estudiante>();



    static void Main(string[] args)

    {

        Console.WriteLine("Bienvenido al sistema de gestión de estudiantes.");



        while (true)

        // Se inicia un bucle infinito para que el usuario ingrese opciones, hasta que prefiera salir. 

        {

            Console.WriteLine("\n1. Agregar estudiante");

            Console.WriteLine("2. Mostrar lista de estudiantes");

            Console.WriteLine("3. Calcular promedio de calificaciones");

            Console.WriteLine("4. Mostrar estudiante con la calificación más alta");

            Console.WriteLine("5. Salir");

            Console.Write("Seleccione una opción: ");



            if (!int.TryParse(Console.ReadLine(), out int opcion))

            {

                Console.WriteLine("Opción no válida. Intente de nuevo.");

                continue;

            }

            // Se cambia if-else por Switch ya que es más fácil de leer y entender cuando tenemos muchas opciones, 

            // y si en un futuro deseamos agregar más opciones con switch se nos facilita. 

            switch (opcion)

            {

                case 1:

                    AgregarEstudiante();

                    break;

                case 2:

                    MostrarEstudiantes();

                    break;

                case 3:

                    CalcularPromedio();

                    break;

                case 4:

                    MostrarEstudianteConMaxCalificacion();

                    break;

                case 5:

                    Console.WriteLine("Saliendo del sistema...");

                    return;

                default:

                    Console.WriteLine("Opción no válida. Intente de nuevo.");

                    break;

            }

        }

    }



    static void AgregarEstudiante()

    {

        Console.Write("Ingrese el nombre del estudiante: ");

        string nombre = Console.ReadLine();



        Console.Write("Ingrese la calificación del estudiante (0-100): ");

        if (!double.TryParse(Console.ReadLine(), out double calificacion))

        // Se utilizó int.TryParse y double.TryParse en vez de int.Parse y double.Parse para evitar errores en caso de que el usuario ingrese un valor no numérico. 

        {

            Console.WriteLine("Calificación no válida. Debe ser un número.");

            return;

        }



        // Validación de que la calificación esta entre 0 y 100. 

        if (calificacion < 0 || calificacion > 100)

        {

            Console.WriteLine("La calificación debe estar entre 0 y 100.");

            return;

        }



        estudiantes.Add(new Estudiante { Nombre = nombre, Calificacion = calificacion });

        Console.WriteLine("Estudiante agregado correctamente.");

    }



    static void MostrarEstudiantes()

    {

        if (estudiantes.Count == 0)

        {

            Console.WriteLine("No hay estudiantes registrados.");

            return;

        }



        Console.WriteLine("\nLista de estudiantes:");

        foreach (var estudiante in estudiantes)

        {

            Console.WriteLine($"{estudiante.Nombre} - Calificación: {estudiante.Calificacion}");

        }

    }



    static void CalcularPromedio()

    {

        if (estudiantes.Count == 0)

        {

            Console.WriteLine("No hay calificaciones registradas.");

            return;

        }



        double promedio = estudiantes.Average(e => e.Calificacion);

        Console.WriteLine($"El promedio de calificaciones es: {promedio}");

        // Se utilizó el método Average de la librería System.Linq para calcular el promedio de valores. 

    }



    static void MostrarEstudianteConMaxCalificacion()

    {

        if (estudiantes.Count == 0)

        {

            Console.WriteLine("No hay calificaciones registradas.");

            return;

        }



        //OrderByDescending lo utilizamos para ordenar la lista de estudiantes de mayor a menor calificacion, por lo que con la funcion First() obtenemos el primer elemento de la lista ordenada el cual seria la calificacion mas alta que es lo que el codigo nos pides. 

        var estudianteMax = estudiantes.OrderByDescending(e => e.Calificacion).First();

        Console.WriteLine($"El estudiante con la calificación más alta es: {estudianteMax.Nombre} con {estudianteMax.Calificacion}");

    }

}