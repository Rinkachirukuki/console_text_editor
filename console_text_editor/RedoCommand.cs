using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_text_editor
{
    class RedoCommand : ICommand
    {
        private Application application;


        public RedoCommand(Application application)
        {
            this.application = application;
        }
        public override void Execute()
        {
            if (application.CommandsHistory.Count == 0)
            {
                Console.WriteLine("Error  | Stack of executed commands is empty [Redo]");
                return;
            }

            ICommand command = application.CommandsHistory.Pop();

            application.CommandsHistory.Push(command);

            if (command is EraseCommand)
            {
                Console.WriteLine("Redo   | [Erase " + ((EraseCommand)command).FromPosition + " " + ((EraseCommand)command).ToPosition + "]");
            }
            else if (command is InsertCommand)
            {
                Console.WriteLine("Redo   | [Insert " + ((InsertCommand)command).OldInputString + " " + ((InsertCommand)command).Position + "]");
            }
            else if (command is PasteCommand)
            {
                Console.WriteLine("Redo   | [Paste " + ((PasteCommand)command).Position + "]");
            }

            command.Execute();

        }
    }
}
