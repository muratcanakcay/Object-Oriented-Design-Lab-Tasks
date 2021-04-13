﻿namespace Task2
{
    public class RemoveCharacterFromContent : Transformation
    {
        private readonly char _c;

        public RemoveCharacterFromContent(char c, IFileSystemNode node) : base(node)
        {
            this._c = c;
        }

        public override string GetPrintableContent()
        {
            if (!Node.IsDir())
            {
                string newContent = RemoveChar(Node.GetPrintableContent(), _c);
                return newContent;
            } 
            else return Node.GetPrintableContent();
        }

        private string RemoveChar(string input, char c)
        {
            var n = input.Length;

            for (int i = 0; i < n; i++)
            {
                if (!input[i].Equals(c)) continue;
                
                input = input.Remove(i--, 1);
                n--;
            }

            return input;
        }
    }
}




