namespace Calculator.Commands
{
    class ClearCommand : ICommand
    {
        private Calculator calculator;
        string prevText = "";
        public ClearCommand(Calculator calculator)
        {
            this.calculator = calculator;
        }
        public void Execute()
        {
            prevText = calculator.Text;
            calculator.PressClear();
        }

        public void Unexecute()
        {
            calculator.Text = prevText;
        }
    }
}
