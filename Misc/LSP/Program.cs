namespace LSP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Demo.Test();
            Console.ReadLine();
        }
    }

    public class Person
    {
        public  string GetInfo()
        {
            return "Person Info";
        }
    }

    public class Student : Person
    {
        public  string GetInfo()
        {
            return "Student Info";
        }
    }

    public class Demo
    {
        public static void Test()
        {
            Student st = new Student();
            Person p = (Person)st; // Casting Student as Person

            Console.WriteLine(p.GetInfo()); // What does this output?
        }
    }

}
