using System.Collections;
using System.ComponentModel;
using System.Xml.Serialization;

class Entrada
{
    private static Baraja baraja = new Baraja();

    public static void Main(String[] args)
    {
        Console.WriteLine("Bienvendo a la mesa de BlackJack");

        baraja.recogeBaraja();
    
        bool tuTurno = true;
        int eleccion = 1; //para continua jugando por defecto
        int tuTotal = 0;

        Console.WriteLine("\n     ~ Las cartas están siendo repartidas ~ ");
        Console.Write("\nTu tienes un:      ");
        int suma = jugar(true);
        Console.WriteLine("                 \u001B[34mLa banca tiene una carta boca abajo\u001B[0m");
        int sumaCasino = jugar();
        Console.Write("También tienes un: ");
        suma += jugar(true);
        Console.Write("                 \u001B[34mY la banca tiene un: \u001B[0m");
        sumaCasino += jugar(true);

        do{
            if(suma > 21)
            {
                Console.WriteLine("\n   Te has pasado! Pierdes la partida!\n");
                break;
            }
            else if(suma == 21)
            {
                if(sumaCasino == 21){
                    Console.WriteLine("\n   Tienes BlackJack! Pero la banca también. Gana la banca!\n");
                }else{
                    Console.WriteLine("\n   Tienes BlackJack! Ganas la partida!\n");
                }
                break;
            }
            else
            {
                if(!tuTurno && (sumaCasino < 17))
                {
                    sumaCasino += jugar();
                    Console.WriteLine($"\u001B[34mSuma Casino: {sumaCasino}\u001B[0m");
                }else
                {
                    Console.WriteLine("\n¿Qué quieres hacer?");
                    Console.WriteLine("1: Robar otra carta");
                    Console.WriteLine("2: Parar");
                    eleccion = Entrada.readNextInt();
                    if(eleccion == 2){
                        tuTurno = false;
                    }
                }
            }

            if(tuTurno)
            {
                Console.Write("Tu siguiente carta es:   ");
                suma += jugar(true);
                Console.WriteLine("Tu suma = "+suma);
            }
            else
            {
                Console.Write("       \u001B[34mLa banca: \u001B[0m");
                sumaCasino += jugar(true);
                Console.WriteLine("Suma casino = "+sumaCasino);
            }

        }while(eleccion == 1 || !tuTurno);
        Console.WriteLine("La suma del casino es: "+sumaCasino);
        Console.WriteLine("Tu suma es: "+tuTotal);
    }
    public static int jugar()
    {
        var cartaRobada = baraja.robarCarta();
        return cartaRobada.Value;
    }

    public static int jugar(bool print)
    {
        var cartaRobada = baraja.robarCarta();
        // Console.Write($"{cartaRobada.Value} ");
        Console.Write($"{cartaRobada.Key}\n");

        return cartaRobada.Value;
    }

    public static int readNextInt()
    {
        int numero;
        bool valido = false;

        do
        {
            string consola = Console.ReadLine();
            // Console.WriteLine();

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
