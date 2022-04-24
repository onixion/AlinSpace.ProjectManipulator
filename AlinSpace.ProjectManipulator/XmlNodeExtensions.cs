using System.Collections.Generic;
using System.Xml;

namespace AlinSpace.ProjectManipulator
{
    /// <summary>
    /// Represents the extensions for <see cref="XmlNode"/>.
    /// </summary>
    public static class XmlNodeExtensions
    {
        /// <summary>
        /// Get the nodes.
        /// </summary>
        /// <param name="node">Node to retrieve nodes from.</param>
        /// <returns>Enumerable of nodes.</returns>
        public static IEnumerable<XmlNode> GetNodes(
           this XmlNode node)
        {
            foreach (var n in node.ChildNodes)
            {
                var t = n as XmlNode;

                if (t == null)
                    continue;

                yield return t;
            }
        }

        /// <summary>
        /// Get the nodes.
        /// </summary>
        /// <param name="node">Node to retrieve nodes from.</param>
        /// <param name="xpath">X Path.</param>
        /// <returns>Enumerable of nodes.</returns>
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

        /// <summary>
        /// Get attributes.
        /// </summary>
        /// <param name="node">Node to retrieve the attributes.</param>
        /// <returns>Enumerable attribute.</returns>
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
