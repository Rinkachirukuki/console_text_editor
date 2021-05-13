using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_text_editor
{
    class Application
    {
        public List<ICommand> Commands;

        public Stack<ICommand> CommandsHistory;

        public string InputString;
        public string BufferString;

        public Application(string inputString)
        {
            InputString = inputString;
            BufferString = "";
            Commands = new List<ICommand>();
            CommandsHistory = new Stack<ICommand>();
        }
        public Application(string inputString, List<ICommand> commands)
        {
            InputString = inputString;
            BufferString = "";
            Commands = commands;
            CommandsHistory = new Stack<ICommand>();
        }
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();

            if(!((command is CopyCommand) || (command is UndoCommand) || (command is RedoCommand))) {
                CommandsHistory.Push(command);
            }
               
        }

        public void ExecuteAll()
        {
            foreach (ICommand c in Commands)
                ExecuteCommand(c);
        }

    }
}
