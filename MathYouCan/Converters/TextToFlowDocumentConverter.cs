using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

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
          |~H~|text|~H~|     -->  Highlighted text


        */

        public List<Tuple<int, int>> IndexesOfSelectedText { get; }

        private Brush _selectedTextColor;
        private Brush _userHighlightColor;

        public TextToFlowDocumentConverter(Brush selectedTextColor, Brush userHighlightColor)
        {
            _selectedTextColor = selectedTextColor;
            _userHighlightColor = userHighlightColor;
        }

        public void ConvertToParagraph(Paragraph paragraph, string text, double fontSize = 12)
        {
            paragraph.Inlines.Clear();
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
                    //span.IsEnabled = false;

                    //Style style = new Style(typeof(Span), span.Style);

                    //var trigger = new EventTrigger();
                    //trigger.RoutedEvent = Span.Lost;
                    //trigger.A

                    //var trigger = new MultiTrigger();
                    //Condition c1 = new Condition();
                    //c1.Property = Span.IsMouseCapturedProperty;
                    //c1.Value = true;
                    //trigger.Conditions.Add(c1);
                    //Setter setter = new Setter();
                    //setter.Property = Span.BackgroundProperty;
                    //setter.Value = _selectedTextColor;
                    //trigger.Setters.Add(setter);
                    //MessageBox.Show((setter.Value.ToString()) );

                    //var trigger = new Trigger();
                    //trigger.Property = Span.FontWeightProperty;
                    //trigger.Value = FontWeights.Bold;
                    //Setter setter = new Setter();
                    //setter.Property = Span.ForegroundProperty;
                    //setter.Value = Brushes.Aqua;
                    //trigger.Setters.Add(setter);

                    //style.Triggers.Add(trigger);
                    //MessageBox.Show(trigger.Value.ToString());

                    //span.Style = style;
                }

                newWord += " ";

                span.Inlines.Add(newWord);
                paragraph.Inlines.Add(span);
            }
        }


        private void SetSelectedTextIndexes()
        {

        }

        public void ColorSelectedText(TextRange selectedTextRange)
        {
            selectedTextRange.ApplyPropertyValue(TextElement.BackgroundProperty, _selectedTextColor);
        }

    }
}
