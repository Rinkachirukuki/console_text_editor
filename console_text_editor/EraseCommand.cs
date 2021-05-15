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

        public int FromPosition;
        public int ToPosition;

        public string OldInputString;

        public EraseCommand(Application application, int fromPosition, int toPosition)
        {
            this.application = application;
            this.FromPosition = fromPosition;
            this.ToPosition = toPosition;

            OldInputString = "";
        }
        public override void Execute()
        {
            if (FromPosition >= ToPosition || FromPosition >= application.InputString.Length || ToPosition >= application.InputString.Length)
            {
                Console.WriteLine("Error  | Out of string range in [Delete " + FromPosition + " " + ToPosition + "]");
                return;
            }

            OldInputString = application.InputString;

            Console.WriteLine("Erase  | From position: " + FromPosition + " to: " + ToPosition);
            application.InputString = application.InputString.Remove(FromPosition, ToPosition - FromPosition + 1);
        }

    }
}
