/*
Student name: Hoang Minh Le
Student number: 511907
*/
using System;
using System.Globalization;
namespace Grade
{
    public class Grade
    {
        private double m_grade;//grade of the test
        private readonly DateTime m_Date;//Date of the exam
        private readonly int m_Exam_code;//Exam code
        private readonly string m_Note;//Note from teacher
        private bool m_Frozen = false;//if this m_Frozen is false then, grade can be changed

        private static bool check(double val)//check for the valid grade that entered
        {
            bool flag = false;
            for (double i = 0; i <= 10; i += 0.5)
            {
                if (val == i)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public DateTime Exam_Date{
            get{return m_Date;}
        }
        public int Exam_code{
            get{return m_Exam_code;}
        }
        public string Note{
            get{return m_Note;}
        }
        public double grade{
            get{return m_grade;}
        }
        public bool immutable{//Able to change grade or not
            get{return m_Frozen;}
            set{m_Frozen=value;}
        }

        public Grade(double val, int Exam_code, string Note)
        {
            if (!check(val))
                //throw new ArgumentException("Your grade is invalid, please check and enter again.\n");
                Console.WriteLine("Your grade is invalid. Please recheck it again");
            else
            {
                this.m_grade = val;
                this.m_Exam_code = Exam_code;
                this.m_Note = Note;
                this.m_Date = DateTime.Now;
            }
        }

        public Grade(double val, int Exam_code, string Note,DateTime exam_Date)
        {
            if (!check(val))
                //throw new ArgumentException("Your grade is invalid, please check and enter again.\n");
                Console.WriteLine("Your grade is invalid. Please recheck it again");
            else
            {
                this.m_grade = val;
                this.m_Exam_code = Exam_code;
                this.m_Note = Note;
                this.m_Date = exam_Date;
            }
        }

        

        public string toString(){
            return ($"{m_Exam_code} on {m_Date}: {m_grade} Note: {m_Note}");
        }
        
        public void change_grade(double val){
            if(m_Frozen){
                Console.WriteLine("Cannot change the grade");
                Console.WriteLine("Please change immutable to able to change the grade");
            }
            else{
                m_grade=val;
            }
        }
    }
}