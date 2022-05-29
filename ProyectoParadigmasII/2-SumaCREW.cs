using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sumaCREW
{
    internal class SumaCREW
    {
        int[] A = {0,5,2,10,1,8,12,7,3};
        int n = 8;
        int x;
        static async Task Main(String[] args)
        {
            SumaCREW suma = new SumaCREW();

            Console.Clear();
            Console.WriteLine("\t\tSUMA EREW\n\n"
                                +"\tEquipo No Me Acuerdo xd\n");

            Console.WriteLine("Espera un segundo...");
            
            await suma.Suma();

            Console.Write("\nPresione cualquier tecla para salir...");
            Console.ReadKey(true);
            Console.Clear(); 
        }
        public async Task Suma() {
            await Task.Run(
                async ()=>{
                    Thread.Sleep(2000);
                    Console.Clear();
                    x = (int)(Math.Log(n, 2));
                    await imprimir();
                    {
                    int g = A.Length;
                    int[] B = new int[g];

                    for ( int i = 1; i <= (int)(Math.Log(n,2)); i++ ) {
                        Parallel.For( 0, g, j => {
                            if ( j >= (int)(Math.Pow(2,i-1)) ) {
                                B[j] = A[j] + A[ j - (int)(Math.Pow(2,i-1)) ];
                            } 
                            else{
                                B[j] = A[j];
                            }
                        });
                    Parallel.For(0,g,count => {
                            A[count]=B[count];
                    });
                    Console.WriteLine();
                    await imprimir();
                    }
                }
                Console.Write("\n");
                Console.WriteLine("\t\tLa suma es: " + A[n]);
                }
            );
        }

        public async Task imprimir() {
            await Task.Run(
                ()=>{
                Console.Write("\t");
                foreach (int z in A)
                {
                    if(z != 0){
                        Console.Write("["+z+"]");
                    }
                }
                Console.WriteLine();
                }
            );
        }
    }
}