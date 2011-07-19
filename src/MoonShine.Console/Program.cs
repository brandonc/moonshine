using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MoonShine.ConsoleApp {
    class Program {
        static int Main(string[] args) {
            string output = String.Empty;

            if (args.Length == 1) {
                // File input

                if (File.Exists(args[0])) {
                    Console.WriteLine(Sundown.MoonShine.Markdownify(File.ReadAllText(args[0]), smartypants : false));
                } else {
                    Console.Error.WriteLine("Could not open file " + args[0]);
                    return -1;
                }
            } else {
                Console.Error.WriteLine("Usage: moonshine.exe <filepath>");
            }

            return 0;
        }
    }
}
