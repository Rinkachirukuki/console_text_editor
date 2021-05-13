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

        private int position;

        public PasteCommand(Application application, int position)
        {
            this.application = application;
            this.position = position;
        }
        public override void Execute()
        {
            if (position > application.InputString.Length)
            {
                Console.WriteLine("Error  | Out of string range in [Paste " + position + "]");
                return;
            }

            Console.WriteLine("Paste  | At position: " + position);
            application.InputString = application.InputString.Insert(position, application.BufferString);
        }
    }
}
