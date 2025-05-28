using System.Windows;
using Laba4Sem2.Model;

namespace Laba4Sem2.Views
{
    /// <summary>
    /// Interaction logic for RoomForm.xaml
    /// </summary>
    public partial class RoomForm : Window
    {
        private List<Room> Rooms { get; set; } = MainWindow.Rooms;
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
            SaveAndClose sac = new SaveAndClose();
            RoomType _roomType = (RoomType)roomType.SelectedValue;
            int _roomSize = Convert.ToInt32(roomSize.Text);
            int _cleaningCost = Convert.ToInt32(cleaningCost.Text);

            if (roomID == -1)
            {
                Room room = new Room(_roomType, Rooms.LastOrDefault() != null ? Rooms.Last().RoomId + 1 : 1, _roomSize, _cleaningCost);
                Rooms.Add(room);

                if (sac.ShowDialog() == false)
                    Rooms.Remove(room);
            }
            else
            {
                Room prevRoom = new Room(Rooms[roomID].RoomType, roomID, Rooms[roomID].Size, Rooms[roomID].CleaningCost);
                Room editingRoom = Rooms[roomID];
                editingRoom.RoomType = _roomType;
                editingRoom.Size = _roomSize;
                editingRoom.CleaningCost = _cleaningCost;

                if (sac.ShowDialog() == false)
                {
                    editingRoom.RoomType = prevRoom.RoomType;
                    editingRoom.Size = prevRoom.Size;
                    editingRoom.CleaningCost = prevRoom.CleaningCost;
                }
            }
            this.Close();
        }
    }
}
