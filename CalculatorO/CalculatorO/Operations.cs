using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorO
{
    public abstract class Operations
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
        public virtual string SaveDisplayRes()
        {
            calculation = $"Mathematical result : { Operand1 } { Label} { Operand2} = { Result}";
            Console.WriteLine(calculation);
            return calculation;
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
            return consequence;
        }
        public virtual void addToHistory(string input) => HistoryManager.AddLog(input);
    }


    public class Add : Operations
    {
        public override string Label => "+";
        public override void Calculate() => Result = Operand1 + Operand2;
    }
    public class Subtract : Operations
    {
        public override string Label => "-";
        public override void Calculate() => Result = Operand1 - Operand2;
    }
    public class Multiply : Operations
    {
        public override string Label => "*";
        public override void Calculate() => Result = Operand1 * Operand2;
    }
    public class Divide : Operations
    {
        public override string Label => "/";
        public override void Calculate()
        {
            if (Operand2 == 0)
                throw new NullReferenceException("You cannot devide on 0");
            Result = Operand1 / Operand2;
        }
    }
    public class BMI : Operations
    {
        public override string Label => "b";
        public override void Calculate() => Result = Math.Round(Operand1 / Math.Pow(Operand2, 2), 2);
        public override string SaveDisplayRes()
        {
            string consequence = BMIConsequence(Result);
            calculation = $"BMI result : { Operand1} / ({Operand2}*2) = {Result} \t It's {consequence} ";
            Console.WriteLine(calculation);
            return calculation;
        }
    }

    public class MatrixMultiply : Operations
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
        }
        public override string SaveDisplayRes()
        {
            calculation = ConvertArrayToString(Matrix1, Matrix2, MatrixResult);
            Console.WriteLine(calculation);
            return calculation;
        }
        public string ConvertArrayToString(int[,] m1, int[,] m2, int[,] m3)
        {
            string stringarray = "matrix multiplication result : ";
            stringarray = IoManager.CreateString(m1, stringarray);
            stringarray += " * ";
            stringarray = IoManager.CreateString(m2, stringarray);
            stringarray += " = ";
            stringarray = IoManager.CreateString(m3, stringarray);

            return stringarray;
        }
    }
}
