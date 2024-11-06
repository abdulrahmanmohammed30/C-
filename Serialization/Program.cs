using System.Xml.Serialization;
using System.Xml;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Example1();

            Example2();

            Example3();
           

            //var jsonData = JsonSerializer.Serialize(entry2);
            //var entiry30 = (DictionaryEntry)JsonSerializer.Deserialize(jsonData, typeof(DictionaryEntry));
            //Console.WriteLine(entiry30.ToString());
            //string name = "name30";
            //using (var file=new FileStream("name.txt", FileMode.Create))
            //{
            //    file.Write(Encoding.UTF8.GetBytes(name));
            //}

            //using (var file=new FileStream("name.txt", FileMode.OpenOrCreate))
            //{
            //    while(file.Position < file.Length)
            //    {
            //        Console.WriteLine(file.ReadByte());
            //    } 
                    
            //}
        }

        private static void Example3()
        {
            DictionaryEntry entry1 = new DictionaryEntry("Amicable", "Characterized by friendliness and absence of discord.", "Adjective");
            entry1.AddSynonym("Friendly");
            entry1.AddSynonym("Cordial");
            entry1.AddAntonym("Hostile");
            entry1.AddAntonym("Unfriendly");

            var xmlSer = new XmlSerializer(typeof(DictionaryEntry));
            using (var writer = new StreamWriter("DictionaryEntry.xml"))
            {
                xmlSer.Serialize(writer, entry1);
            }

            using (var reader = new StreamReader("DictionaryEntry.xml"))
            {
                var entry = (DictionaryEntry)xmlSer.Deserialize(reader);
                entry.DisplayEntry();
            }
        }

        private static void Example1()
        {
            var p = new Person { Name = "Name30", Age = 22 };

            Console.WriteLine(JsonSerializer.Serialize(p));

            var xmlSer = new XmlSerializer(typeof(Person));
            using (var writer = new StreamWriter("person.xml"))
            {
                xmlSer.Serialize(writer, p);
            }

            using (var reader = new StreamReader("person.xml"))
            {
                var person = (Person)xmlSer.Deserialize(reader);
                Console.WriteLine(person.Name + " " + person.Age);
            }
        }

        private static void Example2()
        {

            // Creating the first dictionary entry
            DictionaryEntry entry1 = new DictionaryEntry("Amicable", "Characterized by friendliness and absence of discord.", "Adjective");
            entry1.AddSynonym("Friendly");
            entry1.AddSynonym("Cordial");
            entry1.AddAntonym("Hostile");
            entry1.AddAntonym("Unfriendly");

            // Creating the second dictionary entry
            DictionaryEntry entry2 = new DictionaryEntry("Ephemeral", "Lasting for a very short time.", "Adjective");
            entry2.AddSynonym("Transitory");
            entry2.AddSynonym("Fleeting");
            entry2.AddAntonym("Eternal");
            entry2.AddAntonym("Permanent");


            var jsonSer = new DataContractJsonSerializer(typeof(DictionaryEntry));
            using (var writer = new MemoryStream())
            {
                jsonSer.WriteObject(writer, entry2);

                var jsonStr = Encoding.UTF8.GetString(writer.ToArray());

                File.WriteAllText("person.json", jsonStr);
            }

            using (var reader = new FileStream("person.json", FileMode.Open))
            {
                var deserializedEntry = (DictionaryEntry)jsonSer.ReadObject(reader);
                Console.WriteLine(deserializedEntry.Word);

            }
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


    [Serializable]
    public class DictionaryEntry
    {
        // Attributes of the DictionaryEntry class
        public string Word { get; set; }
        public string Definition { get; set; }
        public string PartOfSpeech { get; set; }
        public List<string> Synonyms { get; set; }
        public List<string> Antonyms { get; set; }
        public DateTime LastUpdated { get; set; }

        public DictionaryEntry() { }
        // Constructor
        public DictionaryEntry(string word, string definition, string partOfSpeech)
        {
            Word = word;
            Definition = definition;
            PartOfSpeech = partOfSpeech;
            Synonyms = new List<string>();
            Antonyms = new List<string>();
            LastUpdated = DateTime.Now; // Automatically set to now when the entry is created
        }

        // Method to add a synonym
        public void AddSynonym(string synonym)
        {
            Synonyms.Add(synonym);
        }

        // Method to add an antonym
        public void AddAntonym(string antonym)
        {
            Antonyms.Add(antonym);
        }

        // Method to update the definition and the last updated time
        public void UpdateDefinition(string newDefinition)
        {
            Definition = newDefinition;
            LastUpdated = DateTime.Now;
        }

        // Method to display the dictionary entry
        public void DisplayEntry()
        {
            Console.WriteLine($"Word: {Word}");
            Console.WriteLine($"Definition: {Definition}");
            Console.WriteLine($"Part of Speech: {PartOfSpeech}");
            Console.WriteLine($"Synonyms: {string.Join(", ", Synonyms)}");
            Console.WriteLine($"Antonyms: {string.Join(", ", Antonyms)}");
            Console.WriteLine($"Last Updated: {LastUpdated}");
            Console.WriteLine();
        }
    }
}
