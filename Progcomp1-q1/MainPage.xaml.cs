using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Progcomp1_q1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        /***
         * Invoked when the cipher text is being changed. Should rot(12) cipher
         * and put output in clearText
         **/
        private void cipherText_TextChanged(object sender, TextChangedEventArgs e)
        {
            clearText.Text = Alien.Decode(cipherText.Text);
        }

        public class Alien
        {
            public static string Decode(string cipher)
            {
                char[] chars = cipher.ToCharArray();

                for (int i = 0; i < chars.Length; i++)
                {
                    int letter = (int)chars[i];

                    if (letter >= 'a' && letter <= 'z')
                    {

                        if (letter > 'l')
                        {
                            letter -= 12;
                        }
                        else
                        {
                            letter += 13;
                        }
                    }
                    else if (letter >= 'A' && letter <= 'z')
                    {
                        if (letter > 'M')
                        {
                            letter -= 13;
                        }
                        else
                        {
                            letter += 13;
                        }
                    }

                    chars[i] = (char)letter;
                }

                return new string(chars);
            }
        }
    }
}
