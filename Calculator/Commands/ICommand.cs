namespace Calculator.Commands
{
    interface ICommand
    {
        void Execute();
        void Unexecute();
    }
}
