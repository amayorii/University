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
    private static List<Room> rooms = [];
    public static List<Room> Rooms
    {
        get { return rooms; }
        set
        {
            rooms = value;
        }
    }
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        Closed += (s, e) => App.Save();
        App.Load();
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