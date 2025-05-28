using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using Laba4Sem2.DTOs;
using Laba4Sem2.Model;
using Mapster;

namespace Laba4Sem2;

public enum RoomType
{
    Cage,
    Enclosure,
    Aquarium,
    Terrarium
}
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private static readonly JsonSerializerOptions serializeOptions = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };
    private static readonly JsonSerializerOptions deserializeOptions = new()
    {
        Converters = { new JsonStringEnumConverter() }
    };
    public static void Save()
    {
        List<RoomDTO> roomsToSerialize = [];

        foreach (var room in Laba4Sem2.MainWindow.Rooms)
        {
            RoomDTO roomJSON = room.Adapt<RoomDTO>();
            roomsToSerialize.Add(roomJSON);
        }

        if (roomsToSerialize.Count > 0)
            File.WriteAllText("savedRooms.json", JsonSerializer.Serialize(roomsToSerialize, serializeOptions));
    }
    public static void Load()
    {
        try
        {
            var roomsJson = File.ReadAllText("savedRooms.json");
            if (!string.IsNullOrEmpty(roomsJson))
                Laba4Sem2.MainWindow.Rooms = JsonSerializer.Deserialize<List<Room>>(roomsJson, deserializeOptions)!;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}