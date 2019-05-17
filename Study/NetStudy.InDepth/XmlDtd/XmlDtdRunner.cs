using NetStudy.Core;
using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace NetStudy.InDepth.XmlDtd
{
    public class XmlDtdRunner : IRunner
    {
        public void Run()
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.DTD;
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            settings.XmlResolver = new XmlUrlResolver();
            //settings.NameTable = new NameTable();

            //XmlParserContext context = new XmlParserContext(settings.NameTable, 
            //    new XmlNamespaceManager(settings.NameTable), "book", "", "resources\\book.dtd", "", "", "en", XmlSpace.Default);

            settings.IgnoreWhitespace = true;

            // Create the XmlReader object.
            // Parse the file.
            XmlReader reader = XmlReader.Create("resources\\book.xml", settings);
            while (reader.Read())
            {
                Console.WriteLine("{0}, {1}: {2} ", reader.NodeType, reader.Name, reader.Value);
            }

            using (XmlWriter writer = XmlWriter.Create(File.OpenWrite("output.xml")))
            {
                writer.WriteNode(reader, true);
            }
        }
        void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
                Console.WriteLine("Warning: Matching schema not found.  No validation occurred." + e.Message);
            else // Error
                Console.WriteLine("Validation error: " + e.Message);
        }
    }
}