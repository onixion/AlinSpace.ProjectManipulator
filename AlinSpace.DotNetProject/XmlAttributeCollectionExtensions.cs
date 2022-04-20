using System.Xml;

namespace AlinSpace.DotNetProject
{
    public static class XmlAttributeCollectionExtensions
    {
        public static XmlAttribute GetAttribute(
            this XmlAttributeCollection collection, 
            string name)
        {
            foreach (var a in collection)
            {
                var attribute = a as XmlAttribute;

                if (attribute == null)
                    continue;

                if (attribute.Name == name)
                {
                    return attribute;
                }
            }

            return null;
        }
    }
}
