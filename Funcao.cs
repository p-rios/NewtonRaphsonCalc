using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Symbolics;
using MathNet.Numerics;
using Expr = MathNet.Symbolics.SymbolicExpression;

namespace NewtonRaphsonCalc
{
    public class Funcao
    {
        public Expr Expressao { get; set; }
       

        public Funcao(Expr expressao)
        {
            Expressao = expressao;
        }

        public Expr DerivarNoPonto(double ponto)
        {
            var x = SymbolicExpression.Variable("x");
            ////SymbolicExpression func = 3 * (x * x * x) + 2 * x - 6;
            ////Console.WriteLine("f(x) = " + func.ToString());

            return Expressao.DifferentiateAt(x, ponto);
            
        }

        public FloatingPoint AplicarNoPonto(double ponto)
        {
            var variables = new Dictionary<string, FloatingPoint>
                {
                    { "x", ponto }
                };
            return Expressao.Evaluate(variables);
        }

        public FloatingPoint MetodoNewton(double ponto)
        {
            var result = ponto - Convert.ToDouble((DerivarNoPonto(ponto)).ToString()) / Convert.ToDouble(AplicarNoPonto(ponto).ToString());
            return result;
        }

    }
}
