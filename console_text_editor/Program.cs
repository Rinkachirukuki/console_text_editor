using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using console_text_editor;

namespace ConsoleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {

            Application application = new Application("sa1sa1sa1sa1");

            application.Commands.Add(new CopyCommand(application, 0, 12));

            application.Commands.Add(new PasteCommand(application, 12));

            application.Commands.Add(new EraseCommand(application, 16,18));

            application.Commands.Add(new InsertCommand(application, 16, "!!!"));

            application.Commands.Add(new InsertCommand(application, 16, "111"));

            application.Commands.Add(new InsertCommand(application, 16, "!!!"));

            application.ExecuteAll();

            Console.WriteLine(application.InputString);

            Console.ReadKey();
            
        }
    }
}
