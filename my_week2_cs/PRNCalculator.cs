
using System.Globalization;
using Token;


namespace RPNCalculator
{
    public interface ICalculator{
        IList<string>SupportedOperators{get;}
        IList<string>OperationsHelpText{get;}
        double Calculate(IList<Token.Token> ex);
    }
    public class RPNCalculator:ICalculator{
        
        private List<string> m_supportedOperators = new List<string>{"+","-"
            ,"*","/","^","sqrt","exp","ln"};

        public IList<string> SupportedOperators => m_supportedOperators;

        private List<string> m_operationsHelpText = new List<string>
        {
            "RPN Calculator\nEnter a RPN expression to evaluate\nEnter '(h)elp' for help\nEnter '(o)ps' for available operations\nEnter '(q)'uit to exit",
            "Enter expression using RPN notation, for instance to calculate:\n 2+3*4\nenter '2 3 4 * +' ",
            "Calculator operations\n+ (Addition) adds two numbers\n- (Substraction) substracts two numbers\n* (Multiplication) multiplies two numbers\n/ (Division) calculate fraction of two numbers\n^ (Power) calculate the power of two numbers\nexp (Exponentiation) calculate the exponent with the natural base e\nln (lograithm) calculate the natural logarithm of a number"

        };

        public IList<string> OperationsHelpText => m_operationsHelpText;
        public double Calculate(IList<Token.Token> ex){
            var my_st=new Stack<double>();

            foreach (var a in ex)
            {
                if (a.IsNumber)
                {
                    my_st.Push(a.NumericaValue);
                }
                else
                {
                    if (a.Value.Equals("+") || a.Value.Equals("-") || a.Value.Equals("*") || a.Value.Equals("^") ||
                        a.Value.Equals("/"))
                    {
                        if (my_st.Count > 1)
                        {
                            var b = my_st.Pop();
                            var c = my_st.Pop();
                            if (a.Value.Equals("+"))
                            {
                                my_st.Push(b + c);
                            }
                            else if (a.Value.Equals("-"))
                            {
                                my_st.Push(c - b);
                            }
                            else if (a.Value.Equals("*"))
                            {
                                my_st.Push(b * c);
                            }

                            if (a.Value.Equals("/"))
                            {
                                my_st.Push(c / b);
                            }

                            if (a.Value.Equals("^"))
                            {
                                my_st.Push(Math.Pow(c, b));
                            }
                        }
                        else
                        {
                            throw new Exception("The RPN is invalid.\n");
                        }
                    }
                    else if (a.Value.Equals("ln") || a.Value.Equals("exp") || a.Value.Equals("sqrt"))
                    {
                        if (my_st.Count >= 1)
                        {
                            if (a.Value.Equals("ln"))
                            {
                                my_st.Push(Math.Log(my_st.Pop()));
                            }

                            if (a.Value.Equals("sqrt"))
                            {
                                my_st.Push(Math.Sqrt(my_st.Pop()));
                            }

                            if (a.Value.Equals("exp"))
                            {
                                my_st.Push(Math.Sqrt(my_st.Pop()));
                            }
                            else
                            {
                                throw new Exception("The RPN is invalid.\n");

                            }
                        }
                        else
                        {
                            throw new Exception($"Unsupported operator {a.Value}\n");

                        }
                    }

                }

            }
            if (my_st.Count == 1)
            {
                return my_st.Pop();
            }
            else
            {
                Console.WriteLine("RPN is invalid");
                return 0;
            }

        }
       
    }
}