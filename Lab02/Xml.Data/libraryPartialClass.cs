using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Library
{
    public partial class library
    {
        public override string ToString()
        {
            var sb = new StringBuilder();

            var authorList = new Dictionary<string, authorType>();
            foreach (var author in authors)
                authorList.Add(author.id, author);

            sb.AppendLine("LIBRARY CONTENTS:\n");
            
            sb.AppendLine("Books:\n");
            foreach(var book in books)
            {
                var bookString = book.ToString();
                var reader = new StringReader(bookString);
                string line;
                var fields = new List<string>();
                while ((line = reader.ReadLine()) != null)
                    fields.Add(line);
                
                sb.AppendLine(String.Format("{0, -15}{1}{2}", "Title", " = ", fields[0]));
                sb.AppendLine(String.Format("{0, -15}{1}{2}", "Language", " = ", fields[1]));
                sb.AppendLine(String.Format("{0, -15}{1}{2}", "Year", " = ", fields[2]));
                sb.AppendLine(String.Format("{0, -14}", "Authors :"));
                for (int i = 3; i < fields.Count; i++)
                {
                    var rf = fields[i];
                    sb.AppendLine(String.Format("       {0, -14}", authorList[rf].ToString()));
                }

                sb.AppendLine();
            }

            sb.AppendLine("Journals:\n");
            foreach (var journal in journals)
            {
                var journalString = journal.ToString();
                var reader = new StringReader(journalString);
                string line;
                var fields = new List<string>();
                while ((line = reader.ReadLine()) != null)
                    fields.Add(line);

                sb.AppendLine(String.Format("{0, -15}{1}{2}", "Title", " = ", fields[0]));
                sb.AppendLine(String.Format("{0, -15}{1}{2}", "Issue no", " = ", fields[1]));
                sb.AppendLine(String.Format("{0, -15}{1}{2}", "Year", " = ", fields[2]));
                sb.AppendLine(String.Format("{0, -14}", "Editors :"));
                for (int i = 3; i < fields.Count; i++)
                {
                    var rf = fields[i];
                    sb.AppendLine(String.Format("       {0, -14}", authorList[rf].ToString()));
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }

    public partial class journalType : documentType
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.title);
            sb.AppendLine(this.issue);
            sb.AppendLine(this.year);
            foreach (var editor in this.editors)
                sb.AppendLine(editor.ToString());

            return sb.ToString();
        }
    }

    public partial class bookType : documentType
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.title);
            sb.AppendLine(this.lang.ToString());
            sb.AppendLine(this.year);
            foreach (var author in this.authors)
                sb.AppendLine(author.ToString());

            return sb.ToString();
        }
    }

    public partial class journalTypeEditor
    {
        public override string ToString()
        {
            return this.@ref;
        }
    }

    public partial class bookTypeAuthor
    {
        public override string ToString()
        {
            return this.@ref;
        }
    }

    public partial class authorType
    {
        public override string ToString()
        {
            return string.Join(", ", this.names) + ", " + this.surname;
        }
    }
}