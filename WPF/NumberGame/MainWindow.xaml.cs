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

namespace NumberGame
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new System.Random();
        private int r1;
        private int numC = 0;
        public MainWindow()
        {
            r1 = random.Next(1,26);
            InitializeComponent();
            AnswerText.Text = "クリック数：" + numC;
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            numC = numC + 1;
            if (int.Parse(button.Content.ToString()) == r1)
            {
                AnswerText.Text = "正解は：" + r1 + "　クリック数：" + numC;

            }
            else if(int.Parse(button.Content.ToString()) > r1)
            {
                AnswerText.Text = "大きい　クリック数" + numC;
            }
            else
            {
                AnswerText.Text = "小さい　クリック数" + numC;
            }
        }
    }
}
