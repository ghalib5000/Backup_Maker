using System;
using System.IO;
using JsonMaker;
using Reader;
using BasicLogger;
using System.Collections.Generic;

namespace Backup_Maker
{
    class Program
    {
        static void Main(string[] args)
        {
            string logloc = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\c#data.txt";
            //Console.WriteLine(logloc);
            var date = DateTime.Now;
            Logger log = new Logger(logloc,date.ToString());
            string s;
            string[] sourceDirectory =  { @"D:\New folder12\Self Made programs\C# Backup Maker\Files\documents.txt" };
            string[] targetDirectory =  { "\\ARC SYSTEM WORKS" };
            string savepath = @"D:\New folder12\Self Made programs\C# Backup Maker\test\settings.json";
            string oututFolder = @"D:\test\Output";


            
            List<string> fileList = new List<string>();
            StreamReader sr = new StreamReader(sourceDirectory[0]);
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                fileList.Add(s);
            }
            foreach (var c in fileList)
            {
                Console.WriteLine(c);
            }
            JSONMaker jm = new JSONMaker(sourceDirectory.Length,sourceDirectory ,targetDirectory,savepath);
            

            //test case
            string pt = @"D:\New folder12\Self Made programs\C# Backup Maker\test\out.json";
            FileManager obj = new FileManager()
            {
                /*
            documents, =
            Local,
            LocalLow,
            Programdata,
            public_documents,
            Roaming,
            */
            };
            //mainf.Add(fileList);
            // var js = new JSONMaker(obj, pt);
            // Reader.Reader read = new Reader.Reader(pt);
            //Console.WriteLine(read.ReturnValueOf("Roaming"));

            //Reader.Reader read = new Reader.Reader(savepath);
            // s = read.ReturnValueOf(sourceDirectory[0]);
            // FolderList fs = new FolderList();
            // Console.WriteLine( fs.findFolder("documents"));

            //Console.WriteLine(s);
            //  CopyFolder.Copy(fs.findFolder(sourceDirectory[0])+s,oututFolder+s);



            //Console.WriteLine("\r\nEnd of program");
            //Console.ReadKey();
            //Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Personal));



            /*
            Environment.SpecialFolder su = (Environment.SpecialFolder.Desktop);
            for(int i=0;i<60;i++)
            {
                try
                {
                    string temp ="the location "+ Environment.GetFolderPath(su) + " is at index number: " + i;
                    Console.WriteLine(temp);

                    log.Information(temp);
                }
                catch { }
                su++;
            }
            */

             
        }
    }
}
