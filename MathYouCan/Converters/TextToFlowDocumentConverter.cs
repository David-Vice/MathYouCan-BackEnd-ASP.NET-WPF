using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MathYouCan.Converters
{
    public class TextToFlowDocumentConverter
    {
        /*
             If word has a differt style or font weight use specificators to show it     
             DO NOT forget to show end of line using '\n' character

             SPECIFICATORS:


               text          -->  Default text
          |~B~|text|~B~|     -->  Bold text
          |~I~|text|~I~|     -->  Italic text
          |~U~|text|~U~|     -->  UnderLine text
          |~C~|text|~C~|     -->  Selected text
          |~H~|text|~H~|     -->  Highlighted text (Not used yet)


        */

        public List<Tuple<int, int>> IndexesOfSelectedText { get; }

        private Brush _selectedTextColor;
        private Brush _userHighlightColor;

        public TextToFlowDocumentConverter(Brush selectedTextColor, Brush userHighlightColor)
        {
            _selectedTextColor = selectedTextColor;
            _userHighlightColor = userHighlightColor;
        }

        public void ConvertToParagraph(Paragraph paragraph, string text ,double fontSize = 12)
        {
            paragraph.Inlines.Clear();
            if (text != null)
            {

            

                String[] words = text.Split(' ');
           
                foreach (String word in words)
                {
                    Span span = new Span();
                    span.FontFamily = new FontFamily("Segoe UI");
                    span.FontSize = fontSize;
                    string newWord = word;


                    if (word.Contains("|~B~|"))
                    {
                        span.FontWeight = FontWeights.Bold;
                        newWord = newWord.Replace("|~B~|", "");
                    }

                    if (word.Contains("|~I~|"))
                    {
                        span.FontStyle = FontStyles.Italic;
                        newWord = newWord.Replace("|~I~|", "");
                    }

                    if (word.Contains("|~U~|"))
                    {
                        span.TextDecorations = TextDecorations.Underline;
                        newWord = newWord.Replace("|~U~|", "");
                    }


                    // 'H' (highlight) must be before 'C' (color)
                    if (word.Contains("|~H~|"))
                    {
                        span.Background = _userHighlightColor;
                        newWord = newWord.Replace("|~H~|", "");
                    }

                    if (word.Contains("|~C~|"))
                    {
                        span.Background = _selectedTextColor;
                        newWord = newWord.Replace("|~C~|", "");
                    }

                    newWord += " ";

                    span.Inlines.Add(newWord);
                    paragraph.Inlines.Add(span);
                }

            }
            
        }
    }
}
