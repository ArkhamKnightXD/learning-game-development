using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int valor1, valor2;
            
            Console.WriteLine("Hello World!");
            
            // Esto sirve para hacer que el usuario tenga que  presionar una tecla para poder avanzar
            Console.ReadKey();
            
            Console.WriteLine("\n");
            
            Console.WriteLine("Digite el primer numero: ");
            
                
            // De esta forma capturo el numero que el usuario digitara lo leo y lo convierto a entero ya que console.readline
            // me captura el dato pero me lo devuelve en string y luego de esto almaceno en valor1
            valor1 = Convert.ToInt32(Console.ReadLine());
            
            
            Console.WriteLine("Digite el segundo numero: ");

            valor2 = Convert.ToInt32(Console.ReadLine());

            valor1 += valor2;
            
            
            // para mostrar el texto junto a la variable hay que concatenar con el signo +
            Console.WriteLine("El resultado de la suma es: " + valor1);


            Console.ReadKey();
            
            Console.WriteLine("\n");
            
            

            Console.WriteLine("Ejemplo de if y else \n");

            if (valor1 > 10)
            {
                Console.WriteLine("El valor de la suma es mayor de 10 por lo tanto se le restara 2");

                valor1 -= 2;
            }

            if (valor1 < 10)
            {
                Console.WriteLine("El valor de la suma es menor de 10 por lo tanto se le sumara 2");
                valor1 += 2;
            }
            

            Console.WriteLine("Nuevo valor: " + valor1);

            
            Console.ReadKey();
            
            Console.WriteLine("\n");
            
            
            
            Console.WriteLine("Ejemplo de For en c#");
            
            
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
            

            Console.ReadKey();
            
            Console.WriteLine("\n");
            
            
            
            Console.WriteLine("Ejemplo de Foreach y listas en c#");
            
            List<int> list = new List<int>();
            
            list.Add(4);
            list.Add(7);
            list.Add(9);


            foreach (int recorredor in list)
            {
                Console.WriteLine("Los numeros almacenados en la lista son: " + recorredor);
            }

        }
    }
}