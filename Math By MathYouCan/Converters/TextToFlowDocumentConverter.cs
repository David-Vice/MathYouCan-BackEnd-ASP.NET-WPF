using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
          |~B~| text |~B~|     -->  Bold text
          |~I~| text |~I~|     -->  Italic text
          |~U~| text |~U~|     -->  UnderLine text
          |~C~| text |~C~|     -->  Selected text
          |~H~| text |~H~|     -->  Highlighted text (Not used yet)


        */

        public List<Tuple<int, int>> IndexesOfSelectedText { get; }

        private Brush _selectedTextColor;
        private Brush _userHighlightColor;

        private bool _isBoldActive = false;
        private bool _isItalicActive = false;
        private bool _isUnderlineActive = false;
        private bool _isSelectedActive = false;


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
                    if (word.Contains("|~B~|"))
                        _isBoldActive = !_isBoldActive;

                    if (word.Contains("|~I~|"))
                        _isItalicActive = !_isItalicActive;

                    if (word.Contains("|~U~|"))
                        _isUnderlineActive = !_isUnderlineActive;

                    if (word.Contains("|~C~|"))
                        _isSelectedActive = !_isSelectedActive;

                    Span span = new Span();
                    span.FontFamily = new FontFamily("Segoe UI");
                    span.FontSize = fontSize;
                    string newWord = word;

                    if (_isBoldActive) span.FontWeight = FontWeights.Bold;
                    if (_isItalicActive) span.FontStyle = FontStyles.Italic;
                    if (_isUnderlineActive) span.TextDecorations = TextDecorations.Underline;
                    if (_isSelectedActive) span.Background = _selectedTextColor;


                    // 'H' (highlight) must be before 'C' (color)
                    if (word.Contains("|~H~|"))
                    {
                        span.Background = _userHighlightColor;
                        newWord = newWord.Replace("|~H~|", "");
                    }

                    newWord = newWord.Replace("|~B~|", "");
                    newWord = newWord.Replace("|~I~|", "");
                    newWord = newWord.Replace("|~U~|", "");
                    newWord = newWord.Replace("|~C~|", "");

                    newWord += newWord.Length > 0 ? " " : "";

                    span.Inlines.Add(newWord);
                    paragraph.Inlines.Add(span);
                }

            }
            
        }
    }
}
