using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerLibrary {

    public class FileManager {

        /// <summary>
        /// Find all files contained in given directory
        /// Return null if directory does not exist
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static string[]? GetFiles(string dirPath) {
            if (Directory.Exists(dirPath)) {
                return Directory.GetFiles(dirPath);
            } else {
                return null;
            }
        }

        /// <summary>
        /// Find all direct subdirs in given directory
        /// Return null if directory does not exist
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static string[]? GetSubDirectories(string dirPath) {
            if (Directory.Exists(dirPath)) {
                return Directory.GetDirectories(dirPath);
            } else {
                return null;
            }
        }

        /// <summary>
        /// Determines whether the given path refers to an existing directory
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static bool DoesDirectoryExist(string dirPath) {
            return Directory.Exists(dirPath);
        }

        /// <summary>
        /// Move src directory to dst directory
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public static void MoveDirectory(string src, string dst) {
            string dstDir = $"{dst}\\{Path.GetFileName(src)}";
            Directory.Move(src, dstDir);
            // Console.WriteLine($"{src} was moved to {dstDir}.");
        }

        /// <summary>
        /// Move all files contained in src directory to dst directory
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <returns></returns>
        public static void MoveFiles(string src, string dst) {
            string[]? files = GetFiles(src);
            if (files == null) return;

            foreach (string srcFile in files) {
                string dstFile = $"{dst}\\{Path.GetFileName(srcFile)}";
                if (!File.Exists(dstFile)) {
                    File.Move(srcFile, dstFile);
                    // Console.WriteLine($"{srcFile} was moved to {dstFile}.");
                }
            }
        }
    }
}
