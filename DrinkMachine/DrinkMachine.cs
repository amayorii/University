namespace DrinkMachine;
public class DrinkMachine : IMachineAction
{
    public void Get(IDrink drink)
    {
        try
        {
            TakePayment(drink.CostMoney, drink.CostPoints, drink.GivePoints);
        }
        catch (NoMoneyException)
        {
            System.Console.WriteLine("You don't have money 😔");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        finally
        {
            System.Console.WriteLine("Have a nice day!");
        }
    }

    public void TakePayment(int costMoney, int costPoints, int givePoints)
    {
        string pathMoney = "./Payment/money.txt", pathBonus = "./Payment/bonus.txt";
        int money, points;

        using (var moneyReader = new StreamReader(pathMoney))
            money = Convert.ToInt32(moneyReader.ReadLine());

        using (var bonusReader = new StreamReader(pathBonus))
            points = Convert.ToInt32(bonusReader.ReadLine());

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
        File.WriteAllText(pathBonus, (points += givePoints).ToString());
        System.Console.WriteLine($"You spent ${costMoney} and gain {givePoints} points\nNow your balance is: ${money} | {points} pts");
    }
}