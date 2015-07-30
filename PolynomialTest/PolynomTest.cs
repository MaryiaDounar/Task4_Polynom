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
      // private CsvReader csv = new CsvReader(new StreamReader("Data.csv"), true);

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
        }

       //private IEnumerable<TestCaseData> GetTestData()
       //{
      
       //        while (csv.ReadNextRecord() != false)
       //        {
       //            string[] polynom1String = Regex.Split(csv[0], ",");
       //            string[] polynom2String = Regex.Split(csv[1], ",");
       //            string[] polynom3String = Regex.Split(csv[2], ",");
       //            double[] coeffPolynom1 = GetCoefficient(polynom1String);
       //            double[] coeffPolynom2 = GetCoefficient(polynom2String);
       //            double[] coeffResult = GetCoefficient(polynom3String);
       //            yield return new TestCaseData(new []{ coeffPolynom1, coeffPolynom2, coeffResult });
       //        }
       //}

   

       //private double[] GetCoefficient(string[] arrayString)
       //{
       //    double[] arrayDouble = new double[arrayString.Length];
       //    for (int i = 0; i < arrayString.Length; i++)
       //    {
       //        arrayDouble[i] = double.Parse(arrayString[i]);
       //    }
       //    return arrayDouble;
       //}
    }
}
