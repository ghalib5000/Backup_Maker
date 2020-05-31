using CliFx;
using CliFx.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Backup_Maker.Commands
{
    [Command]
    public class StartCommandClass
    {
        //backupmaker.exe start filename
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
                            CopyFolder.Copyto(file.Key, file.Value, "out", overwrite);
                        }
                    }

                    Console.WriteLine("overwrite is: "+overwrite);
                    return default;
                }
            }
        }

        //backupmaker.exe startall
        [Command("start all")]
        public class CopyAllCommand : ICommand
        {
            
            [CommandOption("overwrite", 'o', Description = "Name of the file.")]
            public bool overwrite { get; set; }
            public ValueTask ExecuteAsync(IConsole console)
            {
                DirectoryInfo currentPath = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\files\\");

                foreach (FileInfo fi in currentPath.GetFiles())
                {
                    using (var fileManager = new FileManager(fi.Name))
                    {
                        foreach (var file in fileManager.GetValues())
                        {
                            if (!File.Exists(file.Key))
                            {
                                CopyFolder.Copy(file.Key, file.Value, "out", overwrite);
                            }
                            else
                            {
                                CopyFolder.Copyto(file.Key, file.Value, "out", overwrite);
                            }
                        }

                        Console.WriteLine("overwrite is: " + overwrite);
                        
                    }
                }
                return default;
            }
        }




    }
}
