using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        Button PI = new Button() { Content = "π" };
        Button exp = new Button() { Content = "e" };
        Button sqrt = new Button() { Content = "√" };
        Button power = new Button() { Content = "xⁿ" };
        Button ln = new Button() { Content = "ln" };
        public MainWindow()
        {
            InitializeComponent();
            Grid.SetColumn(PI, 5);
            Grid.SetRow(PI, 1);
            Grid.SetColumn(exp, 5);
            Grid.SetRow(exp, 2);
            Grid.SetColumn(sqrt, 5);
            Grid.SetRow(sqrt, 3);
            Grid.SetColumn(power, 5);
            Grid.SetRow(power, 4);
            Grid.SetColumn(ln, 5);
            Grid.SetRow(ln, 5);
        }

        private void BurgerButton_Click(object sender, RoutedEventArgs e)
        {
            grid.ColumnDefinitions.ElementAt(4).Width = new GridLength(1, GridUnitType.Star);
            BurgerButton.Content = "<";
            BurgerButton.Click += Return;
            BurgerButton.Click -= BurgerButton_Click;
            grid.Children.Add(PI);
            grid.Children.Add(exp);
            grid.Children.Add(sqrt);
            grid.Children.Add(power);
            grid.Children.Add(ln);
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            grid.ColumnDefinitions.ElementAt(4).Width = GridLength.Auto;
            grid.Children.Remove(PI);
            grid.Children.Remove(exp);
            grid.Children.Remove(sqrt);
            grid.Children.Remove(power);
            grid.Children.Remove(ln);
            BurgerButton.Content = "☰";
            BurgerButton.Click -= Return;
            BurgerButton.Click += BurgerButton_Click;
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            display.Text += "1";
        }
        private void Two_Click(object sender, RoutedEventArgs e)
        {
            display.Text += "2";
        }
        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            display.Text += "+";
        }
        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            display.Text = display.Text.Remove(display.Text.Length - 1);
        }
        private void Display_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = (TextBox)sender;

            // text limit for 17 chars
            if (textbox.Text.Length > 17)
            {
                textbox.Text = textbox.Text[..17];
                textbox.CaretIndex = textbox.Text.Length;
                return;
            }
        }
    }
}