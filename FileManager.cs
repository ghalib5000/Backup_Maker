using System;
using System.Collections.Generic;
using System.Text;
using JsonMaker;

namespace Backup_Maker
{
    //class for managing folders inside each of these folders
    public class FileManager
    {
       
        public IList<string>[] ArrayOfList;
        
        public IList<string> documents { get; set; }
        public IList<string> Local { get; set; }
        public IList<string> LocalLow { get; set; }
        public IList<string> Programdata { get; set; }
        public IList<string> public_documents { get; set; }
        public IList<string> Roaming { get; set; }

        public FileManager()
        {
            documents = new List<string>();
            Local = new List<string>();
            LocalLow = new List<string>();
            Programdata = new List<string>();
            public_documents = new List<string>();
            Roaming = new List<string>();
            ArrayOfList = new List<string>[6];
            ArrayOfList[0] = documents;
            ArrayOfList[1] = Local;
            ArrayOfList[2] = LocalLow;
            ArrayOfList[3] = Programdata;
            ArrayOfList[4] = public_documents;
            ArrayOfList[5] = Roaming;
        }
    }
}
