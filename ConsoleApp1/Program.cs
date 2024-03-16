using System;
using System.IO;

namespace ConsoleApp1
{
    class Writer
    {
        public virtual void WriteProprty(string propName, object propValue)
        {

        }
    }
    class ConsoleWriter : Writer
    {
        public override void WriteProprty(string propName, object propValue)
        {
            Console.WriteLine($"{propName} : {propValue}"); 
        }
    }
    class FileWriter : Writer
    {
        public override void WriteProprty(string propName, object propValue)
        {
            File.AppendAllText("out.txt",$"{propName} : {propValue}"); 
        }
    }


    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual void Print()
        {
            Console.WriteLine($"{FirstName} {LastName} {BirthDate}");
        }

        public void Save(Writer writer)
        {
            writer.WriteProprty("Фамилия", LastName);
            writer.WriteProprty("Имя", FirstName);
            writer.WriteProprty("ДР", BirthDate);
        }

    }
    

    class Student : Person
    {
        public string [] Disciplines { get; set; }
        public string Group { get; set; }

        public override void Print()
        {
            Console.WriteLine($"{FirstName} {LastName} учится в группе {Group}");
        }

    }
    class Teacher : Person
    {
        public string Kafedra { get; set; }
        public override void Print()
        {
            Console.WriteLine($"{FirstName} {LastName} преподает на кафедре {Kafedra}");
        }
    }



    class Program
    {        

        static void Main(string[] args)
        {
            Person s = new Student();
           // s.Print();

            s.Save(new FileWriter());
            //s.Save(new ConsoleWriter());

        }
    }
}
