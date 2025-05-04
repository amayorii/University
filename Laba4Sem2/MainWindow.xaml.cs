using System.Windows;

namespace Laba4Sem2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Animal animal = new Animal("Dog", "Germany", "Maksim", DateTime.Now);
        Animal animal1 = new Animal("Cat", "Japan", "Dona", DateTime.UtcNow);
        AccUnit accUnit = new AccUnit(animal, DateTime.Now, 50);
        AccUnit accUnit1 = new AccUnit(animal1, DateTime.UtcNow, 200);

        Room room = new Room(RoomType.Cage, 1, 20, 120);
        room.AddAnimal(accUnit);
        room.AddAnimal(accUnit1);
        MessageBox.Show(room.ToShortString());

    }
}