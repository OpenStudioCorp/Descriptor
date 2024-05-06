using System;
using InteractiveReadLine;

namespace siv.TextEditor
{
    public class Canvas
    {
        public string[] textLines;
        public textMode currentTextMode;

        public ReadLineConfig inputConfig = ReadLineConfig.Basic;
        
        public Canvas()
        {
            textLines = new string[1];
            currentTextMode = textMode.Write;
        }

        public void Render()
        {
            for(int i = 0; i < textLines.Length; i++)
            {
                Console.WriteLine(textLines[i]);
            }
        }
    }
}