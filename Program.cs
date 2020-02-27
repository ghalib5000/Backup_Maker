using BasicLogger;
using JsonMaker;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Backup_Maker
{
    class Program
    {
        static void Main(string[] args)
        {
            string savefolderlocations = @"D:\New folder12\saves";

            //logging location
            string logloc = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\C# Backup Maker";
            string item;
            string s;
            var date = DateTime.Now;
            //used for reading from different files
            //only needed when making the settings.json file for the first time
            //string filespath = @"D:\New folder12\Self Made programs\C# Backup Maker\Files";
            IList<string> ListOfNames = new List<string>();
            FolderList fs = new FolderList();
            string savepath = @"D:\New folder12\Self Made programs\C# Backup Maker\settings.json";
            string outputFolder = @"D:\New folder12\saves";

            //the array to cycle through all of the folders
            string[] folders =
            {
                "documents",
                "Local",
                "LocalLow",
                "Programdata",
                "public_documents",
                "Roaming",
            };
            FileManager obj = new FileManager();
            {
                //only needed when making the settings.json file for the first time
                /*
                string[] files;
                files = Directory.GetFiles(filespath);
                foreach (string path in files)
                {
                    int i = 0;
                    string[] temp = new string[100];
                    StreamReader sr = new StreamReader(path);
                    while (!sr.EndOfStream)
                    {

                        temp[i] = sr.ReadLine();
                        i++;
                    }
                    if (path.Contains(folders[4]))
                    {
                        for (int j = 0; j < temp.Length && temp[j] != null; j++)
                        {
                            obj.public_documents.Add(temp[j]);
                        }
                    }
                    else if (path.Contains(folders[0]))
                    {
                        for (int j = 0; j < temp.Length && temp[j] != null; j++)
                        {

                            obj.documents.Add(temp[j]);
                        }
                    }
                    else if (path.Contains(folders[2]))
                    {
                        for (int j = 0; j < temp.Length && temp[j] != null; j++)
                        {
                            obj.LocalLow.Add(temp[j]);
                        }
                    }
                    else if (path.Contains(folders[1]))
                    {
                        for (int j = 0; j < temp.Length && temp[j] != null; j++)
                        {
                            obj.Local.Add(temp[j]);
                        }
                    }
                    else if (path.Contains(folders[3]))
                    {
                        for (int j = 0; j < temp.Length && temp[j] != null; j++)
                        {
                            obj.Programdata.Add(temp[j]);
                        }
                    }
                    else if (path.Contains(folders[5]))
                    {
                        for (int j = 0; j < temp.Length && temp[j] != null; j++)
                        {
                            obj.Roaming.Add(temp[j]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not found!");
                    }
                }
            var js = new JSONMaker(obj, savepath);
            */
            }
            
            Reader.Reader read = new Reader.Reader(savepath);
            
            obj =  read.ReturnValueOf<FileManager>();

            //the code that reads and copies every folder to save location
            for (int i = 0; i < folders.Length; i++)
            {
                string LogFileName = folders[i];
                
                //deleting the old logs
                if (File.Exists(logloc + "\\" + LogFileName + ".txt"))
                {
                    File.Delete(logloc + "\\" + LogFileName + ".txt");
                }
                Logger log = new Logger(logloc + "\\" + LogFileName + ".txt", date.ToString());
                try
                {
                    ListOfNames = obj.ArrayOfList[i];
                    s = fs.findFolderPath(folders[i]) as string;
                    string[] temp = new string[100];
                    ListOfNames.CopyTo(temp, 0);
                    for (int j = 0; j < ListOfNames.Count; j++)
                    {
                        item = s + "\\" + temp[j];
                        Console.WriteLine(item);
                        string temp2 = outputFolder + "\\"+ folders[i] + "\\" + temp[j];

                        CopyFolder.Copy(item,temp2,folders[i],false);
                        
                    }
                }
                catch(IOException ex)
                {

                }
                catch(Exception ex)
                {  
                    Console.WriteLine(ex.Message);
                    log.Error(ex);
                }
                Console.WriteLine("\n\n\n");
            }



            //Console.WriteLine(s);
            //  CopyFolder.Copy(fs.findFolder(sourceDirectory[0])+s,oututFolder+s);



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

