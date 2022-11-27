using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Symbolics;
using Expr = MathNet.Symbolics.SymbolicExpression;

namespace NewtonRaphsonCalc
{
    public class Funcao
    {
        public SymbolicExpression Expressao { get; set; }
        public string Derivada { get; set; }

        public Funcao(SymbolicExpression expressao)
        {
            Expressao = expressao;
        }

        public string Derivar()
        {
            var x = Expr.Variable("x");
            //SymbolicExpression func = 3 * (x * x * x) + 2 * x - 6;
            //Console.WriteLine("f(x) = " + func.ToString());

            var derivada = Expressao.Differentiate(x);
            return derivada.ToString();
        }


    }
}
