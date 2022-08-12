using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Junk_Code_Generator {
    class Program {
        static Random random = new Random();

        [STAThread]
        static void Main() {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Select file:");

            using (OpenFileDialog Dialog = new OpenFileDialog()) {
                Dialog.Filter = "dll files (*.dll) |*.dll";

                if (Dialog.ShowDialog() != DialogResult.OK) MsgAndPause("No file selected.");

                Console.WriteLine($"\nFile selected: {Dialog.SafeFileName}");
                PauseAndClear(500);

                Console.WriteLine("Enter amount of bytes to add (0 = random):\n");
                var amount = Convert.ToInt32(Console.ReadLine());

                if (amount == 0) amount = random.Next(1, 99999);
                var length = Bytes.Build(Dialog, amount);

                PauseAndClear(1000);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Writing bytes...");
                PauseAndClear(1500);

                Console.WriteLine($"File size" +
                    $"\n=========\n\n" +
                    $"Default: {new FileInfo(Dialog.FileName).Length} bytes" +
                    $"\nJunked: {length} bytes");

                Console.ReadKey();
            }
        }

        static void PauseAndClear(int timeout) {
            Thread.Sleep(timeout);
            Console.Clear();
        }

        static void MsgAndPause(string msg) {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(msg);
            Console.ReadKey();
        }
    }
}
