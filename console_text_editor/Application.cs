using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_text_editor
{
    class Application
    {
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }




    }
}
