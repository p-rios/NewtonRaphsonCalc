using System;
namespace NewtonRaphsonCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite a func: ");
            Funcao funcao = new Funcao(Console.ReadLine());

            Console.WriteLine("Digite o erro: ");
            double erro = Convert.ToDouble(Console.ReadLine());
            var random = new Random();
            double x0 = random.Next();         

            while(true)
            {
                var x1 = funcao.MetodoNewton(x0);
                var x2 = funcao.MetodoNewton(x1);

                if (erro > Math.Abs(x1 - x2)) { 
                    Console.WriteLine(x2);
                    break;
                };

                x0 = x2;
            }
                 

        } 

     
    }
}
