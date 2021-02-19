using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Util
{
    public class AccessUrl
    {
        protected string BaseUrl
        {
            get
            {
                string strConn = string.Empty;
                XmlDocument configXml = new XmlDocument();
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + "/API_Url_DEV.xml";
                configXml.Load(path);

                XmlNodeList addNodes = configXml.SelectNodes("configuration/settings/add");

                foreach (XmlNode node in addNodes)
                {
                    if (node.Attributes["key"].InnerText == "ApiAddress")
                    {
                        strConn = (node.ChildNodes[0]).InnerText;
                        break;
                    }
                }
                return strConn;
            }
        }
    }
}
