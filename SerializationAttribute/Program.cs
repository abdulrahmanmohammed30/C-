#define TRACE_ENABLED
#define INFO

using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;
using SerializationAttribute;
using System.Xml.Serialization;

public class Program
{
    private static void Main(string[] args)
    {
        var p = new Person { Name = "Name30", Age = 22 };
        // p.ValidateEmail();
        // p.LogDebug();

        // var xmlSer = new XmlSerializer(typeof(Person));
        // XmlDocument doc = new XmlDocument();

        // xmlSer(doc, p);
        // Console.WriteLine(xml);

        // var s = new Student { Name = "Name50", Age = 22 };
        var binarySer = new BinaryFormatter();
        using (FileStream stream = new FileStream("person.bin", FileMode.Create))
        {
            binarySer.Serialize(stream, p);
        }

        using (FileStream stream = new FileStream("person.bin", FileMode.Open))
        {
            var deserializedPerson = (Person)binarySer.Deserialize(stream);
            Console.WriteLine(deserializedPerson.Name);
            Console.ReadKey();
        }

        #region 
        // var serializizer = new XmlSerializer(typeof(Student));
        // using (TextWriter writer = new StreamWriter("person.xml"))
        // {
        //     serializizer.Serialize(writer, s);
        // }
        #endregion
    }
}

public class Person
{
    public string Name { get; init; }
    public int Age { get; init; }


    [Conditional("INFO")]
    [Obsolete("This method will be deprecated in the next release. Use instead LogDebug2")]
    public void LogDebug()
    {
        Console.WriteLine("Info Method was executed");
    }

    public string email { get; init; }

    [Conditional("TRACE_ENABLED")]
    public void ValidateEmail()
    {
        Console.WriteLine("Trace Method");
    }

    public string password { get; init; }

    public Person() { }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}
