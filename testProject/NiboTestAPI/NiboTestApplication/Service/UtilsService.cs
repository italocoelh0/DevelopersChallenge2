using NiboTestApplication.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NiboTestApplication.Utils
{
    public class UtilsService : iUtilsService
    {
        public string ConvertOFXtoXml(string[] ofxLines)
        {
            string fileStr = "<DtoData>";

            foreach (string line in ofxLines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    string tagValue = "";
                    string tagName = "";

                    if (!line.StartsWith("<"))
                    {
                        string[] strAux = line.Split(":");
                        if (strAux.Count() > 0)
                            tagName = strAux[0];

                        tagValue = line.Replace($"{tagName}:", "");

                        fileStr += $"<{tagName}>{tagValue}</{tagName}>";
                    }
                    else if (line.StartsWith("<") && !line.EndsWith(">") && line.IndexOf('>') > -1)
                    {
                        tagName = line.Substring(1, line.IndexOf('>')-1);

                        if (line.IndexOf('>') < line.Length)
                            tagValue = line.Substring(line.IndexOf('>') + 1);

                        fileStr += $"<{tagName}>{tagValue}</{tagName}>";
                    }
                    else
                    {
                        fileStr += line;
                    }
                }
            }

            fileStr += "</DtoData>";

            return fileStr;
        }

        public T ConvertXmltoObject<T>(string xmlStr)
        {
            if (string.IsNullOrEmpty(xmlStr))
                throw new Exception("O xml está vazio.");

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader dadosXml = new StringReader(xmlStr);
            var obj = (T)serializer.Deserialize(dadosXml);
            dadosXml.Close();

            return (T)Convert.ChangeType(obj, typeof(T));
        }
    
        public DateTime ConvertOfxDateStrtoDateTime(string ofxDateStr)
        {
            string year = ofxDateStr.Substring(0,4);
            string month = ofxDateStr.Substring(4, 2);
            string day = ofxDateStr.Substring(6, 2);

            string hour = ofxDateStr.Substring(8, 2);
            string minutes = ofxDateStr.Substring(10, 2);
            string seconds = ofxDateStr.Substring(12, 2);

            return Convert.ToDateTime($"{year}-{month}-{day}T{hour}:{minutes}:{seconds}");
        }
    }
}
