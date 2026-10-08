using System.Linq;
using System.Timers;

namespace TP_Barajas
{
    public class Funciones
    {
        private static bool primeraFueRoja;
        private static bool segundaFueRoja;
        private static bool seDevolvio;
        private static bool simulacionRealizada;
        private static string primeraCarta;
        private static string segundaCarta;

        private static bool mostrarDetallesEspacioMuestral { get; set; } = false;

        public static string[] cartas = { "R1", "R2", "R3", "R4", "R5", "R6", "R7", "R8", "R9", "R10", "N1", "N2", "N3", "N4", "N5", "N6", "N7", "N8", "N9", "N10" };
        public void Menu()
        {
            Console.WriteLine("\n==========================================");
            Console.WriteLine("          MENÚ DE OPCIONES");
            Console.WriteLine("==========================================");

            if (simulacionRealizada = false) Console.WriteLine("[Usted SI realizo la simulacion, puede proceder con las opciones del 2 al 4]");
            else Console.WriteLine("[¡¡¡Usted NO realizo la simulacion, NO puede acceder a las opciones del 2 al 4!!!]");
            Console.WriteLine();
            Console.WriteLine("1. Realizar dos extracciones consecutivas.");
            Console.WriteLine("2. Mostrar resultado y probabilidad de la 1ª extracción.");
            Console.WriteLine("3. Probabilidad en la 2ª extracción (Con devolución).");
            Console.WriteLine("4. Probabilidad en la 2ª extracción (Sin devolución).");
            Console.WriteLine("5. Comparar probabilidades de ambas situaciones.");
            Console.WriteLine("6. Determinar si los eventos son independientes o dependientes.");
            Console.WriteLine("7. Explicación de la aplicación.");
            Console.WriteLine("8. Configuracion");
            Console.WriteLine("9. Salir.");
            Console.Write("\nSeleccione una opción: ");
        }

        public static void Salir()
        {
            Console.WriteLine("Gracias por utilizar el programa. ¡Hasta luego!");
            Environment.Exit(0);
        }

