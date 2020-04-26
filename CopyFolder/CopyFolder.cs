using BasicLogger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Backup_Maker
{
    class CopyFolder
    {
        static string logloc = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\C# Backup Maker";
        static DateTime date = DateTime.Now;
        public static void Copy(string sourceDirectory, string targetDirectory, string LogFileName)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget, LogFileName);
        }
        public static void Copy(string sourceDirectory, string targetDirectory, string LogFileName,bool overwrite)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget, LogFileName, overwrite);
        }

        private static void CopyAll(DirectoryInfo source, DirectoryInfo target, string LogFileName, bool overwrite)
        {
            Logger log = new Logger(logloc + "\\" + LogFileName + ".txt", date.ToString());
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                string temp = "Copying " + target.FullName + " to " + fi.Name;
                if (File.Exists(Path.Combine(target.FullName, fi.Name)))
                {
                    temp = "The file "+ fi.Name+" already Exsists";

                    log.Information(temp);
                    Console.WriteLine(temp);
                }
                else
                {
                    temp = "Copying " + target.FullName + " to " + fi.Name;
                    log.Information(temp);
                    Console.WriteLine(temp);

                    fi.CopyTo(Path.Combine(target.FullName, fi.Name));

                    temp = "DONE! Copied " + source + " to " + target;

                    log.Information(temp);
                    Console.WriteLine(temp);
                }
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir, LogFileName, overwrite);
            }
        }

        private static void CopyAll(DirectoryInfo source, DirectoryInfo target, string LogFileName)
        {
            Logger log = new Logger(logloc+"\\"+LogFileName+".txt", date.ToString());
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                string temp = "Copying " + target.FullName + " to " + fi.Name;
                log.Information(temp);
                Console.WriteLine(temp);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir, LogFileName);
            }
        }
    }
}

