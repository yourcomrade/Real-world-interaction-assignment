/*
Student name: Hoang Minh Le
Student number: 511907
*/
using System;
using System.Collections.Generic;
using Grade;
namespace Student{
   

    public class Student{
        private List<Grade.Grade> m_grade_list=new List<Grade.Grade>();
        private DateTime m_birth_day;
        private string m_First_name;
        private string m_Last_name;
        private readonly string m_Full_name;
        private int m_student_number;
        public string Full_name{
            get{return m_Full_name;}
        }
        public int student_number{
            get{return m_student_number;}
        }
        public List<Grade.Grade> student_grades{
            get{return m_grade_list;}
        }

        public Student(string First_name,string Last_name,DateTime birth_date,int student_number){
            this.m_First_name=First_name;
            this.m_Last_name=Last_name;
            this.m_birth_day=birth_date;
            this.m_student_number=student_number;
            this.m_Full_name=m_First_name+" "+m_Last_name;
            //this.m_grade_list=new List<Grade.Grade>();
        }

        public void setGrade(int exam_code,double grade){
            if(m_grade_list.Exists(x=>x.Exam_code==exam_code)){//using lambda expression
                var same_code_grade=m_grade_list.Find(x=>x.Exam_code==exam_code);
                if(!same_code_grade.immutable){//Check if the changing grade is possible
                    same_code_grade.change_grade(grade);
                }
                else{
                    m_grade_list.Add(new Grade.Grade(grade,exam_code,"Resit"));
                }
            }
            else{
                m_grade_list.Add(new Grade.Grade(grade,exam_code,"1st attempt"));
            }
            
        }
         public void setGrade(int exam_code,double grade,DateTime exam_Date){
            if(m_grade_list.Exists(x=>x.Exam_code==exam_code)){//using lambda expression
                var same_code_grade=m_grade_list.Find(x=>x.Exam_code==exam_code);
                if(!same_code_grade.immutable){//Check if the changing grade is possible
                    same_code_grade.change_grade(grade);
                }
                else{
                    m_grade_list.Add(new Grade.Grade(grade,exam_code,"Resit",exam_Date));
                }
            }
            else{
                m_grade_list.Add(new Grade.Grade(grade,exam_code,"1st attempt",exam_Date));
            }
            
        }

        public string toString(){
            return ($"Student's full name: {m_Full_name}, student number: {m_student_number}");
        }
        public void printGrades(){//Print all the grades of student
            m_grade_list.Sort((a,b)=>b.Exam_Date.CompareTo(a.Exam_Date));//Sort for descending order
            foreach(Grade.Grade i in m_grade_list){
                Console.WriteLine(i.toString());
            }
        }
        public void printGrades(DateTime start,DateTime end){//Print the grades of student 
        //which are result of exam taking place from DateTime start to end
            foreach(Grade.Grade i in m_grade_list){
                if(i.Exam_Date>=start&&i.Exam_Date<=end){
                    Console.WriteLine(i.toString());
                }
            }
        }
        public  List<Grade.Grade> GradeFor(int exam_code){
            List<Grade.Grade>res=new List<Grade.Grade>();
            foreach(Grade.Grade i in m_grade_list){
                if(i.Exam_code==exam_code){
                    res.Add(i);
                }
            }
            return res;
        }
        public double gradePointAverage(){
            var code_and_grade = new Dictionary<int ,double>();
            foreach(var i in m_grade_list){
                if(code_and_grade.ContainsKey(i.Exam_code)){
                    if(code_and_grade[i.Exam_code]<i.grade){
                        code_and_grade[i.Exam_code]=i.grade;
                    }
                }
                else{
                    code_and_grade.Add(i.Exam_code,i.grade);
                }
            }
            double sum=0;
            int num=1;
            foreach(var i in code_and_grade){
                
                sum+=i.Value;
                num++;
            }
            return (sum/num);
        }
    


    }
}