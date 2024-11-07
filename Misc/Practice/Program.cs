using Entities;

namespace Practice;


 class Program
    {
        static void Main(string[] args)
        {
            var p = new Person("name", 22, "address");
                p.PrintInfo();

            Console.WriteLine(Utils.Add(5, 6));
            Console.ReadLine();
    }
}
