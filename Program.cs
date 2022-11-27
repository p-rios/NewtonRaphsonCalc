using System;
namespace NewtonRaphsonCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("1 - Escolher minha propria \n 2- função c1 pré-gerada");
            Console.WriteLine("Digite a func: ");
            Funcao funcao = new Funcao(Console.ReadLine());
      
            funcao.Derivada = funcao.Derivar();
            Console.WriteLine(funcao.Derivada);
                 


            //Console.WriteLine("Escolha o epsilon ");
            //int epsilon = Convert.ToInt16(Console.ReadLine());
        } 

     
    }
}
