using Figgle;

namespace DrinkMachine;

class Program
{
    static void Main()
    {
        DrinkMachine dm = new();
        System.Console.Write(FiggleFonts.Standard.Render("____________________\n"));
        System.Console.Write(FiggleFonts.Standard.Render("|      >  >  >  Choose a drink  <  <  <      |\n"));
        System.Console.Write(FiggleFonts.Standard.Render("|                                                                                                                    |\n"));
        System.Console.Write(FiggleFonts.Standard.Render("|    < Coffee >    < Tea >    < Juice >    |\n"));
        System.Console.Write(FiggleFonts.Standard.Render("|                                                                                                                    |\n"));
        System.Console.Write(FiggleFonts.Standard.Render("|                                                                                                                    |\n"));
        System.Console.Write(FiggleFonts.Standard.Render("|         [                               ]                                                                    |\n"));
        System.Console.WriteLine(FiggleFonts.Standard.Render(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯"));
        System.Console.WriteLine();

        switch (Console.ReadLine()!.ToLower())
        {
            case "coffee":
                dm.Get(new Coffee());
                return;
            case "tea":
                dm.Get(new Tea());
                return;
            case "juice":
                dm.Get(new Juice());
                return;
            default:
                System.Console.WriteLine("This drink isn't available yet");
                return;
        }
    }
}
