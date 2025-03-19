namespace Calculator.Commands
{
    class SqrtCommand : ICommand
    {
        private Calculator calculator;
        string prevNum = "";
        public SqrtCommand(Calculator calculator)
        {
            this.calculator = calculator;
        }
        public void Execute()
        {
            prevNum = calculator.Text;
            calculator.PressSqrt();
        }

        public void Unexecute()
        {
            calculator.Text = prevNum;
            calculator.WaitingText = "";
        }
    }
}
