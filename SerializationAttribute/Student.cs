using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerializationAttribute
{
    [Serializable]
    // the following class uses this interface for serialization 
    // it's nessassary to mark the class
    public class Student
    {
        public string Name { get; init; }
        public int Age
        {
            get; init;
        }
    }
}