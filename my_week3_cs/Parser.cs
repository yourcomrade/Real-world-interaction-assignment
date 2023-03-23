/*
 * Week3 Assiagnment
 * Student name: Hoang Minh Le
 * Student number:511907
 */
using Microsoft.VisualBasic;
using Token;
using System.Linq;
namespace Parser
{
    public interface IParser{
        IList<string>SupportedOperators{get;set;}
        IList<string> Tokenize(string val);
        IList<Token.Token> Lex(IList<string> mem_token);
    }
    public class Parser:IParser{
        private int m_len=0;
        public IList<string>SupportedOperators{get;set;}
        public int my_len{get{return m_len;} set{m_len=value;}}
        
        public Parser(IList<string>sup_ops){
            this.SupportedOperators=sup_ops;
        }

        public IList<string>Tokenize(string val)
        {
            return val.Split(" ").ToList();
        }
        public IList<Token.Token>Lex(IList<string>mem_token)
        {
            IList<Token.Token> res = new List<Token.Token>();
            for (int i = 0; i < mem_token.Count; i++)
            {
                // TODO
                // double.TryParse()
                if (double.TryParse(mem_token[i],out double _))
                {
                    var out_token = new Token.Token(TokenType.NUMBER, mem_token[i]);
                    res.Add(out_token);
                }
                else 
                {
                    var out_token = new Token.Token(TokenType.OPERATOR, mem_token[i]);
                    res.Add(out_token);

                }
            }
            return res;
        }
    }
}