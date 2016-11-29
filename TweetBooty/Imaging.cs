using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TweetBooty;

namespace TweetBooty
{
    public class Imaging
    {
        private string exeFile = "";
        private string exeDir = "";
        private string fullPath = "";
        private string tweetedPath = "";
        private string path = "";
        public static string[] fileEntries;
        public string ScanForMedia()
        {
            exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            exeDir = Path.GetDirectoryName(exeFile);
            fullPath = Path.Combine(exeDir + "\\Images\\");
            tweetedPath = Path.Combine(exeDir + "\\Images\\tweeted");
            if (!System.IO.Directory.Exists(tweetedPath))
            {
                System.IO.Directory.CreateDirectory(tweetedPath);
            }
            if (Directory.Exists(fullPath))
            {
                return ProcessDirectory(fullPath).ToString();
            }
            return "0";
        }

        public static int ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            fileEntries = Directory.GetFiles(targetDirectory);
            return fileEntries.Length;
        }

        public List<TweetBooty.Archive.FolderName> GetFolderNames()
        {
            List<TweetBooty.Archive.FolderName> folderNames = new List<TweetBooty.Archive.FolderName>();
            try
            {
                path = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
                exeDir = Path.GetDirectoryName(path);
                fullPath = Path.Combine(exeDir + "\\Images\\");
                foreach (string s in Directory.GetDirectories(fullPath))
                {
                    TweetBooty.Archive.FolderName folder = new TweetBooty.Archive.FolderName();
                    //Obtain the name of the folder
                    folder.folderName = s.Replace(Path.GetDirectoryName(s) + Path.DirectorySeparatorChar, "");
                    //Obtain the date of the last mod on the folder
                    folder.lastModified = Directory.GetLastWriteTimeUtc(s);
                    folder.path = s;
                    if (folder.folderName != "tweeted")
                        folderNames.Add(folder);
                }
            }
            catch (Exception ex)
            {
                //lblErrors.Text = "Error: " + ex.Message;
            }

            //Sort folders descendant by Date
            folderNames.Sort((y, x) => y.lastModified.CompareTo(x.lastModified));

            return folderNames;
        }
    }
}
