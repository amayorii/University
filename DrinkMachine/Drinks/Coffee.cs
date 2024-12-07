namespace DrinkMachine;

class Coffee : IDrink
{
    public int CostMoney => 25;

    public int CostPoints => 15;

    public int GivePoints => 3;
}