using CliFx;
using CliFx.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Backup_Maker.Commands
{

    
    [Command]
    public class Commands
    {
        static FileManager fm = new FileManager();

        //TODO: backupmaker.exe --add[filename(json file)][folder location][folder save location]
        // Child of default command
        [Command("add")]
        public class AddCommands : ICommand
        {


            //TODO: backupmaker.exe --add[filename(json file)]  [folder location]  [folder save location]
            [CommandParameter(0, Description = "Name of the file.")]
            public string filename { get; set; }

            [CommandParameter(1, Description = "folder location.")]
            public string folderlocation { get; set; }

            [CommandParameter(2, Description = "folder backup location.")]
            public string foldersavelocation { get; set; }

            public ValueTask ExecuteAsync(IConsole console)
            {
                fm.AddValue(folderlocation, foldersavelocation);
                var fk = fm.GetValues();

                Console.WriteLine("filename is: " + filename + "\n");
                foreach (var f in fk)
                {
                    Debugger.Break();
                    Console.WriteLine("folder location is: " + f.Key + " backup locations is : " + f.Value);
                }

                return default;
            }
        }


        //TODO: backupmaker.exe --remove[filename(json file)][folder location][folder save location]

        //TODO: backupmaker.exe --add[filename(json file)][main folder location][folder name][main folder save location]

        //TODO: backupmaker.exe --remove[filename(json file)][main folder location][folder name][main folder save location]

        //TODO: backupmaker.exe --add[filename(json file)][folder locations from list][folders save location]

        //TODO: backupmaker.exe --remove[filename(json file)]  (delete the whole file! require confirmation)

        //TODO: backupmaker.exe --add[filename(json file)][main folder location][folder names from list][main folder save location]

        //TODO: backupmaker.exe --start all

        //TODO: backupmaker.exe --start filename



    }
    
}
