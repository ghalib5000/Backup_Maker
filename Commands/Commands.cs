using CliFx;
using CliFx.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Backup_Maker.Commands
{

    
    [Command]
    public class Commands
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
                using(var fileManager = new FileManager(filename))
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
        }

        //Show Command
        [Command("show")]
        public class SHowCommands : ICommand
        {
            [CommandOption("file",'f', Description = "Name of the file.")]
            public string filename { get; set; }
            public ValueTask ExecuteAsync(IConsole console)
            {
                if (filename != null)
                {
                    using (var fileManager = new FileManager(filename))
                    {

                        Console.WriteLine("filename is: " + filename + "\n");
                        foreach (var data in fileManager.GetValues())
                        {
                            Console.WriteLine("folder location is: " + data.Key + " backup locations is : " + data.Value);
                        }
                        return default;
                    }
                }
                else
                {
                    var filelocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+"\\files\\";
                    var files= Directory.GetFiles(filelocation);
                    foreach (var  file in files)
                    {
                        using (var fileManager = new FileManager(file.Substring(filelocation.Length)))
                        {
                            

                            Console.WriteLine("filename is: " + file.Substring(filelocation.Length) + "\n");
                            foreach (var data in fileManager.GetValues())
                            {
                                Console.WriteLine("folder location is: " + data.Key + "\nbackup locations is : " + data.Value);
                            }

                            return default;
                        }
                    }
                }
                return default;
            }  
        }

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
                    foreach(var file in fileManager.GetValues())
                    {
                        if(!File.Exists(file.Key))
                        {
                            CopyFolder.Copy(file.Key, file.Value, "out", overwrite);
                        }
                        else
                        {
                            CopyFolder.Copyto(file.Key, file.Value,"out");
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


        //TODO: backupmaker.exe --add[filename(json file)][main folder location][folder name][main folder save location]

        //TODO: backupmaker.exe --remove[filename(json file)][main folder location][folder name][main folder save location]

        //TODO: backupmaker.exe --add[filename(json file)][folder locations from list][folders save location]

        //TODO: backupmaker.exe --remove[filename(json file)]  (delete the whole file! require confirmation)

        //TODO: backupmaker.exe --add[filename(json file)][main folder location][folder names from list][main folder save location]

        //TODO: backupmaker.exe --start all





    }

}
