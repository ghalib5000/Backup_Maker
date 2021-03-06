﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Backup_Maker
{
    //class for managing folders inside each of these folders
    public class FileManager : IDisposable
    {
        private Dictionary<string, string> dict;

        private static string DataFile = Path.Combine(Path.GetTempPath(),"data.json");

        public FileManager()
        {

            if (File.Exists(DataFile))
            {
                dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(DataFile));
            }
            else
                dict = new Dictionary<string, string>();
        }

        public FileManager(string location)
        {
            
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+"\\files\\";
            if (!Directory.Exists(currentPath))
            {
                Directory.CreateDirectory(currentPath);
            }
            DataFile = Path.Combine(currentPath +location);
            DataFile = CheckExtension(DataFile);
            if (File.Exists(DataFile))
            {
                dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(DataFile));
            }
            else
            {
                
                dict = new Dictionary<string, string>();
            }
        }

        public void AddValue(string key,string value)
        {
            try
            {
                dict.Add(key, value);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Remove(string key)
        {
            try
            {
                dict.Remove(key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Dispose()
        {
            var json = JsonConvert.SerializeObject(dict);
           
            File.WriteAllText(DataFile,json);
        }

        public Dictionary<string,string> GetValues()
        {
            return dict;
        }

       
        private static string CheckExtension(string Filename)
        {
            if (!Path.HasExtension(Filename))
            {
                return Filename + ".json";
            }
            else
            {
                return Filename;
            }
        }
    }

}
