namespace cc
{
    /// <summary>
    /// 所有附加到节点的基类
    /// </summary>
    public class Component : Object
    {
        /// <summary>
        /// 
        /// </summary>
        public string _name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 组件的 uuid，用于编辑器
        /// </summary>
        public string uuid { get; set; }
        /// <summary>
        /// 还不知道有什么用
        /// </summary>
        public int _objFlags { get; set; }
        /// <summary>
        /// 该组件被附加到的节点
        /// </summary>
        public Node node { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public string _enabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string _id { get; set; }
    }
}