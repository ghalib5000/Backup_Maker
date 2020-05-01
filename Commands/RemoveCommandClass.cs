using CliFx;
using CliFx.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backup_Maker.Commands
{
    [Command]
    public class RemoveCommandClass
    {
        //TODO: backupmaker.exe --remove[filename(json file)][folder location][folder save location]
        [Command("remove")]
        public class RemoveCommand : ICommand
        {
            [CommandParameter(0, Description = "Name of the file.")]
            public string filename { get; set; }

            [CommandParameter(1, Description = "folder location.")]
            public string folderlocation { get; set; }

            public ValueTask ExecuteAsync(IConsole console)
            {


                using (var fileManager = new FileManager(filename))
                {
                    fileManager.Remove(folderlocation);

                    Console.WriteLine("Folder " + folderlocation + " is removed");

                    return default;
                }
            }

            ValueTask ICommand.ExecuteAsync(IConsole console)
            {
                throw new NotImplementedException();
            }
        }
        //TODO: backupmaker.exe --remove[filename(json file)][main folder location][folder name][main folder save location]

        //TODO: backupmaker.exe --remove[filename(json file)]  (delete the whole file! require confirmation)

    }
}
