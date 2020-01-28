using System;
using System.Collections.Generic;
using System.Text;
using JsonMaker;

namespace Backup_Maker
{
    class FileManager
    {

        public IList<string> documents { get; set; }
        public IList<string> Local { get; set; }
        public IList<string> LocalLow { get; set; }
        public IList<string> Programdata { get; set; }
        public IList<string> public_documents { get; set; }
        public IList<string> Roaming { get; set; }

    }
}
