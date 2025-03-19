namespace Calculator.Commands
{
    class OperationCommand
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
            calculator.Text = calculator.WaitingText[..^1];
            calculator.WaitingText = "";
        }
    }
}
