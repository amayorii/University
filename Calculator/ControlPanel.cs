using Calculator.Commands;
namespace Calculator
{
    class ControlPanel
    {
        ICommand command;
        ICommand undo;
        ICommand lastCommand;

        Stack<ICommand> commandHistory = new Stack<ICommand>();
        Stack<ICommand> undoHistory = new Stack<ICommand>();

        public void SetCommand(ICommand command) => this.command = command;
        public void RunCommand()
        {
            if (command != null)
            {
                commandHistory.Push(command);
                command.Execute();
                lastCommand = command;
            }
        }
        public void Undo()
        {
            if (commandHistory.Count != 0)
            {
                undo = commandHistory.Pop();
                undo.Unexecute();
                undoHistory.Push(undo);
                lastCommand = undo;
            }
        }
        public void Redo()
        {
            if (lastCommand != undo) return;
            if (undoHistory.Count != 0)
                undoHistory.Pop().Execute();
        }
    }
}
