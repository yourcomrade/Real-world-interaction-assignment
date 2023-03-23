/*
Week4 Assignment
Student name: Hoang Minh Le
Student number: 511907
*/
using System;
using Evaluator;
using MathJs;
using Parser;
using RPNCalculator;

namespace Program
{
    public class Program{
        public async static  Task Main(string[] args)
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
            var parser = new Parser.Parser(calc.SupportedOperators); 
            var rpn = new RPNEvaluator(calc, parser); 
            // create the MathJS evaluator
            var mathjs = new MathJSCalculator();
            var my = new Controller.Controller(new IExpressionEvaluator[]{rpn,mathjs},menu);
            await my.Run();
        }
    }
}
