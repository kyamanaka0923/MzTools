using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace DiffForMzPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            MzXmlParser xmlPerser = new MzXmlParser();
            xmlPerser.SplitInvocations(args[0]);

        }
    }

    class MzXmlParser
    {
        // XMLを読み取りファイルに出力する
        public void SplitInvocations(string filename)
        {
            XDocument xmlDoc = XDocument.Load(filename);
            foreach (var invocation in  xmlDoc.Element("information").Element("invocations").Elements("invocation")){
                // コンポーネントIDを取得
                var srcComponentId = invocation.Element("source").Attribute("component").Value.ToString();

                // ファイル名に変換
                Directory.CreateDirectory("splitfiles");
                File.WriteAllText("splitfiles\\component_" + srcComponentId + ".xml", invocation.ToString());

            }

        }

    }
}
