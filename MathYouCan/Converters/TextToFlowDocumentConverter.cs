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


          <strong> text </strong>       -->  Bold text
          <em> text </em>               -->  Italic text
          <u> text </u>                 -->  underline text


     

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
                    if (word.Contains("<strong>")) _isBoldActive = true;
                    if (word.Contains("<em>")) _isItalicActive = true;
                    if (word.Contains("<u>")) _isUnderlineActive = true;
                    if (word.Contains("<span")) _isSelectedActive = true;

               
                    Span span = new Span();
                    span.FontFamily = new FontFamily("Segoe UI");
                    span.FontSize = fontSize;
                    string newWord = word;

                    // applying decorator to span
                    if (_isBoldActive) span.FontWeight = FontWeights.Bold;
                    if (_isItalicActive) span.FontStyle = FontStyles.Italic;
                    if (_isUnderlineActive) span.TextDecorations = TextDecorations.Underline;
                    if (_isSelectedActive) span.Background = _selectedTextColor;



                    
                    if (word.Contains("</strong>")) _isBoldActive = false;
                    if (word.Contains("</em>")) _isItalicActive = false;
                    if (word.Contains("</u>")) _isUnderlineActive = false;
                    if (word.Contains("</span>")) _isSelectedActive = false;



                    newWord = newWord.Replace("<p>", "");
                    newWord = newWord.Replace("</p>", "\n");
                    newWord = newWord.Replace("<strong>", "");
                    newWord = newWord.Replace("</strong>", "");
                    newWord = newWord.Replace("<em>", "");
                    newWord = newWord.Replace("</em>", "");
                    newWord = newWord.Replace("<u>", "");
                    newWord = newWord.Replace("</u>", "");
                    newWord = newWord.Replace("<span", "");
                    newWord = newWord.Replace("class=\"marker\">", " ");
                    newWord = newWord.Replace("</span>", "");

                    newWord += newWord.Length > 0 ? " " : "";
                    
                    if (newWord != String.Empty)
                    {
                        span.Inlines.Add(newWord);
                        paragraph.Inlines.Add(span);
                    }
                }
            }
        }
    }
}
