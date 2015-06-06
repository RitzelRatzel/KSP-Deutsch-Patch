using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KDPLogsConverter
{
    class Program
    {
        static string xmlNode = "\t<text>\n\t\t<en><![CDATA[{0}]]></en>\n\t\t<de><![CDATA[{1}]]></de>\n\t</text>\n";

        static void Main(string[] args)
        {
            string[] en = File.ReadAllLines(args[0]);
            string[] de = File.ReadAllLines(args[1]);

            string document = "";

            if (en.Count() == de.Count())
            {
                for (int i = 0; i < en.Count(); i++)
                {
                    if (en[i] != de[i])
                    {
                        document += string.Format(xmlNode, en[i].Replace("[SpriteText] ", "").Replace("[SpriteTextRich] ", ""), de[i].Replace("[SpriteText] ", "").Replace("[SpriteTextRich] ", ""));
                    }
                }
            }

            document = "<de>\n" + document + "</de>";
            File.WriteAllText("deText.xml", document, Encoding.UTF8);

        }
    }
}
