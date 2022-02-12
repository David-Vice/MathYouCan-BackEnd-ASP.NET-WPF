using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace MathYouCan.Converters
{
    /*
     
        Accepts Stack Panel(in method) located in view and text
        to divide text in textblocks and add them to Stack Panel
     
     */

    public class StackPanelConverter
    {
        private bool _isPressed = false;

        private SolidColorBrush _background;

        public StackPanelConverter(string colorHex)
        {
            _background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorHex)); ;
        }


        #region Hightlight

        //  WHEN STACK PANEL HIGHLIGHT IS ENABLED

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isPressed = false;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _isPressed = true;

            TextBlock l = sender as TextBlock;

            l.Background = _background;
            ;
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            if (_isPressed)
            {
                TextBlock l = sender as TextBlock;

                l.Background = _background;
            }
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            _isPressed = false;
        }

        #endregion



        public void FillStackPanel(StackPanel stackPanel, string text, bool highlightPossible = false, int textFontSize = 17)
        {
            stackPanel.Children.Clear();

            String[] lines = text.Split('\n');  // Getting lines

            foreach (String line in lines)
            {
                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Horizontal;
                sp.HorizontalAlignment = HorizontalAlignment.Stretch;
                sp.Width = stackPanel.ActualWidth;


                String[] words = line.Split(' ');  // Getting all words in 1 line
                foreach (String word in words)
                {
                    TextBlock tb = new TextBlock();
                    tb.TextWrapping = TextWrapping.Wrap;
                    tb.HorizontalAlignment = HorizontalAlignment.Stretch;
                    tb.FontSize = textFontSize;

                    FillTextBlock(tb, word, highlightPossible);

                    sp.Children.Add(tb);  // Adding word to stack panel
                }

                stackPanel.Children.Add(sp);  // Adding line To Stack Panel
            }

            if (highlightPossible)
            {
                stackPanel.MouseLeave += StackPanel_MouseLeave;
                stackPanel.MouseUp += StackPanel_MouseUp;
            }
        }


        private void FillTextBlock(TextBlock tb, string word, bool highlightPossible)
        {
            if (word.StartsWith("|~B~|"))
            {
                string newWord = word.Replace("|~B~|", "");
                tb.Inlines.Add(new Bold(new Run(newWord + " ")));
            }

            else if (word.StartsWith("|~I~|"))
            {
                string newWord = word.Replace("|~I~|", "");
                tb.Inlines.Add(new Italic(new Run(newWord + " ")));
            }

            else
            {
                tb.Inlines.Add(new Run(word + " "));
            }


            if (highlightPossible)
            {
                tb.MouseEnter += TextBlock_MouseEnter;
                tb.MouseDown += TextBlock_MouseDown;
            }
        }


    }
}
