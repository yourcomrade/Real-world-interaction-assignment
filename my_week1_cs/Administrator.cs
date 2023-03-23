/*
Student name: Hoang Minh Le
Student number: 511907
*/
using System;
using System.Globalization;
using Grade;
using Student;
using System.Collections.Generic;
namespace Administrator{
    public class Administrator{
        private List<Student.Student> m_student_list=new List<Student.Student>();
        public List<Student.Student> my_students{
            get{return m_student_list;}
            set{m_student_list=value;}
        }

        public void printStudents(){
            foreach(var i in m_student_list){
                Console.WriteLine(i.toString());
            }
        }
        public void add(Student.Student the_student){
            m_student_list.Add(the_student);
        }
        public void remove(int student_number){
            if(m_student_list.Exists(x=>x.student_number == student_number)){
                var student=m_student_list.Find(x=>x.student_number==student_number);
                m_student_list.Remove(student);
            }
            else{
                Console.WriteLine("Cannot delete the student who does not exist");
            }
        }

    }
}