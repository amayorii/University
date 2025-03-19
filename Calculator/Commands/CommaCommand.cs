namespace Calculator.Commands
{
    class CommaCommand : ICommand
    {
        Calculator calculator;
        public CommaCommand(Calculator calculator)
        {
            this.calculator = calculator;
        }

        public void Execute()
        {
            calculator.PressComma();
        }

        public void Unexecute()
        {
            calculator.PressBackspace();
        }
    }
}
