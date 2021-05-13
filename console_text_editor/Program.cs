using System;
using System.Collections.Generic;
using System.IO;
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
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Application application = new Application(Parser.ParseInputString("InputString.txt"));

            application.Commands = Parser.ParseInputCommands(application, "InputCommands.txt");

            Console.WriteLine(application.InputString);

            application.ExecuteAll();

            Console.WriteLine(application.InputString);

            SaveFile(application);

            Console.ReadKey();
            
        }

        static void SaveFile(Application application)
        {
            StreamWriter sw = new StreamWriter("OutputString.txt");

            sw.WriteLine(application.InputString);

            sw.Close();
        }
    }
}
