using System.Collections;
using System.ComponentModel;
using System.Windows;
using Laba4Sem2.Model;

namespace Laba4Sem2.Views
{
    /// <summary>
    /// Interaction logic for RoomForm.xaml
    /// </summary>
    public partial class RoomForm : Window, INotifyDataErrorInfo
    {
        private List<Room> Rooms { get; set; } = MainWindow.Rooms;
        private readonly int roomID;

        private readonly Dictionary<string, List<string>> Errors = [];
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        public bool HasErrors => Errors.Count > 0;

        public IEnumerable GetErrors(string? propertyName)
        {
            if (Errors.TryGetValue(propertyName, out List<string>? value))
            {
                return value;
            }
            else return Enumerable.Empty<string>();
        }

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
            bool exception = false;
            SaveAndClose sac = new SaveAndClose();
            RoomType _roomType = (RoomType)roomType.SelectedValue;
            int _roomSize = Convert.ToInt32(roomSize.Text);
            int _cleaningCost = Convert.ToInt32(cleaningCost.Text);

            if (roomID == -1)
            {
                try
                {
                    Room room = new Room(_roomType, Rooms.LastOrDefault() != null ? Rooms.Last().RoomId + 1 : 1, _roomSize, _cleaningCost);

                    Rooms.Add(room);

                    if (sac.ShowDialog() == false)
                        Rooms.Remove(room);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    exception = true;
                }
            }
            else
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    exception = true;
                }
            }
            if (!exception)
                this.Close();
        }
    }
}
