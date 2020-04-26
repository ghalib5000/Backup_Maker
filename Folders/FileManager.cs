using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using JsonMaker;
using Newtonsoft.Json;

namespace Backup_Maker
{
    //class for managing folders inside each of these folders
    public class FileManager : IDisposable
    {
        private Dictionary<string, string> dict;

        private static string DataFile = Path.Combine(Path.GetTempPath(),"data.json");

        public  FileManager()
        {
            if(File.Exists(DataFile))
            {
                dict = JsonConvert.DeserializeObject<Dictionary<string,string>>(File.ReadAllText(DataFile));
            }
            else 
                dict = new Dictionary<string, string>();
        }

        public void AddValue(string key,string value)
        {
            dict.Add(key, value);
        }

        public void Remove(string key)
        {
            dict.Remove(key);
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

    }

}
