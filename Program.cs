using System;
using System.ComponentModel;
using System.Linq;

namespace NewtonRaphsonCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Função: ");
            Funcao funcao = new Funcao(Console.ReadLine().Split(' ').Select(double.Parse).ToList()) ;

            Console.WriteLine("Aproximação: ");
            double erro = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Intervalo(valorMin valorMax): ");
            string[] intervalos = Console.ReadLine().Split();

            Console.WriteLine("Maximo de iterações: ");
            int iteracoes = Convert.ToInt32(Console.ReadLine());

            int minVal = int.Parse(intervalos[0]);
            int maxVal = int.Parse(intervalos[1]);

            var random = new Random();
            double x0 = random.Next(minVal, maxVal);

            int i = 0;

            while(true)
            {
                var x1 = funcao.MetodoNewton(x0);
                var x2 = funcao.MetodoNewton(x1);

                if (erro > Math.Abs(x1 - x2) ^ i == iteracoes) { 
                    Console.WriteLine(@"Raiz da função :" + x2.ToString());
                    break;
                };

                x0 = x2;
                i++;
            }

            Console.Read();
        } 

     
    }
}
