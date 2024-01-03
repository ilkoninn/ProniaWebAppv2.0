using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaWebApp.Business.Helpers
{
    public static class FileManager
    {
        public static bool CheckLength(this IFormFile file, int length)
        {
            return file.Length <= length;
        }
        public static bool CheckType(this IFormFile file, string type) 
        {
            return file.ContentType.Contains(type);
        }
        public static string Upload(this IFormFile file, string webPath, string folderName)
        {
            if(!Directory.Exists(webPath + folderName))
            {
                Directory.CreateDirectory(webPath + folderName);
            }

            string fileName = file.FileName;

            if(fileName.Length > 64)
            {
                fileName = fileName.Substring(fileName.Length - 64);   
            }

            fileName = Guid.NewGuid().ToString() + fileName;

            string filePath = webPath + folderName + fileName;

            using(FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            return fileName;
        }

        public static void Delete(this IFormFile file, string webPath, string folderName)
        {
            string filePath = webPath + folderName + file.FileName;
            if(!File.Exists(filePath)) 
            {
                File.Delete(filePath);
            }
        }

    }
}
