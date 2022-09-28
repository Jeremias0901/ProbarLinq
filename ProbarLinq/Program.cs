using System;
using System.Collections.Generic;
using System.Linq;

namespace ProbarLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] valoresNumericos = new int[10] { 2, 4, 6, 8, 53, 21, 6, 95, 1, 0 }; // origen de datos → lista
            //List<int> numerosPares = new List<int>();

            //foreach (int numero in valoresNumericos)
            //{
            //    if(numero % 2 == 0)
            //    {
            //        numerosPares.Add(numero);
            //    }
            //}

            IEnumerable<int> numerosPares = from numero in valoresNumericos where numero % 2 == 0 select numero;
            // en el lenguaje Linq podemos utilizzar expresiones lambda

            Console.WriteLine("numero pares: ");
            foreach (int numero in numerosPares)
            {
                Console.WriteLine(numero);
            }
        }
    }
}
