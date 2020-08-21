using System;
using System.Collections.Generic;
using System.Text;

namespace NiboTestApplication.Interface
{
    public interface iUtilsService
    {
        public string ConvertOFXtoXml(string[] ofxLines);

        public T ConvertXmltoObject<T>(string xmlStr);

        public DateTime ConvertOfxDateStrtoDateTime(string ofxDateStr);
    }
}
