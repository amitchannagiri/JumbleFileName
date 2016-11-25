using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JumbleFilename
{
    class Program
    {
        public static string GenerateJumbledName(string oldFileName)
        {
            int startOfFileName = oldFileName.LastIndexOf(@"\");
            int endOfFileName = oldFileName.LastIndexOf('.');
            string nameToBeModified = oldFileName.Substring(startOfFileName);

            int startOfPart = nameToBeModified.IndexOf("Part");
            string namePart = nameToBeModified.Substring(startOfPart);
            string partNumber = namePart.Remove(namePart.LastIndexOf('.'));

            string modifiedNewName = nameToBeModified.Remove(startOfPart);
             modifiedNewName = modifiedNewName.Insert(1, partNumber+" ");
            modifiedNewName=modifiedNewName.Insert(modifiedNewName.Length - 1, ".mp4");

            oldFileName = oldFileName.Remove(startOfFileName);
            string newFileName = oldFileName.Insert(oldFileName.Length, modifiedNewName);
            return newFileName;
        }

        static void Main(string[] args)
        {
            //System.IO.File f = new File(@"");

            string[] filenames = System.IO.Directory.GetFiles(@"T:\Vittal-tutorials\SQL Server");


            foreach(string oldFileName in filenames)
            {
                if (oldFileName.Contains("Part"))
                {
                    string newFileName = GenerateJumbledName(oldFileName);
                    File.Move(oldFileName, newFileName);
                }
            }
            
        }

        
    }
}
