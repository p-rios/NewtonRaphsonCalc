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

        public double DerivarNoPonto(double ponto)
        {
            var variables = new Dictionary<string, FloatingPoint>
                {
                    { "x", ponto }
                };
          
            var x = Expr.Variable("x");
            return Expressao.Differentiate(x).Evaluate(variables).RealValue;                             
        }

        public double AplicarNoPonto(double ponto)
        {
            var variables = new Dictionary<string, FloatingPoint>
                {
                    { "x", ponto }
                };
            return Expressao.Evaluate(variables).RealValue;
        }

        public double MetodoNewton(double ponto)
        {         
            return ponto - AplicarNoPonto(ponto) / DerivarNoPonto(ponto) ;
        }

    }
}
