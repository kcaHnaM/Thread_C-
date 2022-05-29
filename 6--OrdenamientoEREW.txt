using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrdenamientoEREW;
internal class OrdenamientoEREW
{

    static async Task Main(String[] args)
    {
        
        int[] L = {0,16,22,35,40,53,66,70,85,25,28,33,55,60,69,72,78};
        int a = 16;

        var task1 = new Task(
            ()=>{
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("\t\tBusqueda EREW\n\n"
                                +"\tEquipo No Me Acuerdo xd\n");
                Console.WriteLine("\n\t\tVector Inicial:\n");
                ShowVect(a, L);
        });
        var task2 = new Task(
            ()=>{
                Thread.Sleep(1000);
                Console.WriteLine("\n\t\tComienza A Ordenar:\n");
                mergeSort(L, 1, a);
            }
        );
        var task3 = new Task(
            ()=>{
                Thread.Sleep(1000);
                Console.WriteLine("\n\t\tVector Final:\n");
                ShowVect(a, L);
            }
        );

        Console.Clear();
            Console.WriteLine("\t\tBusqueda EREW\n\n"
                                +"\tEquipo No Me Acuerdo xd\n");

            Console.WriteLine("Espera un segundo...");

        task1.Start();
        await task1;
        task2.Start();
        await task2;
        task3.Start();
        await task3;
        
        Console.Write("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
        Console.Clear();
    }

    public static void mergeSort(int[] L, int ini, int fin)
    {
        int centro = (fin + ini) / 2;
        if (ini < fin)
        {
            Parallel.Invoke(() => {
                mergeSort(L, ini, centro);
                mergeSort(L, centro + 1, fin);
            });
            oddEvenMerge(L, ini, fin);
        }
    }

    public static void interchange(int[] L, int a, int b)
    {
        int aux;
        aux = L[a];
        L[a] = L[b];
        L[b] = aux;
        ShowVect(15, L);
    }
    public static void oddEvenSplit(int[] L, int[] odd, int[] even, int ini, int fin)
    {
        int cont1 = 1, cont2 = 1;
        Parallel.For(0, 1, f => {
            for (int i = ini; i <= fin; i++)
            {
                if ((i % 2) == 0)
                {
                    even[cont1] = L[i];
                    cont1++;
                }
                else
                {
                    odd[cont2] = L[i];
                    cont2++;
                }
            }
        });
    }

    public static void oddEvenMerge(int[] L, int ini, int fin)
    {
        int n = fin - ini + 1;
        int[] odd = new int[16];
        int[] even = new int[16];
        if (n == 2)
        {
            if (L[ini] > L[fin])
            {
                interchange(L, ini, fin);
            }
        }
        else
        {

            oddEvenSplit(L, odd, even, ini, fin);
            Parallel.Invoke(() => {
                oddEvenMerge(odd, 1, (n / 2));
                oddEvenMerge(even, 1, (n / 2));
            });
            int aux2 = fin - n;

            intercala(L,odd,even,aux2,n);

            /*Parallel.For(0, 1, f => {
                for (int i = 1; i <= (n / 2); i++)
                {

                    intercala(L, odd, even, i, aux2, n);
                }
            });*/


            for (int i = ini; i <= ((fin / 2) - 1); i++)
            {
                int a, b;
                a = 2 * i;
                b = (2 * i) + 1;
                if ((L[a]) > (L[b]))
                {
                    interchange(L, a, b);
                }
            }
        }

    }
    public static void intercala(int[] m, int[] odd, int[] even, int aux, int n)
    {
        Parallel.For(0, 1, f => {
                for (int i = 1; i <= (n / 2); i++)
                {

                    m[(2 * i) - 1 + aux] = odd[i];
                    m[(2 * i) + aux] = even[i];
                }
            }
        );
        //m[(2 * i) - 1 + aux] = odd[i];
        //m[(2 * i) + aux] = even[i];
    }

    public static void ShowVect(int g, int[] L)
    {
        Console.Write("[");
        for (int i = 1; i <= g; i++)
        {
            if (i < g)
            {
                Console.Write(L[i] + ",");
            }
            else
            {
                Console.Write(L[i]);
            }
        }
        Console.Write("]\n\n");

    }
}