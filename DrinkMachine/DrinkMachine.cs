namespace DrinkMachine;
public class DrinkMachine : IMachineAction
{
    public void GetCoffee()
    {
        throw new NotImplementedException();
    }

    public void GetJuice()
    {
        throw new NotImplementedException();
    }

    public void GetTea()
    {
        throw new NotImplementedException();
    }

    public void TakePayment(int costMoney, int costPoints)
    {
        string pathMoney = "./Payment/money.txt", pathBonus = "./Payment/bonus.txt";

        int money = Convert.ToInt32(new StreamReader(pathMoney).ReadLine());
        int points = Convert.ToInt32(new StreamReader(pathBonus).ReadLine());

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