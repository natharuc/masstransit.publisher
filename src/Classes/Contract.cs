using System;

namespace Publicador.Classes
{
    public class Contract
    {
        public string Name { get; set; }
        public Type Type { get; set; }

        public Contract(string name, Type type)
        {
            Name = name;
            Type = type;
        }
    }
}
