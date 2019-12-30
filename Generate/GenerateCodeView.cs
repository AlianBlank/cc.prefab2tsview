using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace cc.Generate
{
    public class GenerateCodeView
    {
        public string Type
        {
            get { return m_type; }
            set
            {
                if (!value.EndsWith("View"))
                {
                    value += "View";
                }
                m_type = value;
            }
        }

        public string SavePath { get; set; }

        public List<NodeModel> NodeModels { get; set; }
        private string m_type;

        public void Save()
        {
            StringBuilder stringBuilder = new StringBuilder();
            // title
            stringBuilder.AppendLine("/**");
            stringBuilder.AppendLine(" * generate by time :" + DateTime.Now);
            stringBuilder.AppendLine(" */");
            // 引用
            stringBuilder.AppendLine("import Utility from '../Script/Utils/Utility';");
            stringBuilder.AppendLine();
            // 头定义
            stringBuilder.AppendLine("const { ccclass, property } = cc._decorator;");
            stringBuilder.AppendLine();
            // 类型声明
            stringBuilder.AppendLine("@ccclass");
            stringBuilder.AppendFormat("export default class {0} extends cc.Component {{\r", Type);

            // 私有节点对象
            for (var index = 1; index < NodeModels.Count; index++)
            {
                NodeModel nodeModel = NodeModels[index];
                string newName = nodeModel.FullName.Substring(nodeModel.FullName.IndexOf('/') + 1);
                stringBuilder.AppendFormat("    private {0}:cc.Node;\r", newName.Replace("/", "_"));
            }

            stringBuilder.AppendLine();
            stringBuilder.AppendLine("    onLoad() {");

            // 获取节点对象
            for (var index = 1; index < NodeModels.Count; index++)
            {
                NodeModel nodeModel = NodeModels[index];

                string newName = nodeModel.FullName.Substring(nodeModel.FullName.IndexOf('/') + 1);
                stringBuilder.AppendFormat("        this.{0} = Utility.findChildByName(this.node,'{1}');\r",
                    newName.Replace("/", "_"), newName);
            }

            stringBuilder.AppendLine("    }");

            // Methods 
            stringBuilder.AppendLine();


            stringBuilder.AppendLine("    /**");
            stringBuilder.AppendLine("    * 隐藏当前对象");
            stringBuilder.AppendLine("    */");
            stringBuilder.AppendLine("    public hide(): void {");
            stringBuilder.AppendLine("        this.node.active = false;");
            stringBuilder.AppendLine("    }");

            stringBuilder.AppendLine("    /**");
            stringBuilder.AppendLine("    * 显示当前对象");
            stringBuilder.AppendLine("    */");
            stringBuilder.AppendLine("    public show(): void {");
            stringBuilder.AppendLine("        this.node.active = true;");
            stringBuilder.AppendLine("    }");


            stringBuilder.AppendLine("}");
            File.WriteAllText(SavePath, stringBuilder.ToString(), Encoding.UTF8);
        }

    }
}