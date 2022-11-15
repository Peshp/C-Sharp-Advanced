using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Elf elf = new Elf("Sasho", 4);
            DarkWizard bad = new DarkWizard("Gosho", 3);

            Console.WriteLine($"They arrive in big room in a cave where is full darkness. " +
                $"{bad} use Lightness magic to see where is he and in fron of him there was" +
                "{elf} ");
        }
    }
}
