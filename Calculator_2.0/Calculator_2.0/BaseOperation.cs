using System;
using System.Collections;
using System.Collections.Generic;

namespace Calculator_2._0
{
    /// <summary>
    /// coz it's abstract class i cant create object of it 
    /// 
    /// </summary>
    
    public abstract class BaseOperation
    {
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public double Result { get; set; }
        public int[,] Matrix1 { get; set; }
        public int[,] Matrix2 { get; set; }
        public int[,] MatrixResult { get; set; }
        public string calculation { get; set; }

        public abstract string Label { get;  }
        public abstract void Calculate();
        public virtual void DisplayRes()
        {
            calculation = $"{ Operand1 } { Label} { Operand2} = { Result}";
            Console.WriteLine(calculation);
            //var list = new ArrayList();
           // list.Add($"{ Operand1 } { Label} { Operand2} = { Result}");
           
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
        public override void Calculate() => Result = Operand1 / Operand2;

    }
    public class BMI : BaseOperation
    {
        public override string Label => "b";
        public override void Calculate() => Result = Math.Round(Operand1 / Math.Pow(Operand2, 2), 2);
        
        public override void DisplayRes()
        {
            calculation = $"{ Operand1} / ({Operand2}*2) = {Result} ";
            Console.WriteLine(calculation);
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

        }
        public override void DisplayRes()
        {
            var matrixPrint = new MathMatrixRunnerMenu();

            Console.WriteLine("result");
            matrixPrint.Print(MatrixResult);

            calculation = $"{ MatrixResult}";
            

        }

    }
   
}
