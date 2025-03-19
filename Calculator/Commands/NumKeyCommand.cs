namespace Calculator.Commands
{
    class NumKeyCommand : ICommand
    {
        Calculator calculator;
        string content;
        public NumKeyCommand(Calculator calculator, string content)
        {
            this.calculator = calculator;
            this.content = content;
        }

        public void Execute()
        {
            calculator.PressNumKey(content);
        }

        public void Unexecute()
        {
            calculator.PressBackspace();
        }
    }
}
