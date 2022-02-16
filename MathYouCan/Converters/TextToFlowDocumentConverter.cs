using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace MathYouCan.Converters
{
    public class TextToFlowDocumentConverter
    {
        private Brush _selectedTextColor;
        private Brush _userHighlightColor;

        public TextToFlowDocumentConverter(Brush selectedTextColor, Brush userHighlightColor)
        {
            _selectedTextColor = selectedTextColor;
            _userHighlightColor = userHighlightColor;

        }


        public void ConvertToParagraph(Paragraph paragraph, string text, int fontSize = 12)
        {
            paragraph.Inlines.Clear();
            String[] words = text.Split(' ');

            foreach (String word in words)
            {
                Span span = new Span();
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
