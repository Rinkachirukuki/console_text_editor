using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_text_editor
{
    class Application
    {
        public List<ICommand> Commands;

        public string InputString;
        public string BufferString;

        public Application(string inputString)
        {
            InputString = inputString;
            BufferString = "";
            Commands = new List<ICommand>();
        }
        public Application(string inputString, List<ICommand> commands)
        {
            InputString = inputString;
            BufferString = "";
            Commands = commands;
        }
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }

        public void ExecuteAll()
        {
            foreach (ICommand c in Commands)
                c.Execute();
        }



        

    }
}
