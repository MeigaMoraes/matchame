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

    using System.Windows.Threading;

    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;//armazena a quantidade de pares encontrados



        public MainWindow()
        {
            InitializeComponent();


            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;


            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            TimeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if(matchesFound == 8){
                timer.Stop();
                TimeTextBlock.Text = TimeTextBlock.Text + " - play again?";
            }

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
                if (textBlock.Name != "TimeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count); //gera index aleatorio, de 0 até a quantidade de emojis que tem na animalEmoji
                    string nextEmoji = animalEmoji[index]; //nextEmoji recebe o valor atual de animalEmoji[index]
                    textBlock.Text = nextEmoji;// textblock recebe o valor de nextEmoji, que é o emoji, logo aparecera um emoji na tela
                    animalEmoji.RemoveAt(index); //remove o emoji atual, sendo assim impedindo de aparecer o mesmo emoji mais de duas vezes (duas vezes pq ainda tem o outro do par para aparecer)
                }
                
            }

            timer.Start();
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;


        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if(findingMatch == false) // o bloco controla se o jogador clicou ou não no primeiro animal do par, se clicou ele esconde o animal e redefinaa findindMatch pra true
            {
                textBlock.Visibility = Visibility.Hidden; 
                lastTextBlockClicked = textBlock;
                findingMatch = true;

            }
            else if(textBlock.Text == lastTextBlockClicked.Text) // se o segundo animal clicado for igual ao primeiro, ele apaga o animal e redefine findingMatch pra false
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible; // se o animal clicado nao for igual ao primeiro ele então deixa o primeiro animal clicado visivel e redefine findingMatch
                findingMatch = false;
            }



        }

        private void TimeTextBlock_mouseDown(object sender, MouseButtonEventArgs e)
        {
            if(matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}
