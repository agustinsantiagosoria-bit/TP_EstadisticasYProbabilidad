namespace TP_Barajas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================================");
            Console.WriteLine("Bienvenido al programa de barajas");
            Console.WriteLine("================================");

            Console.WriteLine("A continuacion se le comentaran las opciones que puede realizar");
            while (true)
            {
                Funciones f = new Funciones();
                f.Menu();
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Funciones.SimularExtracciones();
                        break;
                    case 2:
                        // Lógica para mostrar resultado y probabilidad de la 1ª extracción
                        Funciones.calcularProbabilidadDeRojaConDevolucion();
                        break;
                    case 3:
                        // Lógica para calcular probabilidad en la 2ª extracción (Con devolución)
                        Funciones.calcularProbabilidadDeRojaConDevolucion();
                        break;
                    case 4:
                        // Lógica para calcular probabilidad en la 2ª extracción (Sin devolución)
                        Funciones.calcularProbabilidadDeRojaSinDevolucion();
                        break;
                    case 5:
                        Funciones.comparacionDevoluciones();
                        break;
                    case 6:
                        Funciones.determinarPuntos();
                        break;
                    case 7:
                        Funciones.explicacionPrograma();
                        break;
                    case 8:
                        Funciones.ConfigurarDetalles();
                        break;
                    case 9:
                        Funciones.Salir();
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }

            }
        }
    }
}