namespace DrinkMachine;

class Tea : IDrink
{
    public int CostMoney => 10;

    public int CostPoints => 3;

    public int GivePoints => 1;
}