
using System.Globalization;
using Token;
using Operation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace RPNCalculator
{
    public interface ICalculator{
        IList<string>SupportedOperators{get;}
        IList<string>OperationsHelpText{get;}
        double Calculate(IList<Token.Token> ex);
    }
    public class RPNCalculator:ICalculator, ICollection<IOperation>{
        

        private List<IOperation> _operations = new();
        
        //These line is for ICollection
        public void Add(IOperation item)=> _operations.Add(item);
        public void Clear()=>_operations.Clear();
        public bool Contains(IOperation item)=>_operations.Contains(item);
        public void CopyTo(IOperation[] item,int index)=>_operations.CopyTo(item,index);
        public int Count=>_operations.Count;
        public bool IsReadOnly=>false;
        public bool Remove(IOperation item)=>_operations.Remove(item);
        public IEnumerator<IOperation>GetEnumerator()=> _operations.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();

        public IList<string> OperationsHelpText => _operations.Select(op =>
        {
            return op.Operator+" "+op.Name+" "+ op.Description;
        }).ToList();
        public IList<string>SupportedOperators=>_operations.Select(op=>op.Operator).ToList();
        public double Calculate(IList<Token.Token> ex){
            var my_st=new Stack<double>();

            foreach (var token in ex)
            {
               switch(token.pubTokenType){
                   case Token.TokenType.OPERATOR:
                        var op=_operations.Find(op=>op.Operator.Equals(token.Value));
                        if(op!=null){
                            try
                            {
                                if (op is IBinaryOperation oper)
                                {
                                    var a = my_st.Pop();
                                    var b = my_st.Pop();
                                    my_st.Push(
                                        oper.Calculate(b, a));
                                }

                                else if (op is IUnaryOperation oper1)
                                {
                                    my_st.Push(oper1.Calculate(my_st.Pop()));
                                }
                                else if (op is INullayOperation oper2)
                                {
                                    my_st.Push(oper2.Value);
                                }
                            }
                            catch (Exception)
                            {
                                throw new Exception("The RPN is invalid\n");
                            }
                           
                        }
                        else{
                            throw new InvalidOperationException($"Unknown operation {token.Value}");
                        }
                   break;
                   case Token.TokenType.NUMBER:
                   my_st.Push(token.NumericaValue);
                   break;
               }
            }
            if(my_st.Count==1){
                return my_st.Pop();
            }
            else{
                throw new Exception("The RPN is invalid\n");
            }
        }
    }
}