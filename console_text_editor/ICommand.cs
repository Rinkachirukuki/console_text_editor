using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_text_editor
{
    class ICommand
    {
        public virtual void Execute() { 
            Console.WriteLine("Error  | Execute function not implemented");
        }
    }
}
