using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack02
{
    class Program
    {
        static void Main()
        {
            Random aleatorio = new Random();
            int jugador = 0, carta1 = 0, carta2 = 0, total = 0, puntajeGanador = 0, jugadorGanador = 0;
            Console.WriteLine("Ingrese el numero de jugadores");
            int n = int.Parse(Console.ReadLine());
            string respuesta = "";
            int[] puntaje = new int[n];

            while (jugador < n) // Cumplir con la cantidad de jugadores
            {
                Console.WriteLine("Hola jugador numero " + (jugador + 1));

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
                    if (total > 21) break;
                    if (total == 21) break;
                    total = 0;
                    if (respuesta == "n") break; 
                }           
            }
            for (int i = 0; i < puntaje.Length; i++) //Revisar quien gano entre ellos
            {
                if (puntaje[i] > puntajeGanador && puntaje[i] <= 21)
                {
                    puntajeGanador = puntaje[i];
                    jugadorGanador = i;
                }
            }
            Console.WriteLine("El ganador es el jugador numero " + (jugadorGanador + 1) + " con " + puntajeGanador + " puntos");
        }
    }
}
