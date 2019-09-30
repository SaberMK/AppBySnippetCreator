using System;
using System.IO;

namespace AppBySnippetCreator
{
    class Program
    {
        static readonly string PROJECT_NAME = "CodeSnippets";
        static readonly string REPLACE_NAME = "_$PROJECT_NAME$_";
        static void Main(string[] args)
        {
            // var a = Guid.NewGuid().ToString().ToUpper();
            //Console.WriteLine(a);
            RunForDir("CheckFolder");
        }
        static void RunForDir(string dir)
        {
            var dirs = Directory.GetDirectories(dir);
            
            foreach (var directory in dirs)
            {
                var dirPath = directory;
                if (dirPath.Contains(PROJECT_NAME))
                {
                    dirPath = dirPath.Replace(PROJECT_NAME, REPLACE_NAME);
                    Directory.Move(directory, dirPath);
                }
                    
                RunForDir(dirPath);
            }

            var filesInDirectory = Directory.GetFiles(dir);
            foreach (var file in filesInDirectory)
            {
                RunForFile(file);
                Console.WriteLine($"Done {file}");
            }            
        }
        static void RunForFile(string file)
        {
            var filename = file;
            if (filename.Contains(PROJECT_NAME))
            {
                var replaced = filename.Replace(PROJECT_NAME, REPLACE_NAME);
                File.Move(file, replaced);
                filename = replaced;
            }
            string text = File.ReadAllText(filename);
            text = text.Replace(PROJECT_NAME, REPLACE_NAME);
            File.WriteAllText(filename, text);
        }
    }
}
