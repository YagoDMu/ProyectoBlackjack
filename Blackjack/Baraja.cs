using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

class Baraja
{
    private string[] palos = {"\u2660","\u2663","\u2665","\u2666"};
    private string[] numeros = {" A"," 2"," 3"," 4"," 5"," 6"," 7"," 8"," 9","10"," J"," Q"," K"};

    private Dictionary<string,int> baraja = new Dictionary<string,int>();
    
    public void recogeBaraja()
    {
        baraja.Clear();
        string key;
        int j;
        for (int i = 0; i < numeros.Length; i++)
        {
            for(int p=0; p<4;p++)
            {
                if(i < 10)
                {
                    j=i+1;
                }else
                {
                    j=10;
                }
                key = numeros[i]+" "+palos[p];
                baraja.Add(key,j);
            }
        }  
    }

    public void mostrarBaraja()
    {
        foreach(var carta in baraja)
        {
            Console.WriteLine(" Carta Key: "+carta.Key + " Valor: "+ carta.Value);
        }
    }

    public KeyValuePair<string,int> robarCarta()
    {
        Random random = new Random();
        var cartaRobada = baraja.ElementAt(random.Next(0,baraja.Count()));
        baraja.Remove(cartaRobada.Key);
        return cartaRobada;
    }

}
