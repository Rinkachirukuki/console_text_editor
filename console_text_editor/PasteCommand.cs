using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_text_editor
{
    class PasteCommand : ICommand
    {
        private Application application;

        public int Position;

        public string OldInputString;

        public PasteCommand(Application application, int position)
        {
            this.application = application;
            this.Position = position;

            OldInputString = "";
        }
        public override void Execute()
        {
            if (Position > application.InputString.Length)
            {
                Console.WriteLine("Error  | Out of string range in [Paste " + Position + "]");
                return;
            }

            OldInputString = application.BufferString;

            Console.WriteLine("Paste  | At position: " + Position);
            application.InputString = application.InputString.Insert(Position, application.BufferString);
        }
    }
}
