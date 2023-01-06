using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Symbolics;
using MathNet.Numerics;
using Expr = MathNet.Symbolics.SymbolicExpression;
using System.Linq;
using MathNet.Numerics.Integration;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace NewtonRaphsonCalc
{
    public class Funcao
    {
        public List<double> Coeficientes{ get; set; }


        public Funcao(List<double> coeficientes)
        {
            Coeficientes= coeficientes;
        }

        public List<double> Briot(double ponto)
        {
           
            var listaBriot = new List<double>();
            int i = 0;
            int UltimoGrau = Coeficientes.Count;
            foreach (double coeficiente in Coeficientes)
            {
                if (i == 0) 
                { listaBriot.Add(coeficiente);
                    i++;
                }
                if(i == 1)
                {

                    int j = i - 1;
                    double quociente = Coeficientes[j] * ponto + Coeficientes[i];
                    listaBriot.Add(quociente);
                    i++;


                }

                if(i>1 && i<UltimoGrau)
                {
                    int j = i - 1;
                    double quociente = listaBriot[j] * ponto + Coeficientes[i];
                    listaBriot.Add(quociente);
                    i++;
                }
            }
            return listaBriot; 
        }

         public double DerivarNoPonto(double ponto)
        {
            var listaQuocientes = new List<double>();
            int k = 2;
            int UltimoGrau = Coeficientes.Count;
           
            foreach (double q in Briot(ponto))
            {
                double _quociente = Math.Pow(ponto,UltimoGrau -k) * q;
                listaQuocientes.Add(_quociente);
                k++;
              
            }

            listaQuocientes.RemoveAt(listaQuocientes.Count - 1);
            double somaLista = listaQuocientes.Sum();
           
            return somaLista;
        }

        public double AplicarNoPonto(double ponto)
        {
            int k = 1;
            var listaPontos = new List<double>();
            int UltimoGrau = Coeficientes.Count;
            foreach (var coeficiente in Coeficientes)
            {
                var result = Math.Pow(ponto, UltimoGrau - k) * coeficiente;
                listaPontos.Add(result);
                k++;
            }
            return listaPontos.Sum();
        }

        public double MetodoNewton(double ponto)
        {         
            return ponto - AplicarNoPonto(ponto) / DerivarNoPonto(ponto) ;
        }

    }
}
