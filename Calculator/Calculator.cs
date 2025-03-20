using System.ComponentModel;
using System.Windows;

namespace Calculator
{
    class Calculator : INotifyPropertyChanged
    {
        #region props
        private string text = "";
        private string waitingText = "";

        public string Text
        {
            get => text;
            set
            {
                text = value;
                if (text.Length > 17) text = text[..17];
                text = text.StartsWith("00") ? "0" : text.StartsWith("-00") ? "-0" : text; // prevent two or more zeros
                OnPropertyChanged("Text");
            }
        }
        public string WaitingText
        {
            get => waitingText;
            set
            {
                waitingText = value;
                OnPropertyChanged("WaitingText");
            }
        }

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        // helping methods
        private bool IsEmptyText() => string.IsNullOrEmpty(Text);
        private bool IsEmptyWaitingText() => string.IsNullOrEmpty(WaitingText);
        private double ConvertPIorExp() => Text == "π" ? Math.PI : Text == "e" ? Math.E : Convert.ToDouble(Text);
        private bool ThereAreErrors(string whatIsThis)
        {
            if (IsEmptyText() || Text == "-") return true;

            if (ConvertPIorExp() < 0)
            {
                MessageBox.Show($"{whatIsThis} of negative number is undefined", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            return false;
        }

        public void PressNumKey(string content)
        {
            if (Text == "π" || Text == "e") return; // if already PI or Exp

            if (content == "π" || content == "e") Text = content; // if not but want to be
            else Text += content; // thanks god nothing happened
        }
        public void PressComma()
        {
            if (IsEmptyText() || Text[^1] == ',' || Text[^1] == '-' || Text.Contains(',') || Text == "π" || Text == "e") return; // dangerous cases for comma
            else Text += ",";
        }
        public void PressBackspace()
        {
            if (!string.IsNullOrEmpty(Text))
                Text = Text[..^1];
        }
        public void PressClear() => Text = "";
        public void PressOperation(string content)
        {
            content = content == "xⁿ" ? "^" : content;

            if (!IsEmptyWaitingText() && !IsEmptyText() && WaitingText[^1] != '=' && Text != "-") PressEquals(); // if already has operation and second number

            if (IsEmptyText() && content == "-") // if dont have any number and its minus
            {
                Text += "-";
                return;
            }
            else if (!IsEmptyText() && Text != "-") // if not empty and isn't only minus
            {
                WaitingText = Text + content;
                Text = "";
            }

        }
        public void PressEquals()
        {
            if (IsEmptyWaitingText() || IsEmptyText() || WaitingText[^1] == '=' || Text == "-") return; // dangerous cases for calculating

            double num1 = WaitingText[..^1] == "π" ? Math.PI : WaitingText[..^1] == "e" ? Math.E : Convert.ToDouble(WaitingText[..^1]); // if PI or Exp in waiting text
            double num2 = ConvertPIorExp(); // in just text

            double result = 0;

            switch (WaitingText[^1])
            {
                case '÷':
                    if (num2 == 0)
                    {
                        MessageBox.Show("Cannot divide by zero!");
                        return;
                    }
                    result = num1 / num2;
                    break;
                case '×':
                    result = num1 * num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '+':
                    result = num1 + num2;
                    break;
                case '^':
                    result = Math.Pow(num1, num2);
                    break;
                default:
                    MessageBox.Show("Invalid operation", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error); // i hope it will be never invoked
                    break;
            }

            WaitingText += Text + "=";

            string resultStr = result.ToString();

            if (resultStr.Length >= 20) Text = result.ToString("e2"); // if number is too big
            else if (resultStr.Contains(',')) Text = result.ToString("F6"); // if number is float
            else Text = resultStr;
        }
        public void PressLn()
        {
            if (!ThereAreErrors("logarithm"))
            {
                WaitingText = $"ln({Text})=";
                Text = Math.Log10(ConvertPIorExp()).ToString();
            }
        }
        public void PressSqrt()
        {
            if (!ThereAreErrors("square root"))
            {
                WaitingText = $"√{Text}=";
                Text = Math.Sqrt(ConvertPIorExp()).ToString();
            }
        }
    }
}
