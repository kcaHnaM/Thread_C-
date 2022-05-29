/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrdenamientoEREW;
public class Ordenamiento_EREW
{

    public static void Main(string[] args)
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("\n\t\tPráctica 6: ORDENAMIENTO ODD-EVEN (EREW)");
        Console.WriteLine("\t\tEquipo 6: ");
        Console.WriteLine("\t\tJuan Hereiva | Octavio Rodríguez | Isaac Vazquez\n");
        Console.WriteLine("----------------------------------------------------------\n");
        int g;
        int[] L = new int[17];
        //int[] L = { 0, 16, 22, 35, 40, 53, 66, 70, 85, 15, 18, 23, 55, 60, 69, 72, 78 };
        g = 16;

        // int[] L = new int[17];
        for (int f = 1; f <= 16; f++)
        {
            Console.Write("Ingrese el valor " + f + ": ");
            String linea;
            linea = Console.ReadLine()+"";
            L[f] = int.Parse(linea);
        }

        Console.WriteLine();
        Console.WriteLine("Inicial:");
        MuestraVec(g, L);
        Console.WriteLine("\nOrdenamiento: \n");
        mergeSort(L, 1, g);
        Console.WriteLine("\n");
        Console.WriteLine("Vector final:");
        MuestraVec(g, L);
        Console.ReadKey();
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
        MuestraVec(15, L);
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

            //intercala(L,odd,even,aux2,n);

            Parallel.For(0, 1, f => {
                for (int i = 1; i <= (n / 2); i++)
                {
                    intercala(L, odd, even, i, aux2, n);
                }
            });


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

    public static void intercala(int[] m, int[] odd, int[] even, int i, int aux, int n)
    {
        Parallel.For(0, 1, f => {
            for (int i = 1; i <= (n/2); i++)
            {
                m[(2 * i) - 1 + aux] = odd[i];
                m[(2 * i) + aux] = even[i];
            }
        }
        );
        //m[(2 * i) - 1 + aux] = odd[i];
        //m[(2 * i) + aux] = even[i];
    }

    public static void MuestraVec(int g, int[] L)
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
}*/

//Notas correciones
//MargeEven va fuera del parallel invoke y no se usa ninguno secuencial y en intercala va un parallel for