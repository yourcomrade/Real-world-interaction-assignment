// See https://aka.ms/new-console-template for more information
/*
Student name: Hoang Minh Le
Student number: 511907
*/

using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Grade;
using Student;
using System.Globalization;
using Administrator;
namespace my_week_1_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Administrator.Administrator person=new Administrator.Administrator();
            DateTime my_1,my_2,my_3,ex_1,ex_2,ex_3,d_t,d_e;
            string date1="03/07/1998",date2="04/05/2000",date3="05/04/1999",
            date_ex="05/04/2022",date_ex2="11/04/2022",date_ex3="06/06/2022",
            date_start="01/04/2022",data_end="05/06/2022";
            string format="d";
            my_1=DateTime.ParseExact(date1,format,CultureInfo.InvariantCulture);
            my_2=DateTime.ParseExact(date2,format,CultureInfo.InvariantCulture);
            my_3=DateTime.ParseExact(date3,format,CultureInfo.InvariantCulture);
            ex_1=DateTime.ParseExact(date_ex,format,CultureInfo.InvariantCulture);
            ex_2=DateTime.ParseExact(date_ex2,format,CultureInfo.InvariantCulture);
            ex_3=DateTime.ParseExact(date_ex3,format,CultureInfo.InvariantCulture);
            d_t=DateTime.ParseExact(date_start,format,CultureInfo.InvariantCulture);
            d_e=DateTime.ParseExact(data_end,format,CultureInfo.InvariantCulture);

            person.add(new Student.Student("The","Wok",my_1,304978));
            person.add(new Student.Student("Yi Long","Musk",my_2,567893));
            person.add(new Student.Student("Zhong","Xina",my_3,768904));

            Console.WriteLine("List of my student");
            person.printStudents();

            //Student The Wok
            person.my_students[0].setGrade(123456,6.5,ex_1);//Biology
            person.my_students[0].setGrade(123675,8.5,ex_2);//Chemistry
            person.my_students[0].setGrade(343546,9,ex_1);//Math, cannot change grade
            person.my_students[0].student_grades[2].immutable=true;
            person.my_students[0].setGrade(343546,9.5,ex_3);//Math resit

            person.my_students[0].setGrade(786312,6.5,ex_1);//Literature
            Console.WriteLine(person.my_students[0].toString());
            person.my_students[0].printGrades();
            Console.WriteLine("Student average point: {0}",person.my_students[0].gradePointAverage());

            //Student Yi Long Musk list of grade
            person.my_students[1].setGrade(234542,8,ex_2);//Biology
            person.my_students[1].setGrade(345231,8.5,ex_2);//Chemistry
            person.my_students[1].setGrade(435612,5.5,ex_1);//Math, cannot change grade
            person.my_students[1].student_grades[2].immutable=true;
            person.my_students[1].setGrade(435612,7.5,ex_3);//Math resit
            person.my_students[1].setGrade(756313,7.5,ex_2);//Literature
            person.my_students[1].setGrade(756313,9.5,ex_3);//Literature reassessemnt 
            Console.WriteLine(person.my_students[1].toString());
            Console.WriteLine("Print grade student Yi Long Musk from {0} to {1} ",d_t.ToString(),d_e.ToString());
            person.my_students[1].printGrades(d_t,d_e);

            //Student Zhong Xina
            person.my_students[2].setGrade(345897,5.5,ex_1);//Biology
            person.my_students[2].setGrade(346123,6.5,ex_1);//Chemistry
            person.my_students[2].setGrade(321454,4.5,ex_1);//Math, cannot change grade
            person.my_students[2].student_grades[2].immutable=true;
            person.my_students[2].setGrade(321454,7.5,ex_3);//Math, resit
            person.my_students[2].setGrade(324152,6.5,ex_2);//Literature
            person.my_students[2].setGrade(324152,7.5,ex_3);//Literature reassessment
            Console.WriteLine(person.my_students[2].toString());
            person.my_students[2].printGrades();
            Console.WriteLine("Student average point: {0}",person.my_students[2].gradePointAverage());


            Console.WriteLine("Try to delete student whose student number is 456281");
            person.remove(456281);
            Console.WriteLine("Now delete Yi Long Musk");
            person.remove(567893);
            person.printStudents();

        }
    }
};

