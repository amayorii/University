namespace Calculator.Commands
{
    class OperationCommand : ICommand
    {
        private Calculator calculator;
        string content = "";

        public OperationCommand(Calculator calculator, string content)
        {
            this.calculator = calculator;
            this.content = content;
        }
        public void Execute()
        {
            calculator.PressOperation(content);
        }

        public void Unexecute()
        {
            if (!string.IsNullOrEmpty(calculator.WaitingText))
            {
                calculator.Text = calculator.WaitingText[..^1];
                calculator.WaitingText = "";
            }
        }
    }
}
