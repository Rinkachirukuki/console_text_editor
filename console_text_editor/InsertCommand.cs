using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_text_editor
{
    class InsertCommand : ICommand
    {
        private Application application;

        public int Position;

        public string InsertString;

        public string OldInputString;

        public InsertCommand(Application application, int position, string insertString)
        {
            this.application = application;
            this.Position = position;
            this.InsertString = insertString;

            OldInputString = "";
        }
        public override void Execute()
        {
            if (Position > application.InputString.Length)
            {
                Console.WriteLine("Error  | Out of string range in [Paste " + Position + "]");
                return;
            }

            OldInputString = InsertString;

            Console.WriteLine("Insert | At position: " + Position);
            application.InputString = application.InputString.Insert(Position, InsertString);
        }
    }
}
