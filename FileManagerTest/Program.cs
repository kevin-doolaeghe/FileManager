using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagerLibrary;

namespace FileManagerTest {

    class Program {

        static void Main(string[] args) {

            const string srcPath = "C:\\FileManagerDirsExample\\src";
            const string dstPath = "C:\\FileManagerDirsExample\\dst";
            const string checkupPath = "Tmp\\scan";

            try {
                FileManager fm = new();
                foreach (string dir in fm.GetDirectories(srcPath)) {
                    Console.WriteLine(dir);
                    if (fm.GetDirectories(checkupPath).Contains($"{dir}\\{checkupPath}")) {
                        fm.MoveDirectory(dir, dstPath);
                    }
                }
            } catch (Exception e) {
                Console.WriteLine($"The process failed: {e.Message}");
            }
        }
    }
}
