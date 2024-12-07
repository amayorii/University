namespace DrinkMachine;

class Juice : IDrink
{
    public int CostMoney => 15;

    public int CostPoints => 8;

    public int GivePoints => 2;
}