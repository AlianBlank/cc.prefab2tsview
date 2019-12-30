using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using cc.Generate;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace cc
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commandLineArgs = Environment.GetCommandLineArgs();

            string srcPath = string.Empty;
            string outPath = string.Empty;
            for (int i = 0; i < commandLineArgs.Length; i++)
            {
                string line = commandLineArgs[i];
                if (line.Equals("-src"))
                {
                    srcPath = commandLineArgs[i + 1];
                }
                else if (line.Equals("-out"))
                {
                    outPath = commandLineArgs[i + 1];
                }
            }

            if (string.IsNullOrWhiteSpace(srcPath))
            {
                srcPath = AppDomain.CurrentDomain.BaseDirectory;
            }
            if (string.IsNullOrWhiteSpace(outPath))
            {
                outPath = AppDomain.CurrentDomain.BaseDirectory;
            }

            outPath = Path.Combine(outPath) + "/";
            if (!Directory.Exists(outPath))
            {
                Directory.CreateDirectory(outPath);
            }

            
            // 目录扫描
            DirectoryInfo directory = new DirectoryInfo(srcPath);
            FileInfo[] prefabFileInfos = directory.GetFiles("*.prefab", SearchOption.AllDirectories);


            foreach (FileInfo prefabFileInfo in prefabFileInfos)
            {
                string text = File.ReadAllText(prefabFileInfo.FullName);
                object prefab = JsonConvert.DeserializeObject(text);

                JArray objectArray = (JArray)prefab;

                List<NodeModel> nodeModels = HandleNodeList(objectArray);


                for (int i = nodeModels.Count - 1; i >= 0; i--)
                {
                    NodeModel nodeModel = nodeModels[i];
                    GetFullName(nodeModels, nodeModel);
                }


                GenerateCodeView generateCodeView = new GenerateCodeView();
                generateCodeView.Type = Path.GetFileNameWithoutExtension(prefabFileInfo.Name);
                generateCodeView.SavePath = outPath + generateCodeView.Type + ".ts";
                generateCodeView.NodeModels = nodeModels;
                generateCodeView.Save();
            }
        }

        private static void GetFullName(List<NodeModel> nodeModels, NodeModel model)
        {
            foreach (NodeModel nodeModel in nodeModels)
            {
                if (nodeModel.Id == model.ParentId)
                {
                    GetFullName(nodeModels, nodeModel);
                    model.FullName = nodeModel.FullName + "/" + model.NodeName;
                }
            }

            if (model.Id == 1)
            {
                model.FullName = model.NodeName;
            }
        }

        /// <summary>
        /// 查找节点列表
        /// </summary>
        /// <param name="objectArray"></param>
        /// <returns></returns>
        private static List<NodeModel> HandleNodeList(JArray objectArray)
        {
            List<NodeModel> nodeModels = new List<NodeModel>();
            for (var index = 1; index < objectArray.Count; index++)
            {
                JToken jToken = objectArray[index];
                string type = jToken["__type__"].ToString();

                if (type == "cc.Node")
                {
                    //                        string name = jToken["_name"] == null ? string.Empty : jToken["_name"].ToString();
                    object cObj1 = JsonConvert.DeserializeObject(jToken.ToString(), ConvertTypeToComponentType(type));
                    var obj1 = (Node)cObj1;
                    NodeModel model = new NodeModel();
                    model.Children.AddRange(obj1._children.Select(m => m.__id__));
                    model.NodeName = obj1._name;
                    model.Id = index;
                    if (obj1._parent != null)
                    {
                        model.ParentId = obj1._parent.__id__;
                    }
                    else
                    {
                        model.ParentId = 0;
                    }

                    nodeModels.Add(model);
                }
            }

            return nodeModels;
        }


        static bool IsConvert(string type)
        {
            switch (type)
            {
                case "cc.Animation":
                case "cc.AudioSource":
                case "cc.Button":
                case "cc.Canvas":
                case "cc.Label":
                case "cc.LabelOutline":
                case "cc.LabelShadow":
                case "cc.Layout":
                case "cc.Mask":
                case "cc.MotionStreak":
                case "cc.PageView":
                case "cc.ProgressBar":
                case "cc.RichText":
                case "cc.ScrollBar":
                case "cc.ScrollView":
                case "cc.Slider":
                case "cc.Sprite":
                case "cc.Toggle":
                case "cc.ToggleContainer":
                case "cc.ViewGroup":
                case "cc.Widget":
                case "cc.Node":
                    return true;
            }

            return false;
        }

        static Type ConvertTypeToComponentType(string type)
        {
            switch (type)
            {
                case "cc.Animation":
                    return new Animation().GetType();
                case "cc.AudioSource":
                    return new AudioSource().GetType();
                case "cc.Button":
                    return new Button().GetType();
                case "cc.Canvas":
                    return new Canvas().GetType();
                case "cc.Label":
                    return new Label().GetType();
                case "cc.LabelOutline":
                    return new LabelOutline().GetType();
                case "cc.LabelShadow":
                    return new LabelShadow().GetType();
                case "cc.Layout":
                    return new Layout().GetType();
                case "cc.Mask":
                    return new Mask().GetType();
                case "cc.MotionStreak":
                    return new MotionStreak().GetType();
                case "cc.PageView":
                    return new PageView().GetType();
                case "cc.ProgressBar":
                    return new ProgressBar().GetType();
                case "cc.RichText":
                    return new RichText().GetType();
                case "cc.ScrollBar":
                    return new ScrollBar().GetType();
                case "cc.ScrollView":
                    return new ScrollView().GetType();
                case "cc.Slider":
                    return new Slider().GetType();
                case "cc.Sprite":
                    return new Sprite().GetType();
                case "cc.Toggle":
                    return new Toggle().GetType();
                case "cc.ToggleContainer":
                    return new ToggleContainer().GetType();
                case "cc.ViewGroup":
                    return new ViewGroup().GetType();
                case "cc.Widget":
                    return new Widget().GetType();
                case "cc.Node":
                    return new Node().GetType();
                default:
                    return new Component().GetType();
            }
        }
    }
}
