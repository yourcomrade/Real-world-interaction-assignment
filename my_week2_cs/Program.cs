/*
Week2 Assignment
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
            var menu = new TextMenu.TextMenu() { OperationsHelp = calc.OperationsHelpText };
            var my=new Controller.Controller(calc,new Parser.Parser(calc.SupportedOperators), menu);
            my.Run();


        }
    }
}
