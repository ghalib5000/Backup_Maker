﻿using CliFx;
using CliFx.Attributes;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Backup_Maker.Commands
{
    [Command]
    public class ShowCommandClass
    {

        //Show Command
        [Command("show")]
        public class SHowCommands : ICommand
        {
            [CommandParameter (0,Description ="Name of the file.",Name ="file")]
            public string filename { get; set; }
            public ValueTask ExecuteAsync(IConsole console)
            {
                if (filename != null)
                {
                    using (var fileManager = new FileManager(filename))
                    {
                        DisplayFileName(filename);
                        foreach (var data in fileManager.GetValues())
                        {
                            Console.WriteLine("folder location is: " + data.Key + "\nbackup locations is : " + data.Value + "\n");
                        }
                        return default;
                    }
                }
                else
                {
                    Console.WriteLine("file "+ filename+" does not exists");
                }
                return default;
            }
        }
        [Command("show all")]
        public class SHowAllCommands : ICommand
        {
            public ValueTask ExecuteAsync(IConsole console)
            {

                var filelocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\files\\";
                var files = Directory.GetFiles(filelocation);
                foreach (var file in files)
                {
                    using (var fileManager = new FileManager(file.Substring(filelocation.Length)))
                    {

                        DisplayFileName(file.Substring(filelocation.Length));
                        foreach (var data in fileManager.GetValues())
                        {
                            Console.WriteLine("folder location is: " + data.Key + "\nbackup locations is : " + data.Value + "\n");
                        }
                    }
                }
                return default;
            }
        }
        private static void DisplayFileName(string filename)
        {
            Console.WriteLine("**************************************************************************");
            Console.WriteLine("filename is: " + filename + "\n");
            Console.WriteLine("**************************************************************************");
        }

    }
}
