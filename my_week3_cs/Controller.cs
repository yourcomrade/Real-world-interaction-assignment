using Token;
using Parser;
using RPNCalculator;
using TextMenu;
namespace Controller
{
    public class Controller{
        private ICalculator i_calc;
        private IParser i_parser;
        private IMenu i_menu;
        public Controller(ICalculator cal,IParser par, IMenu men){
            i_calc=cal;
            i_parser=par;
            i_menu=men;
        }
        public void Run(){
            i_menu.ShowMenu();
            string input=string.Empty;
            do{
                input=Console.ReadLine()??"quit";
                switch(input){
                    case "q":
                    break;
                    case "quit":
                    break;
                    case "h":
                    i_menu.ShowHelp();
                    break;
                    case "help":
                    i_menu.ShowHelp();
                    break;
                    case "o":
                    i_menu.ShowOperations();
                    break;
                    case "ops":
                    i_menu.ShowOperations();
                    break;
                    default:
                    try { 
                            var split = i_parser.Tokenize(input);
                            if(split.Count!=0){
                                var tokens=i_parser.Lex(split);
                                var res=i_calc.Calculate(tokens);
                                Console.WriteLine($"\nresult is {res}\n");
                            }
                    }catch(Exception e){
                        Console.WriteLine(e.Message);
                    }  
                    break;
                }
            }while(!input.ToLower().Equals("q") && !input.ToLower().Equals("quit"));
            Console.WriteLine("\n Calculator ended\n");
        }
    }
}