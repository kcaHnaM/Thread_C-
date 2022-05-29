/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrdenamientoCRCW
{
    class OrdenamientoCRCW
    {
        static int[] L = { 95, 10, 6, 15 };
        static int n = 4;
        static int[] win = { 99, 99, 99, 99 };
        static int[] L2 = { 0, 0, 0, 0 };


        //Programa Principal
        static async Task Main(String[] args)
        {
            OrdenamientoCRCW ocrcw = new OrdenamientoCRCW();
            Console.Clear();
            Console.WriteLine("\t\tSUMA EREW\n\n"
                                +"\tEquipo No Me Acuerdo xd\n");

            Console.WriteLine("Espera un segundo...");

            Console.WriteLine();
            await ocrcw.task1();
            Console.WriteLine();
            await ocrcw.task2();
            Console.WriteLine();
            await ocrcw.task3();
            Console.WriteLine();

            Console.Write("\nPresione cualquier tecla para salir...");
            Console.ReadKey(true);
            Console.Clear();
        }


        //Funciones
        public async Task task1()
        {
            await Task.Run(
                async()=>{
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("\t\tSUMA EREW\n\n"
                                +"\tEquipo No Me Acuerdo xd\n");
                    Console.Write("\n\tVector Inicial:\t");
                    ShowVector(L);
                    Parallel.For(0, n, i =>
                    {
                        win[i] = 0;
                    });
                    Console.Write("\n\tPaso 1:\t\t");
                    var task = new Task(
                        ()=>{
                            ShowVector(win);
                        }
                    );
                    task.Start();
                    await task;
                }
            );

        }
        public async Task task2()
        {
            await Task.Run(
                async()=>{
                    Thread.Sleep(1000);
                    Parallel.For(0, n, i =>
                    {
                        Parallel.For(0, n, j =>
                        {
                            if (L[i] > L[j])
                            {
                                win[i] = win[i] + 1;
                            }
                            //else win[j] = win[j] + 1;
                        });
                    });
                    Console.Write("\n\tPaso 2:\t\t");
                    var task = new Task(
                        ()=>{
                            ShowVector(win);
                        }
                    );
                    task.Start();
                    await task;
                }
            );
        }
        public async Task task3()
        {
            await Task.Run(
                async()=>{
                    Thread.Sleep(1000);
                    Parallel.For(0, n, i=> {
                        L2[win[i]] = L[i];
                    });
                    Console.Write("\n\tRESULTADO:\t");
                    var task = new Task(
                        ()=>{
                            ShowVector(L2);
                        }
                    );
                    task.Start();
                    await task;
                }
            );
        }

        public static void ShowVector(int[] aux)
        {
            int n = aux.Length;
            Console.Write("[");
            foreach (int z in aux){
                Console.Write("{0} ", z);
            }
            Console.Write("]\n");
        }
    }
}*/