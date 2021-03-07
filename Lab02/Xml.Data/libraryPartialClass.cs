using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public partial class library
    {
        public override string ToString()
        {
            return "this is the string";
        }

        public void PrintLibrary()
        {
            foreach (var journal in this.journals)
            {
                Console.WriteLine(journal.ToString());
            }
        }


        

    }

    public partial class journalType : documentType
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("{0, 15}{1}", "Title = ", this.title));
            sb.AppendLine(String.Format("{0, 15}{1}", "Issue no = ", this.issue));
            sb.AppendLine(String.Format("{0, 15}{1}", "Year = ", this.year));
            sb.AppendLine(String.Format("{0, 14}", "Editors :"));
            
            //foreach (var editor in this.editors)
            //    sb.AppendLine(String.Format("{0, 20}", editor.ToString()));


            return sb.ToString();
        }
    }

    //public partial class journalTypeEditor
    //{
    //    public override string ToString()
    //    {
    //        foreach (var editor in ?????)

    //            how do I access the authors list using ref from here?????

    //           StringBuilder sb = new StringBuilder();
    //        sb.Append("{0, 15}{1}", "Title = ", this.@ref));

    //        return sb.ToString();
    //    }

    //}



    }
