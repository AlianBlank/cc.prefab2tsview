using System.Collections.Generic;

namespace cc
{
    public class Node : Object
    {
      
        /// <summary>
        /// 
        /// </summary>
        public int __id__ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string _name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Node _parent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Node> _children { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string _active { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string _id { get; set; }
    }
}