using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_text_editor
{
    class UndoCommand : ICommand
    {
        private Application application;

        public UndoCommand(Application application)
        {
            this.application = application;
        }
        public override void Execute()
        {
            if (application.CommandsHistory.Count == 0)
            {
                Console.WriteLine("Error  | Stack of executed commands is empty [Undo]");
                return;
            }

            ICommand command = application.CommandsHistory.Pop();

            if (command is EraseCommand)
            {
                UndoEraseCommand((EraseCommand)command);
                Console.WriteLine("Undo   | [Erase " + ((EraseCommand)command).FromPosition + " " + ((EraseCommand)command).ToPosition + "]");
            }
            else if (command is InsertCommand)
            {
                UndoInsertCommand((InsertCommand)command);
                Console.WriteLine("Undo   | [Insert " + ((InsertCommand)command).OldInputString + " " + ((InsertCommand)command).Position + "]");
            }
            else if (command is PasteCommand)
            {
                UndoPasteCommand((PasteCommand)command);
                Console.WriteLine("Undo   | [Paste " + ((PasteCommand)command).Position + "]");
            }
        }
       
        private void UndoEraseCommand(EraseCommand command)
        {
            application.InputString = application.InputString.Insert(command.FromPosition, command.OldInputString.Substring(command.FromPosition, command.ToPosition - command.FromPosition));
        }

        private void UndoInsertCommand(InsertCommand command)
        {
            application.InputString = application.InputString.Remove(command.Position, command.OldInputString.Length);
        }

        private void UndoPasteCommand(PasteCommand command)
        {
            application.InputString = application.InputString.Remove(command.Position, command.OldInputString.Length);
        }
    }
}
