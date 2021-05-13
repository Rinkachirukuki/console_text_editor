using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_text_editor
{
    class EraseCommand : ICommand
    {
        private Application application;

        private int fromPosition;
        private int toPosition;

        public EraseCommand(Application application, int fromPosition, int toPostion)
        {
            this.application = application;
            this.fromPosition = fromPosition;
            this.toPosition = toPostion;
        }
        public override void Execute()
        {
            if (fromPosition > toPosition || fromPosition > application.InputString.Length || toPosition > application.InputString.Length)
            {
                Console.WriteLine("Error  | Out of string range in [Delete " + fromPosition + " " + toPosition + "]");
                return;
            }

            Console.WriteLine("Erase  | From position: " + fromPosition + " to: " + toPosition);
            application.InputString = application.InputString.Remove(fromPosition, toPosition - fromPosition);
        }

    }
}
