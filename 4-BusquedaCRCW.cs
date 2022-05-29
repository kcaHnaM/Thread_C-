/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusquedaCREW
{

    class BusquedaCREW
    {
        static int[] L = new int[] {95,10,6,15};
        static int[] win = { 99, 99, 99, 99 };
        static int n = 4;

        static async Task Main(String[] args)
        {
            BusquedaCREW busqueda = new BusquedaCREW();

            Console.Clear();
            Console.WriteLine("\t\tBusqueda CRCW\n\n"
                                +"\tEquipo No Me Acuerdo xd\n");
            Console.WriteLine("\n\nEspera un segundo...");
            
            Console.WriteLine();
            await busqueda.task1();
            Console.WriteLine();
            await busqueda.task2();
            Console.WriteLine();
            await busqueda.task3();
            Console.WriteLine();

            Console.Write("\nPresione cualquier tecla para salir...");
            Console.ReadKey(true);
            Console.Clear();
        }
        public async Task task1()
        {
            await Task.Run(
                ()=>{
                    Thread.Sleep(1000);

                    Console.Clear();
                    Console.WriteLine("\t\tBusqueda EREW\n\n"
                                        +"\tEquipo No Me Acuerdo xd\n");
                    Console.Write("\n\tVector: \n");
                    repite(L);
                    Parallel.For(1, n, i => {
                        win[i] = 0;
                    });

                    Console.Write("\n\n\tPaso 1:\n");
                    repite(win);
                }
            );
        }
        public async Task task2()
        {
            await Task.Run(
                ()=>{
                    Thread.Sleep(1000);
                    Parallel.For(1, n, j => {
                        Parallel.For(1, j, i => {
                            if (L[i] > L[j]){
                                win[i] = 1;
                            }else {
                                win[j] = 1;
                            }
                        });
                    });

                    Console.Write("\n\tPaso 2:\n");
                    repite(win);
                }
            );
        }
        public async Task task3()
        {
            await Task.Run(
                ()=>{
                    Thread.Sleep(1000);
                    int indexMin = 0;
                    Parallel.For(1, n, i => {
                        if (win[i] == 0 || win[i] < 0)
                            indexMin = i;
                    });

                    Console.Write("\n\tPaso 3:\n\nIndice minimo: {0}", indexMin + 1);
                    Console.Write("\n\nResultado: {0}", L[indexMin]);
                }
            );
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