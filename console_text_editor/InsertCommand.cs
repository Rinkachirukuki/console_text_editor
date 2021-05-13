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

        private int position;

        string insertString;

        public InsertCommand(Application application, int position, string insertString)
        {
            this.application = application;
            this.position = position;
            this.insertString = insertString;
        }
        public override void Execute()
        {
            if (position > application.InputString.Length)
            {
                Console.WriteLine("Error  | Out of string range in [Paste " + position + "]");
                return;
            }

            Console.WriteLine("Insert | At position: " + position);
            application.InputString = application.InputString.Insert(position, insertString);
        }
    }
}
