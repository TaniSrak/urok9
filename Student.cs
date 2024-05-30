using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace Urok9
{
    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; } 
        
        public Student(string name, int age) 
        {
            Name = name;
            Age = age;
        }

    }

    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string message) : base(message) { }
    }

    public class StudentManagementSystem
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(string name, int age) //добавляем
        {
            students.Add(new Student{Name = name, Age = age});
        }

        public void RemoveStudent(string name) //кдаляем
        {
            var student = this.GetStudentByName(name);
            students.Remove(student);
        }

        public string GetStudentByName(string name)
        {
            var student = students.FirstOrDefault(s => s.Name == name);
            if(student == null)
            {
                throw new StudentNotFoundException($"Student with name'{name}' not found");
            }
            return student;
        }
        public void Print()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}: {Student.Age}");
            }
        }
    }


}
