namespace DrinkMachine;
interface IMachineAction
{
    void GetTea();
    void GetCoffee();
    void GetJuice();
    void TakePayment(int costMoney, int costPoints);
}