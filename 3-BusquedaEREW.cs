using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaEREW
{
    internal class BusquedaEREW
    {
        //Programa Principal
        static async Task Main(String[] args)
        {
            
            int i;
            int[] L = new int[] {-2,-1,23,-4,2,5,-2,0,5,1,5,-5,8,5,3,-2};
            int[] temp = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int x = 5;
            int n = L.Length;
            double lg = (Math.Log((double)n / (Math.Log(2)) + 3));

            Console.Clear();
            Console.WriteLine("\t\tBusqueda EREW\n\n"
                                +"\tEquipo No Me Acuerdo xd\n");

            Console.WriteLine("Espera un segundo...");

            /**
            *
            *   Creamos las TAREAS para una mejor gestión de los procesos
            *
            */

            var task1 = new Task( // Primer Tarea
                ()=>{
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("\t\tBusqueda EREW\n\n"
                                        +"\tEquipo No Me Acuerdo xd\n");
                    Console.WriteLine("\nOriginal: ");
                    printVector(ref L);
                    Console.WriteLine();
                }
            ); // Finaliza la primer tarea

            
            var task2 = new Task( // Segunda Tarea
                ()=>{
                    Thread.Sleep(2000);
                    //Broadcast
                    for (i = 0; i <= Math.Log(n, 2); i++)
                    {
                        var t = Task.Factory.StartNew(() => Broadcast(x, i, ref temp));
                        t.Wait();
                    }
                    Console.WriteLine("\nBroadcast: ");
                    printVectorTemp(ref temp);
                    Console.WriteLine();
                }
            ); // Finzaliza la segunda tarea

            var task3 = new Task( // Tercer tarea
                ()=>{
                    Thread.Sleep(2000);
                    //Search_EREW
                    Console.WriteLine("\nSearch EREW: ");
                    for (i = 1; i <= n - 1; i++)
                    {
                        var t = Task.Factory.StartNew(() => searchMin(i, ref L, ref temp));
                        t.Wait();

                        printVectorTemp(ref temp);
                        Console.WriteLine();
                    }
                }
            ); // Finaliza la tercer tarea

            var task4 = new Task( // Cuarta y última Tarea
                ()=>{
                    Thread.Sleep(2000);
                    //Funcion Minima
                    for (i = 0; i <= n + 1; i++)
                    {
                        var t = Task.Factory.StartNew(() => getMin(n, ref temp));
                        t.Wait();
                    }
                    Console.WriteLine("\n\nFuncion Minima: ");
                    printVectorTemp(ref temp);
                    Console.WriteLine("\n\nResultado: ");
                    MinPram(x, n, ref temp);
                }
            ); // Finaliza la cuarta Tarea y la creación de tareas

            /**
            *
            * Se inician las tareas para ejecutarlas secuancialmente
            *
            */
            task1.Start();
            await task1;
            task2.Start();
            await task2;
            task3.Start();
            await task3;
            task4.Start();
            await task4;
            
            Console.Write("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
            Console.Clear();
        }

        //Función Broadcast (inicia aquí)
        static void Broadcast(int x, int i, ref int[] temp)
        {
            int n = temp.Length - 1;
            for (int j = 1; j <= (int)(Math.Pow(2, i - 1) + 1); j++)
            {
                if (j <= (int)(Math.Pow(2, i - 1) + 1))
                {
                    temp[j] = x;
                }
            }
        } // Termina aquí la función broadcast

        //Función para buscar el minimo
        static void searchMin(int i, ref int[] L, ref int[] temp)
        {
            if (L[i] == temp[i])
            {
                temp[i] = i;
            }
            else
            {
                temp[i] = 0;
            }

        } // termina aquí la función para buscar el minimo

        //Función para obtener el minimo
        static void getMin(int n, ref int[] temp)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (temp[i] == 0)
                {
                    temp[i] = temp[i + 1];
                    temp[i + 1] = 0;
                }
                else
                {
                    if (temp[i] < temp[i + 1])
                    {
                        temp[i + 1] = 0;
                    }
                }

            }

        } // Aquí termina la función para obtener el minimo
        static void MinPram(int x, int n, ref int[] temp)
        {
            int h = 1;

            while (h < temp.Length)
            {
                if (temp[h] != 0)
                {
                    x = temp[h];
                    break;
                }
                h = h + 1;
            }
            x = x + 1;
            Console.WriteLine("Está en la posicion: " + x);
        }

        // Muestra vector inicial
        static void printVector(ref int[] L)
        {
            int k;
            int n = L.Length;
            for (k = 0; k <= n - 1; k++)
            {
                Console.Write(L[k] + " ");
            }

        } // Finaliza mostrar vector inicial

        // Muestra vector final
        static void printVectorTemp(ref int[] temp)
        {
            int k;
            int n = temp.Length;
            for (k = 0; k <= n - 1; k++)
            {
                Console.Write(temp[k] + " ");
            }

        } // Termina función para mostrar el vector final
    }
}