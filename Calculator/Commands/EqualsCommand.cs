namespace Calculator.Commands
{
    class EqualsCommand : ICommand
    {
        private Calculator calculator;
        private string prevNumber = "";
        public EqualsCommand(Calculator calculator)
        {
            this.calculator = calculator;
        }
        public void Execute()
        {
            prevNumber = calculator.WaitingText[..^1];
            calculator.PressEquals();
        }

        public void Unexecute()
        {
            calculator.Text = prevNumber;
            calculator.WaitingText = "";
        }
    }
}
