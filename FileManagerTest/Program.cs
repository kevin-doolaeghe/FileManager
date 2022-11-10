using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLineInterfaceLibrary;
using FileManagerLibrary;

namespace FileManagerTest {

    class Program {

        static void Main() {
            CommandLineInterface cli = new();

            cli.PrintString("Entrez le chemin source :");
            string srcPath = cli.PromptString();

            cli.PrintString("Entrez le chemin destination :");
            string dstPath = cli.PromptString();

            cli.PrintString("Entrez le chemin relatif à trouver pour effectuer le déplacement :");
            string checkupPath = cli.PromptString();

            try {
                foreach (string dir in FileManager.GetSubDirectories(srcPath) ?? Array.Empty<string>()) {
                    cli.PrintString($"Found directory: {dir}");
                    if (FileManager.DoesDirectoryExist($"{dir}\\{checkupPath}")) {
                        cli.PrintString($"\t---> Moving {dir} to {dstPath}");
                        FileManager.MoveDirectory(dir, dstPath);
                    }
                }
            } catch (Exception e) {
                Console.WriteLine($"The process failed: {e.Message}");
            }
            cli.Pause();
        }
    }
}
