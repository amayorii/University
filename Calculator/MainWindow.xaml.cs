using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Calculator.Commands;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        readonly Button PI = new Button() { Content = "π", Visibility = Visibility.Collapsed };
        readonly Button exp = new Button() { Content = "e", Visibility = Visibility.Collapsed };
        readonly Button sqrt = new Button() { Content = "√", Visibility = Visibility.Collapsed };
        readonly Button power = new Button() { Content = "xⁿ", Visibility = Visibility.Collapsed };
        readonly Button ln = new Button() { Content = "ln", Visibility = Visibility.Collapsed };

        readonly static Calculator calculator = new Calculator();
        readonly ControlPanel controlPanel = new ControlPanel();

        readonly EqualsCommand equalsCommand = new EqualsCommand(calculator);
        readonly LnCommand lnCommand = new LnCommand(calculator);
        readonly SqrtCommand sqrtCommand = new SqrtCommand(calculator);
        readonly ClearCommand clearCommand = new ClearCommand(calculator);
        readonly CommaCommand commaCommand = new CommaCommand(calculator);
        readonly BackspaceCommand backspaceCommand = new BackspaceCommand(calculator);

        public MainWindow()
        {
            InitializeComponent();
            DataContext = calculator;
            KeyDown += Window_KeyDown;

            #region adding btns at specific pos and clicks
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

            grid.Children.Add(PI);
            grid.Children.Add(exp);
            grid.Children.Add(sqrt);
            grid.Children.Add(power);
            grid.Children.Add(ln);

            sqrt.Click += Sqrt_Click;
            power.Click += Operation_Click;
            ln.Click += Ln_Click;
            PI.Click += Numpad_Click;
            exp.Click += Numpad_Click;
            #endregion
        }

        private void BurgerButton_Click(object sender, RoutedEventArgs e)
        {
            Visibility visibility;

            if (grid.ColumnDefinitions.ElementAt(4).Width == GridLength.Auto)
            {
                grid.ColumnDefinitions.ElementAt(4).Width = new GridLength(1, GridUnitType.Star);
                BurgerButton.Content = "<";
                visibility = Visibility.Visible;
            }
            else
            {
                grid.ColumnDefinitions.ElementAt(4).Width = GridLength.Auto;
                BurgerButton.Content = "☰";
                visibility = Visibility.Collapsed;
            }

            PI.Visibility = visibility;
            exp.Visibility = visibility;
            sqrt.Visibility = visibility;
            power.Visibility = visibility;
            ln.Visibility = visibility;
        }

        private void Numpad_Click(object sender, RoutedEventArgs e)
        {
            controlPanel.SetCommand(new NumKeyCommand(calculator, (sender as Button)!.Content.ToString()!));
            controlPanel.RunCommand();
        }
        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            controlPanel.SetCommand(commaCommand);
            controlPanel.RunCommand();
        }
        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            controlPanel.SetCommand(backspaceCommand);
            controlPanel.RunCommand();
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            controlPanel.SetCommand(clearCommand);
            controlPanel.RunCommand();
        }
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            controlPanel.SetCommand(new OperationCommand(calculator, (sender as Button)!.Content.ToString()!));
            controlPanel.RunCommand();
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            controlPanel.SetCommand(equalsCommand);
            controlPanel.RunCommand();
        }
        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            controlPanel.SetCommand(sqrtCommand);
            controlPanel.RunCommand();
        }
        private void Ln_Click(object sender, RoutedEventArgs e)
        {
            controlPanel.SetCommand(lnCommand);
            controlPanel.RunCommand();
        }
        private void Undo(object sender, RoutedEventArgs e)
        {
            controlPanel.Undo();
        }
        private void Redo(object sender, RoutedEventArgs e)
        {
            controlPanel.Redo();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.Z)
            {
                Undo(null!, null!);
            }
            else if (Keyboard.IsKeyDown(Key.LeftShift) && e.Key == Key.D6)
            {
                controlPanel.SetCommand(new OperationCommand(calculator, "xⁿ"));
                controlPanel.RunCommand();
            }
            else if (Keyboard.IsKeyDown(Key.LeftShift) && e.Key == Key.D8)
            {
                controlPanel.SetCommand(new OperationCommand(calculator, "×"));
                controlPanel.RunCommand();
            }
            else if (e.Key == Key.OemPlus)
            {
                controlPanel.SetCommand(new OperationCommand(calculator, "+"));
                controlPanel.RunCommand();
            }
            else if (e.Key == Key.OemMinus)
            {
                controlPanel.SetCommand(new OperationCommand(calculator, "-"));
                controlPanel.RunCommand();
            }
            else if (e.Key == Key.OemQuestion)
            {
                controlPanel.SetCommand(new OperationCommand(calculator, "÷"));
                controlPanel.RunCommand();
            }
            else if (e.Key == Key.Delete)
            {
                Clear_Click(null!, null!);
            }
            else if (e.Key == Key.Back)
            {
                Backspace_Click(null!, null!);
            }
            else if (e.Key == Key.OemComma)
            {
                Comma_Click(null!, null!);
            }
            else if (e.Key == Key.Enter)
            {
                Equals_Click(null!, null!);
            }
            else if (e.Key == Key.D1)
            {
                controlPanel.SetCommand(new NumKeyCommand(calculator, "1"));
                controlPanel.RunCommand();
            }
            else if (e.Key == Key.D2)
            {
                controlPanel.SetCommand(new NumKeyCommand(calculator, "2"));
                controlPanel.RunCommand();
            }
            else if (e.Key == Key.D3)
            {
                controlPanel.SetCommand(new NumKeyCommand(calculator, "3"));
                controlPanel.RunCommand();
            }
            else if (e.Key == Key.D4)
            {
                controlPanel.SetCommand(new NumKeyCommand(calculator, "4"));
                controlPanel.RunCommand();
            }
            else if (e.Key == Key.D5)
            {
                controlPanel.SetCommand(new NumKeyCommand(calculator, "5"));
                controlPanel.RunCommand();
            }
            else if (e.Key == Key.D6)
            {
                controlPanel.SetCommand(new NumKeyCommand(calculator, "6"));
                controlPanel.RunCommand();
            }
            else if (e.Key == Key.D7)
            {
                controlPanel.SetCommand(new NumKeyCommand(calculator, "7"));
                controlPanel.RunCommand();
            }
            else if (e.Key == Key.D8)
            {
                controlPanel.SetCommand(new NumKeyCommand(calculator, "8"));
                controlPanel.RunCommand();
            }
            else if (e.Key == Key.D9)
            {
                controlPanel.SetCommand(new NumKeyCommand(calculator, "9"));
                controlPanel.RunCommand();
            }
            else if (e.Key == Key.D0)
            {
                controlPanel.SetCommand(new NumKeyCommand(calculator, "0"));
                controlPanel.RunCommand();
            }
        }
    }
}