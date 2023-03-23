
using System;
using System.Collections.Generic;
using System.Text;
namespace Token
{
    public enum TokenType{NUMBER,OPERATOR};//declare Token type
    public class Token{
        private TokenType m_TokenType;
        private string m_Value;
        private double m_num_val=0;
        public string Value{
            get{return m_Value;}
        }
        public double NumericaValue{get{return m_num_val;}}
        public TokenType pubTokenType{get{return m_TokenType;}}
        public Token(TokenType type,string val){
            this.m_Value=val;
            this.m_TokenType=type;
            if(type==TokenType.NUMBER){
                this.m_num_val=Convert.ToDouble(val);
            }
            
        }
        // TODO
        public bool IsOperator => m_TokenType == TokenType.OPERATOR;
        

        public bool IsNumber => m_TokenType == TokenType.NUMBER;


    }
}