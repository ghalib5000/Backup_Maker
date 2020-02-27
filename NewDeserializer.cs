using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Backup_Maker
{
    class NewDeserializer
    {
        public static Dictionary<string, List<string>> ReturnValueOf(string name, string pathnew)
        {
            string jsonString = File.ReadAllText(pathnew);
            var fold = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(jsonString);

            Console.WriteLine("returning value of " + name);
            return fold;
        }
    }
}
