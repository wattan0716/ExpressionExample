using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ExpressionSample;

namespace ExpressionTest
{
    [TestClass]
    public class InstanceCreaterTest
    {
        [TestMethod]
        public void Newと動的に生成したインスタンスが同じであること()
        {
            var person = new Person();
            var expressionPerson = InstanceCreater<Person>.Create();
            Assert.AreEqual(person.GetType(), expressionPerson.GetType());
        }

        [TestMethod]
        public void Newと動的に生成したインスタンスが同じであること_引数がひとつ()
        {
            var student = new Student("Test");
            var expressionStudent = InstanceCreater<string, Student>.Create("Test");
            Assert.AreEqual(student.Name, expressionStudent.Name);
        }

        [TestMethod]
        public void Newと動的に生成したインスタンスが同じであること_引数が二つ()
        {
            var teacher = new Teacher("Test", 25);
            var expressionTeacher = InstanceCreater<string, int, Teacher>.Create("Test", 25);

            Assert.AreEqual(teacher.Name, expressionTeacher.Name);
            Assert.AreEqual(teacher.Age, expressionTeacher.Age);
        }

    }
    public class Person { }
    public class Student
    {
        public Student(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }

    public class Teacher
    {
        public Teacher(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
