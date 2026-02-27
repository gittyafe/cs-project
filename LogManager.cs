using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class LogManager
    {
        private static readonly string log = "Log";
        public static string getCurrFolderPath()
        {
            return Path.Combine(log, DateTime.Now.Month.ToString());
        }
        public static string getCurrFilePath()
        {
            return Path.Combine(getCurrFolderPath(), DateTime.Now.Day.ToString());

        }
        public static void writeLog(string nameProject, string nameFunc, string message)
        {
            string folderPath = getCurrFolderPath();
            string filePath = getCurrFilePath();
            string details = $"{DateTime.Now}\t{nameProject}.{nameFunc}:\t{message}";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            if (!File.Exists(filePath))
                File.Create(filePath);

            using (StreamWriter writer = File.CreateText(filePath)) { writer.WriteLine(message); }

        }
        public static void cleanOldLog()
        {
            //string currMonth = DateTime.Now.Month.ToString();
            //var folders = Directory.GetDirectories(log);
            //foreach (string folder in folders)
            //{
            //    string path = Path.Combine(log, folder);
            //    string monthFolder = Path.GetDirectoryName(path);
            //    Console.WriteLine(folder);
            //}
        }

    }
}
