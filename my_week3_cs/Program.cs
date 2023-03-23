/*
Week3 Assignment
Student name: Hoang Minh Le
Student number: 511907
*/
using System;
using Parser;
using RPNCalculator;

namespace Program
{
    public class Program{
        public static void Main(string[] args)
        {
            var calc = new RPNCalculator.RPNCalculator();
            
            calc.Add(new Operation.Addition());
            calc.Add(new Operation.Substraction());
            calc.Add(new Operation.Multiplication());
            calc.Add(new Operation.Division());
            calc.Add(new Operation.Sqrt());
            calc.Add(new Operation.Logarithm());
            calc.Add(new Operation.Power());
            calc.Add(new Operation.Exponentiation());
            calc.Add(new Operation.Constant("pi","pi","constant pi",Math.PI));
            calc.Add(new Operation.Constant("e","e","constant e",Math.E));
                
            var menu = new TextMenu.TextMenu() { OperationsHelp = calc.OperationsHelpText };
            var my=new Controller.Controller(calc,new Parser.Parser(calc.SupportedOperators), menu);
            my.Run();


        }
    }
}
