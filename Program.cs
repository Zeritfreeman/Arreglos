using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack03
{
    class Program
    {
        static void Main()
        {
            Random aleatorio = new Random();
            int jugador = 0, carta1 = 0, carta2 = 0, total = 0; //puntajeGanador = 0;
            Console.WriteLine("Ingrese el numero de jugadores");
            int n = int.Parse(Console.ReadLine());
            string respuesta = ""; //jugadorGanador = "";
            int[] puntaje = new int[n];
            string[] jugadores = new string[n];

            while (jugador < n) // Cumplir con la cantidad de jugadores
            {
                Console.WriteLine("Hola jugador numero " + (jugador + 1) + " como te llamas?");
                jugadores[jugador] =  Console.ReadLine();

                while (true) // Partida del jugador
                {
                    carta1 = aleatorio.Next(1, 11);
                    Console.WriteLine("Primera carta: " + carta1);
                    carta2 = aleatorio.Next(1, 11);
                    Console.WriteLine("Segunda carta: " + carta2);
                    total = carta1 + carta2;
                    Console.WriteLine("Su total es: " + total);

                    while (true)
                    {
                        if (total == 21) // Gana el jugador
                        {
                            Console.WriteLine("Ganaste");
                            break;
                        }
                        else if (total > 21) // Pierde el jugador
                        {
                            Console.WriteLine("Perdiste");
                            total = 0;
                            break;
                        }
                        else // Puede seguir jugando
                        {
                            Console.WriteLine("Desea continuar (s/n)");
                            respuesta = Console.ReadLine();
                            while (respuesta != "s" && respuesta != "n") // Responde algo incoerente
                            {
                                Console.WriteLine("Respuesta invalida, intentelo de nuevo");
                                respuesta = Console.ReadLine();
                            }
                        }
                        if (respuesta == "n") break; // No desea continuar

                        int carta3 = aleatorio.Next(1, 11); //Desdea continuar y se le asigna una nueva carta
                        Console.WriteLine("Siguiente carta: " + carta3);
                        total += carta3;
                        Console.WriteLine("Su total es: " + total);
                    }
                    puntaje[jugador] = total;
                    jugador++;
                    if (total == 0) break;
                    if (total == 21) break;
                    total = 0;
                    if (respuesta == "n") break;
                }
            }

            for (int u = 0; u < puntaje.Length; u++) //Asegurandose de que esten ordenados
            {
                for (int i = 0; i < puntaje.Length - 1; i++) //Intercambiando los valores de los arreglos
                {
                    if (puntaje[i] > puntaje[i + 1])
                    {
                        int tmp = puntaje[i + 1];
                        puntaje[i + 1] = puntaje[i];
                        puntaje[i] = tmp;

                        string tmp2 = jugadores[i + 1];
                        jugadores[i + 1] = jugadores[i];
                        jugadores[i] = tmp2;
                    }
                }
            }

            for (int i = 0; i < puntaje.Length; i++)
            {
                Console.WriteLine(jugadores[i] + " queda en el posicion numero " + (puntaje.Length - i) + " con " + puntaje[i] + " puntos");
            }
        /*

                    for (int i = 0; i < puntaje.Length; i++) //Revisar quien gano entre ellos
                    {
                        if (puntaje[i] > puntajeGanador && puntaje[i] <= 21)
                        {
                            puntajeGanador = puntaje[i];
                            jugadorGanador = jugadores[i];
                        }
                    }
                    Console.WriteLine("El ganador es el jugador numero " + jugadorGanador + " con " + puntajeGanador + " puntos");*/
        }
    }
}
