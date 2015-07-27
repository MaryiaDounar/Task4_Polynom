using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynom
{
    public class MultiMember
    {
        private double[] matrix;
        private int degree;

        public MultiMember(int degree, double[] matrix)
        {
            this.degree = degree;
            this.matrix = matrix;
        }

        public static MultiMember operator +(MultiMember a, MultiMember b)
        {
            int cDegree;
            if (a.degree > b.degree)
            {
                cDegree = a.degree;
            }
            else cDegree = b.degree;
            double[] cMatrix = new double[cDegree+1];
            for(int i=0; i<=cDegree; i++)
            {
                cMatrix[i] = a.matrix[i] + b.matrix[i];
            }
            MultiMember c = new MultiMember(cDegree, cMatrix);
            return c;
        }

        public static MultiMember operator -(MultiMember a, MultiMember b)
        {
            int cDegree;
            if (a.degree > b.degree)
            {
                cDegree = a.degree;
            }
            else cDegree = b.degree;
            double[] cMatrix = new double[cDegree + 1];
            for (int i = 0; i <= cDegree; i++)
            {
                cMatrix[i] = a.matrix[i] - b.matrix[i];
            }
            MultiMember c = new MultiMember(cDegree, cMatrix);
            return c;
        }

        public static MultiMember operator *(MultiMember a, MultiMember b)
        {
            int cDegree = a.degree + b.degree;
            double[] cMatrix = new double[cDegree + 1];
            for (int i = 0; i <= cDegree; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    cMatrix[i] += a.matrix[j] * b.matrix[i-j];
                }   
            }
            MultiMember c = new MultiMember(cDegree, cMatrix);
            return c;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for(int i=0; i<=degree-1; i++)
            {
                stringBuilder.AppendFormat("{0}x^{1}+", matrix[i], i);
            }
            stringBuilder.AppendFormat("{0}x^{1}", matrix[degree], degree);
            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }

            MultiMember multiMember = obj as MultiMember;
            if((System.Object)multiMember == null)
            {
                return false;
            }

            return Calculate(degree, matrix, 1) == Calculate(multiMember.degree, multiMember.matrix, 1);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public double Calculate(int degree, double[] matrix, double x)
        {
            double value = 0;
            for(int i=0; i<=degree; i++)
            {
                x *= matrix[i];
                value += Math.Pow(x, i);
            }
            return value;
        }
    }
}
