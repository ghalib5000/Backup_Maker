using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using JsonMaker;

namespace Backup_Maker
{
    //class for managing folders inside each of these folders
    public class FileManager
    {
        private Dictionary<string, string> dict;

        public  FileManager()
        {
            dict = new Dictionary<string, string>();
        }

        public void AddValue(string key,string value)
        {
            dict.Add(key, value);
        }
        public Dictionary<string,string> GetValues()
        {
            return dict;
        }

    }

}
