using System;
using System.Windows.Documents;
using System.Windows.Media;

namespace MathYouCan.Converters
{
    public class Highlighter
    {
        /*
            APPLIES highlight specificator to text
         */


        private string _selectedText = String.Empty;


        public Highlighter()
        {

        }


        /// <summary>
        /// Adds highlight specificator(|~H~|) to all words in 'range'
        /// </summary>
        /// <param name="text"></param>
        /// <param name="range"></param>
        public void Highlight(string text, TextRange range, Brush highlightBrush)
        {

            //try
            //{
            //    int idxOfRange = text.IndexOf(range.Text);

            //    int startPos = idxOfRange;

            //    while (text[startPos] != ' ' && startPos > 0) startPos--;  // Getting start of the word

            //    int endPos = idxOfRange + range.Text.Length;
            //    while(text[endPos] != ' ' && startPos < text.Length) endPos++;  // Getting end of the word

            //    MessageBox.Show(startPos.ToString() + " " + endPos.ToString());

            //    string tmp = text.Substring(startPos, endPos - startPos + 1);
            //    String[] words = tmp.Split(' ');

            //    for (int i = startPos; i < endPos; i++)
            //    {


            //    }

            //    MessageBox.Show(text);


            //}
            //catch (Exception) { }
        }

    }
}
