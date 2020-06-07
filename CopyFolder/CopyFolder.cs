using BasicLogger;
using System;
using System.IO;

namespace Backup_Maker
{
    class CopyFolder
    {

        static Logger log;//= new Logger(logloc + "\\" + LogFileName + ".txt", date.ToString());
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
            if (!Directory.Exists(logloc))
                Directory.CreateDirectory(logloc);

            if(!Directory.Exists(target.FullName))
                Directory.CreateDirectory(target.FullName);

            if (log == null)
                 log = new Logger(logloc + "\\" + LogFileName + ".txt", date.ToString());

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())

            {
                CopyFile(target.FullName, fi, overwrite);

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
        public static void Copyto(string filelocation,string fileoutputlocation,string LogFileName,bool overwrite)
        {
            FileInfo fn = new FileInfo(filelocation);
            if (!Directory.Exists(logloc))
                Directory.CreateDirectory(logloc);

            if(!Directory.Exists(fileoutputlocation))
                Directory.CreateDirectory(fileoutputlocation);

            if (log==null)
                log = new Logger(logloc + "\\" + LogFileName + ".txt", date.ToString());

            string temp = "Copying " + fn.FullName + " to " + fileoutputlocation;
            log.Information(temp);
            Console.WriteLine(temp);
            CopyFile(fileoutputlocation, fn, overwrite);
        }

        private static void CopyFile(string target ,FileInfo fi,bool overwrite)
        {
            string temp = "Copying " + fi.Name + " to " + target;
            if (File.Exists(target+"\\"+fi.Name))
            {
                if (!overwrite)
                {
                    temp = "The file " + fi.Name + " already Exsists";
                    log.Information(temp);
                    Console.WriteLine(temp);
                }
                else
                {
                    temp = "Copying " + fi.Name + " to " + target;
                    log.Information(temp);
                    Console.WriteLine(temp);
                    fi.CopyTo(Path.Combine(target, fi.Name), overwrite);
                    temp = "DONE! Copied " + fi.Name + " to " + target;
                    log.Information(temp);
                    Console.WriteLine(temp);
                }
            }
            else
            {
                temp = "Copying " + target + " to " + fi.Name;
                log.Information(temp);
                Console.WriteLine(temp);
                fi.CopyTo(Path.Combine(target, fi.Name));
                temp = "DONE! Copied " + fi.Name + " to " + target;
                log.Information(temp);
                Console.WriteLine(temp);
            }
        }
    }
}

