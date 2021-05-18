using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoHashing
{
    class Algoritmos
    {
        //Declaracion de Variables
        public string[] almacenamiento = new string[10];
        public int[] colision = new int[10];
        public bool lleno = false, bandera = false, continuar = true;
        public int pointeranterior, pointer;
        public int direccionanterior;
        char[] letras;
        string l;
        string ans;
        int direccion;

        //Método que prepara la cadena para darle un valor dirección.
        public void Cadena(string c)
        {
            //Asignación de Variables
            letras = new char[c.Length];
            letras = c.ToArray();
            direccion = 0;

            //Dividir Cadena en letras (De la A ala G únicamente en éste caso).
            for(int i = 0; i < c.Length; i++) 
            {
                //Convierte el arreglo char en string para compararlo.
                l = letras[i].ToString();
                if (l.Equals("A")) 
                {
                    direccion = direccion + 1;
                }
                else if (l.Equals("B")) 
                {
                    direccion = direccion + 2;
                }
                else if (l.Equals("C"))
                {
                    direccion = direccion + 3;
                }
                else if (l.Equals("D"))
                {
                    direccion = direccion + 4;
                }
                else if (l.Equals("E"))
                {
                    direccion = direccion + 5;
                }
                else if (l.Equals("F"))
                {
                    direccion = direccion + 6;
                }
                else if (l.Equals("G"))
                {
                    direccion = direccion + 7;
                }
            }
            //Llamada Método Agregar.
            Agregar(c,direccion);
        }
        //Método que agrega Cadenas al arreglo
        public void Agregar(string c, int direccion)
        {
            //Llamada a Método ComprobarEspacio.
            ComprobarEspacio();
            //Compara si el arreglo aún no está lleno.
            if (lleno == false)
            {
                //Da a entender que la cadena aún no ha sido asignada.
                bandera = false;
                //Compara si la dirección solicitada no está ocupada por otra cadena.
                if (almacenamiento[direccion] == null)
                {
                    almacenamiento[direccion] = c;
                }
                else
                {
                    //Busca un espacio vacío en la parte superior del arreglo para asignar la cadena.
                    int i = direccion;
                    while (bandera == false && i < almacenamiento.Length)
                    {
                        i++;
                        if (almacenamiento[i] == null)
                        {
                            almacenamiento[i] = c;
                            bandera = true;
                            pointer = i;
                        }
                    }
                    //Busca un espacio vacío en la parte de inferior del arreglo para asignar la cadena.
                    i = 0;
                    while (bandera == false && i < almacenamiento.Length)
                    {
                        i++;
                        if (almacenamiento[i] == null)
                        {
                            almacenamiento[i] = c;
                            bandera = true;
                            pointer = i;
                        }
                    }
                    //Compara si hubo colisión con la cadena anterior
                    if (colision[direccion] == 0)
                    {
                        //Asigna la colisión y la nueva posición de la cadena actual.
                        colision[direccion] = pointer;
                        pointeranterior = pointer;
                        direccionanterior = direccion;
                    }
                    else
                    {
                        //Compara si la dirección anterior es diferente a la dirección actual.
                        if(direccionanterior!=direccion) 
                        {
                            //Asigna la colisión y la nueva posición de la cadena actual.
                            colision[direccion] = pointer;
                            pointeranterior = pointer;
                            direccionanterior = direccion;
                        }
                        else 
                        {
                            //Asigna una continuación a la colisión de la cadena anterior con misma dirección.
                            colision[pointeranterior] = pointer;
                            pointeranterior = pointer;
                        }
                    }
                }
                //Despliega mensaje de que una cadena fue agregada exitosamente
                Console.WriteLine("");
                Console.WriteLine("¡Cadena agregada exitosamente!");
                Console.WriteLine("La dirección es: " + direccion);
            }
            else
            {
                //Despliega mensaje de que el arregloya ha sido llenado
                Console.WriteLine("El arreglo está lleno");
            }
        }
        //Método que comprueba si el arreglo está lleno.
        public void ComprobarEspacio()
        {
            lleno = true;
            for(int i=1; i<almacenamiento.Length; i++) 
            {
                if (almacenamiento[i]==null) 
                {
                    lleno = false;
                }  
            }
        }
        //Método que imprime el arreglo y sus colisiones.
        public void Imprimir()
        {
            Console.WriteLine();
            Console.WriteLine("////////////////////////");
            Console.WriteLine("[Posición]  "+"[Cadena] ");
            for (int  i=1; i < almacenamiento.Length; i++) 
            {
                if(colision[i] == 0) 
                {
                    Console.WriteLine("   [" + (i) + "]      " + almacenamiento[i]);
                }
                else 
                {
                    Console.WriteLine("   [" + (i) + "]      " + almacenamiento[i] + " [" + colision[i] + "]");
                }
            }
        }
        public void Busqueda(int a) 
        {
            ans = "n";
            continuar = true;
            while (continuar)
            {
                if(colision[a] == 0) 
                {
                    Console.WriteLine("   [" + (a) + "]      " + almacenamiento[a]);
                    ans = "y";
                }
                else 
                {
                    Console.WriteLine("   [" + (a) + "]      " + almacenamiento[a] + " [" + colision[a] + "]");
                    a = colision[a];

                    Console.Write("¿Es la cadena que buscaba? (y/n): ");
                    ans = Console.ReadLine();
                }
                if (ans.Equals("y"))
                {
                    continuar = false;
                }
            }
        }
    }
}
