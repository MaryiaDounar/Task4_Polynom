using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class Polynom :ICloneable, IEquatable<Polynom>
    {
        private double[] coefficient;
        private int degree;

        public Polynom(params double[] coefficient)
        {
            if (!ReferenceEquals(coefficient, null))
            {
                this.degree = coefficient.Length - 1;
                this.coefficient = (double[])coefficient.Clone();
            }
        }

        public double this[int i]
        {
            get
            {
                return this.coefficient[i];
            }
        }

       
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for(int i=0; i<=degree-1; i++)
            {
                stringBuilder.AppendFormat("{0}x^{1}+", coefficient[i], i);
            }
            stringBuilder.AppendFormat("{0}x^{1}", coefficient[degree], degree);
            return stringBuilder.ToString();
        }

        public bool Equals(Polynom other)
        {
            if(ReferenceEquals(this, other))
            {
                return true;
            }

            if(ReferenceEquals(other, null))
            {
                return false;
            }

            return this.coefficient.Length == other.coefficient.Length && this.coefficient.SequenceEqual(other.coefficient);
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(this, obj))
            {
                return true;
            }

            if(ReferenceEquals(obj, null))
            {
                return false;
            }

            Polynom polynom = obj as Polynom;
            if(polynom == null)
            {
                return false;
            }

            return Equals(polynom);
        }

        public static bool operator ==(Polynom polynom1, Polynom polynom2)
        {
            if (ReferenceEquals(polynom1, null) || ReferenceEquals(polynom2, null))
            {
                return false;
            }

            return polynom1.Equals(polynom2);
        }

        public static bool operator !=(Polynom polynom1, Polynom polynom2)
        {
            if (ReferenceEquals(polynom1, null) || ReferenceEquals(polynom2, null))
            {
                return false;
            }
            return !(polynom1.Equals(polynom2));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Polynom(this.coefficient);
        }

        public static Polynom operator +(Polynom a, Polynom b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return null;
            }
            Polynom greater;
            Polynom less;
            if (a.degree > b.degree)
            {
                greater = a;
                less = b;
            }
            else
            {
                greater = b;
                less = a;
            }
            double[] coeff = new double[greater.degree + 1];
            for(int i=0; i<=less.degree; i++)
            {
                coeff[i] = less.coefficient[i];
            }
            for(int i=0; i<=greater.degree; i++)
            {
                coeff[i] += greater.coefficient[i];
            }
            Polynom c = new Polynom(coeff);
            return c;
        }

        public static Polynom operator -(Polynom a)
        {
            if (ReferenceEquals(a, null))
            {
                return null;
            }
            double[] coeff = new double[a.coefficient.Length];
            for(int i=0; i<coeff.Length; i++)
            {
                coeff[i] = a.coefficient[i] * -1;
            }
            return new Polynom(coeff);
        }

        public static Polynom operator -(Polynom a, Polynom b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return null;
            }
            return a + (-b);
        }

        public static Polynom operator *(Polynom a, Polynom b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return null;
            }
            double[] coeff = new double[a.degree + b.degree + 1];
            for(int i=0; i<=a.degree ; i++)
            {
                for(int j=0; j<=b.degree; j++)
                {
                    coeff[i + j] += a[i] * b[j]; 
                }
            }
            Polynom c = new Polynom(coeff);
            return c;
        }

        public double Calculate(double[] matrix, double x)
        {
            if (ReferenceEquals(matrix, null))
            {
                return 0;
            }
            double value = 0;
            for(int i=0; i<=matrix.Length-1; i++)
            {
                x *= matrix[i];
                value += Math.Pow(x, i);
            }
            return value;
        }
    }
}
