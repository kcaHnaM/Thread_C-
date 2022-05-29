/*namespace BusquedaEREW
{
    class MainClass
    {
        public void imprimirArreglo(int[] A)
        {
            Console.Write("[ ");
            for (int i=0; i < A.Length; i++) {
                Console.Write("{0}", A[i]);
                if ( i < A.Length - 1 ) Console.Write(", ");
            }
            Console.Write(" ]\n\n");
        }

        public void broadcast( int[] Temp, int x )
        {
            Temp[0] = x;
            int n = Temp.Length;
            int k = (int)(Math.Log(n,2));

            for ( int i = 1; i <= k; i++ ){
                Parallel.For( (int)(Math.Pow(2,i-1)), (int)(Math.Pow(2,i)), j => {
                    Temp[j] = Temp[j-(int)(Math.Pow(2,i-1))];
                } );
                // imprimirArreglo(Temp);
            }
        }

        public int minimo(int[] Temp)
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
                // imprimirArreglo(Temp);
            }
            return Temp[0];
        }

        public int busquedaEREW(int[] L, int x){
            int n = L.Length;
            int[] Temp = new int[L.Length];

            broadcast(Temp,x);

            Parallel.For(0, n, i =>{
                if ( L[i] == Temp[i] ){
                    Temp[i] = (i+1);
                } else {
                    Temp[i] = int.MaxValue;
                }
            } );
            // imprimirArreglo(Temp);

            return minimo(Temp);
        }

        public static void Main(string[] args){
            MainClass p = new MainClass();
            
            int[] L = new int[16] {2,-1,23,-4,2,5,-2,0,7,1,5,-5,8,5,3,-2};
            int numeroPorBuscar = 7;

            Console.Write("El numero se encuentra en la posicion " + p.busquedaEREW(L,numeroPorBuscar) );
            Console.ReadKey(true);
        }

    }
}*/