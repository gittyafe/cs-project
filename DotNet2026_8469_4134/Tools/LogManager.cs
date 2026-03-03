using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Tools
{
    public class LogManager
    {
        private static readonly string log = "Log";
        public static string getCurrFolderPath()
        {
            // folder format: Log\yyyy-MM (year and month)
            return Path.Combine(log, DateTime.Now.ToString("yyyy-MM"));
        }
        public static string getCurrFilePath()
        {
            // file format: dd.log (day of month with .log extension)
            return Path.Combine(getCurrFolderPath(), DateTime.Now.ToString("dd") + ".log");

        }
        public static void writeLog(string nameProject, string nameFunc, string message)
        {
            string folderPath = getCurrFolderPath();
            string filePath = getCurrFilePath();
            string details = $"{DateTime.Now}\t{nameProject}.{nameFunc}:\t{message}";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            using (var writer = new StreamWriter(filePath, append: true, encoding: Encoding.UTF8))
            {
                writer.WriteLine(details);
            }

        }
        public static void cleanOldLog()
        {
            // Delete any subfolder under the `log` directory whose last write time
            // is older than two months. Using file system timestamps is more
            // reliable than parsing folder names (handles year wrap, unexpected names).
            try
            {
                if (!Directory.Exists(log))
                    return;

                DateTime cutoffDate = DateTime.Now.AddMonths(-2);
                // For month-folder names in format yyyy-MM, compare by parsed year/month.
                DateTime cutoffMonth = new DateTime(cutoffDate.Year, cutoffDate.Month, 1);
                var folders = Directory.GetDirectories(log);
                foreach (string folder in folders)
                {
                    try
                    {
                        var dirInfo = new DirectoryInfo(folder);
                        string monthFolder = Path.GetFileName(folder);

                        // Try to parse folder name as yyyy-MM (year-month).
                        if (DateTime.TryParseExact(monthFolder, "yyyy-MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedMonth))
                        {
                            // parsedMonth will have day default (1) — compare to cutoffMonth
                            var folderMonth = new DateTime(parsedMonth.Year, parsedMonth.Month, 1);
                            if (folderMonth < cutoffMonth)
                            {
                                dirInfo.Delete(recursive: true);
                                continue;
                            }
                        }

                        // Fallback: if folder name couldn't be parsed, use LastWriteTime
                        if (dirInfo.LastWriteTime < cutoffDate)
                        {
                            dirInfo.Delete(recursive: true);
                        }
                    }
                    catch
                    {
                        // ignore individual folder failures to avoid stopping the whole cleanup
                    }
                }
            }
            catch
            {
                // ignore cleanup failures - logging from cleanup may cause recursion
            }
        }
    }
}
