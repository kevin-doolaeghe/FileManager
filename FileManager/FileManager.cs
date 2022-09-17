using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerLibrary {

    public class FileManager {

        public string[] GetFiles(string path) {
            string[] files = Array.Empty<string>();
            if (Directory.Exists(path)) {
                files = Directory.GetFiles(path);
            }
            return files;
        }

        public string[] GetDirectories(string path) {
            string[] dirs = Array.Empty<string>();
            if (Directory.Exists(path)) {
                dirs = Directory.GetDirectories(path);
            }
            return dirs;
        }

        public void MoveDirectory(string src, string dst) {
            string tmp = $"{dst}\\{Path.GetFileName(src)}";
            Directory.Move(src, tmp);
            Console.WriteLine($"{src} was moved to {tmp}.");
        }

        public void MoveFiles(string src, string dst) {
            string[] files = GetFiles(src);
            foreach (string srcFile in files) {
                string dstFile = $"{dst}\\{Path.GetFileName(srcFile)}";
                if (!File.Exists(dstFile)) {
                    File.Move(srcFile, dstFile);
                    Console.WriteLine($"{srcFile} was moved to {dstFile}.");
                }
            }
        }
    }
}
