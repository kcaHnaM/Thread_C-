namespace BusquedaEREW
{
    class BusquedaEREW
    {
        public static void Main(string[] args){
            
            int[] L = new int[16]; //{10,5,-9,0,8,25,30,9,-3,56,-25,-2,3,4,-7,11};
            int numBusc = 0;

            Console.Clear();
            Console.WriteLine("\t\tBusqueda EREW\n\n"
                                +"\tEquipo No Me Acuerdo xd\n");
            
            for(int i = 0; i < L.Length; i++){
                Console.Write("Ingresa valor {0}: ",i+1);
                String aux = Console.ReadLine() + "";
                L[i] = int.Parse(aux);
            }
            Console.Write("\nIngresa Numero A Buscar: ");
            numBusc = int.Parse(Console.ReadLine()+"");

            Console.WriteLine("\nEspera un segundo...");

            BusquedaEREW be = new BusquedaEREW();
            int resultadoBusqueda = be.searchEREW(L, numBusc);

            Console.Write("El numero está en: {0}",be.searchEREW(L,numBusc));
        }

        public static void broadcast( int[] Temp, int x )
        {
            Temp[0] = x;
            int n = Temp.Length;
            int k = (int)(Math.Log(n,2));

                for ( int i = 1; i <= k; i++ ){
                    Parallel.For( (int)(Math.Pow(2,i-1)), (int)(Math.Pow(2,i)), j => {
                        Temp[j] = Temp[j-(int)(Math.Pow(2,i-1))];
                    } );
                }
        }

        public int min(int[] Temp)
        {
            int n = Temp.Length;
            int k = (int)(Math.Log(n,2));
            int[] Temp2 = new int[Temp.Length];

            for( int j = 1; j <= k; j++ ){
                Parallel.For( 0, n , i => {
                    if ( i < n/(int)(Math.Pow(2,j)) ) {
                        if ( Temp[ 2*i+1 ] > Temp[ 2*i ] ) {
                            Temp2[i] = Temp[2*i];
                        } else {
                            Temp2[i] = Temp[2*i+1];
                        }
                    } else {
                        Temp2[i] = 0;
                    }
                } );
                Parallel.For(0,n,count => {Temp[count]=Temp2[count]; });
            }
            return Temp[0];
        }

        public int searchEREW(int[] L, int x){
            int n = L.Length;
            int[] Temp = new int[L.Length];
 broadcast(Temp,x);

                Parallel.For(0, n, i =>{
                    if ( L[i] == Temp[i] ){
                        Temp[i] = (i+1);
                    } else {
                        Temp[i] = int.MaxValue;
                    }
                });
        return min(Temp);
        }
    }
}