        public static void SimularExtracciones()
        {

            cartas = cartas.OrderBy(x => Guid.NewGuid()).ToArray(); // Mezcla las cartas de manera aleatoria

            Console.WriteLine("Antes de realizar la operacion se le consulta:");
            Console.WriteLine("Desea realizar la extraccion usted o dejarlo al azar?");
            Console.WriteLine("1. Realizar la extraccion yo mismo.");
            Console.WriteLine("2. Dejarlo al azar.");
            Console.Write("\nSeleccione una opción: ");

            int C1 = 0;
            int C2 = 0;
            int eleccion = 0;
            int cartasPorFila = 10; // Número de cartas por fila
            int opcion = int.Parse(Console.ReadLine());
            if (opcion == 1)
            {
                Console.Clear();
                Console.WriteLine("=== SIMULACIÓN DE EXTRACCIÓN MANUAL ===\n");
                Console.WriteLine("Usted ha elegido realizar la extracción usted mismo.");

                for (int inicio = 1; inicio <= cartas.Length; inicio += cartasPorFila)
                {
                    int fin = Math.Min(inicio + cartasPorFila - 1, cartas.Length);

                    // Fila de corchetes
                    for (int i = inicio; i <= fin; i++)
                    {
                        Console.Write("[] ");
                    }
                    Console.WriteLine();

                    // Fila de números alineados
                    for (int i = inicio; i <= fin; i++)
                    {
                        Console.Write("{0,-3}", i);
                    }
                    Console.WriteLine("\n"); // Espacio adicional entre bloques de filas
                }

                Console.WriteLine("Ingrese el valor de la primera extracción (1-20): ");
                eleccion = int.Parse(Console.ReadLine());

                if (eleccion < 1 || eleccion > 20)
                {
                    Console.WriteLine("Valor inválido. Por favor, ingrese un número entre 1 y 20.");
                    return;
                }
                else
                {
                    string cartaElegida = cartas[eleccion - 1];
                    Console.WriteLine($"Usted ha elegido la carta: {cartaElegida}");
                }

                Console.WriteLine("Ingrese el valor de la segunda extracción (1-20): ");
                eleccion = int.Parse(Console.ReadLine());

                if (eleccion < 1 || eleccion > 20)
                {
                    Console.WriteLine("Valor inválido. Por favor, ingrese un número entre 1 y 20.");
                    return;
                }
                else
                {
                    string cartaElegida = cartas[eleccion - 1];
                    Console.WriteLine($"Usted ha elegido la carta: {cartaElegida}");
                }

                simulacionRealizada = true;
                Console.WriteLine("Extracciones realizadas correctamente.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }
            else if (opcion == 2)
            {
                Console.Clear();
                Console.WriteLine("=== EXTRACCIÓN ALEATORIA ===\n");
                Console.WriteLine("Usted ha elegido dejarlo al azar.");
                // Lógica para realizar la extracción al azar

                Random random = new Random();
                int primeraExtraccion = random.Next(1, 20);
                // Genera un número aleatorio entre 1 y 20 (inclusive)
                primeraCarta = cartas[primeraExtraccion - 1];
                segundaCarta = cartas[random.Next(1, 20) - 1];
                simulacionRealizada = true;
                Console.WriteLine("Extracciones realizadas correctamente.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
            }
        }





        private static void elif(bool v)
        {
            throw new NotImplementedException();
        }

        private static void resultadoExtraccion()
        {

            if (simulacionRealizada)
            {
                Console.WriteLine("Resultado de la primera extracción: " + primeraCarta);
                Console.WriteLine("Resultado de la segunda extracción: " + segundaCarta);
            }
            else
            {
                Console.WriteLine("No se ha realizado ninguna simulación. Por favor, realice una extracción primero.");
            }
        }

        public static void calcularProbabilidadDeRojaConDevolucion()
        {
            Console.Clear();
            Console.WriteLine("=== CÁLCULO DE PROBABILIDAD (CON DEVOLUCIÓN) ===\n");
            resultadoExtraccion();
            Console.WriteLine("Calculando la probabilidad de que la carta extraída sea roja...");

            for (int i = 0; i < 3; i++)
            {
                Console.Write("\rCalculando.   ");
                Thread.Sleep(500);

                Console.Write("\rCalculando..  ");
                Thread.Sleep(500);

                Console.Write("\rCalculando... ");
                Thread.Sleep(500);
            }

            Console.WriteLine("\nCálculo completado.");
            Thread.Sleep(1000); // Pausa de 1 segundo

            int totalCartas = cartas.Length;
            int cartasRojas = cartas.Count(carta => carta.StartsWith("R"));

            double probabilidadRoja = ((double)cartasRojas / totalCartas) * 100;

            // 🔴 BLOQUE DE ESPACIO MUESTRAL Y CÁLCULOS DETALLADOS
            if (mostrarDetallesEspacioMuestral)
            {
                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine("--- DESGLOSE DEL ESPACIO MUESTRAL Y CÁLCULOS ---");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"• Primera carta extraída: {primeraCarta} (Devuelta al mazo)");
                Console.WriteLine($"• Cartas totales en el mazo |S|: {totalCartas}");
                Console.WriteLine($"• Cartas rojas en el mazo |A|: {cartasRojas}");
                Console.WriteLine("• Condición: Eventos independientes (el mazo no sufre cambios)");
                Console.WriteLine("• Fórmula: P(R2) = Casos Favorables / Casos Totales");
                Console.WriteLine($"• Operación: {cartasRojas} / {totalCartas} = {probabilidadRoja / 100:F4}");
                Console.WriteLine("--------------------------------------------------\n");
            }

            Console.WriteLine($"La probabilidad de que la carta extraída sea roja es de {probabilidadRoja:F2}%.");
            Console.WriteLine("Extracciones realizadas correctamente.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void calcularProbabilidadDeRojaSinDevolucion()
        {
            if (simulacionRealizada = true){
            Console.Clear();
            Console.WriteLine("=== CÁLCULO DE PROBABILIDAD (SIN DEVOLUCIÓN) ===\n");
            resultadoExtraccion();
            Console.WriteLine("Calculando la probabilidad de que la carta extraída sea roja sin devolución...");

            for (int i = 0; i < 3; i++)
            {
                Console.Write("\rCalculando.   ");
                Thread.Sleep(500);

                Console.Write("\rCalculando..  ");
                Thread.Sleep(500);

                Console.Write("\rCalculando... ");
                Thread.Sleep(500);
            }
            Console.WriteLine("\nCálculo completado.");
            Thread.Sleep(1000); // Pausa de 1 segundo

            int totalCartas = cartas.Length - 1;
            bool fueRoja = primeraCarta.StartsWith("R");
            int cartasRojas = cartas.Count(carta => carta.StartsWith("R")) - (fueRoja ? 1 : 0);

            double probabilidadRoja = ((double)cartasRojas / totalCartas) * 100;

            // 🔴 BLOQUE DE ESPACIO MUESTRAL Y CÁLCULOS DETALLADOS
            if (mostrarDetallesEspacioMuestral)
            {
                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine("--- DESGLOSE DEL ESPACIO MUESTRAL Y CÁLCULOS ---");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"• Primera carta extraída (sin devolver): {primeraCarta}");
                Console.WriteLine($"• Cartas restantes en el mazo |S|: {totalCartas}");
                Console.WriteLine($"• Cartas rojas restantes |A|: {cartasRojas} " + (fueRoja ? "(Se resta 1 por la extracción inicial)" : "(Se mantienen 10)"));
                Console.WriteLine("• Condición: P(R2 | R1) = Casos Favorables / Casos Totales");
                Console.WriteLine($"• Operación: {cartasRojas} / {totalCartas} = {probabilidadRoja / 100:F4}");
                Console.WriteLine("--------------------------------------------------\n");
            }

            Console.WriteLine($"La probabilidad de que la carta extraída sea roja sin devolución es de {probabilidadRoja:F2}%.");
            Console.WriteLine("Extracciones realizadas correctamente.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        } else
            {
                Console.WriteLine("Usted no ha realizado la simulacion, porfavor, ingrese a la opcion 1 para realizarla");
                Thread.Sleep(500);
            }
        }

        public static void comparacionDevoluciones()
        {
            Console.Clear();
            Console.WriteLine("=== ANÁLISIS DE RESULTADOS Y CONCLUSIONES ===\n");

            Console.WriteLine("1. CON DEVOLUCIÓN (Eventos Independientes):");
            Console.WriteLine("   - Al reinsertar la carta extraída, el mazo vuelve a tener 20 cartas (10 R / 10 N).");
            Console.WriteLine("   - La probabilidad de la 2.ª extracción sigue siendo 10/20 (50%).");
            Console.WriteLine("   - Conclusión: El primer evento NO afecta al segundo.\n");

            Console.WriteLine("2. SIN DEVOLUCIÓN (Eventos Dependientes / Condicionales):");
            Console.WriteLine("   - Al no devolver la carta, el mazo queda con 19 cartas en total.");
            Console.WriteLine("   - Si la 1.ª fue Roja: quedan 9 Rojas de 19 -> Probabilidad = 9/19 (~47.37%).");
            Console.WriteLine("   - Si la 1.ª fue Negra: quedan 10 Rojas de 19 -> Probabilidad = 10/19 (~52.63%).");
            Console.WriteLine("   - Conclusión: El resultado de la 2.ª extracción DEPENDE directamente de lo que salió en la 1.ª.\n");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void determinarPuntos()
        {
            Console.Clear();
            Console.WriteLine("=== TIPO DE EVENTOS Y JUSTIFICACIÓN ===\n");

            Console.WriteLine("DETERMINACIÓN: Los eventos son DEPENDIENTES.\n");

            Console.WriteLine("JUSTIFICACIÓN TEÓRICA:");
            Console.WriteLine("Dos eventos son independientes si el resultado del primero no altera");
            Console.WriteLine("la probabilidad del segundo. En la extracción sin devolución:\n");

            Console.WriteLine("1. El tamaño del mazo se reduce de 20 a 19 cartas.");
            Console.WriteLine("2. La probabilidad de sacar una carta roja en la 2.ª extracción varía:");
            Console.WriteLine("   - Si la 1.ª fue Roja  -> P(R2) = 9/19 (~47.37%)");
            Console.WriteLine("   - Si la 1.ª fue Negra -> P(R2) = 10/19 (~52.63%)\n");

            Console.WriteLine("CONCLUSIÓN:");
            Console.WriteLine("Como P(R2) cambia según lo extraído en la 1.ª carta, se confirma");
            Console.WriteLine("que la segunda extracción depende del resultado de la primera.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void explicacionPrograma()
        {
            Console.WriteLine("El programa aborda el estudio de la probabilidad estocástica y condicional aplicada a un experimento de muestreo aleatorio sobre una población finita conocida (un mazo de $20$ cartas compuestas por $10$ Rojas y $10$ Negras).");
            Console.WriteLine("Presione ");
            Console.Clear();
        }


        // Método para cambiar la opción desde el menú principal
        public static void ConfigurarDetalles()
        {
            Console.Clear();
            Console.WriteLine("=== CONFIGURACIÓN DE MOSTRAR ESPACIO MUESTRAL Y CÁLCULOS ===");
            Console.WriteLine($"Estado actual: {(mostrarDetallesEspacioMuestral ? "ACTIVADO" : "DESACTIVADO")}\n");

            Console.WriteLine("1. Activar detalle de espacio muestral y cálculos");
            Console.WriteLine("2. Desactivar detalle");
            Console.Write("\nSeleccione una opción: ");

            string opcion = Console.ReadLine();
            if (opcion == "1")
            {
                mostrarDetallesEspacioMuestral = true;
                Console.WriteLine("\n¡Detalle ACTIVADO para todos los experimentos!");
            }
            else if (opcion == "2")
            {
                mostrarDetallesEspacioMuestral = false;
                Console.WriteLine("\n¡Detalle DESACTIVADO!");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }


}
