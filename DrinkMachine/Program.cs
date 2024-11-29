using Figgle;

namespace DrinkMachine;

class Program
{
    static void Main()
    {
        DrinkMachine dm = new();
        System.Console.WriteLine(FiggleFonts.Standard.Render("|  Choose a drink  |"));
        System.Console.WriteLine(FiggleFonts.Standard.Render("   Coffee Tea Juice"));
        switch (Console.ReadLine()!.ToLower())
        {
            case "coffee":
                dm.GetCoffee();
                return;
            case "tea":
                dm.GetTea();
                return;
            case "juice":
                dm.GetJuice();
                return;
            default:
                System.Console.WriteLine("Something went wrong!");
                return;
        }
    }
}
