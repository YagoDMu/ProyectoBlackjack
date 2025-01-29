using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

class Baraja
{
    private string[] palos = {"\u2660","\u2663","\u2665","\u2666"};
    private string[] numeros = {"A","2","3","4","5","6","7","8","9","10","J","Q","K"};

    private Dictionary<string,int> baraja = new Dictionary<string,int>();
    


    public void recogeBaraja()
    {
        baraja.Clear();

        int j=0;
        for (int i = 0; i < 13; i++)
        {
            foreach(string p in palos)
            {
                if(i < 10)
                {
                    j=i+1;
                }else if(i > 9)
                {
                    j=10;
                }
                
                baraja.Add(numeros[i] + p,j);
            }

            //Console.WriteLine(baraja.Keys);
        }  
    }

    public void mostrarBaraja()

    {
        foreach(var carta in baraja)
        {
            Console.WriteLine(carta.Key + " Valor: "+ carta.Value);
            Console.WriteLine();
        }
    }

    public KeyValuePair<string,int> robarCarta()
    {
        Random random = new Random();

        var cartaRobada = baraja.ElementAt(random.Next(0,53));
        baraja.Remove(cartaRobada.Key);

        return cartaRobada;

        
        //Console.WriteLine((baraja.ElementAt(random.Next(0,53)).Key));
        //string carta = baraja.ElementAt(random.Next(0,53)).Key;
    }

    



}
    
    

