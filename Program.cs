using System;
using System.ComponentModel;
using System.Linq;

namespace NewtonRaphsonCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input dos coeficientes da função, exemplo : 5x^3 + 4x^2 +3x +2 = 5 4 3 2
            Console.WriteLine("Função: ");
            Funcao funcao = new Funcao(Console.ReadLine().Split(' ').Select(double.Parse).ToList()) ;

            //erro de aproximação entre a raiz real e a calculada
            Console.WriteLine("Aproximação: ");
            double erro = Convert.ToDouble(Console.ReadLine());

            //intervalo em que se quer encontrar a raiz, útil para polinomios com mais de uma raiz
            Console.WriteLine("Intervalo(valorMin valorMax): ");
            string[] intervalos = Console.ReadLine().Split();

            //número máximo de iterações desejado
            Console.WriteLine("Maximo de iterações: ");
            int iteracoes = Convert.ToInt32(Console.ReadLine());
            
            //dividindo o input string dos intervalos em dois ints
            int minVal = int.Parse(intervalos[0]);
            int maxVal = int.Parse(intervalos[1]);

            //gerando valor randômico 
            var random = new Random();
            double x0 = random.Next(minVal, maxVal);

            int i = 0;
            //laço principal do programa
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
