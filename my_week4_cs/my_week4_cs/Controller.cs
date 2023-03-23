using Evaluator;
using Token;
using Parser;
using RPNCalculator;
using TextMenu;
namespace Controller
{
    public class Controller{
        public IMenu _Menu { get; set; }
        //it's a list now
        private List<IExpressionEvaluator> m_Evaluators { get; } = new();
        //hold the current value selected evaluator
        private IExpressionEvaluator m_currentEvaluator;

        private IExpressionEvaluator CurrentEvaluator
        {
            get => m_currentEvaluator;
            set
            {
                if (_Menu is not null)
                {
                    //set help text for current evaluators
                    _Menu.OperationsHelp = value?.Help;
                }

                m_currentEvaluator = value;
            }
        }

        public Controller(IExpressionEvaluator[] evaluators, IMenu menu)
        {
            m_Evaluators.AddRange(evaluators);
            _Menu = menu;
            m_currentEvaluator = m_Evaluators.First();
        }

        private void SwitchEvaluator()
        {
            Console.WriteLine("Here is the options to change");
            for (int i = 0; i < m_Evaluators.Count; i++)
            {
                Console.WriteLine($"Enter {i} - {m_Evaluators[i].Description}");
            }
            var input = string.Empty;
            bool flag = false;
            do
            {
                input = Console.ReadLine();
                if (Convert.ToInt16(input) < m_Evaluators.Count)
                {
                    CurrentEvaluator = m_Evaluators[Convert.ToInt16(input)];
                    Console.WriteLine($"The current calculator is {CurrentEvaluator.Description}");
                    flag = true;
                }
                else
                {
                    Console.WriteLine("The option is invalid");
                }
               
                
            }while(!flag);
        }

        public async Task Run()
        {
            Console.WriteLine("The default calculator is RPN calculator");
            Console.WriteLine("To use MathJS calculator, please make sure that you have internet connection");
            Console.WriteLine("To switch the calculator, please enter 'switch' or 's'");
            var input = string.Empty;
            do
            {
                input = Console.ReadLine() ?? "quit";
                switch (input)
                {
                    case "quit" or "q":
                        input = "quit";
                        break;
                    case "switch" or "s":
                        SwitchEvaluator();
                        break;
                    case "help" or "h":
                        foreach (var i in CurrentEvaluator.Help)
                        {
                            Console.WriteLine(i);
                        }
                        break;
                    default:
                        Console.WriteLine("The result is: {0}",await CurrentEvaluator.Evaluate(input));
                        break;
                }

            } while (!input.ToLower().Equals("quit"));
        }

    }
}