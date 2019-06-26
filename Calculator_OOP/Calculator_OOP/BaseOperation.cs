using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_OOP
{
    public abstract class BaseOperation
    {
        public double A { get; set; }
        public double B { get; set; }
        public double Result { get; set; }

        public abstract string Label { get; }

        public abstract void Calculate();
    }

    public class Addition : BaseOperation
    {
        public override string Label => "+";

        public override void Calculate()
        {
            Result = A + B;
        }
    }

    public class Subtraction : BaseOperation
    {
        public override string Label => "-";

        public override void Calculate()
        {
            Result = A - B;
        }
    }

    public class Multiplication : BaseOperation
    {
        public override string Label => "*";

        public override void Calculate()
        {
            Result = A * B;
        }
    }

    public class Division : BaseOperation
    {
        public override string Label => "/";

        public override void Calculate()
        {
            Result = A / B;
        }
    }


}
