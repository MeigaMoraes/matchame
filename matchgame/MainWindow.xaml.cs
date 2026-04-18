using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace matchgame
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐶", "🐶",
                "🐲", "🐲",
                "🦬", "🦬",
                "🐒", "🐒",
                "🐸", "🐸",
                "🦖", "🦖",
                "🦍", "🦍",
                "🐌","🐌",
            };

            Random random = new Random();
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalEmoji.Count); //gera index aleatorio, de 0 até a quantidade de emojis que tem na animalEmoji
                string nextEmoji = animalEmoji[index]; //nextEmoji recebe o valor atual de animalEmoji[index]
                textBlock.Text = nextEmoji;// textblock recebe o valor de nextEmoji, que é o emoji, logo aparecera um emoji na tela
                animalEmoji.RemoveAt(index); //remove o emoji atual, sendo assim impedindo de aparecer o mesmo emoji mais de duas vezes (duas vezes pq ainda tem o outro do par para aparecer)

                
            }
        }
    }
}
