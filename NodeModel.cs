using System.Collections.Generic;

namespace cc
{
    public class NodeModel
    {
        public string NodeName { get; set; }
        public int ParentId { get; set; }
        public List<int> Children { get; set; }

        public string FullName { get; set; }
        public int Id { get; set; }

        public NodeModel()
        {
            Children = new List<int>();
            FullName = string.Empty;
        }
    }
}