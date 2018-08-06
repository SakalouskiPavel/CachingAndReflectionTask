using System;
using System.Security.AccessControl;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace Task2
{
    public class XmlParser<T> 
        where T: class
    {
        public string Serialize(T obj)
        {
            XDocument doc = new XDocument();
            var name = obj.GetType().Name;
            XElement objName = new XElement(name);
            
            foreach (var property in obj.GetType().GetProperties())
            {
                XElement prop = new XElement(property.Name, property.GetValue(obj));
                objName.Add(prop);
            }

            doc.Add(objName);
            
            return doc.ToString();
        }

        public T Deserialize(string xml)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            XDocument doc = new XDocument();
            var obj = XElement.Parse(xml);
            doc.Add(obj);
            var props = typeof(T).GetProperties();

            T newObj = xs.Deserialize(doc.CreateReader()) as T;

            return newObj;
        }
    }
}