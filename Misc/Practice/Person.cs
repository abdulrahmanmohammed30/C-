namespace Entities
{
   internal partial class Person
    {
        public string Name { get; }
        public int Age { get; }
        public string Address { get; }
        public partial void PrintInfo();


        public Person(string Name, int Age, string address)
        {
            this.Name = Name;
            this.Age = Age;
            this.Name = address;

        }
    }
   internal partial class Person
    {
        public partial void PrintInfo()
        {
            Console.WriteLine(Name + " " + Age + " " + Address);
        }

    }
}