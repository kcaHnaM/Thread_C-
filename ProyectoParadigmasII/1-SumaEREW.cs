using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SumaEREW
{
    internal class sumaEREW
    {
        int[] A = { 0, 5, 2, 10, 1, 8, 12, 7, 3 };
        int n = 8; 
        int i, x;

        static async Task Main(String[] args)
        {
            sumaEREW suma = new sumaEREW();
            
            Console.Clear();
            Console.WriteLine("\t\tSUMA EREW\n\n"
                                +"\tEquipo No Me Acuerdo xd\n");

            Console.WriteLine("Espera un segundo...");
            await suma.Suma();
        }

        public async Task Suma() {
            await Task.Run(
                async ()=>{
                    Thread.Sleep(1000);
                    x = (int)(Math.Log(n, 2));

                    Console.Clear();
                    Console.WriteLine("\t\tSUMA EREW\n\n"
                                        +"\tEquipo No Me Acuerdo xd\n");

                    Console.Write("\t\tVector Inicial / Tarea 1:\n\t");
                    await printVector();

                    for (i = 1; i <= x; i++)
                    {
                        Parallel.For(1, n/2 + 1, j => {  
                            if (((2 * j) % ((int)(Math.Pow(2, i)))) == 0)
                            {
                                A[j * 2] = A[j * 2] + A[(j * 2) - (int)(Math.Pow(2, i - 1))];
                            }
                        });
                        if( i < x){
                            Console.Write("\n\t\tVector De Tarea {0}:\n\t",i+1);
                            await printVector();
                        }else{
                            Console.Write("\n\t\tVector Final / Tarea {0}:\n\t",i+1);
                            await printVector();
                        }
                    }

                    Console.WriteLine("\nSuma Total: " + A[n]);
                    Console.Write("\nPresione cualquier tecla para salir...");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            );
        }
        public async Task printVector()
        {
            await Task.Run(
                ()=>{
                    Console.Write("[");
                    foreach (int z in A){
                        Console.Write("{0} ", z);
                    }
                    Console.Write("]\n");
                }
            );
        }
    }
}