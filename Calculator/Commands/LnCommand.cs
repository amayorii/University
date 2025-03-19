namespace Calculator.Commands
{
    class LnCommand
    {
        private Calculator calculator;
        string prevNum = "";
        public LnCommand(Calculator calculator)
        {
            this.calculator = calculator;
        }
        public void Execute()
        {
            prevNum = calculator.Text;
            calculator.PressLn();
        }

        public void Unexecute()
        {
            calculator.Text = prevNum;
            calculator.WaitingText = "";
        }
    }
}
