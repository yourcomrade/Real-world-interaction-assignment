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
        };

        public IList<string>? OperationsHelp
        {
            get;
            set;
        }
        public void ShowMenu()
        {
            Console.WriteLine(m_OperationsHelp[0]);
        }
        public void ShowHelp(){
            
            Console.WriteLine(m_OperationsHelp[1]);
        }
        public void ShowOperations(){
            foreach (var i in OperationsHelp)
            {
                Console.WriteLine(i);
            }
        }
    }
}