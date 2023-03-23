using System;
using System.Collections.Generic;
using System.Text;
namespace Operation
{
    public interface IOperation{
        public string Name{get;}
        public string Operator{get;}
        public string Description{get;} 
    }
    public interface IUnaryOperation:IOperation{
        double Calculate(double val);
    }
    public interface INullayOperation:IOperation{
        double Value{get;}
    }
    public interface IBinaryOperation:IOperation{
        double Calculate(double lhs,double rhs);
    }
    public class Operation:IOperation{
        public string Name{get;}
        public string Operator{get;}
        public string Description{get;}
        public Operation(string name,string oper,string des){
            this.Name=name;
            this.Operator=oper;
            this.Description=des;
        }
    }
    public class Constant:Operation,INullayOperation{
        public double Value{get;}
        public Constant(string name,string oper,string des,double val) :base(name,oper,des)
        {
            this.Value=val;
        }
    }
    public class Sqrt:Operation,IUnaryOperation{
        public double Calculate(double val)=>Math.Sqrt(val);
        
        public Sqrt():base("Square root","sqrt","calculate the square root of a positive number "){

        }

    }
    public class Logarithm:Operation,IUnaryOperation{
        public double Calculate(double val)=>Math.Log(val);
        public Logarithm():base("Logarithm","ln","Caculate the natural logarithm of a positive number"){}
    }
    public class Exponentiation:Operation,IUnaryOperation{
        public double Calculate(double val)=>Math.Exp(val);
        public Exponentiation():base("Exponentiation","exp","Calculate the exponent with natural base e"){}
    }
    public class Multiplication:Operation,IBinaryOperation{
        public double Calculate(double lhs,double rhs)=>lhs*rhs;
        public Multiplication():base("Multiplication","*","Multiply 2 numbers"){}
    }
    public class Division:Operation,IBinaryOperation{
        public double Calculate(double lhs,double rhs){
            if(rhs==0){
                throw new Exception("Cannot divide by 0\n");
            }
            else{
                return lhs/rhs;
            }
        }
        public Division():base("Division","/","Calculate fraction of 2 numbers"){}
    }
    public class Addition:Operation,IBinaryOperation{
        public double Calculate(double lhs,double rhs)=>lhs+rhs;
        public Addition():base("Addition","+","Add 2 numbers"){}
    }
    public class Substraction:Operation,IBinaryOperation{
        public double Calculate(double lhs,double rhs)=>lhs-rhs;
        public Substraction():base("Substraction","-","Substract 2 numbers"){}
    }
    
    public class Power:Operation,IBinaryOperation{
        public double Calculate(double lhs,double rhs)=>Math.Pow(lhs,rhs);
        public Power():base("Power","^","calculate the power of 2 numbers"){}
    }
}