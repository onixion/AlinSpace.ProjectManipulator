using System;
using System.Xml;

namespace AlinSpace.ProjectManipulator.Internal
{
    public class NodePropertyHandler<T>
    {
        private readonly XmlDocument document;
        private readonly XmlNode parentNode;
        private readonly string name;
        private Func<T, string> serialize;

        private XmlNode node;

        public NodePropertyHandler(
            XmlDocument document,
            XmlNode parentNode,
            string name,
            Func<string, T> deserialize,
            Func<T, string> serialize)
        {
            this.document = document;
            this.parentNode = parentNode;
            this.name = name;
            this.serialize = serialize;

            // Initial read.

            node = parentNode.SelectSingleNode(name);
            if (node != null)
            {
                try
                {
                    value = deserialize(node.InnerText);
                }
                catch
                {
                    value = default;
                }
            }
        }

        private T value;

        public T GetValue()
        {
            return value;
        }

        public void SetValue(T value)
        {
            if (value == null)
            {
                if (node != null)
                {
                    parentNode.RemoveChild(node);
                    node = null;
                }
            }
            else
            {
                if (node == null)
                {
                    node = document.CreateElement(name);
                    parentNode.AppendChild(node);
                }

                try
                {
                    node.InnerText = serialize(value);
                    this.value = value;
                }
                catch
                {
                    node.InnerText = null;
                    this.value = default;
                }
            }
        }
    }
}
