using System.Collections;
using System.Runtime.CompilerServices;

class Baraja
{
    private string[] palos = {"Picas","Treboles","Corazones","Diamantes"};
    private string[] numeros = {"A","2","3","4","5","6","7","8","9","10","J","Q","K"};

    private Dictionary<string,int> baraja = new Dictionary<string,int>();

    public void creaBaraja()
    {
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
                
                baraja.Add(numeros[i] +" "+ p,j);
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

}
    
    

