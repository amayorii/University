using System.Diagnostics;
using System.Xml;
namespace Laba3;

class Program
{
    static void Main()
    {
        System.Console.WriteLine(AvgSum());
    }
    static double AvgSum()
    {
        double avg = 0;
        ushort count = 0;
        byte number = 1;
        for (int i = 10; i < 30; i++)
        {
            string path = $"./txts/{i}.txt";
            try
            {
                var file = new FileStream(path, FileMode.Open);
                StreamReader reader = new StreamReader(file);
                int num1 = Convert.ToInt32(reader.ReadLine() ?? throw new ArgumentNullException());
                int num2 = Convert.ToInt32(reader.ReadLine() ?? throw new ArgumentNullException());
                file.Close();
                reader.Close();
                checked
                {
                    num1 *= num2;
                }
                avg += num1;
                count++;
            }
            catch (OverflowException)
            {
                System.Console.WriteLine($"Exception {number}\nReason: numbers are too big and their product cannot exceed {int.MaxValue}\nFile name: {Path.GetFileName(path)}\n");
                number++;
            }
            catch (ArgumentNullException)
            {
                System.Console.WriteLine($"Exception {number}\nReason: file must contain only 1 integer in first and 1 integer in second lines\nFile name: {Path.GetFileName(path)}\n");
                number++;
            }
            catch (FormatException ex)
            {
                System.Console.WriteLine($"Exception {number}\nReason: {ex.Message.ToLower()}\nFile name: {Path.GetFileName(path)}\n");
                number++;
            }
            catch (FileNotFoundException)
            {
                System.Console.WriteLine($"Exception {number}\nReason: file wasn't found\nFile name: {Path.GetFileName(path)}\n");
                number++;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        return avg / count;
    }
}
