namespace DrinkMachine;
public interface IDrink
{
    public int CostMoney { get; }
    public int CostPoints { get; }
    public int GivePoints { get; }
}