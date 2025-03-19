namespace Calculator.Commands
{
    class BackspaceCommand : ICommand
    {
        Calculator calculator;
        Stack<char> chars = new Stack<char>();
        public BackspaceCommand(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public void Execute()
        {
            if (!string.IsNullOrEmpty(calculator.Text))
                chars.Push(calculator.Text[^1]);
            calculator.PressBackspace();
        }

        public void Unexecute()
        {
            if (chars.Count != 0)
                calculator.Text += chars.Pop();
        }
    }
}
