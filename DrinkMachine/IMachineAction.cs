namespace DrinkMachine;
interface IMachineAction
{
    void Get(IDrink drink);
    void TakePayment(int costMoney, int costPoints, int givePoins);
}