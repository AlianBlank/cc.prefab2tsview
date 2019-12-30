namespace cc
{
    public class Object
    {

        public Object()
        {
            __type__ = GetType().FullName;
        }
        /// <summary>
        /// 类型
        /// </summary>
        public string __type__ { get; }
    }
}