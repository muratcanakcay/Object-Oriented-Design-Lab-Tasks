using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Collections.Generic;
using System;

namespace Xml.Console
{
    public static class LibraryReader
    {
        static bool valid = true; // validation result

        public static Library.library ReadLibrary(string path)
        {
            if (!Validate(path)) return null;
            var serializer = new XmlSerializer(typeof(Library.library));
            return (Library.library)serializer.Deserialize(new FileStream(path, FileMode.Open, FileAccess.Read));
        }

        public static bool Validate(string path)
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
            
            // Read method reads next element or attribute from the document
            // It will call ValidationEventHandler if some invalid
            // part occurs
            while (reader.Read());

            // always dispose of reader to free the resources!
            reader.Dispose();
            
            if (valid) System.Console.WriteLine("Validation passed");
            else System.Console.WriteLine("Validation failed"); ;

            return valid;
        }

        private static void ValidationHandler(Object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                System.Console.WriteLine("Warning: {0}", args.Message);
            else
                System.Console.WriteLine("Error: {0}", args.Message);
            
            System.Console.WriteLine("------------------------------------------");
            valid = false;
        }
    }
}