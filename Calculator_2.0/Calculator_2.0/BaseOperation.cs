using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator_2._0
{
    public abstract class BaseOperation
    {
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public double Result { get; set; }
        public int[,] Matrix1 { get; set; }
        public int[,] Matrix2 { get; set; }
        public int[,] MatrixResult { get; set; }
        public string calculation { get; set; }

        public abstract string Label { get; }
        public abstract void Calculate();
        public virtual void DisplayRes()
        {
            calculation = $"Mathematical result : { Operand1 } { Label} { Operand2} = { Result}";
            Console.WriteLine(calculation);
        }

    }


    public class Add : BaseOperation
    {
        public override string Label => "+";
        public override void Calculate() => Result = Operand1 + Operand2;

    }
    public class Subtract : BaseOperation
    {
        public override string Label => "-";
        public override void Calculate() => Result = Operand1 - Operand2;
    }
    public class Multiply : BaseOperation
    {
        public override string Label => "*";
        public override void Calculate() => Result = Operand1 * Operand2;

    }
    public class Divide : BaseOperation
    {
        public override string Label => "/";
        public override void Calculate()
        {
            if (Operand2 == 0)
                throw new NullReferenceException("You cannot devide on 0");
            Result = Operand1 / Operand2;
        }

    }
    public class BMI : BaseOperation
    {
        public override string Label => "b";
        public override void Calculate() => Result = Math.Round(Operand1 / Math.Pow(Operand2, 2), 2);

        public override void DisplayRes()
        {
            BMIConsequence(Result);
            calculation = $"BMI result : { Operand1} / ({Operand2}*2) = {Result} ";
            Console.WriteLine(calculation);
        }
        public string BMIConsequence(double Result)
        {
            string consequence;

            if (Result <= 18.5)
                consequence = "Underweight";
            else if (Result > 18.5 && Result <= 25)
                consequence = "Normal weight";
            else if (Result > 25 && Result <= 30)
                consequence = "Overweight";
            else
                consequence = "Obese";

            Console.WriteLine(consequence);
            return consequence;
        }
    }

    public class MatrixMultiply : BaseOperation
    {
        public override string Label => "m";
        public override void Calculate()
        {
            int[,] A = new int[Matrix1.GetLength(0), Matrix2.GetLength(1)];

            for (int i = 0; i < Matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < Matrix1.GetLength(1); k++)
                    {
                        A[i, j] += Matrix1[i, k] * Matrix2[k, j];
                    }
                }
            }
            MatrixResult = A;
            calculation = ConvertArrayToString(Matrix1, Matrix2, MatrixResult);
        }
        public override void DisplayRes()
        {
            Console.WriteLine(calculation);
        }
        public string ConvertArrayToString(int[,] Matrix1, int[,] Matrix2, int[,] MatrixResult)
        {
           var stringarray = "matrix multiplication result : ";

            for (int i = 0; i < Matrix1.GetLength(0); i++)
            {
                if (i > 0) stringarray += ',';
                stringarray += '{';
                for (int j = 0; j < Matrix1.GetLength(1); j++)
                {
                    if (j > 0) stringarray += ',';
                    stringarray += Matrix1[i, j];
                }
                stringarray += '}';

            }

           stringarray += " * ";

            for (int i = 0; i < Matrix2.GetLength(0); i++)
            {
                if (i > 0) stringarray += ',';
                stringarray += '{';
                for (int j = 0; j < Matrix2.GetLength(1); j++)
                {
                    if (j > 0) stringarray += ',';
                    stringarray += Matrix2[i, j];
                }
                stringarray += '}';

            }

            stringarray += " = ";

            for (int i = 0; i < MatrixResult.GetLength(0); i++)
            {
                if (i > 0) stringarray += ',';
                stringarray += '{';
                for (int j = 0; j < MatrixResult.GetLength(1); j++)
                {
                    if (j > 0) stringarray += ',';
                    stringarray += MatrixResult[i, j];
                }
                stringarray += '}';

            }
            return stringarray;
        } 

    }
}
       
