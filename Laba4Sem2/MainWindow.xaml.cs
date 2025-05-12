using System.Windows;
using System.Windows.Controls;
using Laba4Sem2.Model;
using Laba4Sem2.Views;

namespace Laba4Sem2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private static readonly List<Room> rooms = [];

    public static List<Room> Rooms => rooms;
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        Animal animal = new Animal("Dog", "Germany", "Maksim", DateTime.Now);
        Animal animal1 = new Animal("Cat", "Japan", "Dona", DateTime.UtcNow);
        Animal animal2 = new Animal("Cat", "Japan", "Dona", DateTime.UtcNow);
        Animal animal3 = new Animal("Cat", "Japan", "Dona", DateTime.UtcNow);
        Animal animal4 = new Animal("Cat", "Japan", "Dona", DateTime.UtcNow);
        AccUnit accUnit = new AccUnit(animal, DateTime.Now, 50);
        AccUnit accUnit1 = new AccUnit(animal1, DateTime.UtcNow, 200);
        AccUnit accUnit2 = new AccUnit(animal2, DateTime.UtcNow, 200);
        AccUnit accUnit3 = new AccUnit(animal3, DateTime.UtcNow, 200);
        AccUnit accUnit4 = new AccUnit(animal4, DateTime.UtcNow, 200);

        Room room = new Room(RoomType.Cage, 1, 20, 120);
        Room room1 = new Room(RoomType.Aquarium, 2, 50, 110);
        Room room2 = new Room(RoomType.Aquarium, 3, 50, 110);
        Room room3 = new Room(RoomType.Aquarium, 4, 50, 110);
        Room room4 = new Room(RoomType.Aquarium, 5, 50, 110);
        room.AddAnimal(accUnit);
        room.AddAnimal(accUnit1);
        room.AddAnimal(accUnit2);
        room.AddAnimal(accUnit3);
        room.AddAnimal(accUnit4);
        room.AddAnimal(accUnit4);
        room.AddAnimal(accUnit4);
        room.AddAnimal(accUnit4);
        room1.AddAnimal(accUnit);
        room1.AddAnimal(accUnit1);
        room1.AddAnimal(accUnit2);
        room1.AddAnimal(accUnit3);
        room1.AddAnimal(accUnit4);

        room2.AddAnimal(accUnit);
        room2.AddAnimal(accUnit1);
        room2.AddAnimal(accUnit2);
        room2.AddAnimal(accUnit3);

        room3.AddAnimal(accUnit);
        room3.AddAnimal(accUnit1);
        room3.AddAnimal(accUnit2);
        room3.AddAnimal(accUnit3);

        room4.AddAnimal(accUnit);
        room4.AddAnimal(accUnit1);
        room4.AddAnimal(accUnit2);
        room4.AddAnimal(accUnit3);
        //RoomDTO roomJSON = room.Adapt<RoomDTO>();
        //var options = new JsonSerializerOptions
        //{
        //    WriteIndented = true,
        //    Converters = { new JsonStringEnumConverter() }
        //};
        //string json = JsonSerializer.Serialize(roomJSON, options);
        //MessageBox.Show(json);
        Rooms.Add(room);
        Rooms.Add(room1);
        Rooms.Add(room2);
        Rooms.Add(room3);
        Rooms.Add(room4);
    }
    private void ShowAnimalsList_Click(object sender, RoutedEventArgs e)
    {
        DetailsWindow viewMoreWindow = new DetailsWindow(table.SelectedItem as Room)
        {
            Owner = this,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
        };
        viewMoreWindow.ShowDialog();
    }

    private void Table_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        viewMoreBtn.IsEnabled = table.SelectedItem != null;
        editBtn.IsEnabled = table.SelectedItem != null;
    }

    private void NewRoom_Click(object sender, RoutedEventArgs e)
    {
        RoomForm newRoom = new RoomForm()
        {
            Owner = this,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
        };
        newRoom.ShowDialog();
        table.Items.Refresh();
    }
    private void EditRoom_Click(object sender, RoutedEventArgs e)
    {
        var selectedRoom = table.SelectedItem as Room;
        RoomForm newRoom = new RoomForm(selectedRoom.RoomId - 1)
        {
            Owner = this,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
        };
        newRoom.roomType.Text = selectedRoom.RoomType.ToString();
        newRoom.roomSize.Text = selectedRoom.Size.ToString();
        newRoom.cleaningCost.Text = selectedRoom.CleaningCost.ToString();
        newRoom.ShowDialog();
    }
}