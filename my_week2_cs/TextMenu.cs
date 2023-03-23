using System;
using System.Text;
using System.Collections.Generic;
namespace TextMenu
{
    public interface IMenu{
        IList<string>OperationsHelp{get;set;}
        void ShowMenu();
        void ShowOperations();
        void ShowHelp();
    }
    public class TextMenu:IMenu{
        private IList<string>m_OperationsHelp=new List<string>()
        { 
            "RPN Calculator\nEnter a RPN expression to evaluate\nEnter '(h)elp' for help\nEnter '(o)ps' for available operations\nEnter '(q)'uit to exit",
            "Enter expression using RPN notation, for instance to calculate:\n 2+3*4\nenter '2 3 4 * +' ",
            "Calculator operations\n+ (Addition) adds two numbers\n- (Substraction) substracts two numbers\n* (Multiplication) multiplies two numbers\n/ (Division) calculate fraction of two numbers\n^ (Power) calculate the power of two numbers\nexp (Exponentiation) calculate the exponent with the natural base e\nln (lograithm) calculate the natural logarithm of a number"
        };

        public IList<string> OperationsHelp
        {
            get => m_OperationsHelp;
            set { m_OperationsHelp = value; }
        }
        public void ShowMenu()
        {
            Console.WriteLine(OperationsHelp[0]);
        }
        public void ShowHelp(){
            
            Console.WriteLine(OperationsHelp[1]);
        }
        public void ShowOperations(){
            Console.WriteLine(OperationsHelp[2]);
            // TODO

            
            
        }
    }
}