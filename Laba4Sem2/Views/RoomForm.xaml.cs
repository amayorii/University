using System.Windows;
using Laba4Sem2.Model;

namespace Laba4Sem2.Views
{
    /// <summary>
    /// Interaction logic for RoomForm.xaml
    /// </summary>
    public partial class RoomForm : Window
    {
        private readonly int roomID;
        public RoomForm(int id = -1)
        {
            InitializeComponent();
            roomType.ItemsSource = Enum.GetValues<RoomType>().ToList();
            DataContext = this;
            roomID = id;
            Title = roomID == -1 ? "Register" : "Edit";
        }
        private void Submit(object sender, RoutedEventArgs e)
        {
            RoomType _roomType = (RoomType)roomType.SelectedValue;
            int _roomSize = Convert.ToInt32(roomSize.Text);
            int _cleaningCost = Convert.ToInt32(cleaningCost.Text);

            if (roomID == -1)
            {
                Room room = new Room(_roomType, MainWindow.Rooms.Last().RoomId + 1, _roomSize, _cleaningCost);
                MainWindow.Rooms.Add(room);
            }
            else
            {
                Room editingRoom = MainWindow.Rooms[roomID];
                editingRoom.RoomType = _roomType;
                editingRoom.Size = _roomSize;
                editingRoom.CleaningCost = _cleaningCost;
            }
            this.Close();
        }
    }
}
