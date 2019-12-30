using System.Collections.Generic;

namespace cc.Generate
{
    public class ClassViewModel
    {
        public string Name { get; }
        public Dictionary<string, string> Properties { get; }

        public ClassViewModel(string name)
        {
            Name = name;
            Properties = new Dictionary<string, string>();
        }
    }
}