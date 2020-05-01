using CliFx;
using CliFx.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Backup_Maker.Commands
{
    [Command]
    public class StartCommandClass
    {
        //TODO: backupmaker.exe --start filename
        [Command("start")]
        public class CopyCommand : ICommand
        {
            [CommandParameter(0, Description = "Name of the file.")]
            public string filename { get; set; }
            [CommandOption("overwrite", 'o', Description = "Name of the file.")]
            public bool overwrite { get; set; }
            public ValueTask ExecuteAsync(IConsole console)
            {
                using (var fileManager = new FileManager(filename))
                {
                    foreach (var file in fileManager.GetValues())
                    {
                        if (!File.Exists(file.Key))
                        {
                            CopyFolder.Copy(file.Key, file.Value, "out", overwrite);
                        }
                        else
                        {
                            CopyFolder.Copyto(file.Key, file.Value, "out");
                        }
                    }

                    Console.WriteLine("filename is: " + filename + "\n");
                    foreach (var data in fileManager.GetValues())
                    {
                        Console.WriteLine("folder location is: " + data.Key + " backup locations is : " + data.Value);
                    }

                    return default;
                }
            }
        }

        //TODO: backupmaker.exe --start all



    }
}
