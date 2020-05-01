using CliFx;
using CliFx.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backup_Maker.Commands
{
    [Command]
    public class AddCommandClass
    {
        //TODO: backupmaker.exe --add[filename(json file)][folder location][folder save location]
        // Child of default command
        [Command("add")]
        public class AddCommand : ICommand
        {
            [CommandParameter(0, Description = "Name of the file.")]
            public string filename { get; set; }

            [CommandParameter(1, Description = "folder location.")]
            public string folderlocation { get; set; }

            [CommandParameter(2, Description = "folder backup location.")]
            public string foldersavelocation { get; set; }

            public ValueTask ExecuteAsync(IConsole console)
            {
                using (var fileManager = new FileManager(filename))
                {
                    fileManager.AddValue(folderlocation, foldersavelocation);

                    Console.WriteLine("filename is: " + filename + "\n");
                    foreach (var data in fileManager.GetValues())
                    {
                        Console.WriteLine("folder location is: " + data.Key + " backup locations is : " + data.Value);
                    }

                    return default;
                }
            }
        }
        //TODO: backupmaker.exe --add[filename(json file)][folder locations from list][folders save location]

        //TODO: backupmaker.exe --add[filename(json file)][main folder location][folder name][main folder save location]

        //TODO: backupmaker.exe --add[filename(json file)][main folder location][folder names from list][main folder save location]


    }
}
