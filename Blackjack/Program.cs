using System.Collections;
using System.ComponentModel;
using System.Xml.Serialization;

class Entrada
{
    private static Baraja baraja = new Baraja();

    public static void Main(String[] args)
    {
        int continuar;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("\n      Bienvendo a la mesa de BlackJack");

        do{
            baraja.recogeBaraja();
            // baraja.mostrarBaraja();
            bool blackJackNatural = false, blackJackBanca = false;
            bool tuTurno = true;
            int eleccion = 1; //para continua jugando por defecto

            Console.WriteLine("\n   ~ Las cartas están siendo repartidas ~");
            Console.Write("\n\u001B[32mTienes un: \u001B[0m");
            int suma = jugar(true);
            if(suma == 1||suma == 10){
                blackJackNatural = true;
            }
            Console.Write("         \u001B[34mLa banca tiene:\u001B[0m  |?|");
            KeyValuePair<string,int> cartaRobada = jugar(true, true);
            int sumaCasino = cartaRobada.Value;
            Console.Write("    -->   (cartaRobada) = "+cartaRobada.Key);
            if(sumaCasino == 1||sumaCasino == 10){
                blackJackBanca = true;
            }
            Console.Write("\n\u001B[32mTienes un: \u001B[0m");
            suma += jugar(true);
            if(blackJackNatural && suma == 11){
                Console.WriteLine("\n   \u001B[32mTienes BlackJack!  A ver que saca la banca...\u001B[0m");
            }
            Console.Write("                   \u001B[34my un: \u001B[0m");
            sumaCasino += jugar(true);
            if(blackJackNatural && blackJackBanca && sumaCasino == 11){
                Console.WriteLine("\n       La primera carta de la banca ha sido un :"+cartaRobada.Key);
                Console.WriteLine("\n   \u001B[33mLa banca también tiene 21. Gana la banca!\u001B[0m");
                break;
            }
            Console.WriteLine();

            do{
                if(suma >= 21){
                    Console.WriteLine("\n                   GAME OVER");
                    if(suma > 21){
                        Console.WriteLine("   \u001B[0;30m Te has pasado!  La suma tuya = "+suma+"  Pierdes la partida!\u001B[0m");
                        // Console.WriteLine($"\u001B[34mSuma Casino: {sumaCasino}\u001B[0m");
                        break;
                    }else if(sumaCasino == 21){
                        Console.WriteLine("La primera carta de la banca ha sido un :"+cartaRobada.Key);
                        Console.WriteLine("\n   \u001B[33mLa banca también tiene "+sumaCasino+". \u001B[0m");
                        Console.Write("\u001B[33mEs un empate!\u001B[0m");
                        break;
                    }else if(sumaCasino != 21){
                        Console.WriteLine("\n   \u001B[32m¡Tienes BlackJack!     \u001B[33mLa banca tiene "+sumaCasino+". \n \u001B[0m");
                        Console.WriteLine("\n   \u001B[33m  ~ Ganas la partida\u001B[0m ~");
                        break;
                    }
                }
                else{
                    if(tuTurno){
                        Console.WriteLine("\n  ¿Qué quieres hacer?");
                        Console.WriteLine("1: Robar otra carta");
                        Console.WriteLine("2: Parar");
                        eleccion = Entrada.readNextInt();
                        if(eleccion == 2){
                            tuTurno = false;
                            Console.WriteLine("\nLa primera carta de la banca ha sido un :"+cartaRobada.Key);
                            Console.WriteLine("   \u001B[34mLa banca tiene "+sumaCasino+". \u001B[0m");
                        }else{
                            Console.Write("\u001B[32m Tu siguiente carta es:    \u001B[0m");
                            suma += jugar(true);
                            Console.Write("\u001B[32m    La suma = \u001B[0m"+suma);
                        }
                    }else{
                        if(sumaCasino < 17){
                            Console.Write("\u001B[34m La banca saca un: \u001B[0m");
                            sumaCasino += jugar(true);
                            Console.Write($"\u001B[34m      Ahora tiene:\u001B[0m {sumaCasino}\n");
                        }
                        if(sumaCasino > 21){
                            Console.WriteLine(" \u001B[34m La banca ha pasado con \u001B[0m"+sumaCasino+"\u001B[32m     Ganas la partida!\u001B[0m\n");
                            break;
                        }else if(sumaCasino == 21){
                            Console.Write("\u001B[33m  ~ Gana la banca ~\u001B[0m\n");
                            break;
                        }else{
                            Console.WriteLine("\n La suma del casino es: "+sumaCasino);
                            Console.Write("     Tu suma es: "+suma);
                            if(sumaCasino > suma){
                                Console.Write("\u001B[33m  ~ Gana la banca ~\u001B[0m\n");
                            }
                            else{
                                Console.WriteLine("\u001B[33m  ~ Ganas la partida ~\u001B[0m");
                            }
                            break;
                        }
                    }
                }
                
            }while(eleccion == 1 || !tuTurno);

            Console.WriteLine("\n       \u001B[40m¿Quieres seguir apostando tus últimos ahorros?\u001B[0m");
            Console.WriteLine("     1: Juega otra partida");
            Console.WriteLine("     2: Irme de la mesa antes de perder más");
            continuar = Entrada.readNextInt();
        }while(continuar == 1);
        Console.WriteLine("Gracias por jugar, ¡hasta pronto!");
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
        Console.Write($"{cartaRobada.Key}");

        return cartaRobada.Value;
    }

    public static KeyValuePair<string,int> jugar(bool print, bool returnObj)
    {
        var cartaRobada = baraja.robarCarta();
        return cartaRobada;
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
