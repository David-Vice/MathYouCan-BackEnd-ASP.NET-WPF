using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace MathYouCan.Converters
{
    public class HtmlTextToParagraphConverter
    {
        private Brush _selectedTextColor;

        private bool _isBoldActive = false;
        private bool _isItalicActive = false;
        private bool _isUnderlineActive = false;
        private bool _isSelectedActive = false;

        public HtmlTextToParagraphConverter(Brush selectedTextColor)
        {
            _selectedTextColor = selectedTextColor;
        }


        public void Convert(Paragraph paragraph, string text, double fontSize = 12)
        {
            paragraph.Inlines.Clear();
            if (!String.IsNullOrEmpty(text))
            {
                text = text.Replace("\n", "\n ");
                
                text = text.Replace("<p>", "");
                text = text.Replace("</p>", "\n ");
                
                text = text.Replace(" class=\"marker-yellow\"", "");
                text = text.Replace(" class=\"marker-green\"", "");
                text = text.Replace(" class=\"marker-pink\"", "");
                text = text.Replace(" class=\"marker-blue\"", "");
                text = text.Replace(" class=\"pen-green\"", "");
            
                text = text.Replace("<strong>", " <strong> ");
                text = text.Replace("</strong>", " </strong> ");
                text = text.Replace("<i>", " <i> ");
                text = text.Replace("</i>", " </i> ");
                text = text.Replace("<u>", " <u> ");
                text = text.Replace("</u>", " </u> ");
                text = text.Replace("<mark>", " <mark> ");
                text = text.Replace("</mark>", " </mark> ");


                String[] words = text.Split(' ');

                foreach (string word in words)
                {
                    if (String.IsNullOrEmpty(word)) continue;

                    string newWord = word;

                    Span span = new Span();
                    span.FontFamily = new FontFamily("Segoe UI");
                    span.FontSize = fontSize;

                    if (newWord.Contains("<strong>")) _isBoldActive = true;
                    if (newWord.Contains("<i>")) _isItalicActive = true;
                    if (newWord.Contains("<u>")) _isUnderlineActive = true;
                    if (newWord.Contains("<mark>")) _isSelectedActive = true;


                    // applying decorator to span
                    if (_isBoldActive) span.FontWeight = FontWeights.Bold;
                    if (_isItalicActive) span.FontStyle = FontStyles.Italic;
                    if (_isUnderlineActive) span.TextDecorations = TextDecorations.Underline;
                    if (_isSelectedActive) span.Background = _selectedTextColor;


                    if (newWord.Contains("</strong>")) _isBoldActive = false;
                    if (newWord.Contains("</i>")) _isItalicActive = false;
                    if (newWord.Contains("</u>")) _isUnderlineActive = false;
                    if (newWord.Contains("</mark>")) _isSelectedActive = false;

                    newWord = newWord.Replace("<strong>", "");
                    newWord = newWord.Replace("</strong>", "");
                    newWord = newWord.Replace("<i>", "");
                    newWord = newWord.Replace("</i>", "");
                    newWord = newWord.Replace("<u>", "");
                    newWord = newWord.Replace("</u>", "");
                    newWord = newWord.Replace("<mark>", "");
                    newWord = newWord.Replace("</mark>", "");
                    //newWord = newWord.Replace(" ", "");
                    newWord = newWord.Replace("&nbsp;", " ");
                    
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
