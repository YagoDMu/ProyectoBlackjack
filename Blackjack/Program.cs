using System.Collections;
using System.ComponentModel;
using System.Xml.Serialization;

class Entrada
{


    public static void Main(String[] args)
    {

        Baraja baraja = new Baraja();

        baraja.recogeBaraja();


        Console.WriteLine("Bienvendo a la mesa de BlackJack");
        bool otra = false;
        bool otraCasino = false;
        int eleccion;
        int suma = 0;
        int sumaCasino = 0;
        int tuTotal = 0;
        int casinoTotal=0;

        do{
            var cartaRobada = baraja.robarCarta();

            suma += cartaRobada.Value;

            Console.WriteLine(cartaRobada.Key);
            Console.WriteLine("Suma: " + suma);

            if(suma > 21)
            {
                Console.WriteLine("Te has pasado! Pierdes la partida!");
                break;
            }


            Console.WriteLine("¿Qué quieres hacer?");
            Console.WriteLine("1: Robar otra carta");
            Console.WriteLine("2: Parar");
            eleccion = Entrada.readNextInt();
            
            if(eleccion == 1)
            {
                otra = true;
            } else
            {
                otra = false;
                tuTotal = suma;
            }

        }while(otra);

        do{
            var cartaRobada = baraja.robarCarta();

            sumaCasino += cartaRobada.Value;

            Console.WriteLine(cartaRobada.Key);
            Console.WriteLine("Suma: " + sumaCasino);

            if(sumaCasino < 17)
            {
                otraCasino = true;
            } else
            {
                otraCasino = false;
                casinoTotal = sumaCasino;
            }

        }while(otraCasino);

        Console.WriteLine();
        Console.WriteLine("Tu suma es: "+tuTotal);
        Console.WriteLine();
        Console.WriteLine("La suma del casino es: "+casinoTotal);
        

    }

    public static int readNextInt()
    {
        int numero;
        bool valido = false;

        do
        {
            string consola = Console.ReadLine();
            Console.WriteLine();

            valido = int.TryParse(consola, out numero);

            if(!valido)
            {
                Console.WriteLine("Entrada no válida");
                Console.WriteLine();
            }
            
        }while (!valido);

        return numero;
    }

    






}