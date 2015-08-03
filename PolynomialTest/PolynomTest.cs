using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Polynomial;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using System.Text.RegularExpressions;

namespace PolynomialTest
{
    [TestFixture]
    public class PolynomTest
    {
       public double[] coeffPolynom1 = { 1, 2, 3 };
       private double[] coeffPolynom2 = { 1, 2, 3, 4 };
       private double[] coeffAdd = { 2, 4, 6, 4 };
       private double[] coeffSub = { 0, 0, 0, 4 };
       private double[] coeffMul = { 1, 4, 10, 16, 17, 12 };


       [Test]
       public void Add()
        {
            Polynom polynom1 = new Polynom(coeffPolynom1);
            Polynom polynom2 = new Polynom(coeffPolynom2);
            Polynom expectedPolynom = new Polynom(coeffAdd);
            Assert.That(polynom1 + polynom2, Is.EqualTo(expectedPolynom));
        }

       [Test]
       public void Sub()
       {
           Polynom polynom1 = new Polynom(coeffPolynom1);
           Polynom polynom2 = new Polynom(coeffPolynom2);
           Polynom expectedPolynom = new Polynom(coeffSub);
           Assert.That(polynom2 - polynom1, Is.EqualTo(expectedPolynom));
       }

        [Test]
        public void Mul()
       {
           Polynom polynom1 = new Polynom(coeffPolynom1);
           Polynom polynom2 = new Polynom(coeffPolynom2);
           Polynom expectedPolynom = new Polynom(coeffMul);
           Assert.That(polynom2 * polynom1, Is.EqualTo(expectedPolynom));
       }

        [Test]
        public void Equals()
        {
            Polynom polynom1 = new Polynom(coeffPolynom1);
            Polynom polynom2 = new Polynom(coeffPolynom1);
            Assert.That(polynom1.Equals(polynom2), Is.True);
        }

        [Test]
        public void EqualsOperator()
        {
            Polynom polynom1 = new Polynom(coeffPolynom1);
            Polynom polynom2 = new Polynom(coeffPolynom1);
            Assert.That(polynom1==polynom2, Is.True);
        }

        [Test]
        public void NotEqualsOperator()
        {
            Polynom polynom1 = new Polynom(coeffPolynom1);
            Polynom polynom2 = new Polynom(coeffPolynom2);
            Assert.That(polynom1 != polynom2, Is.True);
        }

        [Test]
        public void Clone()
        {
            Polynom polynom1 = new Polynom(coeffPolynom1);
            Polynom polynom2 = (Polynom) polynom1.Clone();
            Assert.That(polynom1.Equals(polynom2), Is.True);
            Assert.That(ReferenceEquals(polynom1, polynom2), Is.False);
        }
    }
}
