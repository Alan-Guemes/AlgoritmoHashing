using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoHashing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaración de Variables
            int apuntador;
            bool continuar = true;
            string opc, cadena;

            //Menú
            try
            {
                //Constructor Clase Algoritmos
                Algoritmos alg = new Algoritmos();
                while (continuar)
                {
                    Console.Clear();
                    Console.WriteLine("Algoritmo Hashing");
                    Console.WriteLine("");
                    Console.WriteLine("Menú");
                    Console.WriteLine("A- Ingresar una cadena al arreglo.");
                    Console.WriteLine("B- Imprimir el arreglo.");
                    Console.WriteLine("C- Buscar en el arreglo");
                    Console.WriteLine("D- Salir");

                    Console.Write("Ingrese una opción: ");
                    opc = Console.ReadLine();

                    switch (opc)
                    {
                        case "A":
                            Console.Write("Ingrese una cadena(A-G): ");
                            cadena = Console.ReadLine();
                            alg.Cadena(cadena);
                            break;
                        case "B":
                            alg.Imprimir();
                            break;
                        case "C":
                            Console.Write("Ingrese una dirección: ");
                            apuntador = int.Parse(Console.ReadLine());
                            alg.Busqueda(apuntador);
                            break;
                        case "D":
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Ingrese una opción correcta.");
                            break;
                    }
                    Console.ReadKey();
                }
                //Atrapa Errores
            } catch (Exception e) { Console.WriteLine("Ocurrió algo inesperado: " + e); };
            Console.ReadKey();
        }
    }
}
