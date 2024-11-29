namespace DrinkMachine;
public class DrinkMachine : IMachineAction
{
    public void GetCoffee()
    {
        try
        {
            TakePayment(10, 5);
        }
        catch (NoMoneyException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        finally
        {
            System.Console.WriteLine("Have an awesome day!");
        }
    }

    public void GetJuice()
    {
        try
        {
            TakePayment(15, 7);
        }
        catch (NoMoneyException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        finally
        {
            System.Console.WriteLine("Have a juicy day!");
        }
    }

    public void GetTea()
    {
        try
        {
            TakePayment(5, 3);
        }
        catch (NoMoneyException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        finally
        {
            System.Console.WriteLine("Have a sweet day!");
        }
    }

    public void TakePayment(int costMoney, int costPoints)
    {
        string pathMoney = "./Payment/money.txt", pathBonus = "./Payment/bonus.txt";
        var moneyReader = new StreamReader(pathMoney);
        int money = Convert.ToInt32(moneyReader.ReadLine());
        moneyReader.Close();

        var bonusReader = new StreamReader(pathBonus);
        int points = Convert.ToInt32(bonusReader.ReadLine());
        bonusReader.Close();

        if (money < costMoney && points < costPoints) throw new NoMoneyException("You don't have money 😔");

        if (points >= costPoints)
        {
            System.Console.WriteLine("You have enough points, do you want to spend them? (y/n)");
            if (Console.ReadLine() == "y")
            {
                File.WriteAllText(pathBonus, (points -= costPoints).ToString());
                System.Console.WriteLine($"You spent {costPoints} points\nNow your balance is: ${money} | {points} pts");
                return;
            }
        }
        File.WriteAllText(pathMoney, (money -= costMoney).ToString());
        File.WriteAllText(pathBonus, (++points).ToString());
        System.Console.WriteLine($"You spent ${costMoney} and gain 1 point\nNow your balance is: ${money} | {points} pts");
    }
}