using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Xml.Console
{
    public static class LibraryReader
    {
        // --------- Lab01
        
        public static Library.library ReadLibrary1(string path)
        {
            var serializer = new XmlSerializer(typeof(Library.library));
            return (Library.library)serializer.Deserialize(new FileStream(path, FileMode.Open, FileAccess.Read));
        }

        // --------- Lab02

        public static IEnumerable<string> ReadLibrary2(string path)
        {

            XmlReaderSettings settings = new XmlReaderSettings();
            // Validator settings
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

            // Here we add xsd files to namespaces we want to validate
            // (It's like XML -> Schemas setting in Visual Studio)
            settings.Schemas.Add("http://example.org/mca/library", "library.xsd");

            // Processing XSI Schema Location attribute
            // (Disabled by default as it is a security risk). 
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;

            // A function delegate that will be called when 
            // validation error or warning occurs
            settings.ValidationEventHandler += ValidationHandler;

            XmlReader reader = XmlReader.Create(path, settings);

            var authors = new List<string>();
            
            // Read method reads next element or attribute from the document
            // It will call ValidationEventHandler if some invalid
            // part occurs
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "surname")
                    authors.Add(reader.ReadElementContentAsString());
            }

            return authors;



            void ValidationHandler(Object sender, ValidationEventArgs args)
            {
                if (args.Severity == XmlSeverityType.Warning)
                    System.Console.WriteLine("Warning: {0}", args.Message);
                else
                    System.Console.WriteLine("Error: {0}", args.Message);
            }

        }

    }

    
   
}
