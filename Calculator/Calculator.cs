using System.ComponentModel;

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
    }
}
