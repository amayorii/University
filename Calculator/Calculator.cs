using System.ComponentModel;
using System.Windows;

namespace Calculator
{
    class Calculator : INotifyPropertyChanged
    {
        private string text = "";
        private string waitingText = "";

        public string Text
        {
            get => text;
            set
            {
                text = value;
                if (text.Length > 17) text = text[..17];
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

        public void PressNumKey(string content) => Text += content;
        public void PressComma()
        {
            if (string.IsNullOrEmpty(Text) || Text[^1] == ',' || Text[^1] == '-' || Text.Contains(',')) return;
            else Text += ",";
        }
        public void PressBackspace() => Text = Text[..^1];
        public void PressClear() => Text = "";
        public void PressOperation(string content)
        {
            content = content == "xⁿ" ? "^" : content;

            if (!string.IsNullOrEmpty(WaitingText) && !string.IsNullOrEmpty(Text) && WaitingText[^1] != '=' && Text != "-") PressEquals();

            if (string.IsNullOrEmpty(Text) && content == "-")
            {
                Text += "-";
                return;
            }
            else if (!string.IsNullOrEmpty(Text) && Text != "-")
            {
                WaitingText = Text + content;
                Text = "";
            }

        }
        public void PressEquals()
        {
            if (string.IsNullOrEmpty(WaitingText) || string.IsNullOrEmpty(Text) || WaitingText[^1] == '=' || Text == "-") return;

            double num1 = Convert.ToDouble(WaitingText[..^1]);
            double num2 = Convert.ToDouble(Text);

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
                    MessageBox.Show("Invalid operation");
                    break;
            }

            WaitingText += Text + "=";

            if (result.ToString().Length >= 20)
                Text = result.ToString("e2");
            else if (result.ToString().Contains(','))
                Text = result.ToString("F3");
            else
                Text = result.ToString();
        }
        public void PressLn()
        {
            WaitingText = $"ln({Text})=";
            Text = Math.Log10(Convert.ToDouble(Text)).ToString();
        }
        public void PressSqrt()
        {
            WaitingText = $"√{Text}=";
            Text = Math.Sqrt(Convert.ToDouble(Text)).ToString();
        }
    }
}
