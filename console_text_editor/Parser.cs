using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_text_editor
{
    static class Parser
    {
        public static string ParseInputString(string filePath) // "InputString.txt"
        {
            StreamReader sr = new StreamReader(filePath);

            string str = sr.ReadLine();

            sr.Close();

            return str;
        }

        public static List<ICommand> ParseInputCommands(Application application, string filePath) // "InputCommands.txt"
        {
            List<ICommand> commands = new List<ICommand>();

            StreamReader sr = new StreamReader(filePath);

            string str = sr.ReadLine();

            while (str != null)
            {
                string[] comParts = str.Split(' ');

                if (comParts[0].ToLower() == "delete")
                {
                    commands.Add(ParseEraseCommand(comParts, application));
                }
                else  if (comParts[0].ToLower() == "copy")
                {
                    commands.Add(ParseCopyCommand(comParts, application));
                }
                else if (comParts[0].ToLower() == "paste")
                {
                    commands.Add(ParsePasteCommand(comParts, application));
                }
                else if (comParts[0].ToLower() == "insert")
                {
                    commands.Add(ParseInsertCommand(comParts, application));
                }
                else if(comParts[0].ToLower() == "undo")
                {
                    commands.Add(ParseUndoCommand(application));
                }
                else if (comParts[0].ToLower() == "redo")
                {
                    commands.Add(ParseRedoCommand(application));
                }
                else
                {
                    Console.WriteLine("Error  | String contains syntax errors: [" + str + "]");
                }

                str = sr.ReadLine();
            }

            sr.Close();

            return commands;
        }

        private static ICommand ParseRedoCommand(Application application)
        {
            return new RedoCommand(application);
        }

        private static ICommand ParseUndoCommand(Application application)
        {
            return new UndoCommand(application);
        }

        private static ICommand ParseCopyCommand(string[] commandElems, Application application)
        {
            int fromPos = Convert.ToInt32(commandElems[1].Replace(",", ""));
            int toPos = Convert.ToInt32(commandElems[2]);

            return new CopyCommand(application, fromPos, toPos);
        }

        private static ICommand ParseEraseCommand(string[] commandElems, Application application)
        {
            int fromPos = Convert.ToInt32(commandElems[1].Replace(",", ""));
            int toPos = Convert.ToInt32(commandElems[2]);

            return new EraseCommand(application, fromPos, toPos);
        }

        private static ICommand ParsePasteCommand(string[] commandElems, Application application)
        {
            int position = Convert.ToInt32(commandElems[1]);

            return new PasteCommand(application, position);
        }

        private static ICommand ParseInsertCommand(string[] commandElems, Application application)
        {
            string insertString = commandElems[1].Replace(",", "").Replace("\"", "");

            int position = Convert.ToInt32(commandElems[2]);

            return new InsertCommand(application, position, insertString);
        }




    }
}
