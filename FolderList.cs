using System;
using System.Collections.Generic;
using System.Text;

namespace Backup_Maker
{
    class FolderList
    {
     //used to get folders path location  
      
            
       public enum Folder
        {
            documents,
            Local,
            LocalLow,
            Programdata,
            public_documents,
            Roaming,
        }
        public object findFolderPath(string folderName)
        {
            if (folderName == Folder.Local.ToString())
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            }
            else if (folderName == Folder.LocalLow.ToString())
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+ @"\AppData\LocalLow";
            }
            else if (folderName == Folder.Roaming.ToString())
            {
              
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            }
            else if (folderName == Folder.Programdata.ToString())
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            }
            else if (folderName == Folder.public_documents.ToString())
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            }
            else if (folderName == Folder.documents.ToString())
            {
                 return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
            else
            {
                return "not found!";
            }
        }
    }

}
