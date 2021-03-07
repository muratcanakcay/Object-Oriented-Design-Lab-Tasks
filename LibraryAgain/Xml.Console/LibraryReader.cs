using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace Xml.Console
{
    public static class LibraryReader
    {
        static bool valid = true;
        
        public static Library.library ReadLibrary(string path)
        {
            var serializer = new XmlSerializer(typeof(Library.library));
            
            if(!Validator(path)) return null;

            return (Library.library)serializer.Deserialize(new FileStream(path, FileMode.Open, FileAccess.Read));
        }

        public static bool Validator(string path)
        {
            void ValidationHandler(Object sender, ValidationEventArgs args)
            {
                if (args.Severity == XmlSeverityType.Warning)
                    System.Console.WriteLine("Warning: {0}", args.Message);
                else
                    System.Console.WriteLine("Error: {0}", args.Message);

                valid = false;
            }

            //...
            XmlReaderSettings settings = new XmlReaderSettings();
            // Validator settings
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

            // Here we add xsd files to namespaces we want to validate
            // (It's like XML -> Schemas setting in Visual Studio)
            settings.Schemas.Add("http://example.org/mca/library2", "library2.xsd");

            // Processing XSI Schema Location attribute
            // (Disabled by default as it is a security risk). 
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;

            // A function delegate that will be called when 
            // validation error or warning occurs
            settings.ValidationEventHandler += ValidationHandler;

            XmlReader reader = XmlReader.Create(path, settings);

            // Read method reads next element or attribute from the document
            // It will call ValidationEventHandler if some invalid
            // part occurs
            while (reader.Read())
            {
            }

            return valid;
        }
    }

    


}
