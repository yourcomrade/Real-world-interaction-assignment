

using Parser;
using RPNCalculator;

namespace Evaluator
{
    public interface IExpressionEvaluator
    {
        //evaluate an expression and return the result
        Task<double> Evaluate(string expression);
        //get help for the calculator
        IList<string>Help { get; }
        //get a short description of the calculator
        string Description { get; }
    }
    public interface IExpressionEvaluator<T>
    {
        //evaluate an expression and return the result
        Task<double> Evaluate(string expression);
        //get help for the calculator
        IList<string>Help { get; }
        //get a short description of the calculator
        string Description { get; }
    }
    public class RPNEvaluator:IExpressionEvaluator
    {
        private ICalculator _calculator;
        public ICalculator Calculator { get; set; }
        public IParser Parser { get; set; }

        public RPNEvaluator(ICalculator calculator, IParser parser)
        {
            this.Parser = parser;
            this._calculator = calculator;
            this.Calculator = calculator;
            
        }

        public Task<double> Evaluate(string expression)
        {
            var parsed = Parser.Tokenize(expression);
            var tokens = Parser.Lex(parsed);
            return  Task.FromResult(_calculator.Calculate(tokens));
        }

        public IList<string> Help => _calculator.OperationsHelpText;

        public string Description => "RPN calculator";
    }
}

