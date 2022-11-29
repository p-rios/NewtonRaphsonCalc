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

            var random = new Random();
            double x1 = random.Next();
            Console.WriteLine(x1);

            var derivadaNoPonto = funcao.DerivarNoPonto(x1);
            Console.WriteLine(derivadaNoPonto);

            //var r = derivadaNoPonto.ToString();
            //var _r = Convert.ToDouble(r);
            var a = funcao.AplicarNoPonto(Convert.ToDouble(derivadaNoPonto.ToString()));
             

            var b = funcao.MetodoNewton(x1);



            //Console.WriteLine("Escolha o epsilon ");
            //int epsilon = Convert.ToInt16(Console.ReadLine());
        } 

     
    }
}
