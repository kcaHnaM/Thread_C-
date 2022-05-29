/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace parallelfor
{

    class MainClass
    {
        static int[] L1 = new int[4]; // = { 95, 10, 6, 15 };
        static int[] win = { 99, 99, 99, 99 };
        static int n = 4;

        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("\t\tBusqueda EREW\n\n"
                                +"\tEquipo No Me Acuerdo xd\n");
            Console.WriteLine("\n\nEspera un segundo...");

            for (int f = 0; f <= 3; f++)
            {
                Console.Write("Ingrese el valor " + (f+1) + ": ");
                String linea;
                linea = Console.ReadLine()+"";
                L1[f] = int.Parse(linea);
            }
            Console.Write("\nVector: \n");
            repite(L1);
            Console.WriteLine();
            Console.ReadKey();
            Task t = new Task(() => { tarea1(); });
            Task t1 = new Task(() => { tarea2(); });
            Task t2 = new Task(() => { tarea3(); });
            t.Start();
            t.Wait();
            Console.WriteLine();
            Console.ReadKey();
            t1.Start();
            t1.Wait();
            Console.WriteLine();
            Console.ReadKey();
            t2.Start();
            t2.Wait();
            Console.WriteLine();
            Console.ReadKey();
        }
        public static void tarea1()
        {
            Parallel.For(1, n, i => {
                win[i] = 0;
            });

            Console.Write("\nPaso 1: \n");
            repite(win);
        }
        public static void tarea2()
        {
            Parallel.For(1, n, j => {
                Parallel.For(0, j, i => {
                    if (L1[i] > L1[j]){
                        win[i] = 1;
                        Console.WriteLine("\n"+$"Thread = {Thread.CurrentThread.ManagedThreadId}\n");
                }
                else {
                    win[j] = 1;
                    Console.WriteLine("\n"+$"Thread = {Thread.CurrentThread.ManagedThreadId}\n");
                }
                });
            });

            Console.Write("\nPaso 2: \n");
            repite(win);
        }
        public static void tarea3()
        {
            int indexMin = 0;
            Parallel.For(1, n, i => {
                if (win[i] == 0)
                    indexMin = i;
            });

            Console.Write("\nPaso 3: \nIndice minimo: {0}", indexMin + 1);
            Console.Write("\nResultado: {0}", L1[indexMin]);
            Console.WriteLine("\n Pulse enter para continuar");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static void repite(int[] aux)
        {
            Console.Write("[");
            for (int i = 0; i < n; i++)
            {
                if (i == n - 1)
                    Console.Write("{0}", aux[i]);
                else
                    Console.Write("{0}, ", aux[i]);
            }
            Console.Write("]");
        }
    }
}*/