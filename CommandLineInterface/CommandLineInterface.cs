namespace CommandLineInterfaceLibrary {

    public class CommandLineInterface {

        private readonly string Brackets = "<>";

        public CommandLineInterface() { }

        public CommandLineInterface(string brackets) { Brackets = brackets; }

        public string PromptString() {
            try {
                PrintInputBrackets();
                return Console.ReadLine() ?? "";
            } catch {
                PrintString("Une erreur est survenue.. Veuillez réessayer :");
                PrintInputBrackets();
                return PromptString();
            }
        }

        public void PrintString(string message) {
            PrintInputBrackets();
            Console.WriteLine(message);
        }

        public void PrintInputBrackets() {
            Console.Write($"{Brackets} ");
        }

        public void Pause() {
            Console.ReadKey();
        }
    }
}
