using System.Xml;

namespace AlinSpace.ProjectManipulator
{
    public static class XmlNodeExtensions
    {
        public static IEnumerable<XmlNode> GetNodes(
            this XmlNode node, 
            string xpath)
        {
            foreach (var n in node.SelectNodes(xpath))
            {
                var t = n as XmlNode;

                if (t == null)
                    continue;

                yield return t;
            }
        }

        public static IEnumerable<XmlAttribute> GetAttributes(
            this XmlNode node)
        {
            foreach (var a in node.Attributes)
            {
                var t = a as XmlAttribute;

                if (t == null)
                    continue;

                yield return t;
            }
        }
    }
}
